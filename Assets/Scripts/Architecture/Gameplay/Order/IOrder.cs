using System;
using UniRx;

public enum OrderStatus { Active, Completed, Failed, Cancelled }

public interface IOrder : IDisposable
{
    string Id { get; }
    OrderStatus Status { get; }

    IReadOnlyReactiveProperty<float> RemainingSeconds { get; } // сколько осталось
    IReadOnlyReactiveProperty<float> Progress01 { get; }       // 1..0 (удобно для UI)
    IObservable<Unit> Completed { get; }
    IObservable<Unit> Failed { get; }

    bool TryComplete(); // сервис/кухня вызывает, когда блюдо готово
    void Cancel();      // возможно в конце дня)
}
