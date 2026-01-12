using UnityEngine;

public class InputService : IInputService
{
    private const string HorizontalAxisName = "Horizontal";
    private const string VerticalAxisName = "Vertical";

    private bool enabled = true;
    public bool Enabled { get => enabled; set => enabled = value; }
    public Vector2 MovementAxis
    {
        get
        {
            return GetMovementAxis();
        }
    }
    private Vector2 GetMovementAxis()
    {
        if (enabled == false) return Vector2.zero;

        /*if (VirtualJoystick.Value != Vector2.zero)
            return VirtualJoystick.Value;*/

        return new Vector2(Input.GetAxis(HorizontalAxisName), Input.GetAxis(VerticalAxisName));
    }
}