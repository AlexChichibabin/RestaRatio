using UnityEngine;

public class ActionPutInContainerOnView : IGameAction
{
	public string Id => "put_in_container_on_view";

	public int Priority => 50;

	public bool CanExecute(ActionContext ctx, IInteractable inter)
	{
		if (inter == null) return false;
		if (inter.Flags.HasFlag(InteractableFlags.Container))
		{
			if (!inter.TryGetCapability<IItemContainerOnView>(out var container)) return false;
			if (ctx.Slot.TryGetContentAs<IInteractable>(out var actorInter) && inter.Equals(actorInter)) return false;
			if (!ctx.Slot.TryGetContentAs<IInteractable>(out var actorHandInter)) return false;
			if (!actorHandInter.TryGetCapability<IItem>(out var actorItem)) return false;

			return container.CanAdd(actorHandInter) == true
				&& ctx.Button == ButtonId.Button1;
		}

		return false;
	}

	public void Execute(ActionContext ctx, IInteractable inter)
	{
		if (!ctx.Slot.TryGetContentAs<IInteractable>(out var actorInter)) return;
		if (!actorInter.TryGetCapability<IItem>(out var actorItem)) return;
		if (!actorItem.TryGetItemData(out var data)) return;

		if (inter.TryGetCapability<IItemContainerOnView>(out var container))
		{
			container.Add(actorInter);

			if (actorInter is MonoBehaviour mb)
				Object.Destroy(mb.gameObject);
		}
	}
}
