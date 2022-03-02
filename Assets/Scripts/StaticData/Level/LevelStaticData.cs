using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.StaticData.Level
{
    [CreateAssetMenu(fileName = "LevelData", menuName = "Static Data/Level")]
    public class LevelStaticData : ScriptableObject
    {
        public string LevelName;

        public int CoinsPicked;
        public int MinCointAmount;
        public int MaxCointAmount;

        public Vector3 HeroInitialPoint;
        public Vector3 LevelTransiotionPoint;

        public List<EnemySpawnerStaticData> Spawners;

        public bool MinimumCoinCollected() =>
            CoinsPicked <= MinCointAmount;

        public bool MediumCoinCollected() =>
            CoinsPicked > MinCointAmount && CoinsPicked <= MaxCointAmount;

        public bool MaximumCointCollected() =>
            CoinsPicked >= MaxCointAmount;

    }
}
