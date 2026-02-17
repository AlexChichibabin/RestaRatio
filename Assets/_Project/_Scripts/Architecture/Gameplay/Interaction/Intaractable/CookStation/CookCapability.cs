using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class CookCapability : MonoBehaviour, ICookStation, IActionProvider
{
    private ActionRoast roast;

    [Inject]
    public void Construct(ActionRoast roast)
    {
        this.roast = roast;
    }
    public IEnumerable<IGameAction> GetActionsByCapability()
    {
        yield return roast;
    }
    public void FinishCook(IItem item)
    {
        item.SetState(ItemStateFlags.Roasted);
        Debug.Log("Ингридиент пожарен");
    }
}
