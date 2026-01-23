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
		//this.inputService.EnableGameplay();
		this.orderService = orderService;
	}
	//private void OnEnable()
	//{
	//	if (inputService == null) return;

	//	inputService.EnableGameplay();
	//}
	//private void OnDisable()
	//{
	//	if (inputService == null) return;

	//	inputService.DisableGameplay();
	//}
	//private void Update()
	//{
	//	if (inputService == null) return;

	//}
	//private void GetPress()
	//{

	//}
}
