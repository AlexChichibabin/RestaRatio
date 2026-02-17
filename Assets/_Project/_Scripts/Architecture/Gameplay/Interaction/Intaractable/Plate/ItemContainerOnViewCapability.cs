using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ItemContainerOnViewCapability : MonoBehaviour, IItemContainerOnView, IActionProvider
{
	public IReadOnlyList<ItemData> Datas => datas;


	[SerializeField] private int capacity = 5;
	[SerializeField] private Transform viewRoot;

	private List<ItemData> datas;

	[Inject] private ActionPutInContainerByView put;


	private void Awake()
	{
		datas = new List<ItemData>(capacity: capacity);
	}
	public void Add(IInteractable inter)
	{
		if (CanAdd(inter) == false) return;

		if (inter.TryGetCapability<IItem>(out var item))
		{
			if(item.TryGetItemData(out var data))
				datas.Add(data);
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
}
