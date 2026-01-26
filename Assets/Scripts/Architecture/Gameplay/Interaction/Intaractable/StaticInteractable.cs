using UnityEngine;

public abstract class StaticInteractable : MonoBehaviour
{
    public Transform ItemPlace => itemPlace;

    [SerializeField] protected Transform itemPlace;

    public void Place(Transform item)
    {
        item.SetParent(itemPlace, true);
    }
}
