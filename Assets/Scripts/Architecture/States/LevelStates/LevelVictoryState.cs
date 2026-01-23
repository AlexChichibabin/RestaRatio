using UnityEngine;
using Zenject;

public class LevelVictoryState : IEnterableState
{
    private IInputService inputService;
    private IGameFactory gameFactory;
    //      private IProgressSaver progressSaver;
    //      private IProgressProvider progressProvider;
    private IWindowProvider windowProvider;

    [Inject]
    public LevelVictoryState(
        IInputService inputService, 
        IGameFactory gameFactory/*, 
        IProgressSaver progressSaver,
        IProgressProvider progressProvider*/,
        IWindowProvider windowProvider)
    {
        this.inputService = inputService;
        this.gameFactory = gameFactory;
        /*this.progressSaver = progressSaver;
        this.progressProvider = progressProvider;*/
        this.windowProvider = windowProvider;
    }

     public void Enter()
     {
        inputService.DisableGameplay();
         //gameFactory.VirtualJoystick.gameObject.SetActive(false);

         //progressProvider.PlayerProgress.HeroStats.Damage += 2;
         //progressProvider.PlayerProgress.HeroStats.MaxHitpoints += 5;
         //progressProvider.PlayerProgress.HeroStats.MovementSpeed += 0.1f;
         //progressProvider.PlayerProgress.CurrentLevelIndex++;

         windowProvider.Open(WindowId.VictoryWindow);

         //progressSaver.SaveProgress();
     }
}