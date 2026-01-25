using System;
using System.Threading.Tasks;
using UnityEngine;
using Zenject;
using Cysharp.Threading.Tasks;

public class UIFactory : IUIFactory
{
	private const string UIRootGameObjectName = "UI Root";
	private DiContainer container;
	private IAssetProvider assetProvider;
	private IConfigProvider configProvider;

	public UIFactory(DiContainer container, 
		IAssetProvider assetProvider, 
		IConfigProvider configProvider)
	{
		this.container = container;
		this.assetProvider = assetProvider;
		this.configProvider = configProvider;
	}

	public Transform UIRoot { get; set; }
	public async UniTask WarmUpAsync()
	{
		for (int i = 1; i < Enum.GetNames(typeof(WindowId)).Length; i++)
            await assetProvider.LoadAsync<GameObject>(configProvider.GetWindow((WindowId)i).PrefabReference);
    }
	public async UniTask<LevelResultPresenter> CreateLevelResultWindowAsync(WindowConfig config)
	{
		return await CreateWindowAsync<LevelResultWindow, LevelResultPresenter>(config);
	}
	public async UniTask<MainMenuPresenter> CreateMainMenuWindowAsync(WindowConfig config)
	{
		return await CreateWindowAsync<MainMenuWindow, MainMenuPresenter>(config);
	}
	public void CreateUIRoot()
	{
		UIRoot = new GameObject(UIRootGameObjectName).transform;
	}
	private async UniTask<TPresenter> CreateWindowAsync<TWindow, TPresenter>(WindowConfig config) 
		where TWindow : WindowBase where TPresenter : WindowPresenterBase<TWindow>
	{
		GameObject prefab = await assetProvider.LoadAsync<GameObject>(config.PrefabReference);
		TWindow window = container.InstantiatePrefab(prefab).GetComponent<TWindow>();
		window.transform.SetParent(UIRoot);
		window.SetTitle(config.Title);

		TPresenter presenter = container.Instantiate<TPresenter>();
		presenter.SetWindow(window);

		return presenter;
	}
}