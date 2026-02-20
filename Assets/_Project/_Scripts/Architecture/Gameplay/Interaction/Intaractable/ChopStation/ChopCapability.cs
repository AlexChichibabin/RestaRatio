using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ChopCapability : MonoBehaviour, IChopStation, IActionProvider
{
    private ActionChop chop;

    [Inject]
    public void Construct(ActionChop chop)
    {
        this.chop = chop;
    }

    public IEnumerable<IGameAction> GetActionsByCapability()
    {
        yield return chop;
    }

    public void FinishChop(IItem item)
    {
        item.SetState(ItemStateFlags.Cutted);
        Debug.Log("Ингридиент нарезан");
    }
}
