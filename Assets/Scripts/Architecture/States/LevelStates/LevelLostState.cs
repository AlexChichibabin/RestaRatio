using UnityEngine;
using Zenject;


public class LevelLostState : IEnterableState
{
    private IInputService inputService;
    private IGameFactory gameFactory;
    //private IWindowProvider windowProvider;

    [Inject]
    public LevelLostState(IInputService inputService, IGameFactory gameFactory/*,
        IWindowProvider windowProvider*/)
    {
        this.inputService = inputService;
        this.gameFactory = gameFactory;
        /*this.windowProvider = windowProvider*/;
    }

    public void Enter()
    {
        inputService.Enabled = false;
        //gameFactory.VirtualJoystick.gameObject.SetActive(false);

        //windowProvider.Open(WindowId.LoseWindow);
    }
}