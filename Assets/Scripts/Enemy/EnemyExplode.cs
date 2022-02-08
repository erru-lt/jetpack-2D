using UnityEngine;

namespace Assets.Scripts.Enemy
{
    public class EnemyExplode : MonoBehaviour
    {
        [SerializeField] private TriggerObserver _triggerObserver;
        private bool _isExploded;

        private void Start() => 
            _triggerObserver.TriggerEnter += Explode;

        private void Explode()
        {
            if (_isExploded) return;

            _isExploded = true;
        }
    }
}
