using System.Collections.Generic;
using UnityEngine;

public interface IItemContainer
{
	bool TryGetItem(out IItem item);
	List<GameObject> Items { get; }

	bool CanAdd(GameObject item);
	void Add(GameObject item);

	bool CanTake();               
	GameObject Take();
}