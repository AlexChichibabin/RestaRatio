using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using Zenject;

public class Plate : BaseInteractable, IPortable
{
	private Rigidbody rb;
	private Collider[] cols;


	private ActionDrop drop;
	private ActionTakePortable takeItem;
	//public bool TryGetItem(out IItem item)
	//{
	//    //if (itemContainer.childCount > 0
	//    //    && itemContainer.GetChild(0).TryGetComponent(out item)) return true;

	//    //item = null;
	//    return false;
	//}

	List<GameObject> Items => throw new System.NotImplementedException();

	public Transform Parent => transform.parent;

	protected override void Awake()
	{
		base.Awake();

		rb = GetComponent<Rigidbody>();
		cols = GetComponentsInChildren<Collider>();
	}

	[Inject]
	public void Construct(
		ActionDrop drop,
		ActionTakePortable takeItem
	)
	{
		this.drop = drop;
		this.takeItem = takeItem;
	}

	public void Add(GameObject item)
    {
        throw new System.NotImplementedException();
    }

    public bool CanAdd(GameObject item)
    {
        throw new System.NotImplementedException();
    }

	public override IEnumerable<IGameAction> GetActions(ActionContext ctx)
    {
		if (drop != null) yield return drop;
		if (takeItem != null) yield return takeItem;
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
}
