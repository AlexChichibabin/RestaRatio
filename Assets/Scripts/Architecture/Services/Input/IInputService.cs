using System;
using UniRx;
using UnityEngine;

public interface IInputService
{
	IReadOnlyReactiveProperty<bool> Enabled { get; }
	IObservable<Vector2> MoveAxis { get; }
	IObservable<Unit> InteractDown { get; }
    //IObservable<Unit> InteractUp { get; }
    void EnableGameplay();
	void DisableGameplay();
}
