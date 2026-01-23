using UnityEngine;
using Zenject;

public class OrderReceiver : MonoBehaviour
{
    private IOrderService orderService;

    [Inject]
    public void Construct(IOrderService orderService)
    {
        this.orderService = orderService;
    }

    private void OnTriggerEnter(Collider other)
    {
        HeroMovement hero = other.transform.root.GetComponent<HeroMovement>();
        if (hero != null)
        {
            orderService.CreateOrder(100);
        }
    }
}
