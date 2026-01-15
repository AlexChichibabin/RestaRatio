using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using Zenject;
//using UnityEngine.AddressableAssets;
//using UnityEngine.ResourceManagement.AsyncOperations;

public class GameFactory : IGameFactory
{
    private IAssetProvider assetProvider;
    private IConfigProvider configProvider;
    private DiContainer container;
    //private IProgressSaver progressSaver;

    public GameFactory(
        IAssetProvider assetProvider,
        IConfigProvider configProvider,
        DiContainer container/*,
        IProgressSaver progressSaver,
        IProgressProvider progressProvider*/)
    {
        this.assetProvider = assetProvider;
        this.configProvider = configProvider;
        this.container = container;
        //this.progressSaver = progressSaver;
    }

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
    private async Task<GameObject> InstantiateAndInject(string address)
    {
        GameObject newGameObject = await Addressables.InstantiateAsync(address).Task;
        container.InjectGameObject(newGameObject);
        //Container.InjectToGameObject(newGameObject);

        return newGameObject;
    }
    //public async Task<FollowCamera> CreateFollowCameraAsync()
    //{
    //    GameObject followCameraObject = await InstantiateAndInject(AssetAddress.FollowCameraAddress);
    //    FollowCamera = followCameraObject.GetComponent<FollowCamera>();
    //    return FollowCamera;
    //}

    //public async Task<VirtualJoystick> CreateVirtualJoystickAsync()
    //{
    //    GameObject virtualJoystickObject = await InstantiateAndInject(AssetAddress.VirtualJoystickAddress);
    //    VirtualJoystick = virtualJoystickObject.GetComponent<VirtualJoystick>();
    //    return VirtualJoystick;
    //}

    //public async Task<GameObject> CreateEnemy(EnemyId id, Vector3 position)
    //{
    //    EnemyConfig config = configProvider.GetEnemy(id);

    //    GameObject enemyPrefab = await assetProvider.Load<GameObject>(config.PrefabReference);
    //    GameObject enemy = dIContainer.Instantiate(enemyPrefab);

    //    enemy.transform.position = position;

    //    IEnemyConfigInstaller[] enemyConfigInstallers = enemy.GetComponentsInChildren<IEnemyConfigInstaller>();

    //    for (int i = 0; i < enemyConfigInstallers.Length; i++)
    //    {
    //        enemyConfigInstallers[i].InstallConfig(config);
    //    }

    //    return enemy;
    //}
}