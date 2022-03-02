using System;

namespace Assets.Scripts.Data
{
    [Serializable]
    public class LevelProgress
    {
        public int LevelAt;

        public void UnlockNextLevel(int levelIndex)
        {
            if(LevelAt <= levelIndex)
            {
                LevelAt++;
            }
        }   
    }
}
