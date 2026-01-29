using UnityEngine;

public class ActionDrop : IGameAction
{
	public string Id => "drop";

	public int Priority => 20;

	public bool CanExecute(ActionContext ctx)
	{
		return ctx.Inventory.HasItem
			
			&& ctx.Target  == null
			&& ctx.Button == ButtonId.Button1;
	}

	public void Execute(ActionContext ctx)
	{
		var item = ctx.Inventory.ItemContainer.GetChild(0);
		if (item == null) return;
		Pickupable pu = item.GetComponent<Pickupable>();
		if (pu != null)
		{
			pu.Put(ctx.Target.ItemContainer);
		}
	}
}
