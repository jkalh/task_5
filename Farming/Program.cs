using System;
using System.Collections.Generic;

namespace Farming
{
    // Define the interface
    public interface IFarm
    {
        string Name { get; set; }
        void FeedAnimals();
        void MilkAnimals();
    }

    // Implement the abstract class
    public abstract class LivestockFarm : IFarm
    {
        public string Name { get; set; }
        public int NumberOfAnimals { get; set; }
        public bool HasFeed { get; set; }

        public void FeedAnimals()
        {
            if (HasFeed)
            {
                Console.WriteLine($"Feeding {NumberOfAnimals} animals on {Name}.");
            }
            else
            {
                Console.WriteLine($"No feed available on {Name}.");
            }
        }

        public abstract void MilkAnimals();
        public abstract void BreedAnimals();
    }

    // Implement the DairyFarm class, inheriting from LivestockFarm
    public class DairyFarm : LivestockFarm
    {
        public int MilkProduction { get; set; }
        public bool HasMilkingEquipment { get; set; }

        public override void MilkAnimals()
        {
            if (HasMilkingEquipment)
            {
                Console.WriteLine($"Milking {NumberOfAnimals} animals on {Name}. Total milk production: {MilkProduction} liters.");
            }
            else
            {
                Console.WriteLine($"No milking equipment available on {Name}.");
            }
        }

        public override void BreedAnimals()
        {
            Console.WriteLine($"Breeding animals on {Name}.");
        }
    }

    
    public class Program
    {
        public static void Main()
        {
            // Create a list of IFarm objects
            List<IFarm> farms = new List<IFarm>();

            // Create instances of DairyFarm and add them to the list
            DairyFarm farm1 = new DairyFarm
            {
                Name = "Farm 1",
                NumberOfAnimals = 50,
                HasFeed = true,
                MilkProduction = 100,
                HasMilkingEquipment = true
            };
            farms.Add(farm1);

            DairyFarm farm2 = new DairyFarm
            {
                Name = "Farm 2",
                NumberOfAnimals = 30,
                HasFeed = false,
                MilkProduction = 75,
                HasMilkingEquipment = false
            };
            farms.Add(farm2);

            // Iterate over the farms and perform actions
            foreach (var farm in farms)
            {
                Console.WriteLine($"Farm name: {farm.Name}");
                farm.FeedAnimals();
                farm.MilkAnimals();
                Console.WriteLine();
            }
        }
    }

}
