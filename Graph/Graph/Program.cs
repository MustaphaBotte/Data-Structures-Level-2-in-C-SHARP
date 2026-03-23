namespace Graph_Namespace
{
    class Graph<T>
    {
        public enum EnGraphType { Directed, UnDirected };

        EnGraphType CurrentGraphType;

        private Dictionary<T, int> Vertices;



        private int[,] AdjacancyMatrix;

        public Graph(IList<T> source, EnGraphType enGraphType)
        {
            CurrentGraphType = enGraphType;
            Vertices  = new Dictionary<T, int>(source.Count);

            int UniqueIndex = 0;
            for (int i= 0 ;i < source.Count; i++)
            {
                // any duplicated key will be replaced
                if(!Vertices.ContainsKey(source[i]))
                {
                    Vertices[source[i]] = UniqueIndex++;
                };     
            }
            AdjacancyMatrix = new int[UniqueIndex, UniqueIndex];
        }

        public void AddEdge(T source , T destination,int Weight)
        {
                         

            if(!Vertices.TryGetValue(source, out int SrcIdx))         
                throw new Exception("Source Not Found");


            if (!Vertices.TryGetValue(destination, out int DestIdx))
                throw new Exception("Destination Not Found");


            AdjacancyMatrix[SrcIdx, DestIdx] = Weight;          
            if(EnGraphType.UnDirected == CurrentGraphType)
            {
                AdjacancyMatrix[DestIdx, SrcIdx] = Weight;
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
                    Console.Write(AdjacancyMatrix[kvp.Value,i]+" ");
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
                if (AdjacancyMatrix[i,VertexIdx]!=0)
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
                if (AdjacancyMatrix[VertexIdx,i] != 0)
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


            if (AdjacancyMatrix[SrcIdx,DestIdx]>0)
            {
                weight = AdjacancyMatrix[SrcIdx, DestIdx];
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

            AdjacancyMatrix[SrcIdx, DestIdx] = 0;
            if(CurrentGraphType== EnGraphType.UnDirected)
            {
                AdjacancyMatrix[DestIdx, SrcIdx] = 0;
            }
        }
    }

    internal class Program
    {
        static void Main()
        {
            List<char> Vertices = new List<char> {'A', 'A', 'B', 'C', 'D', 'E', 'F', 'G' };

            Graph<char> graph = new Graph<char>(Vertices,Graph<char>.EnGraphType.UnDirected);

            graph.AddEdge('A', 'B', 1);
            graph.AddEdge('A', 'C', 1);
            graph.AddEdge('C', 'A', 1);
            graph.AddEdge('E', 'F', 1);
            graph.AddEdge('F', 'G', 1);
            graph.AddEdge('G', 'A', 1);

            graph.PrintGraph("UnDirected Graph");

            Graph<char> graph2 = new Graph<char>(Vertices, Graph<char>.EnGraphType.Directed);
            graph2.AddEdge('A', 'B', 1);
            graph2.AddEdge('A', 'C', 1);
            graph2.AddEdge('C', 'C', 1);
            graph2.AddEdge('E', 'F', 1);
            graph2.AddEdge('F', 'G', 1);
            graph2.AddEdge('G', 'A', 1);
            graph2.PrintGraph("Directed Graph2");


            Console.WriteLine("In Degree Of A In Graph  = "+graph.InDegreeOf('A'));
            Console.WriteLine("Out Degree Of A In Graph = " + graph.OutDegreeOf('A'));

            Graph<char> graph3 = new Graph<char>(Vertices, Graph<char>.EnGraphType.UnDirected);
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