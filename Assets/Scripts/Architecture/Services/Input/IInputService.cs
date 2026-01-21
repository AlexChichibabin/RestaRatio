using UnityEngine;

public interface IInputService
{
    bool Enabled { get; set; }
    Vector2 MovementAxis { get; }
    PlayerInputActions Input { get; }
    void GetPressEButton();
}