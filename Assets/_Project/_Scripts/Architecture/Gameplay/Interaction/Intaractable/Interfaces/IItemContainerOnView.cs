using System.Collections.Generic;

public interface IItemContainerOnView
{
	IReadOnlyList<ItemData> Datas { get; }
	bool CanAdd(IInteractable inter);
	void Add(IInteractable inter);
}