using Assignment;
using ConsoleApp1;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace ConsoleApplication
{
    public class Game
    {
        private Hero hero;
        private List<Monster> monsters;
        private List<Monster> defeatedMonsters;
        private Fight fight;
        private int gamesPlayed;
        private int fightsWon;
        private int fightsLost;
        private CoinSystem coinSystem;

        public static List<Weapon> Weapons { get; set; }
        public static List<Armour> Armours { get; set; }

        public Game()
        {
            hero = new Hero();
            monsters = new List<Monster>();
            defeatedMonsters = new List<Monster>();
            Weapons = new List<Weapon>();
            Armours = new List<Armour>();
            coinSystem = new CoinSystem();

            InitializeWeapons();
            InitializeArmours();
            InitializeMonsters();
        }

        private void InitializeWeapons()
        {
            Weapons.Add(new Weapon("Sword", 10));
            Weapons.Add(new Weapon("Bow", 8));
            Weapons.Add(new Weapon("Axe", 12));
        }

        private void InitializeArmours()
        {
            Armours.Add(new Armour("Helmet", 5));
            Armours.Add(new Armour("Chestplate", 8));
            Armours.Add(new Armour("Leggings", 6));
        }

        private void InitializeMonsters()
        {
            monsters.Add(new Monster("Monster 1", 20, 5, 50));
      
        }

        public void Start()
        {
            Console.Write("Enter your name: ");
            string playerName = Console.ReadLine();
            hero.Name = playerName;

            while (true)
            {
                DisplayMainMenu();
                Console.Write("Enter your choice: ");
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        hero.GetStats();
                        DisplayGameStatistics();
                        break;

                    case "2":
                        DisplayInventoryMenu();
                        break;

                    case "3":
                        StartFight();
                        break;

                    case "4":
                        return;

                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        private void DisplayMainMenu()
        {
            Console.WriteLine("Main Menu");
            Console.WriteLine("1. Display Statistics");
            Console.WriteLine("2. Display Inventory");
            Console.WriteLine("3. Fight Monster");
            Console.WriteLine("4. Quit");
        }

        private void DisplayInventoryMenu()
        {
            while (true)
            {
                Console.WriteLine("Inventory Menu");
                Console.WriteLine("1. Show Equipped Weapon");
                Console.WriteLine("2. Show Equipped Armour");
                Console.WriteLine("3. Change Equipped Weapon");
                Console.WriteLine("4. Change Equipped Armour");
                Console.WriteLine("5. Increase Base Strength (Cost: 5 coins)");
                Console.WriteLine("6. Increase Base Defence (Cost: 5 coins)");
                Console.WriteLine("7. Increase Current Health (Cost: 10 coins)");
                Console.WriteLine("8. Go back to Main Menu");

                Console.Write("Enter your choice: ");
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        hero.GetInventory();
                        break;

                    case "2":
                        hero.GetInventory();
                        break;

                    case "3":
                        hero.ChangeEquippedWeapon();
                        break;

                    case "4":
                        hero.ChangeEquippedArmour();
                        break;

                    case "5":
                        if (coinSystem.SpendCoins(5))
                        {
                            hero.Strength += 2; // Increase base strength by 2
                            Console.WriteLine("Base Strength increased by 2!");
                        }
                        else
                        {
                            Console.WriteLine("Insufficient coins.");
                        }
                        break;

                    case "6":
                        if (coinSystem.SpendCoins(5))
                        {
                            hero.Defence += 2; 
                            Console.WriteLine("Base Defence increased by 2!");
                        }
                        else
                        {
                            Console.WriteLine("not enough; coins.");
                        }
                        break;

                    case "7":
                        if (coinSystem.SpendCoins(10))
                        {
                            hero.CurrentHealth += 20; 
                            Console.WriteLine("Current Health increased by 20!");
                        }
                        else
                        {
                            Console.WriteLine("not enough; coins");
                        }
                        break;

                    case "8":
                        return;

                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        private void StartFight()
        {
            if (monsters.Count == 0)
            {
                Console.WriteLine("No monsters available to fight.");
                return;
            }


            Random random = new Random();
            int monsterIndex = random.Next(0, monsters.Count);
            var selectedMonster = monsters[monsterIndex];
        
        
            fight = new Fight(hero, selectedMonster);
            PerformFight(fight);

            if (fight.Win())
            {
                monsters.Remove(selectedMonster);
                defeatedMonsters.Add(selectedMonster);
                coinSystem.EarnCoins(10);
            }
            else if (fight.Lose())
            {
                hero.CurrentHealth = hero.MaxHealth; // Reset the hero's current health to the maximum health
                Console.WriteLine("Your health has been restored.");
            }
        }




        private void PerformFight(Fight fight)
        {
            gamesPlayed++;
            while (true)
            {
                fight.HeroTurn();
                fight.MonsterTurn();

                if (fight.Win())
                {
                    fightsWon++;
                    RestartGame();
                    return;
                }

                if (fight.Lose())
                {
                    fightsLost++;
                    RestartGame();
                    return;
                }
            }
        }

        public void RestartGame()
        {
            hero = new Hero();
            monsters = new List<Monster>();
            defeatedMonsters = new List<Monster>();
            Weapons = new List<Weapon>();
            Armours = new List<Armour>();

            InitializeWeapons();
            InitializeArmours();
            InitializeMonsters();
        }


         private void DisplayGameStatistics()
    {
        Console.WriteLine("Game Statistics:");
        Console.WriteLine("Number of games played: " + gamesPlayed);
        Console.WriteLine("Number of fights won: " + fightsWon);
        Console.WriteLine("Number of fights lost: " + fightsLost);
    }
     

    }

}
