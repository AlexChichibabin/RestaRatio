using System;
using UniRx;

public class Order : IOrder
{
    public string Id { get; }

    public OrderStatus Status => status.Value;
    public IReadOnlyReactiveProperty<float> RemainingSeconds => remainingSeconds;
    public IReadOnlyReactiveProperty<float> Progress01 => progress01;
    public IObservable<Unit> Completed => completed;
    public IObservable<Unit> Failed => failed;

    private ReactiveProperty<OrderStatus> status = new(OrderStatus.Active);
    private ReactiveProperty<float> remainingSeconds;
    private ReactiveProperty<float> progress01 = new(1f);
    private Subject<Unit> completed = new();
    private Subject<Unit> failed = new();

    private CompositeDisposable disposables = new();
    private float totalSeconds;

    public Order(string id, float totalSeconds)
    {
        Id = id;
        this.totalSeconds = Math.Max(0.01f, totalSeconds);
        remainingSeconds = new ReactiveProperty<float>(this.totalSeconds).AddTo(disposables);

        Observable.EveryUpdate()
            .Select(_ => UnityEngine.Time.deltaTime)   // можно прокинуть deltaTime иначе. Мб через UniRx
            .Scan(totalSeconds, (remain, dt) => remain - dt)
            .Select(remain => Math.Max(0f, remain))
            .TakeUntil(status.Where(s => s != OrderStatus.Active))
            .Subscribe(remain =>
            {
                remainingSeconds.Value = remain;
                progress01.Value = remain / totalSeconds;

                if (remain <= 0f)
                    FailInternal();
            })
            .AddTo(disposables);
    }

    public bool TryComplete()
    {
        if (status.Value != OrderStatus.Active) return false;

        status.Value = OrderStatus.Completed;
        completed.OnNext(Unit.Default);
        completed.OnCompleted();

        Dispose(); // останавливаем таймер
        return true;
    }

    public void Cancel()
    {
        if (status.Value != OrderStatus.Active) return;

        status.Value = OrderStatus.Cancelled;
        Dispose();
    }

    private void FailInternal()
    {
        if (status.Value != OrderStatus.Active) return;

        status.Value = OrderStatus.Failed;
        failed?.OnNext(Unit.Default);
        //failed?.OnCompleted();

        Dispose();
    }

    public void Dispose()
    {
        // Закрываем все реактивное
        disposables?.Dispose();
        failed?.Dispose();
        completed.Dispose();
        status.Dispose();
        progress01.Dispose();
        remainingSeconds.Dispose();
    }
}
