using System.Collections.Generic;
using UnityEngine;

public class PortableInteractable : BaseInteractable
{
    private ActionDrop drop;
    private ActionTakePortable takeItem;

    public override IEnumerable<IGameAction> GetActions(ActionContext ctx)
    {
        if (drop != null) yield return drop;
        if (takeItem != null) yield return takeItem;

    }
}
