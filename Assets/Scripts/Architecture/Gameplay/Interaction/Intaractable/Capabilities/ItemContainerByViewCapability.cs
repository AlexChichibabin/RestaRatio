using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ItemContainerByViewCapability : MonoBehaviour, IItemContainer, IActionProvider
{
	public IReadOnlyList<IInteractable> Inters => interactables;

	[SerializeField] private int capacity = 5;
	[SerializeField] private Transform container;
	[SerializeField] private bool isFakePlacing;

	private List<IInteractable> interactables; // OLD //////////////


	[Inject] private ActionPutInContainerByView put;
	private void Awake()
	{
		interactables = new List<IInteractable>(capacity: capacity);
	}
	public void Add(IInteractable inter)
	{
		if (CanAdd(inter) == false) return;
		// item.IsDone Проверка на возможность сдать, решается в правиле конфига
		if (isFakePlacing == false) // OLD //////////////
		{
			if (inter.TryGetCapability<IPortable>(out var portable))
			{
				portable.Put(container);
				interactables.Add(inter);
			}
		}
		else
		{
			if (inter.TryGetCapability<IItem>(out var item))
			{
				interactables.Add(inter);
			}
		}
	}

	public bool CanAdd(IInteractable inter)
	{
		if (interactables.Count >= capacity) return false;
		if (!inter.TryGetCapability<IItem>(out var item) || item.IsServable == false) return false;
		Debug.Log(interactables.Count);
		return true;
	}

	public IEnumerable<IGameAction> GetActionsByCapability()
	{
		yield return put;
	}

	public bool TryGetContent(out List<IInteractable> content)
	{
		content = this.interactables;

		if (this.interactables.Count == 0)
			return false;
		return true;
	}
	//private void RefreshView()
	//{
	//	if (currentView != null)
	//	{
	//		Destroy(currentView);
	//		//currentView.SetActive(false);
	//		currentView = null;
	//	}

	//	GameObject prefab = null;

	//	if (config != null && config.TryGetView(stateFlags, out var cfgPrefab))
	//		prefab = cfgPrefab;

	//	if (prefab == null && config != null && config.TryGetView(ItemStateFlags.None, out var nonePrefab))
	//		prefab = nonePrefab;

	//	if (prefab == null)
	//		prefab = defaultViewPrefab;

	//	if (prefab == null) return;

	//	currentView = Instantiate(prefab, viewRoot);
	//	currentView.transform.localPosition = Vector3.zero;
	//	currentView.transform.localRotation = Quaternion.identity;
	//}
}
