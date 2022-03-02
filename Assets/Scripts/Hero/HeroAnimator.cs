using UnityEngine;

namespace Assets.Scripts.Hero
{
    [RequireComponent(typeof(Animator))]
    public class HeroAnimator : MonoBehaviour
    {
        private static readonly int IsFlyingHash = Animator.StringToHash("IsFlying");
        private static readonly int IdleHash = Animator.StringToHash("Idle");
        private static readonly int DieHash = Animator.StringToHash("Die"); 

        [SerializeField] private Animator _animator;

        public void PlayDie() => 
            _animator.SetTrigger(DieHash);

        public void PlayFly() => 
            _animator.SetBool(IsFlyingHash, true);

        public void PlayRun() => 
            _animator.SetBool(IsFlyingHash, false);

        public void PlayIdle() => 
            _animator.SetBool(IdleHash, true);
    }
}
