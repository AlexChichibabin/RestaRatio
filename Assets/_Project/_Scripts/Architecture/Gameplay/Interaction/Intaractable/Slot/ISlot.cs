using System;
using UniRx;
using UnityEngine;

public interface ISlot
{
	abstract bool TryGetContentAs<T>(out T item);
	abstract Transform Container { get; }
    IObservable<Unit> PutEvent {  get; }
    IObservable<Unit> RemoveEvent { get; }
}
