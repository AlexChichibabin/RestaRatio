using System;
using UnityEngine;
using Zenject;

public class LevelInstaller : MonoInstaller
{
    [SerializeField] private LevelStateMachineTicker levelStateMachineTicker;

    public override void InstallBindings()
    {
        Debug.Log("LEVEL: Install");

		RegisterLevelStateMachine();

        Container.Bind<LevelStateMachineTicker>().FromInstance(levelStateMachineTicker).AsSingle();
        Container.Bind<IInitializable>().To<LevelBootstrapper>().AsSingle().NonLazy();
    }


	private void OnDestroy()
    {
        Container.Unbind<LevelStateMachineTicker>();

        UnregisterLevelStateMachine();
    }


	private void RegisterLevelStateMachine()
    {
        Container.Bind<ILevelStateSwitcher>().To<LevelStateMachine>().AsSingle();
        Container.Bind<LevelBootstrappState>().FromNew().AsSingle();
		Container.Bind<LevelResearchState>().FromNew().AsSingle();
		Container.Bind<LevelVictoryState>().FromNew().AsSingle();
		Container.Bind<LevelLostState>().FromNew().AsSingle();
    }

    private void UnregisterLevelStateMachine()
    {
        Container.Unbind<ILevelStateSwitcher>();
		Container.Unbind<LevelBootstrappState>();
		Container.Unbind<LevelResearchState>();
		Container.Unbind<LevelVictoryState>();
		Container.Unbind<LevelLostState>();
    }
}
