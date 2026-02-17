using UnityEngine;
using UnityEngine.AddressableAssets;
using Zenject;
using Cysharp.Threading.Tasks;

public class GameFactory : IGameFactory
{
    private IAssetProvider assetProvider;
    private IConfigProvider configProvider;
    private DiContainer ñontainer;

    public GameFactory(
        IAssetProvider assetProvider,
        IConfigProvider configProvider,
        DiContainer ñontainer)
    {
        this.assetProvider = assetProvider;
        this.configProvider = configProvider;
        this.ñontainer = ñontainer;
    }
    public GameObject HeroObject { get; private set; }

    public async UniTask<GameObject> CreateHeroAsync(Vector3 position, Quaternion rotation)
    {
        HeroObject = await InstantiateAndInject(AssetAddress.HeroAddress);

        HeroObject.transform.position = position;
        HeroObject.transform.rotation = rotation;
        
        return HeroObject;
    }
    private async UniTask<GameObject> InstantiateAndInject(string address)
    {
        GameObject newGameObject = await Addressables.InstantiateAsync(address).ToUniTask();
        ñontainer.InjectGameObject(newGameObject);

		return newGameObject;
    }
}