using System.Collections.Generic;
using UnityEngine;

public interface IItemContainer : IHasCapabilities
{
	bool TryGetItems(out List<IItem> item);
	IReadOnlyList<IItem> Items { get; }
	bool CanAdd(IItem item);
	void Add(IItem item);
}