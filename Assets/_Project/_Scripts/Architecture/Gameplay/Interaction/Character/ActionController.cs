using UnityEngine;
using Zenject;

// Можно сделать тоже интерактаблом
public class ActionController : MonoBehaviour, ISlot 
{
    [SerializeField] private Transform handsInventory;
    [SerializeField] private InteractTriggerBase interractionTrigger;

    public ActionRunner runner;
    private IActionResolver actionResolver;

    public Transform Container => handsInventory;

    [Inject]
    public void Construct(ActionRunner runner,
        IActionResolver actionResolver)
    {
        this.runner = runner;
        this.actionResolver = actionResolver;
    }

    public void OnInteractDown1() => // Можно обобщить
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
        slot: this,
        candidates: interractionTrigger.Candidates,
        button: buttonId);

        var resolvedAction = actionResolver.Resolve(ctx);
        if (!resolvedAction.HasValue) return;

        if (resolvedAction.Value.Action is IActionHold hold)
            runner.StartHold(ctx, hold, resolvedAction.Value.Target);
        else
            runner.Run(ctx, resolvedAction.Value.Action, resolvedAction.Value.Target);
    }

    public bool TryGetContentAs<T>(out T portable)
    {
        if (handsInventory.childCount > 0
            && handsInventory.GetChild(0)
            .TryGetComponent(out portable)) return true;

        portable = default(T);
        return false;
    }
    public bool TryGetCapability<T>(out T cap) where T : class
    {
        cap = default(T);
        return false;
    }
}
