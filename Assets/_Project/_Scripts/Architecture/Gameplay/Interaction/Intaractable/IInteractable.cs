using System.Collections.Generic;
using UnityEngine;

public interface IInteractable : IHasCapabilities
{
    IEnumerable<IGameAction> GetActions();
    int Priority { get; }
    InteractableFlags Flags { get; }
    Vector3 Position { get; }
}
