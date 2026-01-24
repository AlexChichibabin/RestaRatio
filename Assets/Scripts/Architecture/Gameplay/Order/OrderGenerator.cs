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
		Observable
			.Timer(TimeSpan.FromSeconds(0.5f), TimeSpan.FromSeconds(20))
			.Subscribe(_ =>
			{
			if (orderService.ActiveOrders.Count < 5)
			{
				orderService.CreateOrder(50f);
			}
			})
			.AddTo(disposables);
	}

	public void Dispose() => disposables.Dispose();
}
