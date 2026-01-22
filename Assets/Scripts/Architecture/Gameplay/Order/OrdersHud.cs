using UniRx;
using UnityEngine;
using Zenject;

public class OrdersHud : MonoBehaviour
{
    [SerializeField] private OrderCardView cardPrefab;
    [SerializeField] private Transform root;

    private IOrderService _orders;
    private CompositeDisposable disposables = new();

    [Inject]
    public void Construct(IOrderService orders)
    {
        _orders = orders;
    }

    private void Start()
    {
        // при добавлении создаЄм карточку и подписываемс€ на прогресс
        _orders.ActiveOrders.ObserveAdd()
            .Subscribe(add =>
            {
                var card = Instantiate(cardPrefab, root);
                card.Bind(add.Value); // внутри Bind подпишешьс€ на Remaining/Progress
            })
            .AddTo(disposables);

        // при удалении Ч можно уничтожать карточку (если хранишь мапу orderId->card)
    }

    private void OnDestroy() => disposables.Dispose();
}
