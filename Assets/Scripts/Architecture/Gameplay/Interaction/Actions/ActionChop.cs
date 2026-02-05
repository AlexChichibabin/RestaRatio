using System;
using UniRx;
using UnityEngine;
public sealed class ActionChop : IActionHold
{
	public string Id => "chop";
	public int Priority => 80;

	private bool cancel;
	private ReactiveProperty<float> progress = new(0f);
	public IReadOnlyReactiveProperty<float> Progress01 => progress;

	public bool CanExecute(ActionContext ctx, IInteractable inter)
	{
		if (!inter.Flags.HasFlag(InteractableFlags.ChopStation)) return false;
        if (!inter.TryGetCapability<IChopStation>(out var chop)) return false;
        if (!inter.TryGetCapability<IItemSlot>(out var slot)) return false;
        if (!slot.TryGetItem(out var interItem)) return false;
        if (interItem.HasState(ItemStateFlags.Cutted) == true) return false;
        if (interItem.HasAbility(ItemAbilityFlags.Cuttable) == true
			&& ctx.Button == ButtonId.Button2) return true;

		return false; 
	}


    public void Execute(ActionContext ctx, IInteractable inter) { }

    public IObservable<Unit> ExecuteHold(ActionContext ctx, IInteractable inter)
    {
        if (ctx.ItemSlot.TryGetItem(out var actorItem))
        {
            if ((actorItem as IInteractable).TryGetCapability<IItem>(out var item))
            {
                item.Drop(ctx.Actor.transform.parent);
            }
        }

        return Observable.Defer(() => // TODO Доделать отмену
		{
            cancel = false;
            progress.Value = 0f;

            const float duration = 2f;

            return Observable.EveryUpdate()
                .TakeWhile(_ => cancel == false)
                .Select(_ => Time.deltaTime / duration)
                .Scan(0f, (p, dp) => Mathf.Clamp01(p + dp))
                .Do(p => progress.Value = p)
                .Where(p => p >= 1f)
                .Take(1)
                .Do(_ =>
                {
                    if (inter.TryGetCapability<IChopStation>(out var station) 
                    && inter.TryGetCapability<IItemSlot>(out var slot))
                    {
                        slot.TryGetItem(out var interItem);
                        station.FinishChop(interItem);
                    }
                        
				})
                .AsUnitObservable();
        });
    }


    public void Cancel()
	{
		cancel = true;
		//progress.Value = 0f;
	}
}
