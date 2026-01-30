using UnityEngine;

public class ActionTakeFrom : IGameAction
{
	public string Id => "take_from";

	public int Priority => 50;

	public bool CanExecute(ActionContext ctx)
	{
		if (ctx.ItemSlot.HasItem) return false;
		if (!ctx.Interactable.Flags.HasFlag(InteractableFlags.ItemSlot)
			|| !ctx.Interactable.TryGetCapability<IItemSlot>(out var slot)) return false;
		if (slot.HasItem && ctx.Button == ButtonId.Button1) return true;
		return false;
	}

	public void Execute(ActionContext ctx)
	{
		if (ctx.Interactable.TryGetCapability<IItemSlot>(out var slot))
		{
			Transform go = slot.Container.GetChild(0);
			if (go.TryGetComponent(out IItem item))
			{
				item.Take(ctx.ItemSlot.Container);
			}
		}
	}
}
