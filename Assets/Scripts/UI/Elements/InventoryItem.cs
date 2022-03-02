using Assets.Scripts.GameLogic;
using Assets.Scripts.Infrastructure.Services.ProgressService;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI.Elements
{
    public class InventoryItem : MonoBehaviour
    {
        private float _damage;
        private float _speed;
        private Sprite _projectileSprite;

        [SerializeField] private Button _selectButton;
        [SerializeField] private Button _selectedButton;

        [SerializeField] private Image _image;
        [SerializeField] private Image _damageAttributeImage;
        [SerializeField] private Image _speedAttributeImage;

        private IProgressService _progressService;

        public void Construct(IProgressService progressService) => 
            _progressService = progressService;

        public void ItemStats(Sprite projectileSprite, float damage, float speed)
        {
            _projectileSprite = projectileSprite;
            _damage = damage;
            _speed = speed;
        }

        public void Image(Sprite image) =>
            _image.sprite = image;

        public void DamageAttributeImage() =>
            _damageAttributeImage.fillAmount = _damage / Constants.MaxDamage;

        public void SpeedAttributeImage() =>
            _speedAttributeImage.fillAmount = _speed / Constants.MaxSpeed;

        public void SelectButton(InventoryItem item, Action<InventoryItem> action)
        {
            _selectButton.onClick.AddListener(() => action(item));
            _selectButton.onClick.AddListener(() => OnItemSelected());
        }

        public void NotSelected()
        {
            _selectButton.gameObject.SetActive(true);
            _selectedButton.gameObject.SetActive(false);
        }

        private void OnItemSelected()
        {
            _progressService.PlayerProgress.PlayerStats.UpdateAttackStats(_projectileSprite, _damage);
            Selected();
        }

        private void Selected()
        {
            _selectButton.gameObject.SetActive(false);
            _selectedButton.gameObject.SetActive(true);
        }
    }
}
