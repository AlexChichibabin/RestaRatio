using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using Zenject;

public class Plate : BaseInteractable, IPortable, IItemContainer
{
    public Transform Parent => transform.parent;
    public IReadOnlyList<IItem> Items => items;


    [SerializeField] private int capacity = 5;
	[SerializeField] private Transform container;

	private Rigidbody rb;
	private Collider[] cols;

	private ActionDrop drop;
	private ActionTakePortable takeItem;
	private ActionPutInContainer putInContainer;


    private List<IItem> items;

    protected override void Awake()
	{
		base.Awake();

		rb = GetComponent<Rigidbody>();
		cols = GetComponentsInChildren<Collider>();

        items = new List<IItem>(capacity: capacity);
    }

	[Inject]
	public void Construct(
		ActionDrop drop,
		ActionTakePortable takeItem,
        ActionPutInContainer putInContainer
	)
	{
		this.drop = drop;
		this.takeItem = takeItem;
		this.putInContainer = putInContainer;
	}
    public bool TryGetItems(out List<IItem> items)
    {
        items = this.items;

        if (this.items.Count == 0)
			return false;
		return true;
    }

    public void Add(IItem item)
    {
		if (CanAdd(item) == false) return;
        // item.IsDone Проверка на возможность сдать, решается в правиле конфига
		if (item.TryGetCapability<IPortable>(out var portable))
		{
			portable.Put(container);
			items.Add(item);
        }	
    }

    public bool CanAdd(IItem item)
    {
        if (items.Count >= capacity) return false;
		Debug.Log(items.Count);
        return true;
    }

	public override IEnumerable<IGameAction> GetActions(ActionContext ctx)
    {
		if (drop != null) yield return drop;
		if (takeItem != null) yield return takeItem;
        if (putInContainer != null) yield return putInContainer;
    }

    #region IPortable
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
    #endregion
}
