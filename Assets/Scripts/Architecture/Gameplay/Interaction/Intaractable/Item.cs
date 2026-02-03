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
[Flags]
public enum ItemStateFlags
{
    None = 0,
    Cutted = 1 << 0,
    Roasted = 1 << 1,
    Baked = 1 << 2
}

public class Item : InteractableBase, IItem
{
    public Transform Parent => transform.parent;
    public ItemAbilityFlags ItemFlags => config != null ? config.Abilities : itemFlags;
    public ItemStateFlags State => stateFlags;

    [Header("Data")]
    [SerializeField] private ItemConfig config;

    [SerializeField] private ItemAbilityFlags itemFlags; 
    [SerializeField] private ItemStateFlags stateFlags;       

    [Header("View")]
    [SerializeField] private Transform viewRoot;         
    [SerializeField] private GameObject defaultViewPrefab; 

    private GameObject currentView;

    private Rigidbody rb;
    private Collider[] cols;

    private ActionDrop drop;
    private ActionTakeItem takeItem;

    protected override void Awake()
    {
        base.Awake();

        rb = GetComponent<Rigidbody>();
        cols = GetComponentsInChildren<Collider>();

        if (viewRoot == null) viewRoot = transform;

        RefreshView();
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

    public bool HasState(ItemStateFlags s) => (stateFlags & s) == s;

    public void AddState(ItemStateFlags s)
    {
        if (HasState(s)) return;

        stateFlags |= s;

      
        RefreshView();
    }

    public void SetState(ItemStateFlags s)
    {
        stateFlags = s;

        if (stateFlags.HasFlag(ItemStateFlags.Cutted)) itemFlags |= ItemAbilityFlags.Roastable; // Testing
        RefreshView();
    }

    private void RefreshView()
    {
        if (currentView != null)
        {
            Destroy(currentView);
            //currentView.SetActive(false);
            currentView = null;
        }

        GameObject prefab = null;

        if (config != null && config.TryGetView(stateFlags, out var cfgPrefab))
            prefab = cfgPrefab;

        if (prefab == null && config != null && config.TryGetView(ItemStateFlags.None, out var nonePrefab))
            prefab = nonePrefab;

        if (prefab == null)
            prefab = defaultViewPrefab;

        if (prefab == null) return;

        currentView = Instantiate(prefab, viewRoot);
        currentView.transform.localPosition = Vector3.zero;
        currentView.transform.localRotation = Quaternion.identity;
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

    public override IEnumerable<IGameAction> GetActions(ActionContext ctx)
    {
        if (drop != null) yield return drop;
        if (takeItem != null) yield return takeItem;
    }
}