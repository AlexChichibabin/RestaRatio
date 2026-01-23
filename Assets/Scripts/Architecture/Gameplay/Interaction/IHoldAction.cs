using System;
using UniRx;

public interface IHoldAction : IGameAction
{
    IObservable<Unit> ExecuteHold(ActionContext ctx); // завершение/успех
    void Cancel();
}
