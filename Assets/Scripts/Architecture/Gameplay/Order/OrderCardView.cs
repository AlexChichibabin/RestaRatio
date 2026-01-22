using UniRx;
using UnityEngine;
using UnityEngine.UI;

public class OrderCardView : MonoBehaviour
{
    [SerializeField] private Image progressFill;

    private CompositeDisposable disposables = new();

    public void Bind(IOrder order)
    {
        disposables.Clear();

        order.Progress01
            .Subscribe(v => progressFill.fillAmount = v)
            .AddTo(disposables);
    }

    private void OnDestroy() => disposables.Dispose();
}
