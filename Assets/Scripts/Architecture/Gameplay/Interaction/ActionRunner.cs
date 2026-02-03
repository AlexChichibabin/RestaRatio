using System;
using UniRx;

public class ActionRunner
{
    private IActionHold currentHold;
    private IDisposable holdSub; 

    public void Run(ActionContext ctx, IGameAction action, IInteractable inter)
    {
        action.Execute(ctx, inter);
    }

    public void StartHold(ActionContext ctx, IActionHold action, IInteractable inter)
    {
        CancelHold();

        currentHold = action;

        holdSub = action.ExecuteHold(ctx, inter)
            .Subscribe(
                _ => CancelHold(),  // OnNext
                ex => // Exception
                {
                    UnityEngine.Debug.LogException(ex);
                    CancelHold();
                },
                () => CancelHold() //OnComplete
            );
    }

    public void CancelHold()
    {
        holdSub?.Dispose();
        holdSub = null;

        currentHold?.Cancel();
        currentHold = null;
    }
}
