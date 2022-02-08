using Assets.Scripts.Data;

namespace Assets.Scripts.Infrastructure.Services.SaveLoadService
{
    public interface ISaveLoadService : IService
    {
        PlayerProgress Load();
        void Save();
    }
}