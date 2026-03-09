using System.Collections;

namespace SortedSets
{
     
    internal class Program
    {
        static void Main(string[] args)
        {
           
            SortedSet<string> UserNames = new SortedSet<string>();
            UserNames.Add("admin");
            UserNames.Add("user");
            UserNames.Add("anonym");
            UserNames.Add("system");
            UserNames.Add("admin"); // it will throw an exception / just retursn false;
            // the Big(O) of insertion is O(log n) binary search tree traversal for the insertion  position using red black tree

            foreach (string user in UserNames)
            {
                Console.WriteLine(user);
            }

            // check for existance
            bool IsExists = UserNames.Contains("admin"); // O(log n)
            Console.WriteLine("is admin exists ? "+(IsExists?"Yes":"No"));

            // removing elements
            Console.WriteLine("is admin Removes ? " + (UserNames.Remove("admin") ? "Yes" : "No")); //O(log n)

            UserNames.RemoveWhere(username => username == "");
            // the complexity is O(n log n) in the worst case . if all the elements maches
            // first loop to get the elements that needs to be deleted and put them in an array


            #region LINQ
            // ================================= LINQ OPERTIONS =====================================

            SortedSet<Employee> Employees = new SortedSet<Employee>();
            // because Employee class is implented the IComparable , now it's safe to insert
            Employees.Add(new Employee(1, "Alice Johnson", 5500.00m, "Engineering"));
            Employees.Add(new Employee(2, "Bob Smith", 4200.00m, "Marketing"));
            Employees.Add(new Employee(9, "Isabel Taylor", 3700.00m, "HR"));
            Employees.Add(new Employee(10, "James Anderson", 6600.00m, "Finance"));
            Employees.Add(new Employee(4, "David Brown", 3900.00m, "HR"));
            Employees.Add(new Employee(6, "Frank Miller", 5200.00m, "Engineering"));
            Employees.Add(new Employee(7, "Grace Wilson", 4800.00m, "Marketing"));
            Employees.Add(new Employee(8, "Henry Moore", 9200.00m, "Management"));
            Employees.Add(new Employee(3, "Carol White", 7800.00m, "Engineering"));    
            Employees.Add(new Employee(5, "Emma Davis", 6100.00m, "Finance"));

            Console.WriteLine(" Employees In sorted order by their ID");
            foreach (Employee item in Employees)
            {
                Console.WriteLine(item.ToString());
            }
            Console.WriteLine($"Max Salary {Employees.Max(emp => emp.Salary)}");
            Console.WriteLine($"Min Salary {Employees.Min(emp => emp.Salary)}");
            Console.WriteLine($"Total Salaries {Employees.Sum(emp => emp.Salary)}");
            Console.WriteLine($"Average Salaries {Employees.Average(emp=>emp.Salary)}\n\n");

            // Question 1 : Group the employees  by the department and sort each group by the salaries in DESC order , then sort the groups by the total of its  salaries
            // Question 2 : select only the departments that has total salaries bigger than 10k$
            var Query = Employees.GroupBy(emp => emp.Departement).
                                  Select(group =>
                                      new
                                      {
                                          group.Key,
                                          TotalSalaries = group.Sum(emp => emp.Salary),
                                          Employees = group.OrderByDescending(emp => emp.Salary)  // order the employees in each group
                                      }
                                  ).OrderByDescending(group => group.Employees.Sum(emp => emp.Salary))
                                  .Where(group=>group.TotalSalaries>10000); 
                                   // order the groups by the highest total of salaries

            
            foreach (var Group in Query)
            {
                Console.WriteLine("Department name : "+Group.Key);
                Console.WriteLine("Total Salaries  : " + Group.TotalSalaries);

                Console.WriteLine("=========================================================================");
                foreach (Employee employee in Group.Employees)
                {
                    Console.WriteLine(employee);
                }
                Console.WriteLine("=========================================================================");

            }
            #endregion


            SortedSet<string> UserNames2 = new SortedSet<string>()
            { 
              "admin","user","robot","root"
            };
            UserNames.UnionWith(UserNames2);
            Console.WriteLine("Union :"+string.Join(" ,",UserNames));

            UserNames.IntersectWith(UserNames2);
            Console.WriteLine("Intersections :" + string.Join(" ,", UserNames)); // now UserNames is empty


            UserNames.Add("super_admin");
            UserNames.ExceptWith(UserNames2);
            Console.WriteLine("Except :" + string.Join(" ,", UserNames)); // only super_admin exists

            UserNames2.Add("super_admin");
            Console.WriteLine("Is subset    :" +UserNames.IsSubsetOf(UserNames2));  // true 
            Console.WriteLine("Is superset  :" + UserNames2.IsSupersetOf(UserNames));  // true 

            UserNames2.Clear();
            UserNames2.Add("super_admin");
            Console.WriteLine("Is equals  :" + UserNames2.SetEquals(UserNames));  // true // Log(n) if both are SortedSet



        }
        class Employee : IComparable<Employee>
        {
            public int ID = -1;
            public string FullName = "";
            public decimal Salary = 0.0m;
            public string Departement = "";

            public int CompareTo(Employee? other)
            {
                return ID.CompareTo(other?.ID);
            }
            public Employee(int iD, string fullName, decimal salary, string departement)
            {
                ID = iD;
                FullName = fullName;
                Salary = salary;
                Departement = departement;
            }
            public override string ToString()
            {
                return $"ID: {ID} | Name: {FullName} | Salary: {Salary:C} | Department: {Departement}";
            }
        }




    }
}
