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
        if (directionControl.magnitude > 0)
        {
            characterController.Move(directionControl * movementSpeed * Time.deltaTime);
            //viewTransform.rotation = Quaternion.LookRotation(directionControl);
        }
        else
        {
            characterController.Move(Vector3.zero);
        }
    }
    public void SetMoveDirection(Vector2 moveDirection)
    {
		moveDirection.Normalize();
		TargetDirectionControl.x = moveDirection.x;
		TargetDirectionControl.z = moveDirection.y;

    }
}
