using System;

namespace Assets.Scripts.Data
{
    [Serializable]
    public class PlayerLoot
    {
        public event Action Changed;

        public int Coins;
        public int CurrentLevelCoins;

        public void AddCoin()
        {
            Coins++;
            CurrentLevelCoins++;
            Changed?.Invoke();
        }

        public void SubstractCoins(int value)
        {
            Coins -= value;
            Changed?.Invoke();
        }

        public void ResetCurrentLevelCoins() => 
            CurrentLevelCoins = 0;
    }
}
