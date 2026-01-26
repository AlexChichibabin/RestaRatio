using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using Zenject;
using Cysharp.Threading.Tasks;
using UnityEngine.ResourceManagement.AsyncOperations;

public class ActionFactory : IActionFactory
{
  //  private IAssetProvider assetProvider;
  //  private IConfigProvider configProvider;
  //  private DiContainer container;

  //  public ActionFactory(
  //      IAssetProvider assetProvider,
  //      IConfigProvider configProvider,
  //      DiContainer container)
  //  {
  //      this.assetProvider = assetProvider;
  //      this.configProvider = configProvider;
  //      this.container = container;
  //  }

  //  public GameObject HeroObject { get; private set; }


  //  public async UniTask<GameObject> CreateActionRunnerAsync(Vector3 position, Quaternion rotation)
  //  {
  //      HeroObject = await InstantiateAndInject(AssetAddress.HeroAddress);

  //      HeroObject.transform.position = position;
  //      HeroObject.transform.rotation = rotation;

  //      //progressSaver.AddObject(HeroObject);
        
  //      return HeroObject;
  //  }
  //  private async UniTask<GameObject> InstantiateAndInject(string address)
  //  {
  //      GameObject newGameObject = await Addressables.InstantiateAsync(address).Task;
  //      container.InjectGameObject(newGameObject);

		//return newGameObject;
  //  }

}