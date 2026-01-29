
using UnityEngine;

public class InventoryHands : MonoBehaviour, IItemSlot
{
	public bool HasItem => transform.childCount > 0;
	public Transform Container => transform;
}
