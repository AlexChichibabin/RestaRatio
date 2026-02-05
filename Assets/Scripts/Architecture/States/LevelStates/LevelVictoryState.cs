using Zenject;

public class LevelVictoryState : IEnterableState
{
    private IInputService inputService;
    private IWindowProvider windowProvider;

    [Inject]
    public LevelVictoryState(
        IInputService inputService, 
        IWindowProvider windowProvider)
    {
        this.inputService = inputService;
        this.windowProvider = windowProvider;
    }

     public void Enter()
     {
         inputService.DisableGameplay();

         windowProvider.Open(WindowId.VictoryWindow);
     }
}