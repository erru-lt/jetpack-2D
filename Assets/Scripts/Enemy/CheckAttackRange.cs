using Assets.Enemy;
using UnityEngine;

namespace Assets.Scripts.Enemy
{
    [RequireComponent(typeof(EnemyShoot), typeof(EnemyPatrol))]
    public class CheckAttackRange : MonoBehaviour
    {
        [SerializeField] private TriggerObserver _triggerObserver;
        [SerializeField] private EnemyShoot _enemyAttack;
        [SerializeField] private EnemyPatrol _enemyPatrol;

        private void Start()
        {
            _triggerObserver.TriggerEnter += StartAttack;
            _triggerObserver.TriggerExit += StopAttack;
        }

        private void StartAttack()
        {
            _enemyAttack.EnableShoot();
            _enemyPatrol.DisablePatrol();
        }

        private void StopAttack()
        {
            _enemyAttack.DisableShoot();
            _enemyPatrol.EnablePatrol();
        }
    }
}