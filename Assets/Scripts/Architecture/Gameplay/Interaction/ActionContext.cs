using UnityEngine;

public sealed class ActionContext
{
    public GameObject Actor;
    //public IInventory Inventory;
    public IInteractable Target;     // ближайший объект/станция
    public Vector3 Point;            // точка взаимодействия
    public IActionServices S;        // сервисы (audio, orders, vfx, etc.)

    public ActionContext(
        GameObject actor, /*IInventory inventory,*/
        IInteractable target, Vector3 point,
        IActionServices services)
    {
        Actor = actor;
        //Inventory = inventory;
        Target = target;
        Point = point;
        S = services;
    }
}
