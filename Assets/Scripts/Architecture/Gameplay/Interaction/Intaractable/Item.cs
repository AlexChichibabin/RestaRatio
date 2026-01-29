using System.Collections.Generic;
using UnityEngine;

public class Item : InteractableBase, IItem
{
    private Rigidbody rb;
	private Collider[] cols;

    public Transform Parent => transform.parent;

    // действие взять
    // действие положить

    protected override void Awake()
	{
		base.Awake();

		rb = GetComponent<Rigidbody>();
		cols = GetComponentsInChildren<Collider>();
	}

	public void Take(Transform hand)
	{
		//rb.linearVelocity = Vector3.zero;
		//rb.angularVelocity = Vector3.zero;
		rb.isKinematic = true;

		foreach (var c in cols)
			c.enabled = false;

		transform.SetParent(hand, false);
		transform.localPosition = Vector3.zero;
		transform.localRotation = Quaternion.identity;
	}

	public void Put(Transform place)
	{
		rb.isKinematic = true;

		foreach (var c in cols)
			c.enabled = true;

		transform.SetParent(place, false);
		transform.localPosition = Vector3.zero;
		transform.localRotation = Quaternion.identity;
	}
	public void Drop(Transform world)
	{
		rb.isKinematic = false;
		rb.linearVelocity = Vector3.zero;
		rb.angularVelocity = Vector3.zero;

		foreach (var c in cols)
			c.enabled = true;

		transform.SetParent(world, false);
	}

	public override IEnumerable<IGameAction> GetActions(ActionContext ctx)
    {
        throw new System.NotImplementedException();

        // return действие взять
        // return действие положить
    }
}
