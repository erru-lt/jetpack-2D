using UnityEngine;

namespace Assets.Scripts.Enemy
{
    [RequireComponent(typeof(Animator))]
    public class EnemyAnimator : MonoBehaviour
    {
        private static readonly int IsAttackingHash = Animator.StringToHash("IsAttacking");

        [SerializeField] private Animator _animator;

        public void PlayIdle() => 
            _animator.SetBool(IsAttackingHash, true);

        public void PlayRun() => 
            _animator.SetBool(IsAttackingHash, false);
    }
}