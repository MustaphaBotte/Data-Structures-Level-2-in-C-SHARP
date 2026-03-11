class Person : IComparable<Person>
{
    public int id;
    public string name = "";
    public Person(int _id, string name)
    {
        this.id = _id;
        this.name = name;
    }
    public int CompareTo(Person? p)
    {
        if(p==null)throw new ArgumentNullException(nameof(p));
        if (p.id > this.id) return -1;
        if (p.id < this.id) return 1;
        return 0;
    }
}
class PersonComparer : IEqualityComparer<Person>
{
    public bool Equals(Person? p1, Person? p2)
    {
        return p2.id == p1.id;
    }
    public int GetHashCode(Person p)
    {
        return this.GetHashCode();
    }
}

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

        private static void Aggregate()
        {
            List<int> my_list = new List<int> { 10, 20, 30, 40, 50 };

            Console.WriteLine("Sum :"+my_list.Sum());
            Console.WriteLine("Average :" + my_list.Average());
            Console.WriteLine("Max :" + my_list.Max());
            Console.WriteLine("Count :" + my_list.Count());

        }

        private static void Filtering()
        {

            List<int> Numbers = new List<int> { 50, 52, 45, 18, 45, 95, 45,100,120,180 };
            Console.WriteLine("numbers that are  >= 100 :"+string.Join(" ", Numbers.Where(current => current >= 100)));
            Console.WriteLine("all even numbers :" + string.Join(" ", Numbers.Where(current => current %2==0)));
            Console.WriteLine("skipping one elemnt each time :" + string.Join(" ", Numbers.Where((current,index) => index%2==1)));

            List<string> names = new List<string> { "ahmed", "amine", "karim", "omar","sami" };
            Console.WriteLine("name with only four chars: "+string.Join(", ",names.Where(name=>name.Length==4)));

            // behind the scenes the linq extention function calls your function for each element, and if you're function returns true,
            // the element pushed to the returned list
        }

        private static void Sorting()
        {
            List<string> names = new List<string> { "ahmed", "amine", "karim", "omar", "sami" };
            List<Person> Persons = new List<Person> { new Person(10,"kaarim"), new Person(2,"monir"), new Person(3,"hamide") }; // require the implementation of
            //Icomparable interface
         
            Persons.Sort();
            Console.WriteLine("Sorted persons by id :");
            Persons.ForEach(person => Console.WriteLine(person.id.ToString()));
            
            Persons.Reverse();
            Console.WriteLine("reverse persons by id :");
            Persons.ForEach(person => Console.WriteLine(person.id.ToString()));



            // or with simple why 
            // Note : the first mothods are mutating the originla list

            Persons = Persons.OrderBy(person => person.name).ToList(); // order by name
            Console.WriteLine("order by name ASC");
            Persons.ForEach(element => Console.WriteLine(element.name.ToString()));


            Persons = Persons.OrderByDescending(Person => Person.name).ToList<Person>(); // order by name
            Console.WriteLine("order by name DESC");
            Persons.ForEach(element => Console.WriteLine(element.name.ToString()));


        }

        private static void MoreFunctions()
        {
            List<string> names = new List<string> { "ahmed", "amine", "karime", "omar", "sami" };
            List<Person> Persons = new List<Person> { new Person(10, "kaarim"), new Person(2, "monir"), new Person(3, "hamide") };
            List<int> Numbers = new List<int> { 50, 52, 45, 18, 45, 95, 45, 100, 120, -180 };

            //Contains function
            Console.WriteLine("is name exists : "+names.Contains("ahmed"));
            Console.WriteLine("Persons contains :"+Persons.Contains(new Person(2, "monir"),new PersonComparer()));
            Console.WriteLine("Numbers contains :" + Numbers.Contains(100));// returns true in the firts occurence

            //exists
            Console.WriteLine("has negative number :"+Numbers.Exists(num=>num<0));
            Console.WriteLine("has name with more than six chars: "+Persons.Exists(person=>person.name.Length>=6));
            Console.WriteLine("has number bigger than 100 :" + Numbers.Exists(delegate(int n){ return n > 100; }));

            //find
            var num = Numbers.Find(num => num == 50);  // return the first occurence
            Console.WriteLine(num);

            var person = Persons.Find(person => person.name.StartsWith("k"));
            Console.WriteLine(person?.id);


            // find all
            var SearchedPersons = Persons.FindAll(p => p.name.Length <= 5); // returns all matched ones as a List
            Console.WriteLine(SearchedPersons.Count());


            // any
            Console.WriteLine(names.Any(name=>name=="ahmed"));





            // NOTE:  use Any()  without condition or the the Count Property dont do this : Count()>0 . because the count() traverse the entire list each time
            //  and any() retun true in the first element and Count uses the cached value
        }

        private static void ListToArray()
        {
            List<string> names = new List<string> { "ahmed", "amine", "karime", "omar", "sami" };
            string[] namesAsArray = names.ToArray();
            Console.WriteLine("as an array "+string.Join(", ",namesAsArray));
            // Note : internally .Net uses Array.copy() so the big(O) is o(n)
            // so be careful my friend 
        }

        private static void ArrayToList()
        {
           
            string[] namesAsArray = { "ahmed", "amine", "karime", "omar", "sami" };
            List<string> namesAsList = new List<string>(namesAsArray);
            Console.WriteLine("as a List " + string.Join(", ", namesAsList));

        }





        static void Main(string[] args)
        {
            // IntroductionToList();
            // InsertingInto_List();       
            // RemoveFromList();
            //Lopping();
            //Aggregate();
            //Filtering();
            //Sorting();
            //MoreFunctions();
            //ListToArray();
            //ArrayToList();
        }

    }
}
