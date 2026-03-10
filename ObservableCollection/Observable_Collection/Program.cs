using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq.Expressions;
namespace Observable_Collection
{
    internal class Program
    {
        public static ObservableCollection<string> UserNames = new ObservableCollection<string>();
        public static void  handler(object? sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    {
                        Console.WriteLine($"\nNew Item Added in the index {e.NewStartingIndex} ," +
                            $" The Item Value is :{e.NewItems?[0]??"N/A"}");
                        break;
                    }
                case NotifyCollectionChangedAction.Remove:

                    {
                        Console.WriteLine($"\nItem is removed in the index index {e.OldStartingIndex} ," +
                        $" The Item Value is :{e.OldItems?[0] ?? "N/A"}");
                        break;
                    }
                case NotifyCollectionChangedAction.Move:

                    {
                        Console.WriteLine($"\nItem is switched from the index {e.OldStartingIndex} TO {e.NewStartingIndex}," +
                        $" The Item Value is :{e.OldItems?[0] ?? "N/A"} ");
                        break;
                    }
                case NotifyCollectionChangedAction.Replace:

                    {
                        Console.WriteLine($"\nItem is modified in the index {e.OldStartingIndex}" +
                        $" The old Value is :{e.OldItems?[0] ?? "N/A"} and the new item value is " +
                        $"{e.NewItems?[0] ?? "N/A"}");
                        break;
                    }


                default:
                    {
                        Console.WriteLine("\nUNKNOWN");
                        break;
                    }
            }
             
        }
   
        static void Main(string[] args)
        {
            UserNames.CollectionChanged += handler;
            UserNames.Add("admin");
            UserNames.Add("user");
            UserNames.Add("super");
          
          

            UserNames[2]="root";
            UserNames.Move(0, UserNames.Count - 1); // move the first element to the last
            UserNames.RemoveAt(0);


            foreach (var item in UserNames)
            {
                Console.WriteLine(item);
            }

            // the ObservableCollection inherits from Collection<T> which has a List<T> inside + 4 virtual methods
            // ObservableCollection overrides thos four methos : SetItem, InsertItem, RemoveItem, ClearItems  (Run Time Polymorphism)
            // they call the base method for each one to do the normal list operation
            // plus the invocation for your methods. that's how it works 
            // you must not modify the collection without checking the action type in the handler : recursion will happend
            // you must not modify the collection if you have more than one handler : you will get an exception





        }
    }
}
