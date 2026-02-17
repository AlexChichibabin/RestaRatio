using System.Collections.Generic;
using System.Linq;
using UniRx;
using UnityEngine;

public class InteractionRaycastTrigger : InteractTriggerBase
{
	public override IList<IInteractable> Candidates => candidates;

	[SerializeField] private CharacterController characterController;
    [SerializeField] private float radius = 0.8f;
    [SerializeField] private LayerMask interactableMask = ~0; // ¬се интерактаблы должны быть на слое Interactable
    [SerializeField] private int maxHits = 16;

    private readonly HashSet<IInteractable> set = new();
    private Collider[] hits;
	private List<IInteractable> candidates;

	private CompositeDisposable disposables = new();

	private void Awake()
    {
        hits = new Collider[maxHits];
    }
	private void OnEnable()
	{
		SubscribeTargeting();
	}
	private void OnDisable()
	{
		disposables.Clear();
	}
	private void SubscribeTargeting()
	{
		Observable
			.EveryUpdate()
			.Subscribe(_ =>
			{
				set.Clear();

				var cc = characterController;

				Vector3 centerWorld = cc.transform.TransformPoint(cc.center);
				float half = Mathf.Max(0f, cc.height * 0.5f - cc.radius);
				Vector3 p1 = centerWorld + Vector3.up * half;
				Vector3 p2 = centerWorld - Vector3.up * half;

				int count = Physics.OverlapCapsuleNonAlloc(p2, p1, radius, hits, interactableMask);

				for (int i = 0; i < count; i++)
				{
					var collider = hits[i];
					if (!collider) continue;

					var inter = collider.GetComponentInParent<IInteractable>();
					if (inter == null) continue;

					set.Add(inter);
				}
				candidates = set.ToList();
				Debug.Log(candidates.Count);
			})
			.AddTo(disposables);
	}
}
