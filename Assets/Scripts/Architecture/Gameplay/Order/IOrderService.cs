using System;
using UniRx;

public interface IOrderService
{
    IReadOnlyReactiveCollection<IOrder> ActiveOrders { get; }

    IObservable<IOrder> OrderCreated { get; }
    IObservable<IOrder> OrderCompleted { get; }
    IObservable<IOrder> OrderFailed { get; }
    IObservable<IOrder> OrderRemoved { get; }

    IOrder CreateOrder(float seconds);
    void RemoveOrder(string id);
    void Clear(); // например, конец дня
}
