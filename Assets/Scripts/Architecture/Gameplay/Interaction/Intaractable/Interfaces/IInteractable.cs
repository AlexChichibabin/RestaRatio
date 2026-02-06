using System.Collections.Generic;
using UnityEngine;

public interface IInteractable : IHasCapabilities
{
    abstract IEnumerable<IGameAction> GetActions(ActionContext ctx);
    int Priority { get; }
    InteractableFlags Flags { get; }
    Vector3 Position { get; }
}
