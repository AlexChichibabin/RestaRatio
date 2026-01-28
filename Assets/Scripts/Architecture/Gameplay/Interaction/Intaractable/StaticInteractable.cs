using UnityEngine;
using Zenject;

public abstract class StaticInteractable : InteractableBase
{
	[SerializeField] private float toCenterPower;
	[SerializeField] private float unWrapDistance;
	public override Transform ItemContainer => itemContainer;
	public override bool HasItem => itemContainer.childCount > 0;

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
