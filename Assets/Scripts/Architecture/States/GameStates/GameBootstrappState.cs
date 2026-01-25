using Cysharp.Threading.Tasks;
using Cysharp.Threading;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.SceneManagement;
using Zenject;

public class GameBootstrappState : IEnterableState          // Сделать еще загрузку сохранений и сервиса покупок/рекламы
{
    private IGameStateSwitcher gameStateSwitcher;
    private IConfigProvider configProvider;
    private IUIFactory uIFactory;

	public GameBootstrappState(
        IGameStateSwitcher gameStateSwitcher, 
        IConfigProvider configProvider,
        IUIFactory uIFactory)
    {
        this.gameStateSwitcher = gameStateSwitcher;
        this.configProvider = configProvider;
        this.uIFactory = uIFactory;
    }

    public void Enter()
    {
		InitAsync().Forget();
	}
    private async UniTaskVoid InitAsync()
    {
		Debug.Log("GLOBAL: Init");

		Application.targetFrameRate = (int)Screen.currentResolution.refreshRateRatio.numerator;

		// Дожидаюсь Addressables
		await Addressables.InitializeAsync().ToUniTask();

		// Подгружаю конфиги
		configProvider.Load();

		// Прогреваю UI
		await uIFactory.WarmUpAsync();

		// Когда все загрузидось загружаю сцену
		var sceneName = SceneManager.GetActiveScene().name;
		if (sceneName == Constants.BootstrappSceneName || sceneName == Constants.MainMenuSceneName)
			gameStateSwitcher.Enter<LoadMainMenuState>();
	}
}