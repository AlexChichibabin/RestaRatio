using UnityEngine;

public class TakeFromCounterAction : IGameAction
{
	public string Id => "take_from_counter";

	public int Priority => 50;

	public bool CanExecute(ActionContext ctx)
		=> !ctx.Inventory.HasItem && ctx.Target is StaticInteractable && ctx.Target.HasItem;

	public void Execute(ActionContext ctx)
	{
		throw new System.NotImplementedException();
	}
}
