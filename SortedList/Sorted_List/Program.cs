using System.Text.RegularExpressions;

namespace Sorted_List
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SortedList<string,int> SortedProducts = new SortedList<string, int>();
            
            SortedProducts.Add("TV",10);  // if the key  exists you will get an exception
            // if not , the index of insertion will be computed and the element will be placed there (shifting)

            SortedProducts.Add("Phone", 15);

            SortedProducts.Add("Bike", 13);

            SortedProducts.Add("Car", 10);

            SortedProducts.Add("Pc", 7);


            foreach (KeyValuePair<string,int>Product in SortedProducts)
            {
                Console.WriteLine($"Product name {Product.Key} , quantity :{Product.Value}");
            }
            int PhoneQuantity = SortedProducts["Phone"]; // the binary search is used here
            Console.WriteLine($" PhoneQuantity {PhoneQuantity} item");

            Console.WriteLine("Is removed ?" + (SortedProducts.Remove("phone") ? " Yes" : "No"));
            // returns true if the item is deleted, otherwise false
            // it uses the binary search to find the index ,
            // then it shift the elements 
            // it cause O(n) is the worst case and 
            // O(1) in the best case if we are removing the last elemnet


            // int FakeValue = SortedProducts["mouse"]; // KeyNotFoundException
            // =================================== LINQ ==============================

            var Query = from kvp in SortedProducts
                        where kvp.Value>0
                        group kvp  by kvp.Value into KV
                        select KV;


            Console.WriteLine("LINQ QUERY");
            foreach (var group in Query)
            {
                foreach (var item in group)
                {
                    Console.WriteLine(item.Value + " " + item.Key);
                }
                Console.WriteLine("*************");

            }
            // or you can use linq extention methods 
            // Note : the previous syntax is just an alias for the following:

            var FiltredData = SortedProducts.Where(kvp => kvp.Value > 0).
                                              GroupBy(kvp => kvp.Value>0).
                                              Select(KvpGroup => KvpGroup);

            Console.WriteLine("\nLINQ QUERY\n");
            foreach (var group in FiltredData)
            {             
                Console.Write("Group "+ group.Key+" :");
                int GroupLength = group.Count();
                int counter = 0;
                foreach (var Product in group)
                {
                    Console.Write($"{Product.Key} {(GroupLength == ++counter?"":",")}");
                }
                
                Console.WriteLine();
            }

            Console.WriteLine("\n\n=================================== EXERCISE ===================================\n\n");
            SortedList<string, int> StudentGrades = new SortedList<string, int>
            {
                { "Ali", 85 },
                { "Omer", 45 },
                { "Zaid", 92 },
                { "Sara", 78 },
                { "Laila", 30 },
                { "Ahmed", 55 },
                { "Huda", 88 },
                { "Anas", 40 }
            };
            //  group the students into two groups : failed /passes
            //  print the group name + the average grades + students names in this group ordered by their grade
            //  order the groups to show the passes group first

            var FinalReport = StudentGrades.GroupBy(student => student.Value >= 50).
                                            OrderBy(group => group.Key).
                                            Select(group => new
                                            {
                                                Passed = group.Key,
                                                Students = group.OrderByDescending(Student => Student.Value),
                                                Average = (int)group.Average(group => group.Value)
                                            });

                                            


            foreach (var group in FinalReport)
            {
                Console.WriteLine("Group Status   :" + (group.Passed?"Passed":"Failed"));
                Console.WriteLine("Average grades :" +  group.Average);

                foreach (var student in group.Students)
                {
                    Console.WriteLine(student.Key + " " + student.Value);
                }
                Console.WriteLine("==============================================");
            }

            Console.WriteLine("\n\n=================================== EXERCISE ===================================\n\n");

            SortedList<int, double> Employees = new SortedList<int, double>
            {
                { 101, 1500.0 },
                { 102, 3500.0 },
                { 103, 1200.0 },
                { 104, 5000.0 },
                { 105, 3200.0 },
                { 106, 1100.0 },
                { 107, 4800.0 },
                { 108, 3300.0 } 
            };
            var employeesReport = Employees.GroupBy(employee => new
            {
                Category = employee.Value < 2000 ? "Low" :
                           employee.Value >= 2000 && employee.Value <= 4000 ? "Medium" : "High"
            })
            .OrderByDescending(group=>group.Sum(emp=>emp.Value))
            .Select(group => new
            {
                group.Key.Category,
                Employees = group.OrderByDescending(employee=> employee.Value),
                Count = group.Count(),
                AverageSalaries = group.Average(Employee => Employee.Value),
                MinSalary = group.MinBy(Employee=> Employee.Value).Value,
                MaxSalary = group.MaxBy(Employee => Employee.Value).Value
            });

            foreach(var Group in employeesReport)
            {
                Console.WriteLine("=============================================================");
                Console.WriteLine("Group Category    :" + Group.Category);
                Console.WriteLine("Average Salaries  :" + Group.AverageSalaries);
                Console.WriteLine("Min Salary        :" + Group.MinSalary);
                Console.WriteLine("Max Salary        :" + Group.MaxSalary);
                Console.WriteLine("Totla Employees   :" + Group.Count);
                Console.WriteLine("Employees :");

                foreach (KeyValuePair<int, double> Employee in Group.Employees)
                {
                    Console.WriteLine("Employee Number :"+ Employee.Key+ "Employee Salary :" + Employee.Value);
                }
                
            }

            Console.WriteLine("\n============================ Working with classes==============================\n");
            SortedList<int, Employee> employees = new SortedList<int, Employee>()
            {
                { 1, new Employee("Alice", "HR", 50000) },
                { 2, new Employee("Bob", "IT", 70000) },
                { 3, new Employee("Charlie", "HR", 52000) },
                { 4, new Employee("Daisy", "IT", 80000) },
                { 5, new Employee("Ethan", "Marketing", 45000) }
            };
            var report = employees.Where(emp=>emp.Value.Department== "ITgi")
                .Where(emp=>emp.Value.Salary>=50000).
                Select(emp=>$"Employee ID : {emp.Key} , Name{emp.Value.Name} , Department{emp.Value.Department}, Salary {emp.Value.Salary}");

            foreach (var EmployeeInfo in report)
            {
                Console.WriteLine(EmployeeInfo);
            }

           
        }
        public class Employee
        {
            public string Name { get; set; }
            public string Department { get; set; }
            public decimal Salary { get; set; }


            public Employee(string name, string department, decimal salary)
            {
                Name = name;
                Department = department;
                Salary = salary;
            }
        }

    }
}
