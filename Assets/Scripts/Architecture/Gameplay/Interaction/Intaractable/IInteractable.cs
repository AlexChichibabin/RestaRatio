using System.Collections.Generic;
using UnityEngine;

public interface IInteractable : IInventory
{
    IEnumerable<IGameAction> GetActions(ActionContext ctx);
}
