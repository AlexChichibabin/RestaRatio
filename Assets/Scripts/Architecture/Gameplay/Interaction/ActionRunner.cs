using System;
using UniRx;

public class ActionRunner
{
    private IHoldAction _currentHold;
    private IDisposable _holdSub;

    public void Run(ActionContext ctx, IGameAction action)
    {
        action.Execute(ctx);
    }

    public void StartHold(ActionContext ctx, IHoldAction action)
    {
        CancelHold();

        _currentHold = action;
        _holdSub = action.ExecuteHold(ctx)
            .Subscribe(_ => CancelHold());
    }

    public void CancelHold()
    {
        _holdSub?.Dispose();
        _holdSub = null;

        _currentHold?.Cancel();
        _currentHold = null;
    }
}
