using UnityEngine;
using Zenject;

public class InputInteractionTest : MonoBehaviour
{
	private IInputService inputService;
	private IOrderService orderService;

	[Inject]
	public void Construct(IInputService inputService, IOrderService orderService)
	{
		this.inputService = inputService;
		this.inputService.Input.Gameplay.Enable();
		this.orderService = orderService;
	}
	private void OnEnable()
	{
		if (inputService == null) return;

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

	}
	private void GetPress()
	{

	}
}
