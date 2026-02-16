using UnityEngine;

public class ActionPutInContainerByView : IGameAction
{
	public string Id => "put_in_container_by_view";

	public int Priority => 50;

	public bool CanExecute(ActionContext ctx, IInteractable inter)
	{
		if (inter == null) return false;
		if (inter.Flags.HasFlag(InteractableFlags.Container))
		{
			if (!inter.TryGetCapability<IItemContainer>(out var container)) return false;
			if (ctx.Slot.TryGetContentAs<IInteractable>(out var actorInter) && inter.Equals(actorInter)) return false;
			if (!ctx.Slot.TryGetContentAs<IInteractable>(out var actorHandInter)) return false;
			if (!actorHandInter.TryGetCapability<IPortable>(out var actorPortable)) return false;

			return container.CanAdd(actorHandInter) == true
				&& ctx.Button == ButtonId.Button1;
		}

		return false;
	}

	public void Execute(ActionContext ctx, IInteractable inter)
	{
		if (!ctx.Slot.TryGetContentAs<IInteractable>(out var actorInter)) return;
		if (!actorInter.TryGetCapability<IPortable>(out var portable)) return;

		if (inter.TryGetCapability<IItemContainer>(out var container))
		{
			container.Add(actorInter);
		}
	}
}
