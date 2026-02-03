
using UnityEngine;

public class InventoryHands : MonoBehaviour, IItemSlot
{
	public bool TryGetItem(out IItem item)
	{
		if (transform.childCount > 0
			&& transform.GetChild(0).TryGetComponent(out item)) return true;

		item = null;
		return false;
	}

	public Transform Container => transform;
}
