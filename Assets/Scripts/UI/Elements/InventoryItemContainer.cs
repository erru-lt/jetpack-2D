using Assets.Scripts.Infrastructure.Services.ProgressService;
using Assets.Scripts.StaticData.Projectile;
using Assets.Scripts.UI.Factory;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.UI.Elements
{
    public class InventoryItemContainer : MonoBehaviour
    {
        [SerializeField] private ProjectileListStaticData _projectilesList;
        private readonly List<InventoryItem> _inventoryItems = new List<InventoryItem>();

        private IUIFactory _uiFactory;
        private IProgressService _progressService;

        private InventoryItem _activeItem;

        public void Construct(IUIFactory uiFactory, IProgressService progressService)
        {
            _uiFactory = uiFactory;
            _progressService = progressService;
        }

        private void Start()
        {
            InitalizeInventoryItem();
            SelectItem();
        }

        private void InitalizeInventoryItem()
        {
            foreach (ProjectileStaticData item in _projectilesList.Projectiles)
            {
                GameObject gameObject = _uiFactory.CreateInventoryItem(transform);
                InventoryItem inventoryItem = gameObject.GetComponent<InventoryItem>();

                inventoryItem = CreateInventoryItem(item, inventoryItem);

                _inventoryItems.Add(inventoryItem);
            }
        }

        private InventoryItem CreateInventoryItem(ProjectileStaticData item, InventoryItem inventoryItem)
        {
            inventoryItem.Construct(_progressService);
            inventoryItem.ItemStats(item.ProjectileSprite, item.Damage, item.Speed);

            inventoryItem.Image(item.UIProjectileImage);
            inventoryItem.DamageAttributeImage();
            inventoryItem.SpeedAttributeImage();

            return inventoryItem;
        }

        private void SelectItem()
        {
            foreach (InventoryItem inventoryItem in _inventoryItems)
            {
                inventoryItem.SelectButton(inventoryItem, ActiveItem);
            }
        }

        private void ActiveItem(InventoryItem item)
        {
            _activeItem = item;

            DeactivateRestItems();
        }

        private void DeactivateRestItems()
        {
            foreach (InventoryItem inventoryItem in _inventoryItems)
            {
                if (inventoryItem != _activeItem)
                {
                    inventoryItem.NotSelected();
                }
            }
        }
    }
}
