using static System.Net.Mime.MediaTypeNames;
using System.Diagnostics.Metrics;

namespace Tuples
{
    internal class Program
    {
       
        public static (int ID,string Name) GetInfo()
        {
            return (ID: 10, Name: "Mstafa");
        }
        static void Main(string[] args)
        {
            // Using the tuple class
            Console.WriteLine("Tuple Class");
            Tuple<int, string, decimal> Employee = new Tuple<int, string, decimal>(1, "mustapha", 5000.4m);


            Console.WriteLine("Id " + Employee.Item1);
            Console.WriteLine("Name " + Employee.Item2);
            Console.WriteLine("Salary " + Employee.Item3);

            //  It's a reference type (class) — lives on the heap
            //  Always accessed via Item1, Item2, Item3 — no custom names
            //  Immutable — you cannot change values after creation
            //  Slower — heap allocation +garbage collector involved
            //  Max 8 elements(Tuple<T1, T2, T3, T4, T5, T6, T7, TRest>)


            // Using the tuple value type : struct 
            // allocated on the stack
            // Allows : mutation,names fields 

            Console.WriteLine("\nTuple as astruct ");
            var Employee2 = (ID: 1, Name: "mustapha", Salary: 5000.4m, Dep: "IT", ISActive: true); 
                    
            Console.WriteLine("Id " + Employee2.ID);
            Console.WriteLine("Name " + Employee2.Name);
            Console.WriteLine("Salary " + Employee2.Salary);
            Console.WriteLine("Department " + Employee2.Dep);
            Console.WriteLine("Is Active " + Employee2.ISActive);

            
            Employee2.Salary *= 2; // mutation
            Console.WriteLine("New salary " + Employee2.Salary);

            // Getting Data From a function

            var Info = GetInfo();
            Console.WriteLine(Info.ID);
            Console.WriteLine(Info.Name);

            Console.WriteLine(Info.GetType());

            // =================================== LINQ ===========================

            List<(int ID, string Name, decimal Salary)> Employees = new List<(int ID, string Name,decimal Salary)>()
            {
                 (ID: 1, Name: "mustapha",Salary: 5000.4m),
                 (ID: 2, Name: "karim",Salary: 4000),
                 (ID: 3, Name: "samir",Salary: 40000),
            };

            var samir = Employees.Where(emp => emp.Name == "samir").First();
            Console.WriteLine("\nSamir Info ");
            Console.WriteLine("Id " + samir.ID);
            Console.WriteLine("Name " + samir.Name);
            Console.WriteLine("Salary " + samir.Salary);




        }
    }
}
