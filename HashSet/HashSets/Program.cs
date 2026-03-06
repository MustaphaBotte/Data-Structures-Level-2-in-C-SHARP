
using System.Collections.Generic;
using System.Xml.Linq;
namespace HashSets
{
    internal class Program
    {
        class Person
        {
           public string name = "";
        }
       
        static void Main(string[] args)
        {
            HashSet<string> UserNames = new HashSet<string>();

            UserNames.Add("admin");
            UserNames.Add("admin2");
            UserNames.Add("admin0");
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


            int result = UserNames.RemoveWhere(user => user.StartsWith('a')); // you can use lambda expression
            // as a callback

            Console.WriteLine(result); // result is an Int that contains the number of deleted items


            string[] names = new string[] {"ahmed" ,"samir","karim","mourad","ahmed", "samir" };

            HashSet<string> UniqueNames = new HashSet<string>(names);
            // initialize the hash set with an array , and it will automatically remove duplicates
            foreach (string item in UniqueNames)
            {                     
               
                Console.WriteLine(item);
            }// the time compexity is O(n)


            //LINQ
            var Newdata = UniqueNames.Select(name => name + "."); // add point to each username
            Console.WriteLine("New Data : "+string.Join(" ,",Newdata));

            var FiltredData = UniqueNames.Where(name => name.StartsWith('a'));
            Console.WriteLine("Filtred Data : " + string.Join(" ,", FiltredData));


            // UNION
            HashSet<string> Contacts1 = new HashSet<string>(3)
            {"0600000001","0600000002","0600000003" };

            HashSet<string> Contacts2 = new HashSet<string>(3)
            {"0600000003","0600000004","0600000005" };

            Contacts1.UnionWith(Contacts2); // merging two sets with no duplicates
            // time complexity is O(n)
            Console.WriteLine("Merged Contacts with no duplicates :\n"+
               string.Join(" ,",Contacts1));

            // INTERSECTION

            Contacts1.IntersectWith(Contacts2);  // keep only the elements that are in both sets
            // also O(n)
            Console.WriteLine("Intersection Contacts   :\n" +
              string.Join(" ,", Contacts1));




        }

    }
}
