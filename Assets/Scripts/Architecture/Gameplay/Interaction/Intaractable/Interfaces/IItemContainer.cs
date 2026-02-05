using UnityEngine;

public interface IItemContainer
{
	bool HasItem { get; }
	GameObject Item { get; }

	bool CanAdd(GameObject item);
	void Add(GameObject item);

	bool CanTake();               
	GameObject Take();
}