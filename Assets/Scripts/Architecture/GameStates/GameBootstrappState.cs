using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.SceneManagement;
using Zenject;

public class GameBootstrappState : IEnterableState
{
    private IGameStateSwitcher gameStateSwitcher;
    private IConfigProvider configProvider;
    //private IProgressSaver progressSaver;
    //private IUIFactory uIFactory;
    //private IAdsService adsService;

    public GameBootstrappState(
        IGameStateSwitcher gameStateSwitcher, 
        IConfigProvider configProvider/*,
        IProgressSaver progressSaver,
        IUIFactory uIFactory,
        IAdsService adsService*/)
    {
        this.gameStateSwitcher = gameStateSwitcher;
        this.configProvider = configProvider;
        //this.progressSaver = progressSaver;
        //this.uIFactory = uIFactory;
        //this.adsService = adsService;
    }

    public void Enter()
    {
        Debug.Log("GLOBAL: Init");
        // Подключение к серверу
        // Подгрузка конфигов

        //uIFactory.WarmUp();

        //progressSaver.LoadProgress();

        configProvider.Load();

        //adsService.Initialize();
        //adsService.LoadInterstitial();
        //adsService.LoadRewarded();

        Application.targetFrameRate = (int)Screen.currentResolution.refreshRateRatio.numerator;

        //Addressables.InitializeAsync();

        if (SceneManager.GetActiveScene().name == Constants.BootstrappSceneName ||
            SceneManager.GetActiveScene().name == Constants.MainMenuSceneName)
        {
            gameStateSwitcher.Enter<LoadMainMenuState>();
        }
    }
}