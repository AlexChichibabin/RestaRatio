using System.Collections.Generic;

public interface IItemContainer
{
	bool TryGetContent(out List<IInteractable> inter);
	IReadOnlyList<IInteractable> Inters { get; }
	bool CanAdd(IInteractable inter);
	void Add(IInteractable inter);
}