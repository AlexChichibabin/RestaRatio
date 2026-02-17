using UnityEngine;
public class ActionTakeFromSlot : IGameAction
{
	public string Id => "take_from";

	public int Priority => 50;

	public bool CanExecute(ActionContext ctx, IInteractable inter)
	{
		if (ctx.Slot.TryGetContentAs<IPortable>(out var actorPortable)) return false; // У персонажа не должно быть предмета
		if (!inter.Flags.HasFlag(InteractableFlags.ItemSlot)) return false; // У интера должен быть флаг ItemSlot
		if (!inter.TryGetCapability<ISlot>(out var slot)) return false; // У интера должен быть интерфейс ItemSlot
		if (slot.TryGetContentAs<IPortable>(out var interPortable) && ctx.Button == ButtonId.Button1) return true; //
		return false;
	}

	public void Execute(ActionContext ctx, IInteractable inter)
	{
		if (inter.TryGetCapability<ISlot>(out var slot))
		{
			Transform go = slot.Container.GetChild(0);
			if (go.TryGetComponent(out IPortable portable))
			{
				portable.Take(ctx.Slot.Container);
			}
		}
	}
}
