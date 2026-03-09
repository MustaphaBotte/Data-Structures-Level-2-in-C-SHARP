using System.Collections;

namespace Array_list
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ArrayList Content = new ArrayList();
            Content.Add("mustapha"); 
            Content.Add("ahmed");
            Content.Add("mounir");
            Content.Add("samir");
            Content.Add("karim");

            // the capacity of the array grows as needed
            // when the arrya is full it will double it's capacity
            // the insertion costs O(1) is we have the capacity > Count
            // and O(n) if the  capacity == Count (shifting the elements)



            foreach (var item in Content) // O(n)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("========================================");
            for (int i= 0;i< Content.Count;i++) // O(n)
            {
                Console.WriteLine(Content[i]);
            }

            // removing 
            Content.Remove("ahmed");// because the string and other value types are implementing their Equals() method
            // so the comparaison will work and will not compare references (Boxing) 
            // the big O is O(n) : finding the index of the element + shifting the elements

            Console.WriteLine(Content.Capacity); // 8
            Content.TrimToSize(); 
            Console.WriteLine(Content.Capacity); // 5

            Content.RemoveAt(0); // O(n)
            Content.Reverse(); //reverse the order

            foreach (var item in Content) // O(n)
            {
                Console.WriteLine(item);
            }
            Content.Sort(); //  the big depends on the algorithme used internally
                            // it will throw an exception if the element are heterogeneous

            // ================================================ LINQ =================================================

            ArrayList arrayList = new ArrayList { 1, 2, 2, 3, 4, 5, 6, 7, 8, 9, 10, 'c'};

            IEnumerable<int> result = arrayList.Cast<int>();
            //NOTE : if you put a string in the collection you will get an error 
            // the collection must be homogeneouss

            // use this method f you want to get only a specific type
            result = arrayList.OfType<int>();

            foreach (var item in result)
            {
               
                Console.WriteLine("Integer :"+item);
            }

            // ================================= AGGREGATE FUNCTION ========================
            Console.WriteLine($"Sum : {result.Sum()}");
            Console.WriteLine($"Min : {result.Min()}");
            Console.WriteLine($"Max : {result.Max()}");
            Console.WriteLine($"Average : {result.Average()}");
            Console.WriteLine($"Count : {result.Count()}");

            // ================================= Counting occurrences of an int ========================
            
            int number = 2;
            int Occurrences = result.Count(num => num == number);
            Console.WriteLine($"Occurrences of 2 in the array : {Occurrences}");


        }
    }
}
