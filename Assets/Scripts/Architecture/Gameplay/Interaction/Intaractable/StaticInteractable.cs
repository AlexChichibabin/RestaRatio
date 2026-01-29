using UnityEngine;
using Zenject;

public abstract class StaticInteractable : InteractableBase, IItemSlot
{
	public Transform Container => itemContainer;
	public bool HasItem => itemContainer.childCount > 0;

    [SerializeField] private float toCenterPower;
    [SerializeField] private float unWrapDistance;
    [SerializeField] protected Transform itemContainer;

	protected ActionPut putDown;
	protected ActionTake take;

	[Inject]
	public void Construct(ActionPut putDown, ActionTake take)
	{
		this.putDown = putDown;
		this.take = take;
	}

	//public void Place(Transform item)
 //   {
 //       item.SetParent(itemContainer, false);
	//	item.localPosition = Vector3.zero;
 //   }
}
