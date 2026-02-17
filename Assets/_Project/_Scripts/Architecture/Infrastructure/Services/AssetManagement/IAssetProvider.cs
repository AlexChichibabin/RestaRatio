using UnityEngine;
using UnityEngine.AddressableAssets;
using Cysharp.Threading.Tasks;


public interface IAssetProvider
{
    T GetPrefab<T>(string prefabPath) where T : Object;
    T Instantiate<T>(string prefabPath) where T : Object;
    UniTask<TType> LoadAsync<TType>(AssetReference assetReference) where TType : class;
    void Cleanup();
}