using UnityEngine;

public class ActionTake : IGameAction
{
	public string Id => "take";

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
		Pickupable pu = item.GetComponent<Pickupable>();
		if (pu != null) pu.Take(ctx.Inventory.ItemContainer);
		else
		{
			item.SetParent(ctx.Inventory.ItemContainer, false);
			item.SetLocalPositionAndRotation(Vector3.zero, Quaternion.identity); 
		}

	}
}
