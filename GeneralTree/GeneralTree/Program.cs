using System.Text;

namespace GeneralTree
{
    public class TreeNode<T>
    {
        public T Data { set; get; }

        public List<TreeNode<T>> Children { set; get; }

        public TreeNode(T data)
        {
            this.Data = data;
            this.Children = new List<TreeNode<T>>();
        }
        public void AddChild(params TreeNode<T>[] ChildrenParams)
        {
            foreach (var Child in ChildrenParams)
            {
                Children.Add(Child);
            }
        }
    }

    public class Tree<T>
    {
        public TreeNode<T> Root { private set; get; }

        public Tree(TreeNode<T> Root)
        {
            this.Root = Root;
        }
        public void AddChild(params TreeNode<T>[] Children) => Root.AddChild(Children);

        public void PrintFromNode(TreeNode<T> Node, string Indent = "  ")
        {
            Console.WriteLine(Indent + Node.Data);
            foreach (var Child in Node.Children)
            {
                PrintFromNode(Child, Indent+"   ");
            }
        }
        public void Print()
        {
            PrintFromNode(this.Root);
        }

    } 

    public class FolderInfo
    {
        public string FullPath = "";
        public string ShortName = "";

        public FolderInfo(string fullPath, string shortName)
        {
            FullPath = fullPath;
            ShortName = shortName;
        }
        public override string ToString()
        {
            return ShortName;
        }
    }

    public class FileSystemTreeBuilder
    {
        private string _path = "";
        private void LoadDirectoriesToFolderNode(TreeNode<FolderInfo> FolderNode)
        {
            string[] Directories = GetDirectories(FolderNode.Data.FullPath);

            if (Directories.Length == 0) return;

            foreach (var DirectoryPath in Directories)
            {
                var Directory = new FolderInfo(DirectoryPath, DirectoryPath.Split('\\').Last());
                var DirectoryNode = new TreeNode<FolderInfo>(Directory);
                FolderNode.AddChild(DirectoryNode);
                LoadDirectoriesToFolderNode(DirectoryNode);
            }
        }
        private string[] GetDirectories(string Path)
        {
            try
            {
                return Directory.GetDirectories(Path);
            }
            catch
            {
                return Array.Empty<string>();
            }
        }

        public FileSystemTreeBuilder(string Path)
        {
            if (!Directory.Exists(Path))
                throw new DirectoryNotFoundException("Please Check Your Directory Path");

            this._path = Path;
           
        }
        public Tree<FolderInfo> BuildTree()
        {
            DirectoryInfo info = new DirectoryInfo(_path);
            TreeNode<FolderInfo> FolderNode = new TreeNode<FolderInfo>(new FolderInfo(_path,info.Name));
            LoadDirectoriesToFolderNode(FolderNode);
            return new Tree<FolderInfo>(FolderNode);
        }

    }


    internal class Program
    {
        
        static void Main(string[] args)
        {
            #region Organization_hierarchy
            var ExecuterTree = new TreeNode<string>("CEO");
            var TechTree = new TreeNode<string>("CTO");
            var FinanceTree = new TreeNode<string>("CFO");
            var MarketingTree = new TreeNode<string>("CMO");

            var OrganizationTree = new Tree<string>(ExecuterTree);


            ExecuterTree.AddChild(TechTree, FinanceTree, MarketingTree);

            var Accountant = new TreeNode<string>("Accountant");
            var Developer  = new TreeNode<string>("Developer");
            var UiUxDesigner = new TreeNode<string>("UI UX Designer");
            var Marketer = new TreeNode<string>("Social Media Manager");

            TechTree.AddChild(Developer, UiUxDesigner);
            FinanceTree.AddChild(Accountant);
            MarketingTree.AddChild(Marketer);

            Console.WriteLine("================================ Organization hierarchy ================================");
            OrganizationTree.Print();
            #endregion

            // ========================== Example 2 : File System ========================
            string WindowsDirPath = "C:\\Users\\anonymous\\Documents";
            var builder = new FileSystemTreeBuilder(WindowsDirPath);

            Tree<FolderInfo> FileSystem = builder.BuildTree();

            Console.WriteLine("================================ File System  hierarchy ================================");
            FileSystem.Print();

        }
    }
}
