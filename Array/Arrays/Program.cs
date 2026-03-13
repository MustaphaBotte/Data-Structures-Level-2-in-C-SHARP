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

            int[,] nums = { { 10, 20, 30 }, { 40, 50, 60 } };
          
        }
    }
}
