using UniRx;
using UnityEngine;
using Zenject;

public class OrdersHud : MonoBehaviour
{
    [SerializeField] private OrderCardView cardPrefab;
    [SerializeField] private Transform root;

    private IOrderService orders;
    private CompositeDisposable disposables = new();

    [Inject]
    public void Construct(IOrderService orders)
    {
        this.orders = orders;
    }

    private void Start()
    {
        // при добавлении создаём карточку и подписываемся на прогресс
        orders.ActiveOrders.ObserveAdd()
            .Subscribe(add =>
            {
                var card = Instantiate(cardPrefab, root);
				card.SetData(orders);
				card.Bind(add.Value); // внутри Bind подписываемся на Remaining/Progress 
            })
            .AddTo(disposables);
    }
    private void OnDestroy() => disposables.Dispose();
}
