using TMPro;
using UnityEngine;
using Zenject;

public class UIActiveOrders : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;

    private IOrderService orderService;

    [Inject]
    public void Consctuct(IOrderService orderService)
    {
        this.orderService = orderService;
    }
    private void Update()
    {
        text.text = orderService.ActiveOrders.Count.ToString();
    }
}
