//using CodeBase.Config;
//using CodeBase.Gameplay;
//using CodeBase.Gameplay.Enemy;
//using CodeBase.Gameplay.Hero;
//using CodeBase.Infrastructure.AssetManagement;
//using CodeBase.Infrastructure.DependencyInjection;
//using CodeBase.Infrastructure.Services.ConfigProvider;
//using CodeBase.Infrastructure.Services.PlayerProgressProvider;
//using CodeBase.Infrastructure.Services.PlayerProgressSaver;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using Zenject;
//using UnityEngine.AddressableAssets;
//using UnityEngine.ResourceManagement.AsyncOperations;

public class GameFactory : IGameFactory
{
    //private IAssetProvider assetProvider;
    //private DIContainer dIContainer;
    //private IConfigProvider configProvider;
    //private IProgressSaver progressSaver;

    /*public GameFactory(
        IAssetProvider assetProvider,
        DIContainer dIContainer,
        IConfigProvider configProvider,
        IProgressSaver progressSaver,
        IProgressProvider progressProvider)
    {
        this.assetProvider = assetProvider;
        this.dIContainer = dIContainer;
        this.configProvider = configProvider;
        this.progressSaver = progressSaver;
    }*/

    //public VirtualJoystick VirtualJoystick { get; private set; }
    public GameObject HeroObject { get; private set; }
    //public FollowCamera FollowCamera { get; private set; }
    //public HeroHealth HeroHealth { get; private set; }

    //public async Task WarmUp()
    //{
    //    EnemyConfig[] enemyConfigs = configProvider.GetAllEnemies();

    //    for (int i = 0; i < enemyConfigs.Length; i++)
    //    {
    //        await assetProvider.Load<GameObject>(enemyConfigs[i].PrefabReference);
    //    }
    //}

    public async Task<GameObject> CreateHeroAsync(Vector3 position, Quaternion rotation)
    {
        HeroObject = await InstantiateAndInject(AssetAddress.HeroAddress);

        HeroObject.transform.position = position;
        HeroObject.transform.rotation = rotation;

        //HeroHealth = HeroObject.GetComponent<HeroHealth>();

        //progressSaver.AddObject(HeroObject);
        
        return HeroObject;
    }

    //public async Task<FollowCamera> CreateFollowCameraAsync()
    //{
    //    GameObject followCameraObject = await InstantiateAndInject(AssetAddress.FollowCameraAddress);
    //    FollowCamera = followCameraObject.GetComponent<FollowCamera>();
    //    return FollowCamera;
    //}

    /*public async Task<VirtualJoystick> CreateVirtualJoystickAsync()
    {
        GameObject virtualJoystickObject = await InstantiateAndInject(AssetAddress.VirtualJoystickAddress);
        VirtualJoystick = virtualJoystickObject.GetComponent<VirtualJoystick>();
        return VirtualJoystick;
    }*/
    /*public async Task<GameObject> CreateEnemy(EnemyId id, Vector3 position)
    {
        EnemyConfig config = configProvider.GetEnemy(id);

        GameObject enemyPrefab = await assetProvider.Load<GameObject>(config.PrefabReference);
        GameObject enemy = dIContainer.Instantiate(enemyPrefab);

        enemy.transform.position = position;

        IEnemyConfigInstaller[] enemyConfigInstallers = enemy.GetComponentsInChildren<IEnemyConfigInstaller>();

        for (int i = 0; i < enemyConfigInstallers.Length; i++)
        {
            enemyConfigInstallers[i].InstallConfig(config);
        }

        return enemy;
    }*/
   private async Task<GameObject> InstantiateAndInject(string address)
    {
        GameObject newGameObject = await Addressables.InstantiateAsync(address).Task;
        //dIContainer.InjectToGameObject(newGameObject);

        return newGameObject;
    }
}