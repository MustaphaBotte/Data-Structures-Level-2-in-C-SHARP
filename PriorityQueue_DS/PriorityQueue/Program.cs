namespace PriorityQueue
{
    public struct PriorityQueueNode<T>
    {
        public T item;
        public int Priority;

        public PriorityQueueNode(T item, int priority)
        {
            this.item = item;
            Priority = priority;
        }
        public override string ToString()
        {
            return $"{item?.ToString()} Priority : {Priority}";
        }
    }
    public class PriorityQueue<T>
    {
        private List<PriorityQueueNode<T>> _list = new List<PriorityQueueNode<T>>();

        public void Add(PriorityQueueNode<T> item)
        {
            _list.Add(item);
            heapifyUp();
        }
        public PriorityQueueNode<T> RemoveTop()
        {
            if (_list.Count == 0)
                throw new Exception("the Queue is Empty");

            PriorityQueueNode<T> TopItem = _list[0];
            _list[0] = _list[_list.Count - 1];

            _list.RemoveAt(_list.Count - 1);

            HeapifyDown();

            return TopItem;

        }
        private void HeapifyDown()
        {
            int index = 0;

            while (index < _list.Count)
            {
                int smallestIdx = index;

                int RightChild = index * 2 + 2;
                int LeftChild = index * 2 + 1;


                if (RightChild < _list.Count &&
                _list[RightChild].Priority < _list[smallestIdx].Priority)
                {
                    smallestIdx = RightChild;
                }

                if (LeftChild < _list.Count &&
                _list[LeftChild].Priority < _list[smallestIdx].Priority)
                {
                    smallestIdx = LeftChild;
                }

                if (index == smallestIdx) break;

                (_list[index], _list[smallestIdx]) = (_list[smallestIdx], _list[index]);

                index = smallestIdx;
            }

        }
        private void heapifyUp()
        {
            int index = _list.Count - 1;

            while (index > 0)
            {
                int ParentIdx = (index - 1) / 2;

                if (_list[index].Priority > _list[ParentIdx].Priority) break;

                (_list[index], _list[ParentIdx]) = (_list[ParentIdx], _list[index]);

                index = ParentIdx;
            }
        }
        public PriorityQueueNode<T> Peak()
        {
            if (_list.Count == 0)
            {
                throw new InvalidOperationException("Heap is empty :(");
            }

            return this._list[0];
        }

        public void Dipalay()
        {
            foreach (var item in _list)
            {
                Console.WriteLine(item + " ");
            }
        }
    }
    


    internal class Program
    {
        static void Main(string[] args)
        {
            var Task10 = new PriorityQueueNode<string>("Task10", 10);
            var Task6 = new PriorityQueueNode<string>("Task6", 10);
            var Task7 = new PriorityQueueNode<string>("Task7", 7);          
            var Task3 = new PriorityQueueNode<string>("Task3", 70);
            var Task4 = new PriorityQueueNode<string>("Task4", 4);
            var Task5 = new PriorityQueueNode<string>("Task5", 5);         
            var Task8 = new PriorityQueueNode<string>("Task8", 8);
            var Task9 = new PriorityQueueNode<string>("Task9", 9);
            var Task2 = new PriorityQueueNode<string>("Task2", 2);
            var Task1 = new PriorityQueueNode<string>("Task1", 1);

            PriorityQueue<string> PriorityQueue = new PriorityQueue<string>();
            PriorityQueue.Add(Task1);
            PriorityQueue.Add(Task2);
            PriorityQueue.Add(Task3);
            PriorityQueue.Add(Task4);
            PriorityQueue.Add(Task5);
            PriorityQueue.Add(Task6);
            PriorityQueue.Add(Task7);
            PriorityQueue.Add(Task8);
            PriorityQueue.Add(Task9);
            PriorityQueue.Add(Task10);


            PriorityQueue.Dipalay();

            Console.WriteLine("Peeking Tasks");
            var NextTask = PriorityQueue.RemoveTop();
            Console.WriteLine(NextTask);
            NextTask = PriorityQueue.RemoveTop();
            Console.WriteLine(NextTask);
            NextTask = PriorityQueue.RemoveTop();
            Console.WriteLine(NextTask);
            NextTask = PriorityQueue.RemoveTop();
            Console.WriteLine(NextTask);
            NextTask = PriorityQueue.RemoveTop();
            Console.WriteLine(NextTask);
            NextTask = PriorityQueue.RemoveTop();
            Console.WriteLine(NextTask);
            NextTask = PriorityQueue.RemoveTop();
            Console.WriteLine(NextTask);
            NextTask = PriorityQueue.RemoveTop();
            Console.WriteLine(NextTask);
            NextTask = PriorityQueue.RemoveTop();
            Console.WriteLine(NextTask);
            NextTask = PriorityQueue.RemoveTop();
            Console.WriteLine(NextTask);
            
        }
    }
}
