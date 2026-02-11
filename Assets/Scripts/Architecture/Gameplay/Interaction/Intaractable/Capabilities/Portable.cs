using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Portable : MonoBehaviour, IPortable, IActionProvider
{
	public Transform Parent => transform.parent;

	private Rigidbody rb;
	private Collider[] cols;

	private ActionDrop drop;
	private ActionTakePortable takeItem;

	[Inject]
	public void Construct(
		ActionDrop drop,
		ActionTakePortable takeItem)
	{
		this.drop = drop;
		this.takeItem = takeItem;
	}
	protected void Awake()
	{
		rb = GetComponent<Rigidbody>();
		cols = GetComponentsInChildren<Collider>();

	}
	public void Take(Transform hand)
	{
		rb.isKinematic = true;

		transform.SetParent(hand, false);
		transform.localPosition = Vector3.zero;
		transform.localRotation = Quaternion.identity;
	}

	public void Put(Transform place)
	{
		rb.isKinematic = true;

		transform.SetParent(place, false);
		transform.localPosition = Vector3.zero;
		transform.localRotation = Quaternion.identity;
	}

	public void Drop(Transform world)
	{
		rb.isKinematic = false;

		transform.SetParent(world, true);
		rb.linearVelocity = Vector3.zero;
		rb.angularVelocity = Vector3.zero;
	}

    public IEnumerable<IGameAction> GetActionsByCapability()
    {
		yield return drop;
		yield return takeItem;
    }
}
