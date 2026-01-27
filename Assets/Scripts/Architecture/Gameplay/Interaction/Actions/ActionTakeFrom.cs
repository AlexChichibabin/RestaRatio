using UnityEngine;

public class ActionTakeFrom : IGameAction
{
	public string Id => "take_from_counter";

	public int Priority => 50;

	public bool CanExecute(ActionContext ctx)
	{
		return !ctx.Inventory.HasItem
			&& ctx.Target.HasItem
			&& ctx.Target is StaticInteractable
			&& ctx.Button == ButtonId.Button1;

	}


	public void Execute(ActionContext ctx)
	{
		Transform item = ctx.Target.ItemContainer.GetChild(0);
		item.SetParent(ctx.Inventory.ItemContainer, false);
		item.localPosition = Vector3.zero;
	}
}
