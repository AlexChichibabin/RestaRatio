using System;
using UniRx;
using UnityEngine;

public class CookRxCapability : MonoBehaviour, ICookRxStation
{
	public IObservable<float> HeatTick => heatTick;

	[SerializeField] private float heatPerSecond = 1.0f;

	private IInteractable interactable;

	private Subject<float> heatTick = new();

	private CompositeDisposable disposables = new();

	private void Start()
	{
		interactable = GetComponent<Interactable>();
		interactable.TryGetCapability<ISlot>(out var slot);

		Observable
			.EveryUpdate()
			.Select(_ => heatPerSecond * Time.deltaTime)
			.Subscribe(_ =>
			{
				heatTick.OnNext(_);
			})
			.AddTo(disposables);
	}


	public void Dispose() => disposables.Dispose();
}
