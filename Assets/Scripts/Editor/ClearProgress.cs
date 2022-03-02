using UnityEngine;
using UnityEditor;

namespace Assets.Scripts.Editor
{
    
    public class ClearProgress
    {
        [MenuItem("Tools/ClearPrefs")]
        public static void ClearPrefs()
        {
            PlayerPrefs.DeleteAll();
            PlayerPrefs.Save();
        }
    }
}
