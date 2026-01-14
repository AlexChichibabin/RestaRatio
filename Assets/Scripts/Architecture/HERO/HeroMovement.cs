using UnityEngine;

public class HeroMovement : MonoBehaviour
{
    [SerializeField] private CharacterController characterController;
    [SerializeField] private Transform viewTransform;
    [SerializeField] private float movementSpeed;
    [SerializeField] private float dirLerpFactor;

    private Vector3 directionControl;

    public Vector3 DirectionControl => directionControl;
    public Vector3 TargetDirectionControl;

    private void Update()
    {
		directionControl = Vector3.Lerp(directionControl, TargetDirectionControl, Time.deltaTime * dirLerpFactor);
        Debug.Log(directionControl);
		characterController.Move(directionControl * movementSpeed * Time.deltaTime);
		if (TargetDirectionControl.magnitude > 0)
        {
            viewTransform.rotation = Quaternion.LookRotation(directionControl);
        }

    }
    public void SetMoveDirection(Vector2 moveDirection)
    {
		moveDirection.Normalize();
		TargetDirectionControl.x = moveDirection.x;
		TargetDirectionControl.z = moveDirection.y;

    }
}
