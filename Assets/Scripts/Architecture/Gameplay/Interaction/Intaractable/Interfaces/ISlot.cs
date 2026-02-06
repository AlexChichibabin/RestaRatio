using UnityEngine;

public interface ISlot
{
 //   abstract bool TryGetPortable(out IPortable portable);
	//abstract bool TryGetItem(out IItem item);
	abstract bool TryGetChildAs<T>(out T item);
	abstract Transform Container { get; }
}
