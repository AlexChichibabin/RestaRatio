public sealed class PutDownOnCounterAction : IGameAction
{
	public string Id => "put_down_counter";
	public int Priority => 50;

	public bool CanExecute(ActionContext ctx)
		=> ctx.Inventory.HasItem && ctx.Target is Counter;

	public void Execute(ActionContext ctx)
	{
		var counter = (Counter)ctx.Target;
		var item = ctx.Inventory.Drop();
		if (item == null) return;

		counter.Place(item); // лучше делегировать объекту стола
	}
}
