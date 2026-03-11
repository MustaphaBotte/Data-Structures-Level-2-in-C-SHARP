namespace Queue_
{
    internal class Program
    {
         public  class  Order 
         { 
            public int OrderID = -1;
             
            public string OrderName = "";
             
         
             
            public int PersonID = -1;
           
            public Order(int orderID, string orderName,int personID)
            {
                OrderID = orderID;
                OrderName = orderName;
                PersonID = personID;
            }
            public override string ToString()
            {
                return $" ID : {OrderID} , Name : {OrderName}, PersonID :{PersonID}";
            }
            public override bool Equals(object? obj)
            {
                if (!(obj is Order))
                    return false;

                Order order = (Order)obj;

                return order?.OrderID == this.OrderID && order.OrderName == this.OrderName;
            }
        }
        static void Main(string[] args)
        {
            Queue<Order> Orders = new Queue<Order>();
            Orders.Enqueue(new Order(1, "Pizza", 1));
            Orders.Enqueue(new Order(1, "Water", 1));
            Orders.Enqueue(new Order(1, "Bread", 1));
            Orders.Enqueue(new Order(1, "Water", 1));

            // each inque operation is taking O(1) in case we have space in the internal array (the size is doubled each time the array is full)
            // it may take O(n) for shifting the elements into a new array

            Order FirstOrder = Orders.Peek(); // O(1)
            Console.WriteLine($"First order is  {FirstOrder}");
            // its will throw an error if the internal array is empty
            // you can use :

             
            if(Orders.TryPeek(out Order? Safe_FirstOrder)) // O(1)
            {
                Console.WriteLine($"First order is  {Safe_FirstOrder}");
            }


            Order DeQueuedOrder = Orders.Dequeue();   // O(1) in the best case and O(n) if resize is needed
            // its will throw an error if the internal array is empty
            // you can use :

            if (Orders.TryDequeue(out Order? Safe_DeQueuedOrder))
            {
                Console.WriteLine($"DeQueued Order is  {Safe_DeQueuedOrder}");
            }

            Console.WriteLine(Orders.EnsureCapacity(Orders.Count));// 4 

            Orders.TrimExcess();
            // reduce the size of the Queue to the actual number of elements


            Console.WriteLine(Orders.Count);//  2


            Console.WriteLine("resizing the internal array to : "+Orders.EnsureCapacity(100));

 
             Order SearchFor = new Order(1, "Bread", 1);
            Console.WriteLine("Exists :" + Orders.Contains(SearchFor));
            // O(n)
            // to use this method you need to override  the Equals method

            Orders.Clear(); // clear the array 
            // O(n) is T is reference type  (elements must be set to null)
            // O(1) if T is value type 
        }
    }
}
