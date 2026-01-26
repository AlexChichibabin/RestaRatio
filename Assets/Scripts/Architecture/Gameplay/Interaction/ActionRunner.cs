using System;
using UniRx;

public class ActionRunner
{
    private IHoldAction currentHold;
    private IDisposable holdSub;

    public void Run(ActionContext ctx, IGameAction action)
    {
        action.Execute(ctx);
    }

    public void StartHold(ActionContext ctx, IHoldAction action)
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
