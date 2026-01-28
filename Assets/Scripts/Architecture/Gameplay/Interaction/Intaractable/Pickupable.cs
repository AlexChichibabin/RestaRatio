using System.Collections.Generic;
using UnityEngine;

public class Pickupable : InteractableBase//, IInteractable
{
    public override bool HasItem => true;
    public override Transform ItemContainer => null;

    private Rigidbody rb;
	private Collider[] cols;
	// действие взять
	// действие положить


    private void Awake()
	{
		rb = GetComponent<Rigidbody>();
		cols = GetComponentsInChildren<Collider>();
	}

	public void Take(Transform hand)
	{
		rb.linearVelocity = Vector3.zero;
		rb.angularVelocity = Vector3.zero;
		rb.isKinematic = true;

		foreach (var c in cols)
			c.enabled = false;

		transform.SetParent(hand, false);
		transform.localPosition = Vector3.zero;
		transform.localRotation = Quaternion.identity;
	}

	public void Put(Transform place/*, Vector3 impulse*/)
	{
		rb.isKinematic = false;
		rb.linearVelocity = Vector3.zero;
		rb.angularVelocity = Vector3.zero;

		foreach (var c in cols)
			c.enabled = true;

		transform.SetParent(place, false);
		transform.localPosition = Vector3.zero;
		transform.localRotation = Quaternion.identity;
		//transform.SetParent(null);

		//foreach (var c in cols)
		//	c.enabled = true;

		//rb.isKinematic = false;
		//rb.AddForce(impulse, ForceMode.Impulse);
	}

    public override IEnumerable<IGameAction> GetActions(ActionContext ctx)
    {
        throw new System.NotImplementedException();

        // return действие взять
        // return действие положить
    }
}
