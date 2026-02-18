using System;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using Zenject;

public class ItemContainerOnViewCapability : MonoBehaviour, IItemContainerOnView, IActionProvider
{
	//public IReadOnlyList<ItemData> Datas => datas.Value;


	[SerializeField] private int capacity = 5;
	[SerializeField] private Transform viewRoot;

	private ReactiveProperty<List<ItemData>> datas;
	public IReactiveProperty<List<ItemData>> Datas => datas;

	[Inject] private ActionPutInContainerOnView put;


	[SerializeField] private PlateView viewer;

	private void Awake()
	{
		datas = new ReactiveProperty<List<ItemData>>();
		datas.Value = new List<ItemData>(capacity: capacity);
	}
	public void Add(IInteractable inter)
	{
		if (CanAdd(inter) == false) return;

		if (inter.TryGetCapability<IItem>(out var item))
		{
			if (item.TryGetItemData(out var data))
			{
				datas.Value.Add(data);
				viewer.Render(datas.Value);
				Debug.Log("Объект положен в контейнер");
			}
				
		}
	}

	public bool CanAdd(IInteractable inter)
	{
		if (datas.Value.Count >= capacity) return false;
		if (!inter.TryGetCapability<IItem>(out var item) || item.IsServable == false) return false;
		Debug.Log(datas.Value.Count);
		return true;
	}

	public IEnumerable<IGameAction> GetActionsByCapability()
	{
		yield return put;
	}

	public bool TryGetContent(out List<ItemData> datas)
	{
		if (this.datas == null || this.datas.Value.Count == 0)
		{
			datas = default(List<ItemData>);
			return false;
		}
		datas = this.datas.Value;
		return true;
	}
}
