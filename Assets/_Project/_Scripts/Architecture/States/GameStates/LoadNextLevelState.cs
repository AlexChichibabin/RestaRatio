public class LoadNextLevelState : IEnterableState
{
    private ISceneLoader sceneLoader;
    private IConfigProvider configProvider;

    public LoadNextLevelState(
        ISceneLoader sceneLoader,
        IConfigProvider configProvider
        )
    {
        this.sceneLoader = sceneLoader;
        this.configProvider = configProvider;
    }

    public void Enter()
    {
        string sceneName = configProvider.GetLevel(0).SceneName;

        sceneLoader.Load(sceneName);
    }
}