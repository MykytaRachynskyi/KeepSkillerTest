using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animals
{
    public abstract class Animal : IAnimal
    {
        public string ID { get; protected set; }

        public Animal(string id)
        {
            this.ID = id;
        }

        public abstract void Speak();
    }
}
