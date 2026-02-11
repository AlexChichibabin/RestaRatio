using System.Collections.Generic;
using UnityEngine;

public interface IItemContainer<T>
{
	bool TryGetContent(out List<T> item);
	IReadOnlyList<T> Items { get; }
	bool CanAdd(T item);
	void Add(T item);
}