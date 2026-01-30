using System;
using UniRx;
using UnityEngine;

public sealed class ActionPut : IGameAction
{
	public string Id => "put";
	public int Priority => 50;

    public bool CanExecute(ActionContext ctx)
    {
        if (ctx.Interactable == null) return false;
        if (ctx.Interactable.Flags.HasFlag(InteractableFlags.ItemSlot)
            && ctx.Interactable.TryGetCapability<IItemSlot>(out var slot))
        {
            return !slot.HasItem
                && ctx.ItemSlot.HasItem
                && ctx.Button == ButtonId.Button1;
        }
        return false;
    }

    public void Execute(ActionContext ctx)
    {
        var itemGo = ctx.ItemSlot.Container.GetChild(0);

        if (itemGo == null) return;

        if (itemGo.TryGetComponent(out IItem item))
        {
            if (ctx.Interactable.TryGetCapability<IItemSlot>(out var place))
            {
                item.Put(place.Container);
            }
        }



        //Observable
        //	.EveryUpdate()
        //	.TakeWhile(_ => item.parent == ctx.Target.ItemContainer)
        //	.Select(rb => item.GetComponent<Rigidbody>())
        //	.Subscribe(rb => 
        //		{
        //			if (rb == null) return;

        //			Vector3 targetPos = ctx.Target.ItemContainer.position;
        //			Vector3 targetVel = Vector3.zero;

        //			Vector3 pos = rb.position;
        //			Vector3 vel = rb.linearVelocity;

        //			float spring = 120f; 
        //			float damper = 18f;    

        //			Vector3 force = (targetPos - pos) * spring + (targetVel - vel) * damper;
        //			rb.AddForce(force, ForceMode.Force);

        //			if(Vector3.Distance(targetPos, pos) > 0.5) item.SetParent(ctx.Target.ItemContainer.parent.parent);
        //		})
        //	.AddTo(item);
    }
}

