using System;
using UniRx;

public interface IActionHold : IGameAction
{
    IObservable<Unit> ExecuteHold(ActionContext ctx, IInteractable inter); // завершение/успех
    void Cancel();
}
