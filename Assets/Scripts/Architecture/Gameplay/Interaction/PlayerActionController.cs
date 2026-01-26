using UnityEngine;
using Zenject;

public class PlayerActionController : MonoBehaviour
{
	[SerializeField] private HandsInventory handsInventory;
	[SerializeField] private InterationTrigger interractionTrigger;

	private ActionRunner runner;
	//private IActionResolver actionResolver;
	//private IActionServices actionServices;

	//[Inject]
	//public void Construct(
	//	ActionRunner runner/*,
	//	IActionResolver actionResolver*/)
	//{
	//	this.runner = runner;
	//	//this.actionResolver = actionResolver;
	//}

	public void OnInteractDown()
	{
		if (interractionTrigger.Interactable == null) return;

		Debug.Log("Interact!");

		/*var ctx = new ActionContext(
		actor: gameObject,
		inventory: handsInventory as IInventory,
		target: interractionTrigger.Interactable,
		point: handsInventory.transform.position,
		services: actionServices);

		var action = actionResolver.Resolve(ctx);
		if (action == null) return;

		if (action is IHoldAction hold)
			runner.StartHold(ctx, hold);
		else
			runner.Run(ctx, action);*/
	}
}
