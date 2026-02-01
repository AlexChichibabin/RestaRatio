using UnityEngine;

public class ActionTakeItem : IGameAction
{
	public string Id => "take_item";

	public int Priority => 40;

	public bool CanExecute(ActionContext ctx, IInteractable inter)
	{
		if (ctx.ItemSlot.HasItem) return false;
		if (!inter.Flags.HasFlag(InteractableFlags.Item)
			|| !inter.TryGetCapability<IItem>(out var item)) return false;
		if (ctx.Button == ButtonId.Button1) return true;
		return false;
	}

	public void Execute(ActionContext ctx, IInteractable inter)
	{
		if (inter.TryGetCapability<IItem>(out var item))
		{
			item.Take(ctx.ItemSlot.Container);
		}
	}
}
