using System;
using UnityEngine;
using UniRx;
using Zenject;

public class OrderGenerator : IInitializable, IDisposable
{
    private IOrderService orderService;
    private CompositeDisposable disposables = new();

    public OrderGenerator(IOrderService orderService)
    {
        this.orderService = orderService;
    }

    public void Initialize()
    {
        Observable.Interval(TimeSpan.FromSeconds(3))
            .Subscribe(_ =>
            {
                if (orderService.ActiveOrders.Count < 5) // TODO fix hardcode
                {
                    orderService.CreateOrder(5f);
                }
            })
            .AddTo(disposables);
    }

    public void Dispose() => disposables.Dispose();
}
