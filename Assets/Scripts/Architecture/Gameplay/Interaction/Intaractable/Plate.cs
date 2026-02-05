using System.Collections.Generic;
using UnityEngine;

public class Plate : InteractableBase
{
    //public bool TryGetItem(out IItem item)
    //{
    //    //if (itemContainer.childCount > 0
    //    //    && itemContainer.GetChild(0).TryGetComponent(out item)) return true;

    //    //item = null;
    //    return false;
    //}

    List<GameObject> Items => throw new System.NotImplementedException();

    public void Add(GameObject item)
    {
        throw new System.NotImplementedException();
    }

    public bool CanAdd(GameObject item)
    {
        throw new System.NotImplementedException();
    }

    public bool CanTake()
    {
        throw new System.NotImplementedException();
    }

    public override IEnumerable<IGameAction> GetActions(ActionContext ctx)
    {
        throw new System.NotImplementedException();
    }

    public GameObject Take()
    {
        throw new System.NotImplementedException();
    }

}
