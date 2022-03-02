using UnityEngine;

namespace Assets.Scripts.GameLogic
{
    public class FX : MonoBehaviour
    {
        public void SpawnFx(Vector3 position) => 
            Instantiate(gameObject, position, Quaternion.identity);

        private void OnAnimationEnd() => 
            Destroy(gameObject);
    }
}
