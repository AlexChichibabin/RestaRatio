using UnityEngine;

public interface IInventory
{
	abstract bool HasItem { get; }
    abstract Transform ItemContainer { get; }
}
