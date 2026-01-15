using System;
using UniRx;
using Zenject;

public class GameInstaller : MonoInstaller
{
	public override void InstallBindings()
	{
		RegisterGameServices();

		RegisterGameStateMachine();
	}

	private void RegisterGameServices()
	{
		BindSceneLoader();
		BindAssetProvider();
		BindCoroutineRunner();

		BindInputService();
		BindInputSystem();
		BindGameFactory();
	}

	private void RegisterGameStateMachine()
	{
		Container.Bind<IGameStateSwitcher>().To<GameStateMachine>().AsSingle();
		Container.Bind<GameBootstrappState>().FromNew().AsSingle();
		Container.Bind<LoadNextLevelState>().FromNew().AsSingle();
		Container.Bind<LoadMainMenuState>().FromNew().AsSingle();
	}

	private void BindInputSystem() =>
		Container.Bind<PlayerInputActions>().FromNew().AsSingle();
	private void BindInputService() =>
		Container.Bind<IInputService>().To<InputService>().AsSingle();
	private void BindGameFactory() =>
		Container.Bind<IGameFactory>().To<GameFactory>().AsSingle();
	private void BindSceneLoader() =>
		Container.Bind<ISceneLoader>().To<SceneLoader>().AsSingle();
	private void BindAssetProvider() =>
		Container.Bind<IAssetProvider>().To<AssetProvider>().AsSingle();
	private void BindCoroutineRunner() =>
		Container.Bind<ICoroutineRunner>().To<CoroutineRunner>().AsSingle();
}
