public class ActionTakePortable : IGameAction
{
	public string Id => "take_portable";

	public int Priority => 40;

	public bool CanExecute(ActionContext ctx, IInteractable inter)
	{
		if (ctx.Slot.TryGetContentAs<IPortable>(out var actorPortable)) return false;
		if (!inter.Flags.HasFlag(InteractableFlags.Item)) return false;
        if (!inter.TryGetCapability<IPortable>(out var portable)) return false;
		if (ctx.Button == ButtonId.Button1) return true;

		return false;
	}

	public void Execute(ActionContext ctx, IInteractable inter)
	{
		if (inter.TryGetCapability<IPortable>(out var portable))
		{
			portable.Take(ctx.Slot.Container);
		}
	}
}
