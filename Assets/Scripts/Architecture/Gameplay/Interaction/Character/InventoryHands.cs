using UnityEngine;

public class InventoryHands : MonoBehaviour, ISlot
{
	//public bool TryGetPortable(out IPortable portable)
	//{
	//	if (transform.childCount > 0
	//		&& transform.GetChild(0).TryGetComponent(out portable)) return true;

	//	portable = null;
	//	return false;
	//}
	//public bool TryGetItem(out IItem Item)
	//{
	//	if (transform.childCount > 0
	//		&& transform.GetChild(0).TryGetComponent(out Item)) return true;

	//	Item = null;
	//	return false;
	//}
	public bool TryGetChildAs<T>(out T portable)
	{
		if (transform.childCount > 0
			&& transform.GetChild(0).TryGetComponent(out portable)) return true;

		portable = default(T);
		return false;
	}
	public Transform Container => transform;
}
