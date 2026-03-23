using System.Linq;

namespace Graph_Namespace
{
    class AdjacencyMatrixGraph<T>
    {
        public enum EnGraphType { Directed, UnDirected };

        EnGraphType CurrentGraphType;

        private Dictionary<T, int> Vertices;



        private int[,] AdjacencyMatrix;

        public AdjacencyMatrixGraph(IList<T> source, EnGraphType enGraphType)
        {
            CurrentGraphType = enGraphType;
            Vertices  = new Dictionary<T, int>();

            int UniqueIndex = 0;
            for (int i= 0 ;i < source.Count; i++)
            {
                // any duplicated key will be replaced
                if(!Vertices.ContainsKey(source[i]))
                {
                    Vertices[source[i]] = UniqueIndex++;
                };     
            }
            AdjacencyMatrix = new int[UniqueIndex, UniqueIndex];
        }

        public void AddEdge(T source , T destination,int Weight)
        {
                         

            if(!Vertices.TryGetValue(source, out int SrcIdx))         
                throw new Exception("Source Not Found");


            if (!Vertices.TryGetValue(destination, out int DestIdx))
                throw new Exception("Destination Not Found");


            AdjacencyMatrix[SrcIdx, DestIdx] = Weight;          
            if(EnGraphType.UnDirected == CurrentGraphType)
            {
                AdjacencyMatrix[DestIdx, SrcIdx] = Weight;
            }
        }

        public void PrintGraph(string Title)
        {
            Console.WriteLine($"========== {Title} ==========");
            Console.Write("  ");

            foreach (var key in Vertices.Keys)
            {
                Console.Write(key+" ");
            }


            Console.WriteLine();
            foreach (var kvp in Vertices)
            {
                Console.Write(kvp.Key + " ");

                for(int i=0; i< Vertices.Count;i++)
                {
                    Console.Write(AdjacencyMatrix[kvp.Value,i]+" ");
                }
                Console.WriteLine();
            }

            Console.WriteLine($"====================================");
        }

        public int InDegreeOf(T vertex)
        {
            if (!Vertices.TryGetValue(vertex, out int VertexIdx))
                throw new Exception("Vertex Not Found");

            int InDegree = 0;
            for(int i = 0 ; i < Vertices.Count; i++)
            {
                if (AdjacencyMatrix[i,VertexIdx]!=0)
                {
                    InDegree++;
                }
            }
            return InDegree;
        }
        public int OutDegreeOf(T vertex)
        {
            if (!Vertices.TryGetValue(vertex, out int VertexIdx))
                throw new Exception("Vertex Not Found");

            int OutDegree = 0;
            for (int i = 0; i < Vertices.Count; i++)
            {
                if (AdjacencyMatrix[VertexIdx,i] != 0)
                {
                    OutDegree++;
                }
            }
            return OutDegree;
        }
        public bool HasEdgeBetween(T source, T destination,out int weight)
        {
            weight = 0;

            if (!Vertices.TryGetValue(source, out int SrcIdx))
                throw new Exception("Source Not Found");


            if (!Vertices.TryGetValue(destination, out int DestIdx))
                throw new Exception("Destination Not Found");


            if (AdjacencyMatrix[SrcIdx,DestIdx]!=0)
            {
                weight = AdjacencyMatrix[SrcIdx, DestIdx];
                return true;
            }
            return false;
        }
        public void RemoveEdgeBetween(T source, T destination)
        {
            if (!Vertices.TryGetValue(source, out int SrcIdx))
                throw new Exception("Source Not Found");


            if (!Vertices.TryGetValue(destination, out int DestIdx))
                throw new Exception("Destination Not Found");

            AdjacencyMatrix[SrcIdx, DestIdx] = 0;
            if(CurrentGraphType== EnGraphType.UnDirected)
            {
                AdjacencyMatrix[DestIdx, SrcIdx] = 0;
            }
        }
    }

    class AdjacencyListGraph<T>
    {
        public enum EnGraphType { Directed, UnDirected };

        EnGraphType CurrentGraphType;

        private Dictionary<T, List<(T NeighborName, int Weight)>> Vertices;

        public AdjacencyListGraph(IList<T> source, EnGraphType enGraphType)
        {
            CurrentGraphType = enGraphType;
            Vertices = new Dictionary<T, List<(T Neighbor, int Weight)>>();

            for (int i = 0; i < source.Count; i++)
            {
                // any duplicated key will be replaced
                if (!Vertices.ContainsKey(source[i]))
                {
                    Vertices[source[i]] = new List<(T Neighbor, int Weight)>();
                }
                
            }
        }

        public bool ContainsVertex(List<(T NeighborName, int Weight)>VrtxList , T vertex, out int index)
        {
            index = -1;
            for (int i= 0;i< VrtxList.Count;i++)
            {
                if (EqualityComparer<T>.Default.Equals(VrtxList[i].NeighborName, vertex))
                {
                    index = i;
                    return true;
                }
            }
            return false;
        }
        public void AddEdge(T source, T destination, int Weight)
        {


            if (!Vertices.TryGetValue(source, out List<(T Neighbor, int Weight)>? SrcAdjList))
                throw new Exception("Source Not Found");


            if (!Vertices.TryGetValue(destination, out List<(T Neighbor, int Weight)>? DestAdjList))
                throw new Exception("Destination Not Found");

            var tuple = (NeighborName: destination, Weight: Weight);

            if(!ContainsVertex(SrcAdjList,destination,out _))
            {
                SrcAdjList.Add(tuple);
            }
            if (EnGraphType.UnDirected == CurrentGraphType)
            {
                if (!ContainsVertex(DestAdjList, source, out _))
                {
                    tuple.NeighborName = source;
                    DestAdjList.Add(tuple);
                }
            }
            
        }

        public void PrintGraph(string Title)
        {
            Console.WriteLine($"========== {Title} ==========");
            
            foreach(var Vertex in Vertices)
            {
                Console.Write(Vertex.Key + " -> ");
                foreach (var Neighbor in Vertex.Value)
                {
                    Console.Write($"{Neighbor.NeighborName}({Neighbor.Weight}) ");
                }
                Console.WriteLine();
            }
            Console.WriteLine($"====================================");
        }

        public int InDegreeOf(T vertex)
        {
            if (!Vertices.ContainsKey(vertex))
                throw new Exception("Vertex Not Found");

            int InDegree = 0;
            foreach (var Vertex in Vertices)
            {
                if(ContainsVertex(Vertex.Value,vertex,out _))
                {
                    InDegree++;
                }                     
            }
            return InDegree;
        }
        public int OutDegreeOf(T vertex)
        {
            if (!Vertices.TryGetValue(vertex, out List<(T NeighborName, int Weight)>? VertexAdjList))
                throw new Exception("Vertex Not Found");

            return VertexAdjList?.Count??0;
        }
        public bool HasEdgeBetween(T source, T destination, out int weight)
        {
            weight = 0;

            if (!Vertices.TryGetValue(source, out List<(T NeighborName, int Weight)>? SrcAdjList))
                throw new Exception("Source Not Found");


            if (!Vertices.TryGetValue(destination, out _))
                throw new Exception("Destination Not Found");

            if( ContainsVertex(SrcAdjList, destination, out int index))
            {
                weight= SrcAdjList[index].Weight;
                return true;
            }
            return false;
        }
        public void RemoveEdgeBetween(T source, T destination)
        {
            if (!Vertices.TryGetValue(source, out List<(T NeighborName, int Weight)>? SrcAdjList))
                throw new Exception("Source Not Found");


            if (!Vertices.TryGetValue(destination, out List<(T NeighborName, int Weight)>? DestAdjList))
                throw new Exception("Destination Not Found");

            SrcAdjList.RemoveAll(Nbr => EqualityComparer<T>.Default.Equals(Nbr.NeighborName, destination));
            if(CurrentGraphType == EnGraphType.UnDirected)
            {
                DestAdjList.RemoveAll(Nbr => EqualityComparer<T>.Default.Equals(Nbr.NeighborName, source));
            }

        }
    }
    internal class Program
    {
        static void Main()
        {
            #region AdjacencyMatrixGraph
            Console.WriteLine("===================================== AdjacencyMatrixGraph ======================================");

            List<char> Vertices = new List<char> {'A', 'A', 'B', 'C', 'D', 'E', 'F', 'G' };

            var graph = new AdjacencyMatrixGraph<char>(Vertices, AdjacencyMatrixGraph<char>.EnGraphType.UnDirected);

            graph.AddEdge('A', 'B', 1);
            graph.AddEdge('A', 'C', 1);
            graph.AddEdge('C', 'A', 1);
            graph.AddEdge('E', 'F', 1);
            graph.AddEdge('F', 'G', 1);
            graph.AddEdge('G', 'A', 1);

            graph.PrintGraph("UnDirected Graph");

            var graph2 = new AdjacencyMatrixGraph<char>(Vertices, AdjacencyMatrixGraph<char>.EnGraphType.Directed);
            graph2.AddEdge('A', 'B', 1);
            graph2.AddEdge('A', 'C', 1);
            graph2.AddEdge('C', 'C', 1);
            graph2.AddEdge('E', 'F', 1);
            graph2.AddEdge('F', 'G', 1);
            graph2.AddEdge('G', 'A', 1);
            graph2.PrintGraph("Directed Graph2");


            Console.WriteLine("In Degree Of A In Graph  = "+graph.InDegreeOf('A'));
            Console.WriteLine("Out Degree Of A In Graph = " + graph.OutDegreeOf('A'));

            var graph3 = new AdjacencyMatrixGraph<char>(Vertices, AdjacencyMatrixGraph<char>.EnGraphType.UnDirected);
            // the weight here represensts Km from two places
            graph3.AddEdge('A', 'B', 9);
            graph3.AddEdge('A', 'C', 5);
            graph3.AddEdge('C', 'C', 6);
            graph3.AddEdge('E', 'F', 8);
            graph3.AddEdge('F', 'G', 4);
            graph3.AddEdge('G', 'A', 1);
            graph3.PrintGraph("UnDirected Graph3");

            Console.WriteLine("There is a Edge Between A and B In Graph3? "+graph3.HasEdgeBetween('A','B',out int weight));
            graph3.RemoveEdgeBetween('A', 'B');
            Console.WriteLine("There is a Edge Between A and B In Graph3? " + graph3.HasEdgeBetween('A', 'B', out int weight2));
            graph3.PrintGraph("UnDirected Graph3");
            #endregion
            
            Console.WriteLine("================================== AdjacencyListGraph ===================================");
            List<char> Vertices2 = new List<char> { 'A', 'A', 'B', 'C', 'D', 'E', 'F', 'G' };

            var Graph = new AdjacencyListGraph<char>(Vertices2, AdjacencyListGraph<char>.EnGraphType.UnDirected);

            Graph.AddEdge('A', 'B', 2);
            Graph.AddEdge('A', 'B', 1);
            Graph.AddEdge('A', 'B', 1);
            Graph.AddEdge('E', 'F', 1);
            Graph.AddEdge('F', 'G', 1);
            Graph.AddEdge('G', 'A', 1);

            Graph.PrintGraph("UnDirected Graph");

            var Graph2 = new AdjacencyListGraph<char>(Vertices, AdjacencyListGraph<char>.EnGraphType.Directed);
            Graph2.AddEdge('A', 'B', 1);
            Graph2.AddEdge('A', 'C', 1);
            Graph2.AddEdge('C', 'C', 1);
            Graph2.AddEdge('E', 'F', 1);
            Graph2.AddEdge('F', 'G', 1);
            Graph2.AddEdge('G', 'A', 1);
            Graph2.PrintGraph("Directed Graph2");

            Console.WriteLine("In Degree Of A In Graph  = " + Graph.InDegreeOf('A'));
            Console.WriteLine("Out Degree Of A In Graph = " + Graph.OutDegreeOf('A'));
            Console.WriteLine("There is a Edge Between A and B In Graph? " + Graph.HasEdgeBetween('A', 'B', out int Weight));
            Console.WriteLine("The Weight is :"+Weight);
            Graph.RemoveEdgeBetween('A', 'B');
            Console.WriteLine("There is a Edge Between A and B In Graph? " + Graph.HasEdgeBetween('A', 'B', out int Weight2));
            Graph.PrintGraph("UnDirected Graph");
        }
    }
}

#region explanation
//Types of Graph?
// 1. Undirected Graph  : when we have two vertices that can acessing each other in both way
// 2. Directed Graph.   : every vertex point to another vertex in one way
// 3. Weighted Graph.   : the edges or arcs are holding infomation about the connection (Time , Cost , Size etc)
// 4. Unweighted Graph. : the edges are holding no weights or information 
// 5. Cyclic Graph.     : when the graph has at least one cycle for example A=>B  B=>C  C=>A
// 6. Acyclic Graph.    : when the graph has no cycles
// 7. Dense Graph.
// when your graph is close to 100% of relations :
// when  n(n-1)/2 is close to total of edges in undirected graphs
// when  n(n-1) is close to total of edges in directed graphs


// 8. Sparse Graph.
// when your graph is far away from 100% of relations
// when  n(n-1)/2 is not close to total of edges in Undirected graphs
// when  n(n-1) is not close to total of edges in directed graphs
#endregion