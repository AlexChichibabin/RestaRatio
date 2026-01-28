using UnityEngine;

public sealed class ActionPut : IGameAction
{
	public string Id => "put";
	public int Priority => 50;

	public bool CanExecute(ActionContext ctx)
	{
		return ctx.Inventory.HasItem 
			&& !ctx.Target.HasItem 
			&& ctx.Target is StaticInteractable 
			&& ctx.Button == ButtonId.Button1;
	}

	public void Execute(ActionContext ctx)
	{
		//var counter = (Counter)ctx.Target;
		var item = ctx.Inventory.ItemContainer.GetChild(0);
		if (item == null) return;
		Pickupable pu = item.GetComponent<Pickupable>();
		if (pu != null) pu.Put(ctx.Target.ItemContainer);
		else
		{
			item.SetParent(ctx.Target.ItemContainer, false);
			item.SetLocalPositionAndRotation(Vector3.zero, Quaternion.identity);
		}
	}
}
