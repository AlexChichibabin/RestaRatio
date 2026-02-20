using UniRx;
using UnityEngine;
using Zenject;
public enum ButtonId
{
    Button1, Button2, Button3, Button4, Button5, Button6
}
public class PlayerInput : MonoBehaviour
{
	[SerializeField] private HeroMovement playerMovement;
	[SerializeField] private ActionController actionController;

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

		input.InteractDown1 // Можно обобщить
			.Subscribe(_ => actionController.OnInteractDown1())
			.AddTo(disposables);
        input.InteractDown2
            .Subscribe(_ => actionController.OnInteractDown2())
            .AddTo(disposables);
    }

	private void OnDestroy() => disposables.Dispose();
}
