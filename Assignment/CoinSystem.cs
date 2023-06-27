using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment
{
    public class CoinSystem
    {
        private int coins;
        public int Coins { get; set; }

        public CoinSystem()
        {
            coins = 0;

        }
        public void EarnCoins(int amount)
        {
            coins += amount;
        }
        public bool SpendCoins(int amount)
        {
            if (coins >= amount)
            {
                coins -= amount;
                return true;
            }
            return false;
        }
    }
}
