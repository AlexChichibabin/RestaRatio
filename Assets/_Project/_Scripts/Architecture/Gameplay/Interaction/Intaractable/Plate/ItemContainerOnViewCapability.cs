using System.Collections.Generic;
using System.Linq;
using UniRx;
using UnityEngine;
using Zenject;

public class ItemContainerOnViewCapability : MonoBehaviour, IItemContainerOnView, IActionProvider
{
	[SerializeField] private int capacity = 5;
	[SerializeField] private Transform viewRoot;

	private ReactiveCollection<ItemData> datas;
	public IReactiveCollection<ItemData> Datas => datas;

	[Inject] private ActionPutInContainerOnView put;

	private void Awake()
	{
		datas = new ReactiveCollection<ItemData>();
	}
	public void Add(IInteractable inter)
	{
		if (CanAdd(inter) == false) return;

		if (inter.TryGetCapability<IItem>(out var item))
		{
			if (item.TryGetItemData(out var data))
			{
				datas.Add(data);
				Debug.Log("Объект положен в контейнер");
			}
		}
	}

	public bool CanAdd(IInteractable inter)
	{
		if (datas.Count >= capacity) return false;
		if (!inter.TryGetCapability<IItem>(out var item) || item.IsServable == false) return false;
		Debug.Log(datas.Count);
		return true;
	}

	public IEnumerable<IGameAction> GetActionsByCapability()
	{
		yield return put;
	}

	public bool TryGetContent(out List<ItemData> datas)
	{
		if (this.datas == null || this.datas.Count == 0)
		{
			datas = default(List<ItemData>);
			return false;
		}
		datas = this.datas.ToList<ItemData>();
		return true;
	}
}
