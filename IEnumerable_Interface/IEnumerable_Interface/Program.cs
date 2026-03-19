using System.Collections;

namespace IEnumerable_Interface
{
    internal class Program
    {
        class CustomCollection<T> : IEnumerable<T>
        {
            private List<T> _list = new List<T>();

            public IEnumerator<T> GetEnumerator()
            {
                for (int i = 0; i < _list.Count; i++)
                {
                    yield return _list[i]; 
                }
            }
            IEnumerator  IEnumerable.GetEnumerator()
            {
               return GetEnumerator();
            }
            public void Add(T item)
            {
                _list.Add(item);
            }

        }
        
        
        static void Main(string[] args)
        {
            CustomCollection<int> collection = new CustomCollection<int>() {10,20,30,40 };

            foreach (var item in collection)
            {
                Console.WriteLine(item);
            }
      
        }
    }
}
