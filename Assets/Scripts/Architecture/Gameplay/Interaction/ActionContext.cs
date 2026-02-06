using System.Collections.Generic;
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
    public ISlot Slot;
    /// <summary>
    /// What we interact to
    /// </summary>
    public IList<IInteractable> Candidates;
    /// <summary>
    /// What button has been pressed
    /// </summary>
    public ButtonId Button;

    public ActionContext(
        GameObject actor, 
        ISlot slot,
		IList<IInteractable> candidates, 
        ButtonId button)
    {
        Actor = actor;
        Slot = slot;
		Candidates = candidates;
        Button = button;
    }
}
