using UnityEngine;

public class ActionDrop : IGameAction
{
	public string Id => "drop";

	public int Priority => 20;

	public bool CanExecute(ActionContext ctx, IInteractable inter)
	{
		if (inter == null) return false;
		if (inter.Flags.HasFlag(InteractableFlags.Item)
			&& inter.TryGetCapability<IItem>(out var item))
		{
			return item.Parent == ctx.ItemSlot.Container
				&& ctx.Button == ButtonId.Button1;
        }
		return false;
	}

	public void Execute(ActionContext ctx, IInteractable inter)
	{
        if (inter.TryGetCapability<IItem>(out var item))
		{
			item.Drop(ctx.Actor.transform.parent);
		}
	}

}
