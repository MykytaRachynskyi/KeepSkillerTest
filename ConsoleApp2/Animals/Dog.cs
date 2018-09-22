using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animals
{
    public class Dog : Animal
    {
        public Dog(string id) : base(id) { }

        public override void Speak()
        {
            Console.WriteLine("Bark");
        }
    }
}
