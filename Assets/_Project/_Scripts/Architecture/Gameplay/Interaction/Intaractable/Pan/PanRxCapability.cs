//using System;
//using UniRx;
//using UnityEngine;

//[RequireComponent(typeof(Interactable))]
//public class PanRxCapability : MonoBehaviour
//{
//	private IInteractable interactable;

//	private CompositeDisposable disposables;
//	private ICookRxStation currentStation;

//	private void Awake()
//	{
//		interactable = GetComponent<Interactable>();
//	}
//	public void PlaceOnStation(ICookRxStation station)
//	{
//		RemoveFromStation();

//		currentStation = station;

//		heatSubscription = station.HeatTick
//			.Subscribe(heat => ApplyHeat(heat));
//	}

//	public void RemoveFromStation()
//	{
//		disposables?.Clear();
//		//heatSubscription = null;
//		currentStation = null;
//	}

//	private void ApplyHeat(float heat)
//	{
//		if (container == null) return;

//		foreach (var inter in container.Items)
//		{
//			if (inter.TryGetCapability<ICookable>(out var cookable))
//			{
//				cookable.AddHeat(heat);
//			}
//		}
//	}

//	private void OnDestroy()
//	{
//		heatSubscription?.Dispose();
//	}
//}
