using UnityEngine;

public interface IItemPlace
{
	bool HasItem { get; }
	GameObject Item { get; }

	bool CanPlace(GameObject item);
	void Place(GameObject item);

	bool CanTake();               
	GameObject Take();
}