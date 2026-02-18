using System.Collections.Generic;
using UniRx;

public interface IItemContainerOnView
{
	IReactiveProperty<List<ItemData>> Datas { get; }
	bool CanAdd(IInteractable inter);
	void Add(IInteractable inter);

	bool TryGetContent(out List<ItemData> datas);
}