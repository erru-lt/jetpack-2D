using Assets.Scripts.Data;
using TMPro;
using UnityEngine;

namespace Assets.Scripts.UI.Elements
{
    public class CoinCounter : MonoBehaviour
    {
        [SerializeField] private TMP_Text _coinCounterText;
        private PlayerProgress _playerProgress;

        public void Construct(PlayerProgress playerProgress)
        {
            _playerProgress = playerProgress;
            _playerProgress.PlayerLoot.Changed += UpdateCoinValue;
        }

        private void Start() =>
            UpdateCoinValue();

        private void OnDestroy()
        {
            if (_playerProgress != null)
            {
                _playerProgress.PlayerLoot.Changed -= UpdateCoinValue;
            }
        }

        private void UpdateCoinValue() =>
            _coinCounterText.text = _playerProgress.PlayerLoot.Coins.ToString();
    }
}
