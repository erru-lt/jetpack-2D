using Assets.Scripts.Infrastructure.Services;
using UnityEngine;

namespace Assets.Scripts.Infrastructure.AssetManagement
{
    public interface IAssetProvider : IService
    {
        GameObject Instantiate(string path);
        GameObject Instantiate(string path, Transform parent);
        GameObject Instantiate(string path, Vector3 position);
        GameObject Instantiate(string path, Vector3 position, Transform parent);
    }
}