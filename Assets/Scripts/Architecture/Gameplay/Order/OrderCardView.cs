using UniRx;
using UnityEngine;
using UnityEngine.UI;

public class OrderCardView : MonoBehaviour
{
    [SerializeField] private Image progressFill;

    private IOrder order;
    public string Id => order.Id;

    private IOrderService orderService;

	private CompositeDisposable disposables = new();

    public void Bind(IOrder order)
    {
        disposables.Clear();

        this.order = order;

        order.Progress01
            .Subscribe(v =>
            {
                progressFill.color = v >= 0.3f ? Color.green : Color.red;
                progressFill.fillAmount = v;
            })
            .AddTo(disposables);

        orderService.OrderRemoved
            .Select(v => v.Id)
            .Subscribe(id =>
            {
                if (id == order.Id)
                    Destroy(gameObject);
            })
            .AddTo(disposables);
    }

    private void OnDestroy() => disposables.Dispose();

    public void SetData(IOrderService orderService)
    {
		this.orderService = orderService;
    }
}
