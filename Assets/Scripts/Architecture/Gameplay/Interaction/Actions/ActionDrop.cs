public class ActionDrop : IGameAction
{
	public string Id => "drop";

	public int Priority => 20;

	public bool CanExecute(ActionContext ctx, IInteractable inter)
	{
		if (inter == null) return false;
		if (inter.Flags.HasFlag(InteractableFlags.Item) == true
			&& inter.TryGetCapability<IPortable>(out var portable) == true)
		{
			return portable.Parent == ctx.Slot.Container
				&& ctx.Button == ButtonId.Button1;
        }
		return false;
	}

	public void Execute(ActionContext ctx, IInteractable inter)
	{
        if (inter.TryGetCapability<IPortable>(out var portable))
		{
			portable.Drop(ctx.Actor.transform.parent);
		}
	}
}
