using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    class Program
    {
        static readonly string[] Names = { "Bob", "Alice", "Dave", "Joanna", "Kyle", "Julia", "Corey", "Madison", "Bruce", "Hilary", "Derek", "Justine" };

        static void Main(string[] args)
        {
            Console.WriteLine("Press any key to exit.");
            Random rand = new Random();
            List<Person> people = new List<Person>();
            int numberOfNames = rand.Next(10, 15);
            for (int i = 0; i < numberOfNames; i++)
            {
                Person person = new Person { Name = Names[rand.Next(0, Names.Length)], Age = rand.Next(1, 100) };
                people.Add(person);
                Console.WriteLine("Adding {0} age {1} to the list.", person.Name, person.Age);
            }

            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("===================================================================");

            PrintAscending(people);

            Console.ReadKey();
        }

        static void PrintAscending(ICollection<Person> collection)
        {
            Heap<Person> heap = new Heap<Person>(collection.Count);
            foreach (Person person in collection)
            {
                if (person.Age > 18)
                    heap.Add(person);
            }

            int count = heap.Count;
            for (int i = 0; i < count; i++)
            {
                Person p = heap.RemoveFirstItem();
                Console.WriteLine("{0}. {1}, age {2}", i + 1, p.Name, p.Age);
            }
        }
    }

    public class Person : IHeapItem<Person>
    {
        public string Name { get; set; }

        public int Age { get; set; }

        public int HeapIndex { get; set; }

        public int CompareTo(Person person)
        {
            return this.Age.CompareTo(person.Age) * -1;
        }
    }
}
