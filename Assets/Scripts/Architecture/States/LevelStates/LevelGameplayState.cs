using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

public class LevelGameplayState : IEnterableState, ITickableState, IExitableState
{
    private ILevelStateSwitcher levelStateSwitcher;
    private IConfigProvider configProvider;
    private IInputService inputService;

    private LevelConfig levelConfig;

    [Inject]
    public LevelGameplayState(
        ILevelStateSwitcher levelStateSwitcher,
		IInputService inputService,
	    IConfigProvider configProvider)
    {
        this.levelStateSwitcher = levelStateSwitcher;
        this.inputService = inputService;
        this.configProvider = configProvider;
    }

    public void Enter()
    {
        Debug.Log("LEVEL: Gameplay");

        levelConfig = configProvider.GetLevel(SceneManager.GetActiveScene().name);
		
		inputService.EnableGameplay();
	}
    public void Exit() { }

    public void Tick() { }
}