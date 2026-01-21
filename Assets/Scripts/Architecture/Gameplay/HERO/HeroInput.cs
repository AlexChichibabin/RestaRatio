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
		this.inputService.Input.Gameplay.Enable();
	}
    private void OnEnable()
	{
        if(inputService == null) return;

		inputService.Input.Gameplay.Enable();
	}
	private void OnDisable()
	{
		if (inputService == null) return;

		inputService.Input.Gameplay.Disable();
	}
	private void Update()
    {
        if (inputService == null) return;
        heroMovement.SetMoveDirection(inputService.MovementAxis);
    }
}