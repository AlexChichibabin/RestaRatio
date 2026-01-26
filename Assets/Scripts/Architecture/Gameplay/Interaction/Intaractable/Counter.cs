using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Counter : StaticInteractable, IInteractable
{
	public bool HasItem => itemPlace.childCount > 0;

	[Inject] PutDownOnCounterAction putDown;
	[Inject] TakeFromCounterAction take;

	public IEnumerable<IGameAction> GetActions(ActionContext ctx)
	{
		yield return putDown;
		yield return take;
		//yield return null;
	}
}
