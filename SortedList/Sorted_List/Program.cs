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

            SortedProducts.Add("car", 10);

            foreach(KeyValuePair<string,int>Product in SortedProducts)
            {
                Console.WriteLine($"Product name {Product.Key} , quantity :{Product.Value}");
            }
            int PhoneQuantity = SortedProducts["Phone"]; // the binary search is used here
            Console.WriteLine($" PhoneQuantity {PhoneQuantity} item");
        }
    }+
}
