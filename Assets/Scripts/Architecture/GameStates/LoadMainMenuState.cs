using UnityEngine;

public class LoadMainMenuState : IEnterableState
{
    private ISceneLoader sceneLoader;
    //private IWindowProvider windowProvider;
    private IAssetProvider assetProvider;

    public LoadMainMenuState(
        ISceneLoader sceneLoader/*, 
        IWindowProvider windowProvider*/,
        IAssetProvider assetProvider)
    {
        this.sceneLoader = sceneLoader;
        //this.windowProvider = windowProvider;
        this.assetProvider = assetProvider;
    }

    public void Enter()
    {
        //assetProvider.Cleanup();

        //sceneLoader.Load(Constants.MainMenuSceneName, onLoaded: () => windowProvider.Open(WindowId.MainMenuWindow));
        sceneLoader.Load(Constants.MainMenuSceneName, null);
    }
}