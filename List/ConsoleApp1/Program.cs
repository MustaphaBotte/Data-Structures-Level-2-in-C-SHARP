
using Microsoft.VisualBasic;

namespace ConsoleApp1
{
    internal class Program
    {
        private static void IntroductionToList()
        {
            List<int> my_list = new List<int>();
            my_list.Add(10); // adding one element to the list
            my_list.Add(20);
            my_list.Add(30);
            my_list.Add(40);
            Console.WriteLine(my_list.Capacity); // the capacity is initialized by 4 after the first insertion
            my_list.Add(50);
            Console.WriteLine(my_list.Count); // now size is 5 ; and 5 is bigger than the capacity 4
            // so the list will be resized to capacity * 2
            Console.WriteLine(my_list.Capacity); // output = 8

            Console.WriteLine(my_list[0]);  // accessing the first element in the list
            my_list[1] = 1400; // updating the second element
            //Console.WriteLine(my_list[5]); // error out  of range
        }
      
        private static void InsertingInto_List()
        {
            List<int> my_list = new List<int> { 10, 20, 30, 40, 50 };
            Console.WriteLine(string.Join(" ,",my_list));
            Console.WriteLine("Length of the list ="+my_list.Count);

            my_list.Add(60); // insert at the end , it can be O(1) if we still have capacity or O(n) if the capacity is full ,so we need a new block 
            my_list.Insert(0, 0); // insert by index , always o(n) because we must shift the elements
            Console.WriteLine(string.Join(" ,", my_list));

            List<int> newList = new List<int> { 22, 23, 29 };
            my_list.InsertRange(3, newList);  // O(n) shift needed
            Console.WriteLine(string.Join(" ,", my_list));

           // my_list = my_list.Append(500).ToList(); .append creates a new IEnumerableSequence so you need to convert it to list then assing
           //it to the old array
            Console.WriteLine(string.Join(" ,", my_list));

        }

        private static void RemoveFromList()
        {
            List<int> my_list = new List<int> { 10, 20, 30, 40, 50 };
         
            Console.WriteLine("Original List : "+string.Join(" ,",my_list));    
            my_list.Remove(10);   
            Console.WriteLine("List after delete  : " + string.Join(" ,", my_list));
            // internally it will search for the index of that item so it's O(n)
            // then if we are deleting the last item so no shift is needed just clear the last element by GC but only if T is a reference type 
            // note that the size is reduced by 1
            // and if the deletion if operated on an item in the middle of in the beginning so the shifting is needed and
            // it will cost O(n) again

            my_list.RemoveAt(0); // same explanation but we dont have the search operation , because we provide the index

            Console.WriteLine("List after delete  : " + string.Join(" ,", my_list));

            my_list.RemoveRange(2, 1);
            Console.WriteLine("List after delete  : " + string.Join(" ,", my_list));
            // if we are deleting only the last item then it's O(1)
            // otherwise the shift operation is needed so it's O(n)

            my_list.RemoveAll((int current_val) =>
            {
                return current_val >= 40;
            });
            Console.WriteLine("List after delete  : " + string.Join(" ,", my_list));


            my_list.Clear();
            Console.WriteLine(my_list.Capacity); // the capacity still 8 
            Console.WriteLine(my_list.Count); //but the count is 0



        }

        private static void Lopping()
        {
            List<int> my_list = new List<int> { 10, 20, 30, 40, 50 };

            int length = my_list.Count;
            Console.WriteLine("using for loop");
            for(int i=0;i<length;i++)
            {
                Console.Write(my_list[i]+" ");
            }

            Console.WriteLine("\nusing for each");

        
            foreach (int item in my_list)
            {
                Console.Write(item + " ");

            }
            Console.WriteLine("\nusing lambda expression");
            my_list.ForEach(current => Console.Write(current+" "));

           
        }

        static void Main(string[] args)
        {
            // IntroductionToList();
            // InsertingInto_List();       
            // RemoveFromList();
            Lopping();

        }

    }
}
