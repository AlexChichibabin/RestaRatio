using UnityEngine;

public interface IInputService
{
    bool Enabled { get; set; }
    Vector2 MovementAxis { get; }
}