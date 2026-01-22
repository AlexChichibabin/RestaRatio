using System;
using System.Linq;
using UniRx;

public sealed class OrderService : IOrderService, IDisposable
{
    public IReadOnlyReactiveCollection<IOrder> ActiveOrders => activeOrders;
    public IObservable<IOrder> OrderCreated => orderCreated;
    public IObservable<IOrder> OrderCompleted => orderCompleted;
    public IObservable<IOrder> OrderFailed => orderFailed;

    private readonly ReactiveCollection<IOrder> activeOrders = new();
    private readonly Subject<IOrder> orderCreated = new();
    private readonly Subject<IOrder> orderCompleted = new();
    private readonly Subject<IOrder> orderFailed = new();

    private readonly CompositeDisposable disposables = new();
    private int orderSequence;

    public IOrder CreateOrder(float seconds)
    {
        var id = $"order_{++orderSequence}";
        var order = new Order(id, seconds);

        activeOrders.Add(order);
        orderCreated.OnNext(order);

        // Подписываемся на завершение/провал, чтобы сервис мог:
        // - удалить из активных
        // - прокинуть глобальное событие
        order.Completed
            .Subscribe(_ =>
            {
                orderCompleted.OnNext(order);
                RemoveOrder(order.Id);
            })
            .AddTo(disposables);

        order.Failed
            .Subscribe(_ =>
            {
                orderFailed.OnNext(order);
                RemoveOrder(order.Id);
            })
            .AddTo(disposables);

        return order;
    }

    public void RemoveOrder(string id)
    {
        var order = activeOrders.FirstOrDefault(o => o.Id == id);
        if (order == null) return;

        activeOrders.Remove(order);
        order.Dispose(); // важно: остановить таймер
    }

    public void Clear()
    {
        // Например, конец дня: всё отменить
        foreach (var o in activeOrders.ToArray())
        {
            o.Cancel();
            // Cancel вызовет Dispose, но мы всё равно чистим коллекцию
            activeOrders.Remove(o);
        }
    }

    public void Dispose()
    {
        Clear();
        disposables.Dispose();
        activeOrders.Dispose();
        orderCreated.Dispose();
        orderCompleted.Dispose();
        orderFailed.Dispose();
    }
}
