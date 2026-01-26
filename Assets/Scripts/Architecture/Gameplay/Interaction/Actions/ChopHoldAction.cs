using System;
using UniRx;
using UnityEngine;

public sealed class ChopHoldAction : IHoldAction
{
	public string Id => "chop";
	public int Priority => 80;

	private bool cancel;
	private readonly ReactiveProperty<float> progress = new(0f);
	public IReadOnlyReactiveProperty<float> Progress01 => progress;

	public bool CanExecute(ActionContext ctx)
		=> ctx.Target is CuttingBoard board
		   && board.HasItemToChop
		   && !ctx.Inventory.HasItem;

	public void Execute(ActionContext ctx) { }

	public IObservable<Unit> ExecuteHold(ActionContext ctx)
	{
		cancel = false;
		progress.Value = 0f;

		const float duration = 1.2f;

		return Observable.EveryUpdate()
			.TakeWhile(_ => !cancel)
			.Select(_ => Time.deltaTime / duration)
			.Scan(0f, (p, dp) => Mathf.Clamp01(p + dp))
			.Do(p => progress.Value = p)
			.Where(p => p >= 1f)
			.Take(1)
			.Do(_ => Debug.Log(_)/*ctx.Target.HasItem*/)
			.AsUnitObservable();
	}

	public void Cancel()
	{
		cancel = true;
		progress.Value = 0f;
	}
}
