using UnityEngine;

public interface IItemSlot
{
    abstract bool TryGetItem(out IItem item);
    abstract Transform Container { get; }
}
