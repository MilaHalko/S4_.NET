using System;
using System.Collections.Generic;
using Army.Files;

namespace Army
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Unit army = new Troop("TES-Army");
            army.Add(new Dragon("Alduin"));

            Unit dragonUnion = new Troop("Union of young dragons");
            dragonUnion.Add(new Dragon("Mirmulnir"));
            dragonUnion.Add(new Dragon("Reloniliv"));
            dragonUnion.Add(new Dragon("Vulthuryol"));

            var knight = new Knight("Sir Davion");
            dragonUnion.Add(knight);
            dragonUnion.Remove(knight);

            army.Add(dragonUnion);

            Unit mainForces = new Troop("Mixed powers");
            Unit monsters = new Troop("Monsters");
            Unit hybrids = new Troop("Hybrids");
            Unit people = new Troop("People");

            army.Add(mainForces);
            mainForces.Add(monsters);
            mainForces.Add(hybrids);
            mainForces.Add(people);

            monsters.Add(new Hydra("Frost Hydra"));
            monsters.Add(new Dragon("Tiny Fear"));

            hybrids.Add(new Cyclops("Two Eyed John"));
            hybrids.Add(new Minotaur("Calm Todd"));
            hybrids.Add(new Centaur("Pole Da Nce"));
            hybrids.Add(new Orc("Ooohrr"));
            hybrids.Add(new Elf("Thranduil"));

            people.Add(knight);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("// *MONSTERS*");

            Console.ForegroundColor = ConsoleColor.White;
            monsters.Display();
            Console.WriteLine($"Force of monsters: {monsters.GetForce()}");
            Console.WriteLine("--------------------------");


            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("// *HYBRIDS*");

            Console.ForegroundColor = ConsoleColor.White;
            hybrids.Display();
            Console.WriteLine($"Hybrids' FoodNeeds: {hybrids.GetFoodNeeds()}");
            Console.WriteLine("--------------------------");


            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("// *ARMY*");

            Console.ForegroundColor = ConsoleColor.White;
            army.Display();
            Console.WriteLine($"Quantity of Army units: {army.GetQuantity()}");
            Console.WriteLine($"Space by Army: {army.GetSize()}");
            Console.WriteLine("--------------------------");

            Console.ReadLine();

        }
    }
}

