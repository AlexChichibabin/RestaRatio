using System.Collections.Generic;
using UnityEngine;

public class PortableInteractable : InteractableBase
{
    private ActionDrop drop;
    private ActionTakeItem takeItem;

    public override IEnumerable<IGameAction> GetActions(ActionContext ctx)
    {
        if (drop != null) yield return drop;
        if (takeItem != null) yield return takeItem;

    }
}
