using ConsoleApp1;
using System;

namespace ConsoleApplication
{
    public class Hero
    {
        public string Name { get; set; }
        public int Strength { get; set; }
        public int Defence { get; set; }
        public int MaxHealth { get; set; }
        public int CurrentHealth { get; set; }

        public Weapon EquippedWeapon { get; set; }
        public Armour EquippedArmour { get; set; }

        public Hero()
        {
            Strength = 5;
            Defence = 3;
            MaxHealth = 100;
            CurrentHealth = MaxHealth;
            EquippedArmour = new Armour("Default Armour", 0);
        }

        public void GetStats()
        {
            Console.WriteLine($"Hero's Stats:\nName: {Name}\nStrength: {Strength}\nDefence: {Defence}\nMax Health: {MaxHealth}\nCurrent Health: {CurrentHealth}");
        }

        public void GetInventory()
        {
            Console.WriteLine("Hero's Inventory:");
            Console.WriteLine($"Equipped Weapon: {(EquippedWeapon != null ? EquippedWeapon.Name : "None")}");
            Console.WriteLine($"Equipped Armour: {(EquippedArmour != null ? EquippedArmour.Name : "None")}");
        }

        public void ChangeEquippedWeapon()
        {
            Console.WriteLine("Available Weapons:");
            for (int i = 0; i < Game.Weapons.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {Game.Weapons[i].Name}");
            }

            Console.Write("Enter the number of the weapon: ");
            if (int.TryParse(Console.ReadLine(), out int weaponIndex) && weaponIndex >= 1 && weaponIndex <= Game.Weapons.Count)
            {
                EquippedWeapon = Game.Weapons[weaponIndex - 1];
                Console.WriteLine($"Equipped weapon: {EquippedWeapon.Name}");
            }
            else
            {
                Console.WriteLine("Invalid weapon choice. Please try again.");
            }
        }

        public void ChangeEquippedArmour()
        {
            Console.WriteLine("Available Armours:");
            for (int i = 0; i < Game.Armours.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {Game.Armours[i].Name}");
            }

            Console.Write("Enter the number of the armour: ");
            if (int.TryParse(Console.ReadLine(), out int armourIndex) && armourIndex >= 1 && armourIndex <= Game.Armours.Count)
            {
                EquippedArmour = Game.Armours[armourIndex - 1];
                Console.WriteLine($"Successfully equipped the armour: {EquippedArmour.Name}");
            }
            else
            {
                Console.WriteLine("Invalid armour choice. Please try again.");
            }
        }

    }

}

