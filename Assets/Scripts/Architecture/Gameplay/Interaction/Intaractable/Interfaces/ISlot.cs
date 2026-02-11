using UnityEngine;

public interface ISlot// : IHasCapabilities
{
	abstract bool TryGetContentAs<T>(out T item);
	abstract Transform Container { get; }
}
