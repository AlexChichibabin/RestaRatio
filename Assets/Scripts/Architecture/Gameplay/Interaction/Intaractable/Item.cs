using System.Collections.Generic;
using UnityEngine;
using Zenject;
using System;

[Flags]
public enum ItemAbilityFlags
{
	None = 0,
	Cuttable = 1 << 0,
	Roastable = 1 << 1,
	Bakable = 1 << 2
}

public class Item : InteractableBase, IItem
{
	public Transform Parent => transform.parent;
	public ItemAbilityFlags ItemFlags => itemFlags;

	[SerializeField] private ItemAbilityFlags itemFlags;

    private Rigidbody rb;
	private Collider[] cols;

	private ActionDrop drop;
	private ActionTakeItem takeItem;

    protected override void Awake()
	{
		base.Awake();

		rb = GetComponent<Rigidbody>();
		cols = GetComponentsInChildren<Collider>();
	}
	[Inject]
	public void Construct(
		ActionDrop drop,
		ActionTakeItem takeItem
		)
	{
		this.drop = drop;
		this.takeItem = takeItem;
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
		yield return takeItem;
		// return действие взять
		// return действие положить
	}
}
