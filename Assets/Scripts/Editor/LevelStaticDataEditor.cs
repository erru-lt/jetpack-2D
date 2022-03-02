using UnityEngine;
using UnityEditor;
using Assets.Scripts.StaticData.Level;
using Assets.Scripts.GameLogic.Spawner;
using System.Linq;
using Assets.Scripts.StaticData;
using UnityEngine.SceneManagement;
using Assets.Scripts.GameLogic;

namespace Assets.Scripts.Editor
{
    [CustomEditor(typeof(LevelStaticData))]
    public class LevelStaticDataEditor : UnityEditor.Editor
    {

        private const string HeroInitialPointTag = "HeroInitialPoint";
        private const string LevelTransitionPoint = "LevelTransitionPoint";
        private const string CoinTag = "Coin";

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            LevelStaticData levelStaticData = (LevelStaticData) target;

            if(GUILayout.Button("Collect"))
            {
                levelStaticData.Spawners = FindObjectsOfType<SpawnMarker>()
                    .Select(x => new EnemySpawnerStaticData(x.EnemyTypeID, x.transform.position))
                    .ToList();

                levelStaticData.LevelName = SceneManager.GetActiveScene().name;
                levelStaticData.HeroInitialPoint = GameObject.FindGameObjectWithTag(HeroInitialPointTag).transform.position;
                levelStaticData.LevelTransiotionPoint = GameObject.FindGameObjectWithTag(LevelTransitionPoint).transform.position;
                levelStaticData.CoinsPicked = 0;
                levelStaticData.MaxCointAmount = FindObjectsOfType<Coin>().Count();
            }

            EditorUtility.SetDirty(target);
        }
    }
}