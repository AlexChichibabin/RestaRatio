public sealed class ActionPutOnSlot : IGameAction
{
	public string Id => "put_on_slot";
	public int Priority => 50;

    public bool CanExecute(ActionContext ctx, IInteractable inter)
    {
        if (inter == null) return false;
        if (inter.Flags.HasFlag(InteractableFlags.ItemSlot))
        {
            if (!inter.TryGetCapability<ISlot>(out var slot)) return false;
            if (ctx.Slot.TryGetContentAs<IInteractable>(out var actorInter) && inter.Equals(actorInter)) return false;
            if (!ctx.Slot.TryGetContentAs<IPortable>(out var actorPortable)) return false;

			return !slot.TryGetContentAs<IPortable>(out var interPortable)
                && ctx.Button == ButtonId.Button1;
        }

        return false;
    }

    public void Execute(ActionContext ctx, IInteractable inter)
    {
        var portableGo = ctx.Slot.Container.GetChild(0);

        if (portableGo == null) return;

        if (portableGo.TryGetComponent(out IPortable portable))
        {
            if (inter.TryGetCapability<ISlot>(out var place))
            {
                portable.Put(place.Container);
            }
        }
    }
}

