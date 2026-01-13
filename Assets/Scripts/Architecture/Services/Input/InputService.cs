using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

public class InputService : IInputService
{
	private PlayerInputActions input;
	private bool enabled = true;

    public bool Enabled { get => enabled; set  => enabled = value; }
	public PlayerInputActions Input => input;
	public Vector2 MovementAxis
    {
        get
        {
            return GetMovementAxis();
        }
    }
	public InputService(PlayerInputActions input)
	{
		this.input = input;
	}

	private Vector2 GetMovementAxis()
	{
		if (enabled == false) return Vector2.zero;

		return input.Gameplay.Move.ReadValue<Vector2>();
	}
}