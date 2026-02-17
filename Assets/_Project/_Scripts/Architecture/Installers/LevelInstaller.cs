using UnityEngine;
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

        Container.Bind<IInitializable>().To<LevelBootstrapper>().AsSingle().NonLazy();

        Container.BindFactory<HeroRoot, HeroRoot.Factory>()
            .FromComponentInNewPrefab(heroPrefab); // Потом надо брать из подгружаемых конфигов
    }


	private void OnDestroy()
    {
        UnregisterLevelStateMachine();
    }


	private void RegisterLevelStateMachine()
    {
        Container.Bind<ILevelStateSwitcher>().To<LevelStateMachine>().AsSingle();
        Container.Bind<LevelBootstrappState>().FromNew().AsSingle();
		Container.Bind<LevelGameplayState>().FromNew().AsSingle();
		Container.Bind<LevelVictoryState>().FromNew().AsSingle();
        Container.Bind<LevelLostState>().FromNew().AsSingle();
        Container.Bind<LevelStateMachineTicker>().FromInstance(levelStateMachineTicker).AsSingle();
    }

    private void UnregisterLevelStateMachine()
    {
        Container.Unbind<ILevelStateSwitcher>();
		Container.Unbind<LevelBootstrappState>();
		Container.Unbind<LevelGameplayState>();
		Container.Unbind<LevelVictoryState>();
		Container.Unbind<LevelLostState>();
        Container.Unbind<LevelStateMachineTicker>();
    }

    private void RegisterGameplayServices()
    {
        Container.Bind<IOrderService>().To<OrderService>().AsSingle();
        Container.BindInterfacesTo<OrderGenerator>().AsSingle().NonLazy();
        Container.Bind<IGameFactory>().To<GameFactory>().AsSingle();
        Container.Bind<IPlateItemViewFactory>().To<PlateItemViewFactory>().AsSingle();
    }
    private void BindActions()
    {
        Container.Bind<ActionTakeFromSlot>().FromNew().AsSingle();
		Container.Bind<ActionTakePortable>().FromNew().AsSingle();
		Container.Bind<ActionPutOnSlot>().FromNew().AsSingle();
        Container.Bind<ActionChop>().FromNew().AsSingle();
        Container.Bind<ActionDrop>().FromNew().AsSingle();
        Container.Bind<ActionRoast>().FromNew().AsSingle();
        Container.Bind<ActionPutInContainer>().FromNew().AsSingle();
		Container.Bind<ActionPutInContainerByView>().FromNew().AsSingle();
	}
}
