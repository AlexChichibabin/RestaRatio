using System.Collections.Generic;

public class Counter : StaticInteractable
{
	public override IEnumerable<IGameAction> GetActions(ActionContext ctx)
	{
		yield return putDown;
		yield return take;
	}
}
