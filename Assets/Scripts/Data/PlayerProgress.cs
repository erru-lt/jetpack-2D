using System;

namespace Assets.Scripts.Data
{
    [Serializable]
    public class PlayerProgress
    {
        public LevelProgress LevelProgress;
        
        public PlayerProgress()
        {
            LevelProgress = new LevelProgress();
        }
    }
}
