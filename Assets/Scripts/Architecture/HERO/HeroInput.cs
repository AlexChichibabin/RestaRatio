using UnityEngine;
using UnityEngine.Windows;
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
	private void OnEnable()
	{
		inputService.Input.Gameplay.Enable();
	}
	private void OnDisable()
	{
		inputService.Input.Gameplay.Disable();
	}
	private void Update()
    {
        if (inputService == null) return;
        heroMovement.SetMoveDirection(inputService.MovementAxis);
    }
}