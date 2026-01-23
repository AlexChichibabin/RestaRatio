using UniRx;
using UnityEngine;
using Zenject;

public class HeroInput : MonoBehaviour
{
	[SerializeField] private HeroMovement heroMovement;

	private IInputService input;
	private readonly CompositeDisposable disposables = new();

	[Inject]
	public void Construct(IInputService input)
	{
		this.input = input;

		SubscribeOnInput();
	}

	private void OnEnable()
	{
		if (input == null) return;

		SubscribeOnInput();
	}

	private void OnDisable()
	{
		disposables.Clear();

		if (heroMovement != null) heroMovement.SetMoveDirection(Vector2.zero);
	}

	private void SubscribeOnInput()
	{
		disposables.Clear();

		input.MoveAxis
			.Subscribe(dir => heroMovement.SetMoveDirection(dir))
			.AddTo(disposables);

		input.InteractDown
			.Subscribe(_ => Debug.Log("Interact!"))
			.AddTo(disposables);
	}

	private void OnDestroy() => disposables.Dispose();
}
