using UnityEngine;

public class HeroMovement : MonoBehaviour
{
    [SerializeField] private CharacterController characterController;
    [SerializeField] private Transform viewTransform;
    [SerializeField] private float movementSpeed;
    [SerializeField] private float movementLerpFactor;
    [SerializeField] private float rotationLerpFactor;

    private Vector3 directionControl;

    public Vector3 DirectionControl => directionControl;
    public Vector3 TargetDirectionControl;

    private void Update()
    {
		directionControl = Vector3.Lerp(directionControl, TargetDirectionControl, Time.deltaTime * movementLerpFactor);

		characterController.Move(directionControl * movementSpeed * Time.deltaTime);

		if (TargetDirectionControl.magnitude > 0)
        {
            //viewTransform.rotation = Quaternion.LookRotation(directionControl);
            viewTransform.rotation = Quaternion.Lerp(viewTransform.rotation, Quaternion.LookRotation(directionControl), Time.deltaTime * rotationLerpFactor);
        }

    }
    public void SetMoveDirection(Vector2 moveDirection)
    {
		moveDirection.Normalize();
		TargetDirectionControl.x = moveDirection.x;
		TargetDirectionControl.z = moveDirection.y;

    }
}
