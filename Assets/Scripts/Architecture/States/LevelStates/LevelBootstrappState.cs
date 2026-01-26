using UnityEngine;
using UnityEngine.SceneManagement;
using Cysharp.Threading.Tasks;
using Zenject;


public class LevelBootstrappState : IEnterableState
{
    private IGameFactory gameFactory;
    private ILevelStateSwitcher levelStateSwitcher;
    private IInputService inputService;
    private IConfigProvider configProvider;
    private HeroRoot.Factory heroFactory;
    //private IProgressSaver progressSaver;

    public LevelBootstrappState(
        IGameFactory gameFactory,  
        ILevelStateSwitcher levelStateSwitcher,
        IInputService inputService,
        IConfigProvider configProvider,
        HeroRoot.Factory heroFactory/*,
        IProgressSaver progressSaver*/)
    {
        this.gameFactory = gameFactory;
        this.levelStateSwitcher = levelStateSwitcher;
        this.inputService = inputService;
        this.configProvider = configProvider;
        this.heroFactory = heroFactory;
        //this.progressSaver = progressSaver;
    }

    public void Enter()
    {
        Debug.Log("LEVEL: Init");

        //progressSaver.ClearObjects();

        //await gameFactory.WarmUp();

        string sceneName = SceneManager.GetActiveScene().name;
        LevelConfig levelConfig = configProvider.GetLevel(sceneName);

        //EnemySpawner[] enemySpawners = Object.FindObjectsByType<EnemySpawner>(FindObjectsSortMode.None);
        //for (int i = 0; i < enemySpawners.Length; i++) enemySpawners[i].Spawn();

        //await gameFactory.CreateHeroAsync(levelConfig.HeroSpawnPoint, Quaternion.identity);
        CreateHero(levelConfig);

        levelStateSwitcher.Enter<LevelGameplayState>();
		//FollowCamera followCamera = await gameFactory.CreateFollowCameraAsync();

		//followCamera.SetTarget(gameFactory.HeroObject.transform);

		//await gameFactory.CreateVirtualJoystickAsync();

		//progressSaver.LoadProgress();

		//inputService.Enabled = true;

		//levelStateSwitcher.Enter<LevelResearchState>();
	}

    private void CreateHero(LevelConfig levelConfig)  // Можно вынести потом из класса
    {
        heroFactory.Create().transform.SetPositionAndRotation(
            levelConfig.HeroSpawnPoint,
            Quaternion.identity);
    }
}