using UnityEngine;
using Zenject;



public class ActionController : MonoBehaviour
{
    [SerializeField] private InventoryHands handsInventory;
    [SerializeField] private InterationTrigger interractionTrigger;

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
        if (interractionTrigger.Interactable == null) return;

        Debug.Log("Interact " + buttonId);

        var ctx = new ActionContext(
        actor: gameObject,
        inventory: handsInventory,
        target: interractionTrigger.Interactable,
        point: handsInventory.transform.position,
        button: buttonId);

        var action = actionResolver.Resolve(ctx);
        if (action == null) return;

        if (action is IActionHold hold)
            runner.StartHold(ctx, hold);
        else
            runner.Run(ctx, action);
    }
}
