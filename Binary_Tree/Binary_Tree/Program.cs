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
            binaryTree.Print();






        }
    }
}
