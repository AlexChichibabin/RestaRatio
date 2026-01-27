using UnityEngine;

public sealed class ActionContext
{
    public GameObject Actor;
    public IInventory Inventory;
    public IInteractable Target;
    public Vector3 Point;

    public ActionContext(
        GameObject actor, 
        IInventory inventory,
        IInteractable target, 
        Vector3 point)
    {
        Actor = actor;
        Inventory = inventory;
        Target = target;
        Point = point;
    }
}
