using UnityEngine;
using Zenject;



public class ActionController : MonoBehaviour
{
    [SerializeField] private InventoryHands handsInventory;
    [SerializeField] private InteractTriggerBase interractionTrigger;

    public ActionRunner runner;
    private IActionResolver actionResolver;

    [Inject]
    public void Construct(ActionRunner runner,
        IActionResolver actionResolver)
    {
        this.runner = runner;
        this.actionResolver = actionResolver;
    }

    public void OnInteractDown1() =>
        InteractDown(buttonId: ButtonId.Button1);
    public void OnInteractDown2() =>
        InteractDown(buttonId: ButtonId.Button2);

    private void InteractDown(ButtonId buttonId)
    {
        if (interractionTrigger.Candidates == null
            || interractionTrigger.Candidates.Count == 0) return;

        Debug.Log("Interact " + buttonId);

        var ctx = new ActionContext(
        actor: gameObject,
        itemSlot: handsInventory,
        candidates: interractionTrigger.Candidates,
        button: buttonId);

        var resolvedAction = actionResolver.Resolve(ctx);
        if (!resolvedAction.HasValue) return;

        if (resolvedAction.Value.Action is IActionHold hold)
            runner.StartHold(ctx, hold);
        else
            runner.Run(ctx, resolvedAction.Value.Action, resolvedAction.Value.Target);
    }
}
