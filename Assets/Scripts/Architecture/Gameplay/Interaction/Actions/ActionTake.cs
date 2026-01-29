using UnityEngine;
using static UnityEditor.Progress;

public class ActionTake : IGameAction
{
	public string Id => "take";

	public int Priority => 50;

	public bool CanExecute(ActionContext ctx)
	{
		return !ctx.ItemSlot.HasItem
			&& ctx.Interactable.Flags.HasFlag(InteractableFlags.ItemSlot)
            && ctx.Interactable.TryGetCapability<IItemSlot>(out var slot)
			&& slot.HasItem
            && ctx.Button == ButtonId.Button1;
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
