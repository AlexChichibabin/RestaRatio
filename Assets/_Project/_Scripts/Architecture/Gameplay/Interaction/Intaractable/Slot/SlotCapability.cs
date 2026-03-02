using System;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using Zenject;

public class SlotCapability : MonoBehaviour, ISlot, IActionProvider
{
    public Transform Container => itemContainer;
    public IObservable<Unit> PutEvent => putEvent;
    public IObservable<Unit> RemoveEvent => removeEvent;

    [SerializeField] protected Transform itemContainer;

    private Subject<Unit> putEvent;
    private Subject<Unit> removeEvent;

    private ActionPutOnSlot putDown;
    private ActionTakeFromSlot take;

    public bool TryGetContentAs<T>(out T portable)
    {
        if (itemContainer.childCount > 0
            && itemContainer.GetChild(0).TryGetComponent(out portable)) return true;

        portable = default(T);
        return false;
    }

    [Inject]
    public void Construct(ActionPutOnSlot putDown, ActionTakeFromSlot take)
    {
        this.putDown = putDown;
        this.take = take;
    }

    public IEnumerable<IGameAction> GetActionsByCapability()
    {
        yield return putDown;
        yield return take;
    }

}
