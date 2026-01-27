using System;
using UniRx;
using UnityEngine;

public interface IInputService
{
	IReadOnlyReactiveProperty<bool> Enabled { get; }
	IObservable<Vector2> MoveAxis { get; }
	IObservable<Unit> InteractDown1 { get; }
    IObservable<Unit> InteractDown2 { get; }
    void EnableGameplay();
	void DisableGameplay();
}
