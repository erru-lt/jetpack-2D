using Assets.Scripts.Infrastructure.Services;
using Assets.Scripts.Infrastructure.Services.ProgressService;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.UI.Factory
{
    public interface IUIFactory : IService
    {
        GameObject CreateGameOverWindow();
        GameObject CreateInventoryItem(Transform parent);
        GameObject CreateInventoryWindow();
        GameObject CreateLevelCompletedWindow();
        GameObject CreateLevelStartButton(Vector3 position, Transform parent);
        GameObject CreateMainMenuWindow();
        GameObject CreateSelectLevelWindow();
        void CreateUIRoot();
    }
}