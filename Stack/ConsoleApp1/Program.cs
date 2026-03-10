using System.Collections.ObjectModel;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<string> VisitedPages = new Stack<string>();

            VisitedPages.Push("https://google.com");
            VisitedPages.Push("https://github.com");
            VisitedPages.Push("https://stackoverflow.com");
            VisitedPages.Push("https://anthropic.com");

            string LastVisitedPage = VisitedPages.Peek(); // Be careful : it may throw an exception if the stack is empty
            Console.WriteLine($"Last visited page is {LastVisitedPage}");


            // for better control use
            if(!VisitedPages.TryPeek(out string? Safe_LastVisitedPage))
            {
                Console.WriteLine("Stack  is empty");
            }
            else
            {
                Console.WriteLine($"Last visited page is {Safe_LastVisitedPage}");
            }

            // the time complexity is constant : O(1)


            // now remove the last pushed url
            Console.WriteLine($"The current element is poped from the stack ? {VisitedPages.Pop()}");
            // again it may throw an exception if the stack is empty, use can use :


            if(VisitedPages.TryPop(out string? RemovedUrl))
            {
                Console.WriteLine($"The current element is poped from the stack ? {RemovedUrl}");
            }
            else
            {
                Console.WriteLine("The stack is empty");
            }

            Console.WriteLine($"Stack Size : {VisitedPages.Count}"); // total elements in the stack
            Console.WriteLine(VisitedPages.EnsureCapacity(10)); // resize the array (must be bigger than the Count), O(n)
            // Output : 10

            VisitedPages.TrimExcess(); // O(n)
            // resize the array capacity to the total elements
         

        }
    }
}
