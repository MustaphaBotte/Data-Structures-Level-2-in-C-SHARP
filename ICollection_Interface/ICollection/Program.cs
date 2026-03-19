using System.Collections;
namespace ICollection
{
    internal class Program
    {
        class CustomCollection<T> : ICollection<T>
        {
            private List<T> _list = new List<T>();

            public int Count => _list.Count;

            public bool IsReadOnly
            {
                get
                {
                    return false;
                }
            }
            public bool Contains(T item)
            {
                return _list.Contains(item);
            }
            public bool Remove(T item)
            {
                return _list.Remove(item);
            }
            public void CopyTo(T [] destination , int ArrayIndex)
            {
                 _list.CopyTo(destination, ArrayIndex);
            }
            public void Clear()
            {
                this._list.Clear();
            }
            public IEnumerator<T> GetEnumerator()
            {
                for (int i = 0; i < _list.Count; i++)
                {
                    yield return _list[i];
                }
            }
            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }
            public void Add(T item)
            {
                _list.Add(item);
            }
            // i used List<T> here
            // you can use any other DS you want , but you need to implement the interface 
            // now you can extend your collection
        }


        static void Main(string[] args)
        {
            CustomCollection<int> collection = new CustomCollection<int>() { 10, 20, 30, 40 };

            foreach (var item in collection)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("Collection Count :" +collection.Count);
            Console.WriteLine("is Read Only  :" + collection.IsReadOnly);
            collection.Add(50);
            collection.Remove(10);
            Console.WriteLine("Final items :");
            foreach (var item in collection)
            {
                Console.WriteLine(item);
            }
        }
    }
}