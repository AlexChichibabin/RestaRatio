using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class CuttingBoard : StaticInteractable//, IInteractable
{
	public bool HasItemToChop => itemContainer.childCount > 0;

	[Inject] ActionChop chopHold;


	public override IEnumerable<IGameAction> GetActions(ActionContext ctx)
	{
		yield return putDown;
		yield return take;
		yield return chopHold;
	}
	public void FinishChop()
	{
		Debug.Log("Блюдо нарезано");
	}
}
