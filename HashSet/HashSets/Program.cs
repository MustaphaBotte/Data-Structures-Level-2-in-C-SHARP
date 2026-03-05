
using System.Collections.Generic;
namespace HashSets
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> UserNames = new HashSet<string>();

            UserNames.Add("admin");
            UserNames.Add("admin2");
            UserNames.Add("admin2"); // hash set hash this value and map it with its bucket
            // and it uses the .Equal method to compare it with any element in this bucket (collision case)
            // if exists it returns false,
            // otherwise returns true

            foreach (string username in UserNames)
            {
                Console.WriteLine(username);
            }
            //This code checks whether a specific element is present in the HashSet.
            // O(1) in the best and the average case
            // and O(n) in the worst case (collision)
            Console.WriteLine(UserNames.Contains("admin")?"admin is exists":"admin not found");


            //  removing an element from the hashset
            Console.WriteLine(UserNames.Remove("admin")?"Removed":"Not Found");
            // O(1) in the best and the average case
            // and O(n) in the worst case (collision)
        }

    }
}
