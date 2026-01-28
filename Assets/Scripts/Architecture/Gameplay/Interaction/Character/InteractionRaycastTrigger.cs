using System.Collections.Generic;
using UnityEngine;

public class InteractionRaycastTrigger : InteractTriggerBase // TODO
{
    public override IInteractable Interactable => current;

    [SerializeField] private CharacterController characterController;
    [SerializeField] private float radius = 0.8f;
    [SerializeField] private LayerMask interactableMask = ~0;
    [SerializeField] private int maxHits = 32;

    private readonly HashSet<IInteractable> set = new();
    private Collider[] hits;
    private IInteractable current;

    private void Awake()
    {
        hits = new Collider[maxHits];
    }

    private void Update()
    {
        set.Clear();
        current = null;

        var cc = characterController;

        Vector3 centerWorld = cc.transform.TransformPoint(cc.center);
        float half = Mathf.Max(0f, cc.height * 0.5f - cc.radius);
        Vector3 p1 = centerWorld + Vector3.up * half;
        Vector3 p2 = centerWorld - Vector3.up * half;

        int count = Physics.OverlapCapsuleNonAlloc(p2, p1, radius, hits, interactableMask);

        for (int i = 0; i < count; i++)
        {
            var col = hits[i];
            if (!col) continue;

            var inter = col.GetComponentInParent<IInteractable>();
            if (inter == null) continue;

            set.Add(inter);
        }

        float bestDist = float.PositiveInfinity;

        foreach (var inter in set)
        {
            if (current == null)
            {
                current = inter;
                bestDist = DistanceSqr(inter);
                continue;
            }

            if (inter.Priority > current.Priority)
            {
                current = inter;
                bestDist = DistanceSqr(inter);
            }
            else if (inter.Priority == current.Priority)
            {
                float d = DistanceSqr(inter);
                if (d < bestDist)
                {
                    current = inter;
                    bestDist = d;
                }
            }
        }
    }

    private float DistanceSqr(IInteractable inter)
    {
        var mb = (MonoBehaviour)inter;
        return (mb.transform.position - characterController.transform.position).sqrMagnitude;
    }
}
