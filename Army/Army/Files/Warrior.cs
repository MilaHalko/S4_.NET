using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Army.Files
{
    internal abstract class Warrior : Unit
    {
        protected Warrior(string name) : base(name)
        {
        }

        public override void Display()
        {
            Console.WriteLine($"{GetRace()}: {name}\n" +
                $"\tForce: {GetForce()}\n" +
                $"\tSize: {GetSize()}\n" +
                $"\tFoodNeeds: {GetFoodNeeds()}");
        }
        public override void Add(Unit u)
        {
            throw new NotImplementedException();
        }

        public override void Remove(Unit u)
        {
            throw new NotImplementedException();
        }

        public override int GetQuantity()
        {
            return 1;
        }

        public abstract string GetRace();
    }

    class Elf : Warrior
    {
        public Elf(string name)
            : base(name)
        { }
        public override double GetForce()
        {
            return 50;
        }

        public override double GetSize()
        {
            return 50;
        }

        public override double GetFoodNeeds()
        {
            return 40;
        }

        public override string GetRace()
        {
            return "Elf";
        }
    }

    class Orc : Warrior
    {
        public Orc(string name)
            : base(name)
        { }
        public override double GetForce()
        {
            return 65.7;
        }

        public override double GetSize()
        {
            return 60;
        }

        public override double GetFoodNeeds()
        {
            return 70;
        }

        public override string GetRace()
        {
            return "Orc";
        }
    }

    class Minotaur : Warrior
    {
        public Minotaur(string name)
            : base(name)
        { }
        public override double GetForce()
        {
            return 75;
        }

        public override double GetSize()
        {
            return 61;
        }

        public override double GetFoodNeeds()
        {
            return 60;
        }

        public override string GetRace()
        {
            return "Minotaur";
        }
    }

    class Centaur : Warrior
    {
        public Centaur(string name)
            : base(name)
        { }
        public override double GetForce()
        {
            return 70;
        }

        public override double GetSize()
        {
            return 70;
        }

        public override double GetFoodNeeds()
        {
            return 50;
        }

        public override string GetRace()
        {
            return "Centaur";
        }
    }


    class Cyclops: Warrior
    {
        public Cyclops(string name)
            : base(name)
        { }
        public override double GetForce()
        {
            return 40;
        }

        public override double GetSize()
        {
            return 78;
        }

        public override double GetFoodNeeds()
        {
            return 82;
        }

        public override string GetRace()
        {
            return "Cyclops";
        }
    }

    class Dragon : Warrior
    {
        public Dragon(string name)
            : base(name)
        { }
        public override double GetForce()
        {
            return 100;
        }

        public override double GetSize()
        {
            return 100;
        }

        public override double GetFoodNeeds()
        {
            return 95;
        }

        public override string GetRace()
        {
            return "Dragon";
        }
    }

    class Hydra : Warrior
    {
        public Hydra(string name)
            : base(name)
        { }
        public override double GetForce()
        {
            return 96;
        }

        public override double GetSize()
        {
            return 90;
        }

        public override double GetFoodNeeds()
        {
            return 100;
        }

        public override string GetRace()
        {
            return "Hydra";
        }
    }

    class Knight : Warrior
    {
        public Knight(string name)
            : base(name)
        { }
        public override double GetForce()
        {
            return 30;
        }

        public override double GetSize()
        {
            return 30;
        }

        public override double GetFoodNeeds()
        {
            return 25;
        }

        public override string GetRace()
        {
            return "Knight";
        }
    }

}
