using UnityEngine;
using UnityEngine.EventSystems;

public class VirtualJoystick : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
{
    [SerializeField] private RectTransform stickArea;
    [SerializeField] private RectTransform stick;

    public static Vector2 Value { get; private set; }

    private void Start()
    {
        Value = Vector2.zero;
    }

    public void OnPointerDown(PointerEventData pointerEventData)
    {
        Move(pointerEventData.position);
    }
    public void OnDrag(PointerEventData pointerEventData)
    {
        Move(pointerEventData.position);
    }
    public void OnPointerUp(PointerEventData pointerEventData)
    {
        stick.anchoredPosition = Vector2.zero;
        Value = Vector2.zero;
    }
    private void Move(Vector2 newPosition)
    {
        stick.position = newPosition;
        if (stick.anchoredPosition.magnitude > stickArea.sizeDelta.x / 2)
        {
            stick.anchoredPosition = stick.anchoredPosition.normalized * (stickArea.sizeDelta.x / 2);
        }

        Value = new Vector2(stick.anchoredPosition.x, stick.anchoredPosition.y).normalized;
    }
}
