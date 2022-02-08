using UnityEngine;

namespace Assets.Scripts.Infrastructure.Services.InputService
{
    public class InputService : IInputService
    {
        private const string AttackButton = "Attack";
        private const string JumpButton = "Jump";

        public bool IsAttackButtonUp()
        {
            return SimpleInput.GetButtonUp(AttackButton);
        }

        public bool IsJumpButtonUp()
        {
            return SimpleInput.GetButton(JumpButton);
        }
    }
}
