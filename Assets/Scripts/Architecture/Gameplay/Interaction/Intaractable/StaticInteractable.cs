using UnityEngine;
using Zenject;

public abstract class StaticInteractable : BaseInteractable, ISlot
{
	public Transform Container => itemContainer;
    //public bool TryGetPortable(out IPortable portable)
    //{
    //    if (itemContainer.childCount > 0
    //        && itemContainer.GetChild(0).TryGetComponent(out portable)) return true;

    //    portable = null;
    //    return false;
    //}
	public bool TryGetChildAs<T>(out T portable)
	{
		if (itemContainer.childCount > 0
			&& itemContainer.GetChild(0).TryGetComponent(out portable)) return true;

		portable = default(T);
		return false;
	}

	[SerializeField] private float toCenterPower;
    [SerializeField] private float unWrapDistance;
    [SerializeField] protected Transform itemContainer;

	protected ActionPutOnSlot putDown;
	protected ActionTakeFromSlot take;

	[Inject]
	public void Construct(ActionPutOnSlot putDown, ActionTakeFromSlot take)
	{
		this.putDown = putDown;
		this.take = take;
	}
}
