using System;
using UniRx;
using UnityEngine;

public sealed class ActionRoast : IActionHold
{
    public string Id => "roast";
    public int Priority => 80;

    private bool cancel;
    private ReactiveProperty<float> progress = new(0f);
    public IReadOnlyReactiveProperty<float> Progress01 => progress;

    public bool CanExecute(ActionContext ctx, IInteractable inter)
    {
        if (!inter.Flags.HasFlag(InteractableFlags.CookStation)) return false;
        if (!inter.TryGetCapability<ICookStation>(out var cookStation)) return false;
        if (!inter.TryGetCapability<IItemSlot>(out var slot)) return false;
        if (!slot.TryGetItem(out var interItem)) return false;
        if (interItem.StateFlags.HasFlag(ItemStateFlags.Roasted)) return false;
        if (interItem.AbilityFlags.HasFlag(ItemAbilityFlags.Roastable)
            && ctx.Button == ButtonId.Button2) return true;

        return false;
        // ≈сли в руках предмет, то начать можно, но он должен быть выкинут из рук (это уже в Execute)
    }


    public void Execute(ActionContext ctx, IInteractable inter) { }

    public IObservable<Unit> ExecuteHold(ActionContext ctx, IInteractable inter)
    {
        if (ctx.ItemSlot.TryGetItem(out var actorItem)) (actorItem as Transform).SetParent(ctx.Actor.transform.parent);

        return Observable.Defer(() =>
        {
            cancel = false;
            progress.Value = 0f;

            if (actorItem != null)
            {
                Debug.Log("False hold execute because has item");
                return Observable.Empty<Unit>();
            }

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
                    if (inter.TryGetCapability<ICookStation>(out var station)
                    && inter.TryGetCapability<IItemSlot>(out var slot))
                    {
                        slot.TryGetItem(out var interItem);
                        station.FinishCook(interItem);
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
