using UnityEngine;
using Zenject;

public class GameBootstrapper : IInitializable
{
    private IGameStateSwitcher gameStateSwitcher;
    private GameBootstrappState gameBootstrappState;
    private LoadNextLevelState loadNextLevelState;
    private LoadMainMenuState loadMainMenuState;


    public GameBootstrapper(
        IGameStateSwitcher gameStateSwitcher, 
        GameBootstrappState gameBootstrappState, 
        LoadNextLevelState loadNextLevelState,
        LoadMainMenuState loadMainMenuState
        )
    {
        this.gameStateSwitcher = gameStateSwitcher;
        this.gameBootstrappState = gameBootstrappState;
        this.loadNextLevelState = loadNextLevelState;
        this.loadMainMenuState = loadMainMenuState;
    }

    public void Initialize()
    {
        Debug.Log("GLOBAL: Boot");
        InitGameStateMachine();
    }

    private void InitGameStateMachine()
    {
        gameStateSwitcher.AddState(gameBootstrappState);
        gameStateSwitcher.AddState(loadNextLevelState);
        gameStateSwitcher.AddState(loadMainMenuState);

        gameStateSwitcher.Enter<GameBootstrappState>();
    }
}