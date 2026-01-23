using System;
using UniRx;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputService : IInputService, IDisposable
{
	public IReadOnlyReactiveProperty<bool> Enabled => enabled;
	public IObservable<Vector2> MoveAxis =>
		moveAxis.Where(_ => enabled.Value).StartWith(Vector2.zero);
	public IObservable<Unit> InteractDown =>
		interactDown.Where(_ => enabled.Value);


    private PlayerInputActions input;

	private ReactiveProperty<bool> enabled = new(true);
	private Subject<Vector2> moveAxis = new();
	private Subject<Unit> interactDown = new();
    //private Subject<Unit> interactUp = new();

    private CompositeDisposable disposables = new();

	public InputService(PlayerInputActions input)
	{
		this.input = input;

		this.input.Gameplay.Move.performed += OnMove;
		this.input.Gameplay.Move.canceled += OnMoveCanceled;
		this.input.Gameplay.Interaction.performed += OnInteractPerformed;

		enabled
			.Where(x => x == false)
			.Subscribe(_ => moveAxis.OnNext(Vector2.zero))
			.AddTo(disposables);
	}

	public void EnableGameplay() => input.Gameplay.Enable();
	public void DisableGameplay() => input.Gameplay.Disable();

	private void OnMove(InputAction.CallbackContext context)
		=> moveAxis.OnNext(context.ReadValue<Vector2>());

	private void OnMoveCanceled(InputAction.CallbackContext context)
		=> moveAxis.OnNext(Vector2.zero);

	private void OnInteractPerformed(InputAction.CallbackContext context)
	{
		interactDown.OnNext(Unit.Default);
	}

	public void Dispose()
	{
		input.Gameplay.Move.performed -= OnMove;
		input.Gameplay.Move.canceled -= OnMoveCanceled;
		input.Gameplay.Interaction.performed -= OnInteractPerformed;

		disposables.Dispose();
		moveAxis.Dispose();
		interactDown.Dispose();
		enabled.Dispose();
	}
}
