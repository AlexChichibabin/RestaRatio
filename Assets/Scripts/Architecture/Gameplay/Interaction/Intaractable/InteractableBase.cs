using System.Collections.Generic;
using UnityEngine;

public abstract class InteractableBase : MonoBehaviour, IInteractable//, ITargetPriority
{
    [SerializeField] private int priority = 0;
    public int Priority => priority;
    public virtual string DisplayName => gameObject.name;

    abstract public bool HasItem { get; }
    abstract public Transform ItemContainer { get; }

    public abstract IEnumerable<IGameAction> GetActions(ActionContext ctx);
}
