using Unity.Android.Gradle.Manifest;
using UnityEngine;

public class HeroMovement : MonoBehaviour
{
	public Vector3 DirectionControl => directionControl;
	[HideInInspector] public Vector3 TargetDirectionControl;

	[SerializeField] private CharacterController characterController;
    [SerializeField] private Transform viewTransform;
    [SerializeField] private float movementSpeed;
    [SerializeField] private float movementLerpFactor;
    [SerializeField] private float rotationLerpFactor;

	[SerializeField] private float gravity = -20f;
	[SerializeField] private float groundedStick = -2f;

	private Vector3 directionControl;
	private float verticalVelocity;

	private void Update()
    {
		directionControl = Vector3.Lerp(directionControl, TargetDirectionControl, Time.deltaTime * movementLerpFactor);

		var move = directionControl * movementSpeed;

		if (characterController.isGrounded)
		{
			if (verticalVelocity < 0f)
				verticalVelocity = groundedStick;
		}
		else
		{
			verticalVelocity += gravity * Time.deltaTime;
		}

		move.y = verticalVelocity;

		characterController.Move(move * Time.deltaTime);

		if (directionControl.sqrMagnitude > 0.0001f)
		{
			viewTransform.rotation = Quaternion.Lerp(
				viewTransform.rotation,
				Quaternion.LookRotation(new Vector3(directionControl.x, 0f, directionControl.z)),
				Time.deltaTime * rotationLerpFactor);
		}
	}
    public void SetMoveDirection(Vector2 moveDirection)
    {
		moveDirection.Normalize();
		TargetDirectionControl.x = moveDirection.x;
		TargetDirectionControl.z = moveDirection.y;
    }
    private void MoveDown()
    {
		characterController.Move(new Vector3(0, -1, 0) * movementSpeed * Time.deltaTime);
	}
}
