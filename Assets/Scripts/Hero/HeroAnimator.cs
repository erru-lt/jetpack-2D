using UnityEngine;

namespace Assets.Scripts.Hero
{
    [RequireComponent(typeof(Animator))]
    public class HeroAnimator : MonoBehaviour
    {
        private static readonly int IsFlyingHash = Animator.StringToHash("IsFlying");

        private Animator _animator;

        private void Awake() => 
            _animator = GetComponent<Animator>();

        public void PlayFly() => 
            _animator.SetBool(IsFlyingHash, true);

        public void PlayRun() => 
            _animator.SetBool(IsFlyingHash, false);
    }
}
