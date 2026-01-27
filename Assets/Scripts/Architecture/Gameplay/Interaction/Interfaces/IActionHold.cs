using System;
using UniRx;

public interface IActionHold : IGameAction
{
    IObservable<Unit> ExecuteHold(ActionContext ctx); // завершение/успех
    void Cancel();
}
