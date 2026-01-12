using System;
using UnityEngine;
using Zenject;

public class LevelInstaller : MonoInstaller
{
    /*[SerializeField] private LevelStateMachineTicker levelStateMachineTicker;

    public override void InstallBindings()
    {
        Debug.Log("LEVEL: Install");

        dIContainer.RegisterSingle(levelStateMachineTicker);

        RegisterLevelStateMachine();
    }

    private void OnDestroy()
    {
        dIContainer.Unregister<LevelStateMachineTicker>();
        UnregisterLevelStateMachine();
    }

    private void RegisterLevelStateMachine()
    {
        dIContainer.RegisterSingle<ILevelStateSwitcher, LevelStateMachine>();
        dIContainer.RegisterSingle<LevelBootstrappState>();
        dIContainer.RegisterSingle<LevelResearchState>();
        dIContainer.RegisterSingle<LevelVictoryState>();
        dIContainer.RegisterSingle<LevelLostState>();
    }

    private void UnregisterLevelStateMachine()
    {
        dIContainer.Unregister<ILevelStateSwitcher>();
        dIContainer.Unregister<LevelBootstrappState>();
        dIContainer.Unregister<LevelResearchState>();
        dIContainer.Unregister<LevelVictoryState>();
        dIContainer.Unregister<LevelLostState>();
    }*/
}
