using UnityEngine;
using Zenject;

public abstract class StaticInteractable : MonoBehaviour
{
	public Transform ItemContainer => itemContainer;
	public bool HasItem => itemContainer.childCount > 0;

	[SerializeField] protected Transform itemContainer;

	protected ActionPutDownOn putDown;
	protected ActionTakeFrom take;

	[Inject]
	public void Construct(ActionPutDownOn putDown, ActionTakeFrom take)
	{
		this.putDown = putDown;
		this.take = take;
	}

	public void Place(Transform item)
    {
        item.SetParent(itemContainer, false);
		item.localPosition = Vector3.zero;
    }
}
