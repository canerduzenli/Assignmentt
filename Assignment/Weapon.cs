namespace ConsoleApp1
{
    public class Weapon
    {
        public string Name { get; set; }
        public int Power { get; set; }

        public Weapon(string name, int power)
        {
            Name = name;
            Power = power;
        }
    }
}

