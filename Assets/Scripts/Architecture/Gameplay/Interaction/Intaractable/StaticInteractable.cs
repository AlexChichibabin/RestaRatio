using UnityEngine;
using Zenject;

public abstract class StaticInteractable : InteractableBase, IItemSlot
{
	public Transform Container => itemContainer;
	//public bool HasItem => itemContainer.childCount > 0;
    public bool TryGetItem(out IItem item)
    {
        if (itemContainer.childCount > 0
            && itemContainer.GetChild(0).TryGetComponent(out item)) return true;

        item = null;
        return false;
    }

    [SerializeField] private float toCenterPower;
    [SerializeField] private float unWrapDistance;
    [SerializeField] protected Transform itemContainer;

	protected ActionPut putDown;
	protected ActionTakeFrom take;

	[Inject]
	public void Construct(ActionPut putDown, ActionTakeFrom take)
	{
		this.putDown = putDown;
		this.take = take;
	}
}
