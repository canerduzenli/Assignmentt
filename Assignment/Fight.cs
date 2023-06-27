using System;

namespace ConsoleApplication
{
    public class Fight
    {
        private Hero hero;
        private Monster monster;
        private int gamesPlayed;
        private int fightsWon;
        private int fightsLost;

        public Fight(Hero hero, Monster monster)
        {
            this.hero = hero;
            this.monster = monster;
            gamesPlayed = 0;
            fightsWon = 0;
            fightsLost = 0;
        }

        public void HeroTurn()
        {
            if (hero.EquippedWeapon != null)
            {
                // Hero's attack damage is calculated
                int heroDamage = hero.Strength + hero.EquippedWeapon.Power;
                int monsterDefence = monster.Defence;

                // The actual damage dealt to the Monster is calculated
                int damageDealt = Math.Max(heroDamage - monsterDefence, 0);

                // Monster's current health is reduced by the damage dealt
                monster.CurrentHealth -= damageDealt;

                Console.WriteLine("You attacked the monster and dealt " + damageDealt + " damage!");
            }
            else
            {
                Console.WriteLine("Please equip a weapon before attacking.");
            }
        }



    public void MonsterTurn()
{
    int monsterDamage = monster.Strength - hero.Defence - hero.EquippedArmour.Power;
    monsterDamage = monsterDamage > 0 ? monsterDamage : 0;

    int heroDefence = hero.Defence + hero.EquippedArmour.Power;
    int damageDealt = Math.Max(monsterDamage - heroDefence, 0);

    hero.CurrentHealth -= damageDealt;

    Console.WriteLine("The monster attacked you and dealt " + damageDealt + " damage!");
}


        public bool Win()
        {
            if (monster.CurrentHealth <= 0)
            {
                Console.WriteLine("Congratulations! You defeated the monster named " + monster.Name + "!");
                fightsWon++;
                return true;
            }
            return false;
        }

        public bool Lose()
        {
            if (hero.CurrentHealth <= 0)
            {
                Console.WriteLine("Oh no! You were defeated by the monster named " + monster.Name + "!");
                fightsLost++;
                return true;
            }
            return false;
        }

        public int GetGamesPlayed()
        {
            return gamesPlayed;
        }

        public int GetFightsWon()
        {
            return fightsWon;
        }

        public int GetFightsLost()
        {
            return fightsLost;
        }

        public void IncrementGamesPlayed()
        {
            gamesPlayed++;
        }

        public void DisplayStatistics()
        {
            Console.WriteLine("Game Statistics:");
            Console.WriteLine("Games Played: " + gamesPlayed);
            Console.WriteLine("Fights Won: " + fightsWon);
            Console.WriteLine("Fights Lost: " + fightsLost);
        }
    }
}
