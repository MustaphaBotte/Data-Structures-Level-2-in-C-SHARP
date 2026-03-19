namespace IComparable
{
    public class Person :IComparable<Person>
    {
        int ID = -1;
        public string Name { get; set; }
        public int Age { get; set; }
        public Person(int iD, string name, int age)
        {
            ID = iD;
            Name = name;
            Age = age;
        }
        public override string ToString()
        {
            return $"ID :{ID} Name :{Name}  Age: {Age}";
        }
        public int CompareTo(Person? other)
        {
            if (other == null) return 1;

            return this.Age.CompareTo(other.Age);

            // 0 Means Equals
            // 1 means This is Bigger than other
            // any valye less than 0 means other is bigger thatb this
        }

    }
       
    internal class Program
    {
        public static void Sort<T>(List<T> list)
        {
            foreach (var item in list)
            {
                if( item is not IComparable<T>)
                {
                    throw new Exception("I comparable not implemented");
                }
                // sort code
            }
        }
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>(5);
            people.Add(new Person(1, "mustapha", 21));
            people.Add(new Person(2, "ahmed", 21));
            people.Add(new Person(2, "karim", 35));
            people.Add(new Person(4, "said", 18));
            people.Add(new Person(5, "mohammed", 30));


            // Sort<Person>(people);
            Sort(people);

            people.Sort();

            foreach (var person in people)
            {
                Console.WriteLine(person);
            }

            IComparable<Person> comparer = new Person(5, "mohammed", 30);
        }
    }
}
