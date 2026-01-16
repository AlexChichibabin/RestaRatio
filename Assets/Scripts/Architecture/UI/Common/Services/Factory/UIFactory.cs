using System;
using System.Threading.Tasks;
using UnityEngine;
using Zenject;

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
	public async Task WarmUpAsync()
	{
		for (int i = 1; i < Enum.GetNames(typeof(WindowId)).Length; i++)
		{
            await assetProvider.LoadAsync<GameObject>(configProvider.GetWindow((WindowId)i).PrefabReference);
            Debug.Log(configProvider.GetWindow((WindowId)i));
        }
        
        //await assetProvider.Load<GameObject>(configProvider.GetWindow(WindowId.MainMenuWindow).PrefabReference);
        //await assetProvider.Load<GameObject>(configProvider.GetWindow(WindowId.VictoryWindow).PrefabReference);
        //await assetProvider.Load<GameObject>(configProvider.GetWindow(WindowId.LoseWindow).PrefabReference);
    }
	public async Task<LevelResultPresenter> CreateLevelResultWindowAsync(WindowConfig config)
	{
		return await CreateWindowAsync<LevelResultWindow, LevelResultPresenter>(config);
	}
	public async Task<MainMenuPresenter> CreateMainMenuWindowAsync(WindowConfig config)
	{
		return await CreateWindowAsync<MainMenuWindow, MainMenuPresenter>(config);
	}
	public void CreateUIRoot()
	{
		UIRoot = new GameObject(UIRootGameObjectName).transform;
	}
	private async Task<TPresenter> CreateWindowAsync<TWindow, TPresenter>(WindowConfig config) 
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