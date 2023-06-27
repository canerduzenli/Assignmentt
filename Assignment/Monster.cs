using System;

namespace ConsoleApplication
{
    public class Monster
    {
        public string Name { get; set; }
        public int Strength { get; set; }
        public int Defence { get; set; }
        public int OriginalHealth { get; set; }
        public int CurrentHealth { get; set; }

        public Monster(string name, int strength, int defence, int originalHealth)
        {
            Name = name;
            Strength = strength;
            Defence = defence;
            OriginalHealth = originalHealth;
            CurrentHealth = originalHealth;
        }
    }
}
