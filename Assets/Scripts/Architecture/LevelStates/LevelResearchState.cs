using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

public class LevelResearchState : IEnterableState, ITickableState, IExitableState
{
    private IGameFactory gameFactory;
    private ILevelStateSwitcher levelStateSwitcher;
    private IConfigProvider configProvider;

    private LevelConfig levelConfig;

    [Inject]
    public LevelResearchState(IGameFactory gameFactory, 
        ILevelStateSwitcher levelStateSwitcher
        ,IConfigProvider configProvider)
    {
        this.gameFactory = gameFactory;
        this.levelStateSwitcher = levelStateSwitcher;
        this.configProvider = configProvider;
    }

    public void Enter()
    {
        //gameFactory.HeroHealth.Die += OnHeroDie;

        levelConfig = configProvider.GetLevel(SceneManager.GetActiveScene().name);
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