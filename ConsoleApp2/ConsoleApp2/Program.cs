using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Animals;

namespace ConsoleApp2
{
    class Program
    {
        static int currentCatCount = 0;
        static int currentDogCount = 0;

        static List<Cat> cats = new List<Cat>();
        static List<Dog> dogs = new List<Dog>();

        static void Main(string[] args)
        {
            Console.WriteLine("Press Q to exit.");
            Console.WriteLine("Press Space to create some cats and dogs.");

            Random r = new Random();

            while (!(Console.KeyAvailable && Console.ReadKey(true).Key == ConsoleKey.Q))
            {
                if (Console.KeyAvailable && Console.ReadKey(true).Key == ConsoleKey.Spacebar)
                {
                    int count = r.Next(5, 15);
                    for (int i = 0; i < count; i++)
                    {
                        Animal animal;
                        int coinToss = r.Next(2);
                        string id = Guid.NewGuid().ToString();
                        if (coinToss == 0)
                        {
                            animal = new Cat(id);
                            cats.Add((Cat)animal);
                            currentCatCount++;
                        }
                        else
                        {
                            animal = new Dog(id);
                            dogs.Add((Dog)animal);
                            currentDogCount++;
                        }
                    }

                    Console.WriteLine("Created {0} new animals.", count);
                    PrintNrInPopulation();
                }
            }
        }

        static void PrintNrInPopulation()
        {
            Console.WriteLine("There are {0} cats.", currentCatCount);
            Console.WriteLine("=====================================");
            foreach (Cat cat in cats)
                Console.WriteLine(cat.ID);

            Console.WriteLine("=====================================");

            Console.WriteLine("There are {0} dogs.", currentDogCount);
            Console.WriteLine("=====================================");
            foreach (Dog dog in dogs)
                Console.WriteLine(dog.ID);


            Console.WriteLine();
            Console.WriteLine();
        }
    }
}
