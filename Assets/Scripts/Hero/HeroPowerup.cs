using Assets.Scripts.Data;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Hero
{
    public class HeroPowerup : MonoBehaviour
    {
        private readonly float _powerupTimer = 7.5f;

        private PlayerStats _playerStats;

        public void Construct(PlayerStats playerStats) => 
            _playerStats = playerStats;

        public void SpeedPowerup() => 
            StartCoroutine(IncreaseSpeed());

        public void AddHealth() => 
            _playerStats.ResetHp();

        private IEnumerator IncreaseSpeed()
        {
            _playerStats.IncreaseMoveSpeed();
            yield return new WaitForSeconds(_powerupTimer);
            _playerStats.DecreaseMoveSpeed();
        }
    }
}
