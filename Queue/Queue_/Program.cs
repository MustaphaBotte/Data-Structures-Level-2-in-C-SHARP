namespace Queue_
{
    internal class Program
    {
        public class Order
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
        }
        static void Main(string[] args)
        {
            Queue<Order> Orders = new Queue<Order>();
            Orders.Enqueue(new Order(1, "Pizza", 1));
            Orders.Enqueue(new Order(1, "Pizza", 1));
            Orders.Enqueue(new Order(1, "Pizza", 1));
            Orders.Enqueue(new Order(1, "Pizza", 1));
        }
    }
}
