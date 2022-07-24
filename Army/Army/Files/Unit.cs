using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Army.Files
{
    internal abstract class Unit
    {
        protected string name;

        public Unit(string name)
        {
            this.name = name;
        }
        public abstract void Display();
        public abstract void Add(Unit u);
        public abstract void Remove(Unit u);
        public abstract double GetForce();
        public abstract double GetSize();
        public abstract double GetFoodNeeds();
        public abstract int GetQuantity();
    }
}
