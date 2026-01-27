public sealed class ActionPutDownOn : IGameAction
{
	public string Id => "put_down_counter";
	public int Priority => 50;

	public bool CanExecute(ActionContext ctx)
	{
		return ctx.Inventory.HasItem 
			&& !ctx.Target.HasItem 
			&& ctx.Target is StaticInteractable 
			&& ctx.Button == ButtonId.Button1;
	}

	public void Execute(ActionContext ctx)
	{
		var counter = (Counter)ctx.Target;
		var item = ctx.Inventory.ItemContainer.GetChild(0);
		if (item == null) return;

		counter.Place(item); // лучше делегировать объекту стола
	}
}
