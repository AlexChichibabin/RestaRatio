using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;


public interface IAssetProvider
{
    T GetPrefab<T>(string prefabPath) where T : Object;
    T Instantiate<T>(string prefabPath) where T : Object;
    Task<TType> LoadAsync<TType>(AssetReference assetReference) where TType : class;
    void Cleanup();
}