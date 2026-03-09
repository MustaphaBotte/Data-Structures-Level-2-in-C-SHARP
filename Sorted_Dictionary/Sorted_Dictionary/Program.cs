namespace Sorted_Dictionary
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<string, int> ProductsQuantity = new SortedDictionary<string, int>();

            ProductsQuantity.Add("Orange", 75);
            ProductsQuantity.Add("Cherry", 15);
            ProductsQuantity.Add("Apple", 50);
            ProductsQuantity.Add("Banana", 120);
            ProductsQuantity.Add("Mango", 200);  // Each insertion is O(log n) no shifiting 

            foreach (var item in ProductsQuantity)
            {
                Console.WriteLine($"product : {item.Key} quantity :{item.Value}");
            } // traversing is O(n)

            Console.WriteLine("Contains Orange ? "+ProductsQuantity.ContainsKey("Orange")); // O(log n)

            Console.WriteLine("Contains 200 ? " + ProductsQuantity.ContainsValue(200));// O(n) : needs traversing

            int MangoQuantity = ProductsQuantity["Mango"]; // it will throw error if the key not found
            // O(log n) lookup
            Console.WriteLine($"Mango quantity {MangoQuantity}");


            int AppleQuantity = -1;
            ProductsQuantity.TryGetValue("_Apple",out AppleQuantity); // if not found you will get the default value of the value type
            // O(log n)
            Console.WriteLine($"Apple quantity {AppleQuantity}"); // it will print 0 not -1
            Console.WriteLine();

        }
    }
}
