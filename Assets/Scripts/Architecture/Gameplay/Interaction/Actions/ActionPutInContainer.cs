using UnityEngine;

public class ActionPutInContainer : IGameAction
{
    public string Id => "put_in_container";

    public int Priority => 50;

    public bool CanExecute(ActionContext ctx, IInteractable inter)
    {
        if (inter == null) return false;
        if (inter.Flags.HasFlag(InteractableFlags.Container))
        {
            if (!inter.TryGetCapability<IItemContainer>(out var container)) return false;
            if (!ctx.Slot.TryGetContentAs<IPortable>(out var actorPortable)) return false;
            if (!actorPortable.TryGetCapability<IItem>(out var actorItem)) return false;

            return container.CanAdd(actorItem) == true
                && ctx.Button == ButtonId.Button1;
        }

        return false;
    }

    public void Execute(ActionContext ctx, IInteractable inter)
    {
        if (!ctx.Slot.TryGetContentAs<IPortable>(out var portable)) return;
        if (!portable.TryGetCapability<IItem>(out var item)) return;

        if (inter.TryGetCapability<IItemContainer>(out var container))
        {
            container.Add(item);
        }
    }
}
