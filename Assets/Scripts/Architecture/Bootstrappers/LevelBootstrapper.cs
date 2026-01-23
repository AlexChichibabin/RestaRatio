using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

public class LevelBootstrapper : IInitializable
{
    private ILevelStateSwitcher levelStateSwitcher;
    private LevelBootstrappState levelBootstrappState;
    private LevelGameplayState levelResearchState;
    private LevelVictoryState levelVictoryState;
    private LevelLostState levelLostState;

    public LevelBootstrapper(
        ILevelStateSwitcher levelStateSwitcher,
        LevelBootstrappState levelBootstrappState,
        LevelGameplayState levelResearchState,
        LevelVictoryState levelVictoryState,
        LevelLostState levelLostState
        )
    {
        this.levelStateSwitcher = levelStateSwitcher;
        this.levelBootstrappState = levelBootstrappState;
        this.levelResearchState = levelResearchState;
        this.levelVictoryState = levelVictoryState;
        this.levelLostState = levelLostState;
    }

    public void Initialize()
    {
        Debug.Log("LEVEL: Boot");
        InitLevelStateMachine();
    }

    private void InitLevelStateMachine()
    {
        levelStateSwitcher.AddState(levelBootstrappState);
        levelStateSwitcher.AddState(levelResearchState);
        levelStateSwitcher.AddState(levelVictoryState);
        levelStateSwitcher.AddState(levelLostState);

        levelStateSwitcher.Enter<LevelBootstrappState>();
    }
}