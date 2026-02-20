using System.Collections.Generic;
using UniRx;
using UnityEngine;
using Zenject;

public class PlateView : MonoBehaviour
{
	[SerializeField] private Transform contentRoot;
	[SerializeField] private float radius = 0.12f; 
	[SerializeField] private float yOffset = 0.01f; 
	[SerializeField] private bool randomYaw = true;

	[Inject] private IPlateItemViewFactory factory;
	private readonly List<GameObject> spawned = new();
	private ItemContainerOnViewCapability containerCap;

	private void Start()
	{
		if (contentRoot == null) contentRoot = transform;
		containerCap = GetComponent<ItemContainerOnViewCapability>();
		containerCap.Datas
			.ObserveAdd()
			.Subscribe(_ => Render(containerCap.Datas))
			.AddTo(gameObject);
	}

	private void Render(IReactiveCollection<ItemData> contents)
	{
		Clear();
		Debug.Log("dgsdfg");
		int count = contents?.Count ?? 0;
		if (count == 0) return;

		Vector3[] positions = GetLocalPositions(count);

		for (int i = 0; i < count; i++)
		{
			var view = factory.CreateView(contents[i]);
			if (view == null) continue;

			view.transform.SetParent(contentRoot, false);

			Vector3 pos = positions[Mathf.Min(i, positions.Length - 1)];
			pos *= radius;
			pos.y += yOffset;

			view.transform.localPosition = pos;

			if (randomYaw)
				view.transform.localRotation = Quaternion.Euler(0f, Random.Range(0f, 360f), 0f);
			else
				view.transform.localRotation = Quaternion.identity;

			spawned.Add(view);
		}
	}

	private void Clear()
	{
		for (int i = 0; i < spawned.Count; i++)
		{
			if (spawned[i] != null) Destroy(spawned[i]);
		}
		spawned.Clear();
	}

	private static Vector3[] GetLocalPositions(int count)
	{
		switch (count)
		{
			case 1:
				return new[] { Vector3.zero };

			default:
				var result = new Vector3[count];
				float step = 360f / count;
				float start = 90f;
				for (int i = 0; i < count; i++)
					result[i] = DirFromAngleDeg(start + step * i);
				return result;
		}
	}

	private static Vector3 DirFromAngleDeg(float deg)
	{
		float rad = deg * Mathf.Deg2Rad;
		return new Vector3(Mathf.Cos(rad), 0f, Mathf.Sin(rad));
	}
}