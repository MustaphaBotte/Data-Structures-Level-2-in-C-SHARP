using System.Collections;
using System.Globalization;
namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> BookNumbers = new Dictionary<string, string>()
            {
                {"ahmed","060597988" },
            };
            BookNumbers["ahmed"] = "0754545454"; // modify the entry value

            BookNumbers.Add("mustapha", "0645454545");
            BookNumbers.Add("amine", "0645454545");
            BookNumbers.Add("karim", "0645454545");
            BookNumbers.Add("karime", "0645454545");
          

            BookNumbers["ahmed"] = "0600000000";//even if it's already exists , the dictionary will just override it without any run time exception

            // BookNumbers.Add("ahmed", "07789797987"); // but this will throw an exception of : 
            // 'An item with the same key has already been added. Key: ahmed'


            BookNumbers.Remove("ahmed",out string? DeletedValue); //DeletedValue may be  null if the key is not exists
            Console.WriteLine($"Ahmed is deleted with phone number = {DeletedValue}");


            foreach (KeyValuePair<string,string> entry in BookNumbers)
            {
                Console.WriteLine($"KEY {entry.Key}, VALUE {entry.Value}");
            }
            BookNumbers.ContainsKey("ahmed"); // true is yes false if not. the complexity is  O(1) but it may be O(n)in worst case  because of hash collisions
            BookNumbers.ContainsValue("0645454545");  // true is yes false if not. the complexity is  O(n) Linear scan through all entries.

            Console.WriteLine(BookNumbers.EnsureCapacity(107)); // ensures the underlying buffer of the collection can hold at least the requested number of elements —                        
            // avoiding repeated reallocations as it grows.


            BookNumbers.TrimExcess(); // ensure that the capacity of the dictinary is sets to the inital state
            // means the nearest prime number to the Count of the entries;

            Console.WriteLine(BookNumbers.EnsureCapacity(0)); // just to print the capacity 


            BookNumbers.TryGetValue(null, out string? number);
            Console.WriteLine(number??"Not Found");
            // or you can use if condition because the TryGet retunrs true is the value if  founded
            // otherwise the value will hold the default value of it's data type
         
            Console.WriteLine();
        }
    }
}
