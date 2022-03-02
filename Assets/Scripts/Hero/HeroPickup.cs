using Assets.Scripts.Infrastructure.Services.ProgressService;
using UnityEngine;

namespace Assets.Scripts.Hero
{
    public class HeroPickup : MonoBehaviour
    {
        private IProgressService _progressService;

        public void Construct(IProgressService progressService) => 
            _progressService = progressService;

        public void Pickup() => 
            _progressService.PlayerProgress.PlayerLoot.AddCoin();
    }
}
