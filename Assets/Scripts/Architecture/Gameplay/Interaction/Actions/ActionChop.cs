using System;
using UniRx;
using UnityEngine;

public sealed class ActionChop : IActionHold
{
	public string Id => "chop";
	public int Priority => 80;

	private bool cancel;
	private readonly ReactiveProperty<float> progress = new(0f);
	public IReadOnlyReactiveProperty<float> Progress01 => progress;

	public bool CanExecute(ActionContext ctx)
	{
		if (!ctx.Interactable.Flags.HasFlag(InteractableFlags.ChopStation)
			|| !ctx.Interactable.TryGetCapability<IChopStation>(out var chop)) return false;
		if(!ctx.Interactable.TryGetCapability<IItemSlot>(out var slot)) return false;
		if(!slot.HasItem || !slot.Container.GetChild(0).GetComponent<IInteractable>()
			.TryGetCapability<IItem>(out var item)) return false;
		if (item.ItemFlags.HasFlag(ItemFlags.Cuttable)
			&& ctx.Button == ButtonId.Button2) return true;
		return false; 
		// ≈сли в руках предмет, то начать можно, но он должен быть выкинут из рук (это уже в Execute)
	}


    public void Execute(ActionContext ctx) { }

	public IObservable<Unit> ExecuteHold(ActionContext ctx)
	{
		if (ctx.ItemSlot.HasItem) 
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
			.Do(_ => Debug.Log("Cutted"))
			.AsUnitObservable();
	}

	public void Cancel()
	{
		cancel = true;
		//progress.Value = 0f;
	}
}
