using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class CuttingBoard : StaticInteractable, IInteractable
{
	public bool HasItem => itemPlace.childCount > 0;
	public bool HasItemToChop => itemPlace.childCount > 0;

	//[Inject] PutDownOnCounterAction putDown;
	//[Inject] TakeFromCounterAction take;
	//[Inject] ChopHoldAction chopHold;


	public IEnumerable<IGameAction> GetActions(ActionContext ctx)
	{
		//yield return putDown;
		//yield return take;
		//yield return chopHold;
		yield return null;
	}
	public void FinishChop()
	{

	}
}
