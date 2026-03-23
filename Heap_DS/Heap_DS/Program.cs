namespace Heap_DS
{
    class MinHeap<T>
    {
        private List<T> _list = new List<T>();

        public void Add(T item)
        {
            _list.Add(item);
            heapifyUp();
        }

        public T RemoveMin()
        {
         

            T MinItem = _list[0];
            _list[0] = _list[_list.Count - 1];

            _list.RemoveAt(_list.Count-1);

            HeapifyDown();

            return MinItem;

        }
        private void HeapifyDown()
        {
            int index = 0;

            while(index<_list.Count)
            {
                int smallestIdx = index;

                int RightChild = index * 2 + 2;
                int LeftChild =  index * 2 + 1;


                if(RightChild<_list.Count && 
                Comparer<T>.Default.Compare( _list[RightChild] , _list[smallestIdx]) < 0)
                {
                    smallestIdx = RightChild;
                }

                if (LeftChild < _list.Count  &&
                Comparer<T>.Default.Compare(_list[LeftChild], _list[smallestIdx]) < 0)
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

            while(index>0)
            {
                int ParentIdx = (index-1) / 2;

                if (Comparer<T>.Default.Compare(_list[index], _list[ParentIdx]) > 0) break;

                (_list[index], _list[ParentIdx]) = (_list[ParentIdx], _list[index]);


                index = ParentIdx;
           }
        }
        public T Peak()
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
                Console.Write(item+" ");
            }
        }
    }

    class MaxHeap<T>
    { 
        private List<T> _list = new List<T>();

        public void Add(T item)
        {
            _list.Add(item);
            heapifyUp();
        }

        public T RemoveMax()
        {


            T MaxItem = _list[0];
            _list[0] = _list[_list.Count - 1];

            _list.RemoveAt(_list.Count - 1);

            HeapifyDown();

            return MaxItem;

        }
        private void HeapifyDown()
        {
            int index = 0;

            while (index < _list.Count)
            {
                int BiggestIdx = index;

                int RightChild = index * 2 + 2;
                int LeftChild = index * 2 + 1;


                if (RightChild < _list.Count &&
                Comparer<T>.Default.Compare(_list[RightChild], _list[BiggestIdx]) > 0)
                {
                    BiggestIdx = RightChild;
                }

                if (LeftChild < _list.Count &&
                Comparer<T>.Default.Compare(_list[LeftChild], _list[BiggestIdx]) > 0)
                {
                    BiggestIdx = LeftChild;
                }

                if (index == BiggestIdx) break;

                (_list[index], _list[BiggestIdx]) = (_list[BiggestIdx], _list[index]);

                index = BiggestIdx;
            }

        }
        private void heapifyUp()
        {
            int index = _list.Count - 1;

            while (index > 0)
            {
                int ParentIdx = (index - 1) / 2;

                if (Comparer<T>.Default.Compare(_list[index], _list[ParentIdx]) < 0) break;

                (_list[index], _list[ParentIdx]) = (_list[ParentIdx], _list[index]);


                index = ParentIdx;
            }
        }
        public T Peak()
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
                Console.Write(item + " ");
            }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            MinHeap<int> minHeap = new MinHeap<int>();
            minHeap.Add(1);
            minHeap.Add(10);
            minHeap.Add(3);
            minHeap.Add(2);
            minHeap.Add(5);
            minHeap.Add(2);
            minHeap.Add(7);

            minHeap.Dipalay();

            Console.WriteLine("\nRemoving Min Value "+minHeap.RemoveMin());
            minHeap.Dipalay();

            Console.WriteLine("\n=========================================");
            MaxHeap<int> maxHeap = new MaxHeap<int>();
            maxHeap.Add(1);
            maxHeap.Add(10);
            maxHeap.Add(3);
            maxHeap.Add(2);
            maxHeap.Add(5);
            maxHeap.Add(2);
            maxHeap.Add(7);
            Console.WriteLine();
            maxHeap.Dipalay();

            Console.WriteLine("\nRemoving Max Value " + maxHeap.RemoveMax());
            maxHeap.Dipalay();


        }
    }
}
