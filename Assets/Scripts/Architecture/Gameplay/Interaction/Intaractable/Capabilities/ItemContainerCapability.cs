using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ItemContainerCapability : MonoBehaviour, IItemContainer<IInteractable>, IActionProvider
{
    public IReadOnlyList<IInteractable> Items => interactables;

    [SerializeField] private int capacity = 5;
    [SerializeField] private Transform container;

    private List<IInteractable> interactables;

    [Inject] private ActionPutInContainer put;

    public void Add(IInteractable inter)
    {
        if (CanAdd(inter) == false) return;
        // item.IsDone Проверка на возможность сдать, решается в правиле конфига
        if (inter.TryGetCapability<IPortable>(out var portable))
        {
            portable.Put(container);
            interactables.Add(inter);
        }
    }

    public bool CanAdd(IInteractable inter)
    {
        //inter.TryGetCapability<>
        if (interactables.Count >= capacity) return false;
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
