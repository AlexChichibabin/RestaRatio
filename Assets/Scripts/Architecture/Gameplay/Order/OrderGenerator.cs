using System;
using UniRx;
using Zenject;

public class OrderGenerator : IInitializable, IDisposable
{
    private readonly IOrderService orderService;
    private readonly CompositeDisposable disposables = new();

    public OrderGenerator(IOrderService orderService)
    {
        this.orderService = orderService;
    }

    public void Initialize()
    {
        Observable.Interval(TimeSpan.FromSeconds(10))
            .Subscribe(_ =>
            {
                if (orderService.ActiveOrders.Count <= 5) // TODO fix hardcode
                    orderService.CreateOrder(50f);
            })
            .AddTo(disposables);
    }

    public void Dispose() => disposables.Dispose();
}
