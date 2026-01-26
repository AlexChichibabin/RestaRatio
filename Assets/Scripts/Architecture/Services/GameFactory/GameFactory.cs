using UnityEngine;
using UnityEngine.AddressableAssets;
using Zenject;
using Cysharp.Threading.Tasks;

public class GameFactory : IGameFactory
{
    private IAssetProvider assetProvider;
    private IConfigProvider configProvider;
    private DiContainer ñontainer;
    //private IProgressSaver progressSaver;

    public GameFactory(
        IAssetProvider assetProvider,
        IConfigProvider configProvider,
        DiContainer ñontainer/*,
        IProgressSaver progressSaver,
        IProgressProvider progressProvider*/)
    {
        this.assetProvider = assetProvider;
        this.configProvider = configProvider;
        this.ñontainer = ñontainer;
        //this.progressSaver = progressSaver;
    }

    //public VirtualJoystick VirtualJoystick { get; private set; }
    public GameObject HeroObject { get; private set; }
    //public FollowCamera FollowCamera { get; private set; }
    //public HeroHealth HeroHealth { get; private set; }

 //   public async UniTask WarmUpAsync()
 //   {
	//	//EnemyConfig[] enemyConfigs = configProvider.GetAllEnemies();
	//	//for (int i = 0; i < enemyConfigs.Length; i++)
	//	//{
	//	//    await assetProvider.Load<GameObject>(enemyConfigs[i].PrefabReference);
	//	//}

	//	//[] enemyConfigs = configProvider.GetAllEnemies();
	//	//for (int i = 0; i < enemyConfigs.Length; i++)
	//	//{
	//	//	await assetProvider.Load<GameObject>(enemyConfigs[i].PrefabReference);
	//	//}
	//}

    public async UniTask<GameObject> CreateHeroAsync(Vector3 position, Quaternion rotation)
    {
        HeroObject = await InstantiateAndInject(AssetAddress.HeroAddress);

        HeroObject.transform.position = position;
        HeroObject.transform.rotation = rotation;

        //progressSaver.AddObject(HeroObject);
        
        return HeroObject;
    }
    private async UniTask<GameObject> InstantiateAndInject(string address)
    {
        GameObject newGameObject = await Addressables.InstantiateAsync(address).ToUniTask();
        ñontainer.InjectGameObject(newGameObject);

		return newGameObject;
    }
	//public async UniTask<FollowCamera> CreateFollowCameraAsync()
	//{
	//    GameObject followCameraObject = await InstantiateAndInject(AssetAddress.FollowCameraAddress);
	//    FollowCamera = followCameraObject.GetComponent<FollowCamera>();
	//    return FollowCamera;
	//}

	//public async UniTask<VirtualJoystick> CreateVirtualJoystickAsync()
	//{
	//    GameObject virtualJoystickObject = await InstantiateAndInject(AssetAddress.VirtualJoystickAddress);
	//    VirtualJoystick = virtualJoystickObject.GetComponent<VirtualJoystick>();
	//    return VirtualJoystick;
	//}

	//public async UniTask<GameObject> CreateEnemy(EnemyId id, Vector3 position)
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