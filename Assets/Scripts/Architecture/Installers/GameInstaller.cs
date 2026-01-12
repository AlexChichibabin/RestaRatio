using UniRx;
using Zenject;

public class GameInstaller : MonoInstaller
{
	public override void InstallBindings()
	{
		/*BindSceneLoader();
		BindAssetProvider();*/
		//BindCoroutineRunner();
		BindInputService();
	}

	private void BindInputService() =>
		Container.Bind<IInputService>().To<InputService>().AsSingle();

	/*private void BindAssetProvider() =>
		Container.Bind<IAssetProvider>().To<AssetProvider>().AsSingle();

	private void BindSceneLoader()
	{
		Container.Bind<ISceneLoader>().To<SceneLoader>().AsSingle().NonLazy();
	}*/
}
