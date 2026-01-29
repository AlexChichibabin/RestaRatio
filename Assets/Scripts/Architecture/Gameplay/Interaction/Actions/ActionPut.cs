using System;
using UniRx;
using UnityEngine;

public sealed class ActionPut : IGameAction
{
	public string Id => "put";
	public int Priority => 50;

	public bool CanExecute(ActionContext ctx)
	{
		return ctx.Inventory.HasItem 
			&& !ctx.Target.HasItem 
			&& ctx.Target is StaticInteractable 
			&& ctx.Button == ButtonId.Button1;
	}

	public void Execute(ActionContext ctx)
	{
		var item = ctx.Inventory.ItemContainer.GetChild(0);
		if (item == null) return;
		Pickupable pu = item.GetComponent<Pickupable>();
		if (pu != null)
		{
			pu.Put(ctx.Target.ItemContainer);
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
			//
		else
		{
			item.SetParent(ctx.Target.ItemContainer, false);
			item.SetLocalPositionAndRotation(Vector3.zero, Quaternion.identity);
		}
	}
}

