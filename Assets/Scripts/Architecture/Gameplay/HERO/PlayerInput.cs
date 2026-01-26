using UniRx;
using UnityEngine;
using Zenject;

public class PlayerInput : MonoBehaviour
{
	[SerializeField] private HeroMovement playerMovement;
	[SerializeField] private PlayerActionController playerHeroController;

	private IInputService input;

	private CompositeDisposable disposables = new();

	[Inject]
	public void Construct(
		IInputService input)
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

		if (playerMovement != null) playerMovement.SetMoveDirection(Vector2.zero);
	}

	private void SubscribeOnInput()
	{
		disposables.Clear();

		input.MoveAxis
			.Subscribe(dir => playerMovement.SetMoveDirection(dir))
			.AddTo(disposables);

		input.InteractDown
			.Subscribe(_ => playerHeroController.OnInteractDown())
			.AddTo(disposables);
	}

	private void OnDestroy() => disposables.Dispose();
}
