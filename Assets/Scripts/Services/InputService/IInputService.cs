namespace Assets.Scripts.Infrastructure.Services.InputService
{
    public interface IInputService : IService
    {
        bool IsJumpButtonUp();
        bool IsAttackButtonUp();
    }
}
