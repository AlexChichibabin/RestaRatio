using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelBootstrappState : IEnterableState
{
    private ILevelStateSwitcher levelStateSwitcher;
    private IConfigProvider configProvider;
    private HeroRoot.Factory heroFactory;

    public LevelBootstrappState( 
        ILevelStateSwitcher levelStateSwitcher,
        IConfigProvider configProvider,
        HeroRoot.Factory heroFactory)
    {
        this.levelStateSwitcher = levelStateSwitcher;
        this.configProvider = configProvider;
        this.heroFactory = heroFactory;
    }

    public void Enter()
    {
        Debug.Log("LEVEL: Init");

        string sceneName = SceneManager.GetActiveScene().name;
        LevelConfig levelConfig = configProvider.GetLevel(sceneName);

        CreateHero(levelConfig);

        levelStateSwitcher.Enter<LevelGameplayState>();
	}

    private void CreateHero(LevelConfig levelConfig)  // Можно вынести потом из класса
    {
        HeroRoot hero = heroFactory.Create();

		if (hero.TryGetComponent<Rigidbody>(out var rb))
		{
			rb.position = levelConfig.HeroSpawnPoint;
			rb.rotation = Quaternion.identity;
		}
		else
		{
			hero.transform.SetPositionAndRotation(levelConfig.HeroSpawnPoint, Quaternion.identity);
		}
	}
}