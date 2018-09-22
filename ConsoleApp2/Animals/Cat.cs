using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animals
{
    public class Cat : Animal
    {
        public Cat(string id) : base(id) { }

        public override void Speak()
        {
            Console.WriteLine("Meow");
        }
    }
}
