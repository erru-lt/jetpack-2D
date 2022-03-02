using Assets.Enemy;
using UnityEngine;

namespace Assets.Scripts.Enemy
{
    [RequireComponent(typeof(EnemyPatrol), typeof(EnemyChase))]
    public class CheckChaseRange : MonoBehaviour
    {
        [SerializeField] private TriggerObserver _triggerObserver;
        [SerializeField] private EnemyPatrol _enemyPatrol;
        [SerializeField] private EnemyChase _enemyChase;

        private void Start()
        {
            _triggerObserver.TriggerEnter += StartChase;
            _triggerObserver.TriggerExit += StopChase;
        }

        private void OnDestroy()
        {
            _triggerObserver.TriggerEnter -= StartChase;
            _triggerObserver.TriggerExit -= StopChase;
        }

        private void StartChase()
        {
            _enemyChase.EnableChase();
            _enemyPatrol.DisablePatrol();
        }

        private void StopChase()
        {
            _enemyChase.DisableChase();
            _enemyPatrol.EnablePatrol();
        }
    }
}
