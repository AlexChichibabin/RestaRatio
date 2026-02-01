using System.Collections.Generic;
using UnityEngine;

public interface IInteractable
{
    abstract IEnumerable<IGameAction> GetActions(ActionContext ctx);
    int Priority { get; }
    InteractableFlags Flags { get; }
    bool TryGetCapability<T>(out T cap) where T : class;
    Vector3 Position { get; }
}
