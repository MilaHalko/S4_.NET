using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Army.Files
{
    class Troop : Unit
    {
        protected List<Unit> units = new List<Unit>();

        public Troop(string name) : base(name)
        { }

        public override void Add(Unit u)
        {
            units.Add(u);
        }

        public override void Remove(Unit u)
        {
            units.Remove(u);
        }

        public override double GetForce()
        {
            double force = 0;
            foreach (Unit u in units)
            {
                force += u.GetForce();
            }
            return force;
        }

        public override double GetSize()
        {
            double size = 0;
            foreach (Unit u in units)
            {
                size += u.GetSize();
            }
            return size;
        }
        public override double GetFoodNeeds()
        {
            double fn = 0;
            foreach (Unit u in units)
            {
                fn += u.GetFoodNeeds();
            }
            return fn;
        }
        public override int GetQuantity()
        {
            int q = 0;
            foreach (var u in units)
            {
                q += u.GetQuantity();
            }
            return q;
        }

        public override void Display()
        {
            Console.WriteLine($"#Troop {name}#");
            foreach (var u in units)
            {
                u.Display();
            }
        }

    }
}
