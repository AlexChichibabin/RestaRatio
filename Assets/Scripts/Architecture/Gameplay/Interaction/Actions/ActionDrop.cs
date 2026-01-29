using UnityEngine;

public class ActionDrop : IGameAction
{
	public string Id => "drop";

	public int Priority => 20;

	public bool CanExecute(ActionContext ctx)
	{
		if (ctx.Interactable == null) return false;
		if (ctx.Interactable.Flags.HasFlag(InteractableFlags.Item)
			&& ctx.Interactable.TryGetCapability<IItem>(out var item))
		{
			return item.Parent == ctx.ItemSlot.Container
				&& ctx.Button == ButtonId.Button1;
        }
		return false;
	}

	public void Execute(ActionContext ctx)
	{
        if (ctx.Interactable.TryGetCapability<IItem>(out var item))
		{
			item.Drop(ctx.Actor.transform.parent);
		}
	}
}
