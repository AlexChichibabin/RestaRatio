using System.Collections.Generic;
using UnityEngine;

public interface IInteractable : IInventory, ITargetPriority
{
    abstract IEnumerable<IGameAction> GetActions(ActionContext ctx);
}
