
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
            // also O(n) is best case and O(n²) in worst case
            Console.WriteLine("Intersection Contacts   :\n" +
              string.Join(" ,", Contacts1));


            // now contact1 contains : 0600000003 ,0600000004 ,0600000005
            // and contact2 constains: 0600000003 ,0600000004 ,0600000005 

            // now we want to delete the elements from contact1 that are exists in contact2
            Contacts1.ExceptWith(Contacts2); // the hashset now is empty
            // also O(n) is best case and O(n²) in worst case
            Console.WriteLine("after ExceptWith Contact2 :\n"+string.Join(", ",Contacts1));


            Contacts1.Add("0600000003"); // now we want to  remove the intercections                      
            //contact2 has {"0600000003","0600000004","0600000005"}
            // so the Contact will contains only the last 2 elements
            Contacts1.SymmetricExceptWith(Contacts2);
            Console.WriteLine("after Symmetric Exception : "+ string.Join(", ",Contacts1));

            //======================= Comparing two sets
            HashSet<string> LastNames1 = new HashSet<string>() { "Botte", "salimi", "mohammed" };
            HashSet<string> LastNames2 = new HashSet<string>() { "Bottpe", "mohammed", "salimi"};

            Console.WriteLine("Equals ?"+ (LastNames1.SetEquals(LastNames2)?"yes":"No"));
            // returns true if both have the same elements
            // the best case is O(1) if we compare the set with itself or if they have different count or if "other" is null
            // the average case is O(n) 
            // the worst case is O(n²) (collision)


            // ================================= MORE ABOUTSETS ================================

            // returns true if the first set is a part of the second set (regardless of order)
            Console.WriteLine("lastNames1 is a Subset Of LastNames2? " + LastNames1.IsSubsetOf(LastNames2));
            // Best case    :  O(1)  — first element is not found in other, returns false immediately
            // Average case :  O(n)  — iterates all elements, each Contains is O(1)
            // Worst case   :  O(n²) — iterates all elements + collisions degrade each Contains to O(n)


            // returns true if the first set is containing the second set elements (regardless of order)
            Console.WriteLine("lastNames2 is a container Of LastNames1? " + LastNames2.IsSupersetOf(LastNames1)); // true

            Console.WriteLine("Is Proper subset? "+ LastNames1.IsProperSubsetOf(LastNames2));
            //this function returns true only if the first set is a subset of another set + the other set has Count bigger that the first set

            Console.WriteLine("Is Proper subset? " + LastNames1.IsProperSupersetOf(LastNames2));
            //this function returns true only if the first set is a container of another set + the first set subset has Count bigger that the first set


            Console.WriteLine("They overlapes ?" + LastNames1.Overlaps(LastNames2));
            // this function returns true immediatly if any element exists is both sets


            
        }

    }
}
