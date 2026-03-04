using System.Collections;
using System.Runtime.InteropServices;
namespace ConsoleApp1
{
    internal class Program
    {
        private static void PrintDictionaryContent<TKey, TValue>(Dictionary<TKey,TValue> source) where TKey : notnull
        {
            foreach (KeyValuePair<TKey, TValue> entry in source)
            {
                Console.WriteLine($"KEY {entry.Key}, VALUE {entry.Value}");
            }
        }
      
        static void Main(string[] args)
        {
            Dictionary<string, string> BookNumbers = new Dictionary<string, string>()
            {
                {"ahmed","060597988" },
            };
            BookNumbers["ahmed"] = "0754545454"; // modify the entry value

            BookNumbers.Add("mustapha", "0645454545");
            BookNumbers.Add("amine", "0545454545");
            BookNumbers.Add("karim", "0745454545");
            BookNumbers.Add("karime", "0645454545");


            BookNumbers["ahmed"] = "0600000000";//even if it's already exists , the dictionary will just override it without any run time exception

            // BookNumbers.Add("ahmed", "07789797987"); // but this will throw an exception of : 
            // 'An item with the same key has already been added. Key: ahmed'


            BookNumbers.Remove("ahmed", out string? DeletedValue); //DeletedValue may be  null if the key is not exists
            Console.WriteLine($"\nAhmed is deleted with phone number = {DeletedValue}");


            PrintDictionaryContent(BookNumbers);
            
            BookNumbers.ContainsKey("ahmed"); // true is yes false if not. the complexity is  O(1) but it may be O(n)in worst case  because of hash collisions
            BookNumbers.ContainsValue("0645454545");  // true is yes false if not. the complexity is  O(n) Linear scan through all entries.

            Console.WriteLine(BookNumbers.EnsureCapacity(107)); // ensures the underlying buffer of the collection can hold at least the requested number of elements —                        
            // avoiding repeated reallocations as it grows.


            BookNumbers.TrimExcess(); // ensure that the capacity of the dictinary is sets to the inital state
            // means the nearest prime number to the Count of the entries;

            Console.WriteLine("\n"+BookNumbers.EnsureCapacity(0)); // just to print the capacity 


            BookNumbers.TryGetValue("karim", out string? number);
            Console.WriteLine(number ?? "Not Found  \n");
            // or you can use if condition because the TryGet retunrs true is the value if  founded
            // otherwise the value will hold the default value of it's data type

            //-------------------------------------- LINQ --------------------------------------------------------

            IEnumerable<string> result = BookNumbers.Select(kvp => $"KEY {kvp.Key}, VALUE {kvp.Value}"); // this compiler knows the return type 
            // from the lambda return type. this is called inference
            foreach (var item in result)
            {
                Console.WriteLine(item);
            }

            var result2 = BookNumbers.Select(kvp => new  {kvp.Key,kvp.Value }); // this create an anonymous type, thats why i used var
            foreach (var obj in result2)
            {
                Console.WriteLine($"KEY {obj.Key}, VALUE {obj.Value}");
            }
            // if the value is a list you can use SelectMany function

           var FiltredData =BookNumbers.Where(kvp => kvp.Value.StartsWith("06")); // where returns an IEnumerable that contains the 
            // KVP that returns true in the predicate

            Console.WriteLine("\nPhone numbers with 06");
            foreach (var kvp in FiltredData)
            {
                Console.WriteLine($"KEY {kvp.Key}, VALUE {kvp.Value}");
            }

            Console.WriteLine("`\nSorting the dictionary by the key");
            var OrderdData = BookNumbers.OrderBy(KVP=>KVP.Key); // or use OrderByDescending  
            foreach (var entry in OrderdData)
            {
                Console.WriteLine($"KEY {entry.Key}, VALUE {entry.Value}");
            }
            // Note that the OrderBy does not modify the original dictionary 


            string? MinNumber = BookNumbers.Min(Kvp => Kvp.Value); // return only the value
            Console.WriteLine("\n Smallest phone number is :" + MinNumber);

            var MinEntry = BookNumbers.MinBy(Kvp => Kvp.Value); // retussrns the entire entry
            Console.WriteLine("\n Smallest phone  number is "+ MinEntry.Value);


            Console.WriteLine("===================================");
            PrintDictionaryContent(BookNumbers);

            var element = BookNumbers.ElementAt(3); // element at index 3 using GetEnumeretor().moveNext()
            Console.WriteLine(element.Key);



            Console.WriteLine("====================================   Advanced LINQ Queries with Dictionaries ======================================= ");

            Dictionary<string, string> BooksCategory = new Dictionary<string, string>(6);
            BooksCategory.Add("learn c++", "programming");
            BooksCategory.Add("learn c#", "programming");

            BooksCategory.Add("learn linux", "os");
            BooksCategory.Add("learn unix", "os");

            BooksCategory.Add("learn iso", "networks");
            BooksCategory.Add("read got book", "fantasy");
            BooksCategory.Add("read viking book", "fantasy");

            BooksCategory.Add("learn adobe", "photoshop");
            BooksCategory.Add("learn canva", "photoshop");

            IEnumerable<IGrouping<string,KeyValuePair<string,string>>> BooksGroup = BooksCategory.GroupBy(Kvp => Kvp.Value);

            foreach(IGrouping<string, KeyValuePair<string, string>> group in BooksGroup)
            {
                Console.Write($"\n{group.Key} :");
                foreach (KeyValuePair<string,string> book in group)
                {
                    Console.Write($"{book.Key} ,");
                }
                Console.WriteLine();
            }

            Dictionary<string, int> Products_Quantity = new Dictionary<string, int>();

            Products_Quantity.Add("Apple TV", 10);
            Products_Quantity.Add("Samsung A10", 5);
            Products_Quantity.Add("Bike", 15);
            Products_Quantity.Add("Usb", 18);
            Products_Quantity.Add("Ball", 12);
            Products_Quantity.Add("Laptop", 50);
            Products_Quantity.Add("Watch", 70);

            IEnumerable<string> FiltredPrducts = Products_Quantity.Where(prod => prod.Value < 20).
                OrderBy(prod => prod.Key).
                Select(prod => $"Product Name : {prod.Key} , Quantity :{prod.Value}");

            // Note that this query chain will not execute until we use it in a foreach or in other operation
            // this is by design in LINQ for better performance 

            foreach (string item in FiltredPrducts)
            {
                Console.WriteLine(item);
            }




        }


    }  
       
}
