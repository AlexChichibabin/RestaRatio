using UnityEngine;

public class ActionTakeItem : IGameAction
{
	public string Id => "take_item";

	public int Priority => 40;

	public bool CanExecute(ActionContext ctx)
	{
		if (ctx.ItemSlot.HasItem) return false;
		if (!ctx.Interactable.Flags.HasFlag(InteractableFlags.Item)
			|| !ctx.Interactable.TryGetCapability<IItem>(out var item)) return false;
		if (ctx.Button == ButtonId.Button1) return true;
		return false;
	}

	public void Execute(ActionContext ctx)
	{
		if (ctx.Interactable.TryGetCapability<IItem>(out var item))
		{
			item.Take(ctx.ItemSlot.Container);
		}
	}
}
