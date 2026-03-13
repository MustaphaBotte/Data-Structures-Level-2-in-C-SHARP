using System.Diagnostics;
using System.Text.RegularExpressions;

namespace Arrays
{
    internal class Program
    {
        public static void Print(Array arr)
        {
            foreach (var item in arr)
            {
                Console.Write(item+" ");
            }
        }
        static void Main(string[] args)
        {
            string[] usernames =new string[4] { "admin", "root", "user", "system" };

            // or just
            string[] usernames2 = new string[4]; // then assing 


            Console.WriteLine("Array lenth "+usernames.Length);

            Print(usernames);
            

            usernames.SetValue("admin2", 0);
            // Note : its better to use direct indexes  like this :
            usernames[0] = "admin2";


            string? value =usernames.GetValue(0)?.ToString();

            Console.WriteLine("\nElement in index 0 :"+value);
            Console.WriteLine("The Type of the array "+ usernames.GetType());


            // Sort the array :
            Array.Sort(usernames);

            Print(usernames);

            Console.WriteLine("Index of root "+Array.IndexOf(usernames,"root"));

            int  index = Array.BinarySearch(usernames, "system");
            Console.WriteLine("Index of system using binary search on a sorted array  c  " + Array.IndexOf(usernames, "root"));

            int IndexOfUser = Array.IndexOf(usernames, "user");
            Console.WriteLine($"Index of user is {IndexOfUser}");


            string[] Clone =  (string[]) usernames.Clone(); // a separated array

            Console.WriteLine("Cloning");
            Clone[0] = "update";
            Console.WriteLine(usernames[0]); // Untouched

            int[,] nums = {
                { 10, 20, 30 }, { 40, 50, 60 }, { 40, 50, 60 },};
            int TotalRows = nums.GetLength(0);
            int TotalColumns = nums.GetLength(1);

            int totalElements = TotalRows * TotalColumns;


            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            for(int i =0;i< totalElements; i++)
            {
                int Row = i / TotalColumns;
                int Col = i % TotalColumns;

                Console.Write(nums[Row,Col]+" ");

                if(Col+1 == TotalColumns)
                    Console.WriteLine();
            }

            var users = usernames.Where(user => user.Length > 5).Select(user => $"This user has length bigger than 5 :{user}");
            foreach (var item in users)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("=======================LINQ=============================");

            var people = new[]
            {
               new { Name = "Alice",   Age = 30 ,Salary = 1000  ,DepartmentId = 2 },
               new { Name = "Bob",     Age = 25, Salary = 5000  ,DepartmentId = 1 },
               new { Name = "Charlie", Age = 35, Salary = 11000 ,DepartmentId = 1 },
               new { Name = "Diana",   Age = 30, Salary = 2000  ,DepartmentId = 2 },
               new { Name = "Ethan",   Age = 25, Salary = 500   ,DepartmentId = 1 }
            };
            var GroupByAge = people.GroupBy(person => person.Age).
                Select(group => new {People = group.OrderBy(person=> person.Name) ,Age = group.Key});

            foreach (var group in GroupByAge)
            {
                Console.WriteLine($"Group Age: {group.Age}");
                foreach (var person in group.People)
                {
                    Console.WriteLine($"Name : {person.Name} Age : {person.Age}");
                }
            }
            Console.WriteLine("Toatl Salaries " + people.Sum(p=>p.Salary));
            Console.WriteLine("Average Salaries " + people.Average(p => p.Salary));
            Console.WriteLine("Max Salary " + people.Max(p => p.Salary));
            Console.WriteLine("Min Salary " + people.Min(p => p.Salary));


            var departments = new[]
            {
            new { Id = 1, Name = "Human Resources" },
            new { Id = 2, Name = "Development" }
            };
            Console.WriteLine("==================== JOIN =======================");
            var JoinedResult = people.Join(departments,
                               p => p.DepartmentId,
                               d => d.Id,
                               (person, department) => new { person.Salary, person.Age, person.Name, Department= department.Name}
                               );

            foreach (var person in JoinedResult)
            {
                Console.WriteLine($"Name : {person.Name} Age : {person.Age} Salary : {person.Salary} Department :{person.Department}");
            }


        }
    }
}
