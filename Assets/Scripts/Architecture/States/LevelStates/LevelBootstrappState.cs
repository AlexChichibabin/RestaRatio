using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;


public class LevelBootstrappState : IEnterableState
{
    private IGameFactory gameFactory;
    private ILevelStateSwitcher levelStateSwitcher;
    private IInputService inputService;
    private IConfigProvider configProvider;
    //private IProgressSaver progressSaver;

    public LevelBootstrappState(
        IGameFactory gameFactory,  
        ILevelStateSwitcher levelStateSwitcher,
        IInputService inputService,
        IConfigProvider configProvider/*,
        IProgressSaver progressSaver*/)
    {
        this.gameFactory = gameFactory;
        this.levelStateSwitcher = levelStateSwitcher;
        this.inputService = inputService;
        this.configProvider = configProvider;
        //this.progressSaver = progressSaver;
    }

    public async void Enter()
    {
        Debug.Log("LEVEL: Init");

        //progressSaver.ClearObjects();

        //await gameFactory.WarmUp();

        string sceneName = SceneManager.GetActiveScene().name;
        LevelConfig levelConfig = configProvider.GetLevel(sceneName);

        //EnemySpawner[] enemySpawners = Object.FindObjectsByType<EnemySpawner>(FindObjectsSortMode.None);
        //for (int i = 0; i < enemySpawners.Length; i++) enemySpawners[i].Spawn();

        await gameFactory.CreateHeroAsync(levelConfig.HeroSpawnPoint, Quaternion.identity);

        levelStateSwitcher.Enter<LevelGameplayState>();
		//FollowCamera followCamera = await gameFactory.CreateFollowCameraAsync();

		//followCamera.SetTarget(gameFactory.HeroObject.transform);

		//await gameFactory.CreateVirtualJoystickAsync();

		//progressSaver.LoadProgress();

		//inputService.Enabled = true;

		//levelStateSwitcher.Enter<LevelResearchState>();
	}
}