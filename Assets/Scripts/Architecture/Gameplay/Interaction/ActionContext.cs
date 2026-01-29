using UnityEngine;

public sealed class ActionContext
{
    /// <summary>
    /// Who wants to do action
    /// </summary>
    public GameObject Actor;
    /// <summary>
    /// Actor's inventory (his hands)
    /// </summary>
    public IItemSlot ItemSlot;
    /// <summary>
    /// What we interact to
    /// </summary>
    public IInteractable Interactable;
    /// <summary>
    /// What button has been pressed
    /// </summary>
    public ButtonId Button;

    public ActionContext(
        GameObject actor, 
        IItemSlot itemSlot,
        IInteractable interactable, 
        ButtonId button)
    {
        Actor = actor;
        ItemSlot = itemSlot;
        Interactable = interactable;
        Button = button;
    }
}
