using UnityEngine;
using Zenject;


public class LevelLostState : IEnterableState
{
    private IInputService inputService;

    [Inject]
    public LevelLostState(
        IInputService inputService)
    {
        this.inputService = inputService;
    }

    public void Enter()
    {
        inputService.DisableGameplay();
    }
}