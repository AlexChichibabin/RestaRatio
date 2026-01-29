using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Item : InteractableBase, IItem
{
    private Rigidbody rb;
	private Collider[] cols;

    public Transform Parent => transform.parent;

	private ActionDrop drop;
    // действие взять
    // действие положить

    protected override void Awake()
	{
		base.Awake();

		rb = GetComponent<Rigidbody>();
		cols = GetComponentsInChildren<Collider>();
	}
	[Inject]
	public void Construct(ActionDrop drop)
	{
		this.drop = drop;
	}

	public void Take(Transform hand)
	{
		//rb.linearVelocity = Vector3.zero;
		//rb.angularVelocity = Vector3.zero;
		rb.isKinematic = true;

		//foreach (var c in cols)
		//	c.enabled = false;

		transform.SetParent(hand, false);
		transform.localPosition = Vector3.zero;
		transform.localRotation = Quaternion.identity;
	}

	public void Put(Transform place)
	{
		rb.isKinematic = true;

		//foreach (var c in cols)
		//	c.enabled = true;

		transform.SetParent(place, false);
		transform.localPosition = Vector3.zero;
		transform.localRotation = Quaternion.identity;
	}
	public void Drop(Transform world)
	{
		rb.isKinematic = false;


		//foreach (var c in cols)
		//	c.enabled = true;

		transform.SetParent(world, true);
		rb.linearVelocity = Vector3.zero;
		rb.angularVelocity = Vector3.zero;
	}

	public override IEnumerable<IGameAction> GetActions(ActionContext ctx)
    {
		yield return drop;

		// return действие взять
		// return действие положить
	}
}
