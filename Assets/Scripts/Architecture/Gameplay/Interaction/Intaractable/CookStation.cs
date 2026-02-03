using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class CookStation : StaticInteractable, ICookStation
{
    [Inject] ActionRoast roastHold;

    public override IEnumerable<IGameAction> GetActions(ActionContext ctx)
    {
        yield return putDown;
        yield return take;
        yield return roastHold;
    }
    public void FinishCook(IItem item)
    {
        item.SetState(ItemStateFlags.Roasted);
        Debug.Log("Ингридиент пожарен");
    }
}
