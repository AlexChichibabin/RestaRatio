using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

public class LevelGameplayState : IEnterableState, ITickableState, IExitableState
{
    private IGameFactory gameFactory;
    private ILevelStateSwitcher levelStateSwitcher;
    private IConfigProvider configProvider;
    private IInputService inputService;

    private LevelConfig levelConfig;

    [Inject]
    public LevelGameplayState(IGameFactory gameFactory, 
        ILevelStateSwitcher levelStateSwitcher,
		IInputService inputService,
	    IConfigProvider configProvider)
    {
        this.gameFactory = gameFactory;
        this.levelStateSwitcher = levelStateSwitcher;
        this.inputService = inputService;
        this.configProvider = configProvider;
    }

    public void Enter()
    {
        //gameFactory.HeroHealth.Die += OnHeroDie;
        Debug.Log("LEVEL: Gameplay");

        levelConfig = configProvider.GetLevel(SceneManager.GetActiveScene().name);

        inputService.EnableGameplay();
	}
    public void Exit()
    {
        //gameFactory.HeroHealth.Die -= OnHeroDie;
    }

    public void Tick()
    {
        /*if (Vector3.Distance(gameFactory.HeroObject.transform.position, levelConfig.FinishPoint) < FinishPoint.Radius)
        {
            levelStateSwitcher.Enter<LevelVictoryState>();
        }*/
    }

    /* private void OnHeroDie()
     {
         levelStateSwitcher.Enter<LevelLostState>();
     }*/
}