public sealed class ActionPut : IGameAction
{
	public string Id => "put";
	public int Priority => 50;

    public bool CanExecute(ActionContext ctx, IInteractable inter)
    {
        if (inter == null) return false;
        if (inter.Flags.HasFlag(InteractableFlags.ItemSlot))
        {
            if (!inter.TryGetCapability<IItemSlot>(out var slot)) return false;
            if (!ctx.ItemSlot.TryGetItem(out var actorItem)) return false;

			return !slot.TryGetItem(out var InterItem)
                && ctx.Button == ButtonId.Button1;
        }

        return false;
    }

    public void Execute(ActionContext ctx, IInteractable inter)
    {
        var itemGo = ctx.ItemSlot.Container.GetChild(0);

        if (itemGo == null) return;

        if (itemGo.TryGetComponent(out IItem item))
        {
            if (inter.TryGetCapability<IItemSlot>(out var place))
            {
                item.Put(place.Container);
            }
        }
    }
}

