using System.Collections;

namespace _IDictionary
{
    internal class Program
    {
        public class LinkedListNode<TKey, TValue>
        {
             public TKey Key;

             public TValue Value;

             public LinkedListNode<TKey, TValue>? Next = null;
             public LinkedListNode<TKey, TValue>? Previous = null;

            public LinkedListNode(TKey key , TValue value)
             {
                this.Key = key;
                this.Value = value;
             }

        }
        public class CustomDictionary<TKey, TValue> : IDictionary<TKey,TValue>
        {
           
            
            List<LinkedListNode<TKey, TValue>?> _Entries = new List<LinkedListNode<TKey, TValue>?>();
            
            List<int> _buckets =new List<int>();
            
            public ICollection<TKey> Keys
            {
                get 
                {
                    TKey[] keys = this._Entries.Select(entry => entry.Key).ToArray();
                    return keys;
                }
            }
            public ICollection<TValue> Values
            {
                get => this._Entries.Select(entry => entry.Value).ToArray();
            }
            public int Count
            {
                get => this._Entries.Count;
            }
            public bool IsReadOnly
            {
                get => false;
            }
            public TValue this[TKey key]
            {
                get
                {
                    if (this.TryGetValue(key,out TValue Out_Value))
                    {
                        return Out_Value;
                       
                    }
                    throw new Exception("key Does Not Exists");
                }
                set
                {
                    if(!ContainsKey(key))
                    {
                        Add(key, value);
                        return;
                    }
                    SetValue(key, value);
                }
            }
            public void SetValue(TKey key , TValue value)
            {
                if (key == null || _Entries.Count <= 0) return;

                int HashCode = key.GetHashCode();
                int index = HashCode % _Entries.Count;

                var Node = _Entries[index];

                var temp = Node;

                while (temp != null)
                {
                    if (temp.Key == null)
                        return ;

                    int NodekeyHashCode = temp.Key.GetHashCode();


                    if (temp.Key.Equals(key) && NodekeyHashCode == HashCode)
                    {
                        temp.Value = value;
                    }
                    temp = temp.Next;
                }
            }
            public bool TryGetValue(TKey key , out TValue value)
            {
                value = default;
                if (key == null) throw new ArgumentNullException("The key cannot be null!");

                int HashCode = key.GetHashCode();
                int index = HashCode % _Entries.Count;

                var Node = _Entries[index];

                var temp = Node;

                while (temp != null)
                {
                    if (temp.Key == null)
                        return false;

                    int NodekeyHashCode = temp.Key.GetHashCode();


                    if (temp.Key.Equals(key) && NodekeyHashCode == HashCode)
                    {
                        value= temp.Value;
                        return true;
                    }
                    temp = temp.Next;
                }
                return false;
            }
            public void Add(TKey key, TValue value)
            {
                if (key == null) throw new ArgumentNullException("The key cannot be null!");

                var LinkedListNode = new LinkedListNode<TKey, TValue>(key, value);

                if (_Entries.Count==0)
                {
                    _Entries.Add(LinkedListNode);                 
                    return;
                }

                int HashCode = key.GetHashCode();
                int index = HashCode % _Entries.Count;
                var Node = _Entries[index];
                
              

                if (Node ==null)
                {
                    // no collision                    
                    _Entries[index] = LinkedListNode;
                }
                else
                {
                    var temp = Node;
                    while (temp.Next != null)
                    {
                        // just in case any one changed remove the validation on the key
                        if (temp.Key == null) 
                            return;     
                        
                        if(temp.Key.Equals(key)&& HashCode == temp.Key.GetHashCode())
                        {
                            throw new Exception("This key is already exists");
                        }

                        temp = temp.Next;
                    }
                    if(temp==null)
                    {
                        temp = LinkedListNode;
                    }
                    temp.Next = LinkedListNode;
                }

            }
            public bool ContainsKey(TKey key)
            {
                if (key == null || _Entries.Count <= 0) return false;

                int HashCode = key.GetHashCode();
                int index = HashCode % _Entries.Count;

                var Node = _Entries[index];

                var temp = Node;

                while (temp != null)
                {
                    if (temp.Key == null)
                        return false;

                    int NodekeyHashCode = temp.Key.GetHashCode();


                    if (temp.Key.Equals(key) && NodekeyHashCode == HashCode)
                    {
                        return true;
                    }
                    temp = temp.Next;
                }
                return false;
            }
            public bool Remove(TKey key)
            {
                if (key == null || _Entries.Count<=0) return false;

                int HashCode = key.GetHashCode();
                int index = HashCode % _Entries.Count;


        
                var Node = _Entries[index];

                var temp = Node;
                while(temp!=null)
                {
                    if (temp.Key == null)
                        return false;

                    int NodekeyHashCode = temp.Key.GetHashCode();


                    if (temp.Key.Equals(key)&& NodekeyHashCode == HashCode)
                    {
                        if(temp.Previous!=null)
                        {
                            temp.Previous.Next = temp.Next;
                            return true;
                        }                      
                    }
                    temp = temp.Next;
                }
                return false;
            }

            public bool Remove(KeyValuePair<TKey,TValue> keyValuePair)
            {
                return Remove(keyValuePair.Key);
            }
            public void Add(KeyValuePair<TKey, TValue> keyValuePair)
            {
                Add(keyValuePair.Key,keyValuePair.Value);
            }

            public bool Contains(KeyValuePair<TKey, TValue> keyValuePair)
            {
                return TryGetValue(keyValuePair.Key,out _);
            }
            public void CopyTo(KeyValuePair<TKey, TValue>[] array,int StartIndex)
            {
                if (array.Length < _Entries.Count)
                    throw new Exception("The array size is less that the dictionary elements count");

                if(StartIndex>=array.Length)
                    throw new Exception("The index is bigger than the size of the array");



                for (int i = StartIndex; i < array.Length; i++)
                {
                    array[i] =new KeyValuePair<TKey, TValue>(_Entries[i].Key, _Entries[i].Value);
                }

            }
            public IEnumerator<KeyValuePair<TKey,TValue>> GetEnumerator()
            {
                foreach(var Node in _Entries)
                {
                    yield return new KeyValuePair<TKey,TValue>(Node.Key, Node.Value);
                }
            }
            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }

            public void Clear()
            {
                this._Entries.Clear();
                this._Entries.TrimExcess();
            }
        }
        static void Main(string[] args)
        {
          
        }
    }
}
