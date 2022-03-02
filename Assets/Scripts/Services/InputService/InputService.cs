namespace Assets.Scripts.Infrastructure.Services.InputService
{
    public class InputService : IInputService
    {
        private const string AttackButton = "Attack";
        private const string JumpButton = "Jump";

        public bool IsAttackButtonUp() =>
            SimpleInput.GetButtonUp(AttackButton);

        public bool IsJumpButtonUp() =>
            SimpleInput.GetButton(JumpButton);
    }
}
