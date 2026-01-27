using System;
using UnityEngine;
using UnityEngine.AddressableAssets;
using Zenject;

public class LevelInstaller : MonoInstaller
{
    [SerializeField] private LevelStateMachineTicker levelStateMachineTicker;
    [SerializeField] private GameObject heroPrefab;

    public override void InstallBindings()
    {
        Debug.Log("LEVEL: Install");

        RegisterGameplayServices();

        BindActions();

		RegisterLevelStateMachine();

        Container.Bind<LevelStateMachineTicker>().FromInstance(levelStateMachineTicker).AsSingle();

        Container.Bind<IInitializable>().To<LevelBootstrapper>().AsSingle().NonLazy();

        Container.BindFactory<HeroRoot, HeroRoot.Factory>()
            .FromComponentInNewPrefab(heroPrefab); // Потом надо брать из подгружаемых конфигов
    }
	private void BindActions()
	{
		Container.Bind<ActionTakeFrom>().FromNew().AsSingle();
		Container.Bind<ActionPutDownOn>().FromNew().AsSingle();
		Container.Bind<ActionChop>().FromNew().AsSingle();
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
		Container.Bind<LevelGameplayState>().FromNew().AsSingle();
		Container.Bind<LevelVictoryState>().FromNew().AsSingle();
		Container.Bind<LevelLostState>().FromNew().AsSingle();
    }

    private void UnregisterLevelStateMachine()
    {
        Container.Unbind<ILevelStateSwitcher>();
		Container.Unbind<LevelBootstrappState>();
		Container.Unbind<LevelGameplayState>();
		Container.Unbind<LevelVictoryState>();
		Container.Unbind<LevelLostState>();
    }

    private void RegisterGameplayServices()
    {
        BindOrderService();
        BindOrderGenerator();
        BindGameFactory();
    }
    private void BindOrderService() => 
        Container.Bind<IOrderService>().To<OrderService>().AsSingle();
    private void BindOrderGenerator() => 
        Container.BindInterfacesTo<OrderGenerator>().AsSingle().NonLazy();
    private void BindGameFactory() =>
    Container.Bind<IGameFactory>().To<GameFactory>().AsSingle();

}
