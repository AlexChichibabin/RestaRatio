using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Counter : StaticInteractable
{
	public override IEnumerable<IGameAction> GetActions(ActionContext ctx)
	{
		yield return putDown;
		yield return take;
	}
}
