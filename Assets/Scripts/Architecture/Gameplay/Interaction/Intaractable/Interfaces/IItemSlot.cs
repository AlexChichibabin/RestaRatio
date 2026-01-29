using UnityEngine;

public interface IItemSlot
{
	abstract bool HasItem { get; }
    abstract Transform Container { get; }
}
