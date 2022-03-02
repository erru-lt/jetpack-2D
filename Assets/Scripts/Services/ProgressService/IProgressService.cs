using Assets.Scripts.Data;

namespace Assets.Scripts.Infrastructure.Services.ProgressService
{
    public interface IProgressService : IService
    {
        PlayerProgress PlayerProgress { get; set; }
    }
}