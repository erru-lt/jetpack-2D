using UnityEngine;

namespace Assets.Scripts.Enemy
{
    public class EnemyAnimator : MonoBehaviour
    {
        private static readonly int IsAttackingHash = Animator.StringToHash("IsAttacking");

        private Animator _animator;

        private void Awake() => 
            _animator = GetComponent<Animator>();

        public void PlayIdle() => 
            _animator.SetBool(IsAttackingHash, true);

        public void PlayRun() => 
            _animator.SetBool(IsAttackingHash, false);
    }
}