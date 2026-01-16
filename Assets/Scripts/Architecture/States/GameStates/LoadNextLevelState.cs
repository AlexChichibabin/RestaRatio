using UnityEngine;

public class LoadNextLevelState : IEnterableState
{
    private ISceneLoader sceneLoader;
    //private IProgressProvider progressProvider;
    private IConfigProvider configProvider;

    public LoadNextLevelState(
        ISceneLoader sceneLoader,
        IConfigProvider configProvider
        //,IProgressProvider progressProvider
        )
    {
        this.sceneLoader = sceneLoader;
        //this.progressProvider = progressProvider;
        this.configProvider = configProvider;
    }

    public void Enter()
    {
        //         int levelIndex = progressProvider.PlayerProgress.CurrentLevelIndex;
        //         levelIndex = Mathf.Clamp(levelIndex, 0, configProvider.LevelAmount - 1);
        string sceneName = configProvider.GetLevel(0).SceneName;

        sceneLoader.Load(sceneName);
    }
}