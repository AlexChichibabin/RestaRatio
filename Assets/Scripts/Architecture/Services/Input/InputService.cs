using System;
using UniRx;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputService : IInputService, IDisposable
{
	public IReadOnlyReactiveProperty<bool> Enabled => enabled;
	public IObservable<Vector2> MoveAxis =>
		moveAxis.Where(_ => enabled.Value == true).StartWith(Vector2.zero);
	public IObservable<Unit> InteractDown1 =>
		interactDown1.Where(_ => enabled.Value);
    public IObservable<Unit> InteractDown2 =>
        interactDown2.Where(_ => enabled.Value);

    private PlayerInputActions input;

	private ReactiveProperty<bool> enabled = new(true);
	private Subject<Vector2> moveAxis = new();
	private Subject<Unit> interactDown1 = new();
    private Subject<Unit> interactDown2 = new();

    private CompositeDisposable disposables = new();

	public InputService(PlayerInputActions input)
	{
		this.input = input;

		this.input.Gameplay.Move.performed += OnMove;
		this.input.Gameplay.Move.canceled += OnMoveCanceled;
		this.input.Gameplay.Interaction1.performed += OnInteract1Performed;
        this.input.Gameplay.Interaction2.performed += OnInteract2Performed;

        enabled
			.Where(x => x == false)
			.Subscribe(_ => moveAxis.OnNext(Vector2.zero))
			.AddTo(disposables);
	}

	public void EnableGameplay() => input.Gameplay.Enable();
	public void DisableGameplay() => input.Gameplay.Disable();

	private void OnMove(InputAction.CallbackContext context) =>
		moveAxis.OnNext(context.ReadValue<Vector2>());

	private void OnMoveCanceled(InputAction.CallbackContext context) =>
		moveAxis.OnNext(Vector2.zero);

	private void OnInteract1Performed(InputAction.CallbackContext context) =>
		interactDown1.OnNext(Unit.Default);
    private void OnInteract2Performed(InputAction.CallbackContext context) =>
        interactDown2.OnNext(Unit.Default);


    public void Dispose()
	{
		input.Gameplay.Move.performed -= OnMove;
		input.Gameplay.Move.canceled -= OnMoveCanceled;
		input.Gameplay.Interaction1.performed -= OnInteract1Performed;
        input.Gameplay.Interaction2.performed -= OnInteract2Performed;

        disposables.Dispose();
		moveAxis.Dispose();
        interactDown1.Dispose();
        interactDown2.Dispose();
		enabled.Dispose();
	}
}
