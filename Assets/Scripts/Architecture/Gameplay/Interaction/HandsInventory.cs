
using UnityEngine;

public class HandsInventory : MonoBehaviour, IInventory
{
	public bool HasItem => transform.childCount > 0;
	public Transform ItemContainer => transform;
}
