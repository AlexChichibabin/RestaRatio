
using UnityEngine;

public class InventoryHands : MonoBehaviour, IInventory
{
	public bool HasItem => transform.childCount > 0;
	public Transform ItemContainer => transform;
}
