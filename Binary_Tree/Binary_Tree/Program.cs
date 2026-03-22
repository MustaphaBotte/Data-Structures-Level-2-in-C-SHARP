using System.Text;

namespace Binary_Tree
{
    class BinaryTreeNode<T>
    {
        public T Data { set; get; }

        public BinaryTreeNode<T>? Left  = null;
        public BinaryTreeNode<T>? Right = null;

        public BinaryTreeNode(T data)
        {
            if (Data is null)
                throw new NullReferenceException("Data Cannot Be Null!");

            Data = data;
        }
    }
    class BinaryTree<T>
    {
        public BinaryTreeNode<T>Root { private set; get; }

        public BinaryTree(T Data)
        {
            this.Root = new BinaryTreeNode<T>(Data);
        }
        
        // using level order insertion strategy
        public void Insert(T Data)
        {
            if (Data is null)
                throw new NullReferenceException("Data Cannot Be Null!");

            var NewNode = new BinaryTreeNode<T>(Data);
          

            var NodesQueue = new Queue<BinaryTreeNode<T>>();
            NodesQueue.Enqueue(this.Root);

            while (NodesQueue.Count>0)
            {

                var CurrentNode = NodesQueue.Dequeue();
                if(CurrentNode.Left is null)
                {
                    CurrentNode.Left = NewNode;
                    break;
                }
                else
                {
                    NodesQueue.Enqueue(CurrentNode.Left);
                }

                if(CurrentNode.Right is null)
                {
                    CurrentNode.Right = NewNode;
                    break;
                }
                else
                {
                    NodesQueue.Enqueue(CurrentNode.Right);
                }

            }

        }

        private void Print(BinaryTreeNode<T>TreeNode, int Spaces)
        {
            

            if (TreeNode.Right !=null)
            {
                Print(TreeNode.Right, Spaces + 10);
            }
            Console.WriteLine(" ".PadLeft(Spaces) + TreeNode.Data);
            if (TreeNode.Left != null)
            {
                Print(TreeNode.Left, Spaces + 10);
            }
        } 
        public void Print() => Print(this.Root, 0);

        private void PreOrderTraversal(BinaryTreeNode<T> Node, Action<T> CallBack)
        {
            if (Node == null)
                return;

            CallBack(Node.Data);
            PreOrderTraversal(Node.Left, CallBack);
            PreOrderTraversal(Node.Right, CallBack);
            
        }
        public void PreOrderTraversal(Action<T> CallBack)
        {
            PreOrderTraversal(Root, CallBack);
        }

        private void PostOrderTraversal(BinaryTreeNode<T> Node, Action<T> CallBack)
        {

            if (Node == null)
                return;

           
            PostOrderTraversal(Node.Left, CallBack);
            PostOrderTraversal(Node.Right, CallBack);
            CallBack(Node.Data);

        }
        public void  PostOrderTraversal(Action<T> CallBack)
        {
            PostOrderTraversal(Root, CallBack);
        }

        private void InOrderTraversal(BinaryTreeNode<T> Node, Action<T> CallBack)
        {

            if (Node == null)
                return;


            InOrderTraversal(Node.Left, CallBack);
            CallBack(Node.Data);
            InOrderTraversal(Node.Right, CallBack);

        }
        public void InOrderTraversal(Action<T> CallBack)
        {
            InOrderTraversal(Root, CallBack);
        }






        public void PreOrderWithoutRecursion(Action<T> CallBack)
        {
            Stack<BinaryTreeNode<T>> Nodes = new Stack<BinaryTreeNode<T>>();
            List<T> Values = new List<T>();

            Nodes.Push(Root);

            while(Nodes.Count>0)
            {
                var Current = Nodes.Pop();
                Values.Add(Current.Data);

                if (Current.Right != null)
                {
                    Nodes.Push(Current.Right);
                }
                if (Current.Left!=null)
                {
                    Nodes.Push(Current.Left);
                }             
            }
            foreach (var item in Values)
            {
                CallBack(item);
            }
        }
        public void PostOrderWithoutRecursion(Action<T> CallBack)
        {
            Stack<BinaryTreeNode<T>> Nodes = new Stack<BinaryTreeNode<T>>();
            List<T> Values = new List<T>();

            Nodes.Push(Root);

            while (Nodes.Count > 0)
            {
                var Current = Nodes.Pop();
                Values.Add(Current.Data);

                if (Current.Left != null)
                {
                    Nodes.Push(Current.Left);
                }
                if (Current.Right != null)
                {
                    Nodes.Push(Current.Right);
                }              
            }
            for(int i = Values.Count-1;i>=0;i--)
            {
                CallBack(Values[i]);
            }
        }
        public void InOrderWithoutRecursion(Action<T> CallBack)
        {
            Stack<BinaryTreeNode<T>> Nodes = new Stack<BinaryTreeNode<T>>();

            var current = Root;
            while (Nodes.Count > 0 || current !=null)
            {
                while(current!=null)
                {
                    Nodes.Push(current);
                    current = current.Left;
                }

                current = Nodes.Pop();
                CallBack(current.Data);
                current = current?.Right;            
            }                  
        }
    }


    internal class Program
    {
        static void Main(string[] args)
        {
            BinaryTree<int> binaryTree = new BinaryTree<int>(1);
            binaryTree.Insert(2);
            binaryTree.Insert(3);
            binaryTree.Insert(4);
            binaryTree.Insert(5);
            binaryTree.Insert(6);
            binaryTree.Insert(7);
            binaryTree.Insert(8);
            binaryTree.Insert(9);
            binaryTree.Insert(10);
            binaryTree.Insert(11);
            binaryTree.Insert(12);
            binaryTree.Insert(11);



            binaryTree.Print();


            Console.WriteLine("\nPre Order With Recursion");
            binaryTree.PreOrderTraversal(Value=> Console.Write(Value+" "));

            Console.WriteLine("\nPost Order With Recursion");
            binaryTree.PostOrderTraversal(Value => Console.Write(Value+" "));


            Console.WriteLine("\n In Order With Recursion");
            binaryTree.InOrderTraversal(Value => Console.Write(Value + " "));




            Console.WriteLine("\nPre Order WithOut Recursion");
            binaryTree.PreOrderWithoutRecursion(Value => Console.Write(Value + " "));

            Console.WriteLine("\nPost Order WithOut Recursion");
            binaryTree.PostOrderWithoutRecursion(Value => Console.Write(Value + " "));

            Console.WriteLine("\nIn Order WithOut Recursion");
            binaryTree.InOrderWithoutRecursion(Value => Console.Write(Value + " "));


            //Need the parent first → Pre-order :copy, serialaize
            //Need sorted output → In-order  ,  traverse the sorted tree (log n)
            //Need children first → Post-order  (deleting tree , calculating size  )
        }
    }
}
