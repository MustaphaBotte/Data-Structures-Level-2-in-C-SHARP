using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Lisked_List 
{

    class TrainStation
    {
        public string StationNumber = "";
        public TrainStation(string stationNumber)
        {
            StationNumber = stationNumber;
        }
        public override string ToString()
        {
            return $"Station {StationNumber}";
        }
        public override bool Equals(object? obj)
        {
            if (obj == null) return false;

            if (obj is TrainStation trainStation)
            {
                return trainStation.StationNumber == this.StationNumber;
            }
            return false;
        }
        public override int GetHashCode()
        {
            return StationNumber.GetHashCode();
        }
    }
    class Node<T>
    {
        public T? Data = default(T);
        public Node<T>? Next = null;
        public Node<T>? Previous = null;
        internal DoublyLinkedList<T> _List;

        public Node(T? data, DoublyLinkedList<T> list)
        {
            Data = data;
            _List = list;
        }
    }
    class DoublyLinkedList<T>
    {
        private Node<T>? _Head = null;
        private Node<T>? _Tail = null;

        public void AddFirst(T Data)
        {
            Node<T> Node = new Node<T>(Data,this);

            if(_Head ==null)
            {
                _Head = _Tail =  Node;          
            }
            else
            {
                Node.Next = _Head;
                _Head.Previous = Node;
                _Head = Node;
            }

        }
        public void AddLast(T Data)
        {
            Node<T> Node = new Node<T>(Data, this);
            if (_Tail == null)
            {
                _Head = _Tail = Node;
            }
            else
            {
                _Tail.Next = Node;
                Node.Previous = _Tail;
                _Tail = Node;
            }
        }

        public bool InsertBefore(Node<T> Node, T Value)
        {
            if (Node == null) return false;

            Node<T>? NewNode = new Node<T>(Value, this);

           
            
            if (Node._List == this)
            {
                    NewNode.Next = Node;
                    NewNode.Previous = Node.Previous;

                    if(Node.Previous != null)
                    {
                        Node.Previous.Next = NewNode;
                    }
                    else
                    {
                        _Head = NewNode;
                    }
                    Node.Previous = NewNode;
                    return true;
                
            }
            return false;
        }
        public bool InsertAfter(Node<T> Node , T Value)
        {
            if (Node == null) return false ;

            Node<T>? NewNode = new Node<T>(Value, this);



            if (Node._List == this)
            {
                NewNode.Previous = Node;
                NewNode.Next = Node.Next;

                if (Node.Next != null)
                {
                    Node.Next.Previous = NewNode;
                }
                else
                {
                    _Tail = NewNode;
                }
                Node.Next = NewNode;
                return true;        
            }
            return false;
        }



        public Node<T>? GetNode(T Value)
        {
                Node<T>? temp = _Head;
                while (temp != null)
                {
                    if(temp.Data ==null && Value ==null)
                    {
                        return temp; ;
                    }

                    else if (temp.Data!=null && temp.Data.Equals(Value))
                    {
                        return temp;
                    }
                    
                    temp = temp.Next;
                }
                return null;        
        }
        public void PrintBackWard()
        {
            if(_Tail==null)
            {
                throw new Exception("Linked list is empty");
            }
            else
            {
                Console.WriteLine("Print the Linked List in BackWard manner");
                Node<T>? temp = _Tail;
                while(temp!=null)
                {
                    Console.WriteLine(temp.Data);
                    temp = temp.Previous;
                }

            }


        }
        public void PrintForward()
        {
           
            if(_Head == null)
            {
                throw new Exception("Linked list is empty");
            }
            else
            {
                Console.WriteLine("Print the Linked List in forward manner");
                Node<T>? temp = _Head;
                while(temp!=null)
                {
                    Console.WriteLine($"{temp.Data}");
                    temp = temp.Next;
                }
            }

        }



    }
    internal class Program
    {
        static void Main(string[] args)
        {
            DoublyLinkedList<TrainStation> TrainStations = new DoublyLinkedList<TrainStation>();
            TrainStation TrainStationA = new TrainStation("A");
            TrainStation TrainStationB = new TrainStation("B");
            TrainStation TrainStationC = new TrainStation("C");
            TrainStation TrainStationD = new TrainStation("D");

            TrainStations.AddFirst(TrainStationA);
            TrainStations.AddFirst(TrainStationB);
            TrainStations.AddFirst(TrainStationC);
            TrainStations.AddFirst(TrainStationD);


            TrainStations.PrintForward();
            TrainStations.PrintBackWard();

            Node<TrainStation>? node = TrainStations.GetNode(TrainStationA);
            Console.WriteLine("The Node is  :"+node?.Data);
            Console.WriteLine("The next Node is :"+node?.Next?.Data);
            Console.WriteLine("The previous Node is :" + node?.Previous?.Data);


            TrainStation TrainStationC1 = new TrainStation("C1");


            DoublyLinkedList<TrainStation> TrainStations2 = new DoublyLinkedList<TrainStation>();
            TrainStations2.AddFirst(TrainStationA);
            Node<TrainStation>? node2 = TrainStations2.GetNode(TrainStationA);


            TrainStations.InsertBefore(node2, TrainStationC1);

            TrainStations.PrintForward();
            TrainStations.PrintBackWard();



        }
    }
}
