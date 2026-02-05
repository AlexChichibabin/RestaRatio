using System;
using System.Collections.Generic;
using UnityEngine;

[Flags]
public enum InteractableFlags
{
    None = 0,
    Item = 1 << 0,
    ItemSlot = 1 << 1,
    Container = 1 << 2,
    CookStation = 1 << 3,
    ChopStation = 1 << 4,
    ServePoint = 1 << 5,
    Trash = 1 << 6,
}

public abstract class InteractableBase : MonoBehaviour, IInteractable
{
    public int Priority => priority;
    public virtual string DisplayName => gameObject.name;
    public InteractableFlags Flags => flags;
	public Vector3 Position => transform.position;
	public abstract IEnumerable<IGameAction> GetActions(ActionContext ctx);

    [SerializeField] private int priority = 0;
    [SerializeField] private InteractableFlags flags;

    private readonly Dictionary<Type, object> capabilities = new();

    protected virtual void Awake()
    {
        foreach (var comp in GetComponents<MonoBehaviour>())
        {
            var type = comp.GetType();
            foreach (var i in type.GetInterfaces())
                capabilities[i] = comp;
        }
    }

    public bool TryGetCapability<T>(out T cap) where T : class
    {
        if (capabilities.TryGetValue(typeof(T), out var obj))
        {
            cap = obj as T;
            return cap != null;
        }
        cap = null;
        return false;
    }
}
