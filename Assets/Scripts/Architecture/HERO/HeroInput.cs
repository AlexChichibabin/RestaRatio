using UnityEngine;
using Zenject;


public class HeroInput : MonoBehaviour
{
    [SerializeField] private HeroMovement heroMovement;

    private IInputService inputService;

    [Inject]
    public void Construct(IInputService inputService)
    {
        this.inputService = inputService;
    }
    private void Update()
    {
        if (inputService == null) return;
        heroMovement.SetMoveDirection(inputService.MovementAxis);
    }
}