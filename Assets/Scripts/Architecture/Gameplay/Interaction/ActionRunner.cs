using System;
using UniRx;
using UnityEngine;

public class ActionRunner
{
    private IActionHold currentHold;
    private IDisposable holdSub;

    public void Run(ActionContext ctx, IGameAction action)
    {
        action.Execute(ctx);
    }

    public void StartHold(ActionContext ctx, IActionHold action)
    {
        CancelHold();

        currentHold = action;
        holdSub = action.ExecuteHold(ctx)
            .Subscribe(_ => CancelHold());
    }

    public void CancelHold()
    {
        holdSub?.Dispose();
        holdSub = null;

        currentHold?.Cancel();
        currentHold = null;
    }
}
