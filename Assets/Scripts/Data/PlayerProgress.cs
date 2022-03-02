using System;

namespace Assets.Scripts.Data
{
    [Serializable]
    public class PlayerProgress
    {
        public LevelProgress LevelProgress;
        public PlayerLoot PlayerLoot;
        public PlayerStats PlayerStats;

        public PlayerProgress()
        {
            LevelProgress = new LevelProgress();
            PlayerLoot = new PlayerLoot();
            PlayerStats = new PlayerStats();
        }
    }
}
