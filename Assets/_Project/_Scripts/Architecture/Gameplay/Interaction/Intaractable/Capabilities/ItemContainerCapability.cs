using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ItemContainerCapability : MonoBehaviour, IItemContainer, IActionProvider
{
    public IReadOnlyList<IInteractable> Inters => interactables;

	[SerializeField] private int capacity = 5;
    [SerializeField] private Transform container;

    private List<IInteractable> interactables;


	[Inject] private ActionPutInContainer put;
	private  void Awake()
	{
		interactables = new List<IInteractable>(capacity: capacity);
	}
	public void Add(IInteractable inter)
	{
		if (CanAdd(inter) == false) return;

		if (inter.TryGetCapability<IPortable>(out var portable))
		{
			portable.Put(container);
			interactables.Add(inter);
		}
	}

    public bool CanAdd(IInteractable inter)
    {
        if (interactables.Count >= capacity) return false;
        if(!inter.TryGetCapability<IItem>(out var item) || item.IsServable == false) return false;
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
}
