using System.Collections; 


namespace HashTables
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //this data strtucture is non generic
            // it means we have an overhead caused by boxing and unboxing
            Hashtable hashtable = new Hashtable(capacity:5) // initialize the capacity by 5 entries 
            //but •	Internally, the actual bucket array size may be a prime number greater than or equal to 5 (for better hash distribution).
            {
                {"key",1 },
                {"key0",0 }
                // you can also use the constructor
            };
            hashtable["key1"] = 10;
            hashtable["key1"] = 22; // if you want to add a key that is already exists, it will be overrided

            //hashtable.Add("key1", 30); // using the add method , if that is already exists, you will get an exception


            hashtable.Remove("key"); //removing an element by the key 

            foreach(DictionaryEntry entry in hashtable)
            {
                Console.WriteLine($"KEY {entry.Key} VALUE{entry.Value}");
            }


            // we will stop here because we will learn Dictionnary
            // it's an advanced hashtable and it's a generic DS
            // so there is no boxing and unboxing
        }
    }
}
