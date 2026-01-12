using UnityEngine;

public class HeroMovement : MonoBehaviour
{
    [SerializeField] private CharacterController characterController;
    [SerializeField] private Transform viewTransform;
    [SerializeField] private float movementSpeed;

    private Vector3 directionControl;

    public Vector3 DirectionControl => directionControl;


    private void Update()
    {
        if (directionControl.magnitude > 0)
        {
            characterController.Move(directionControl * movementSpeed * Time.deltaTime);
            viewTransform.rotation = Quaternion.LookRotation(directionControl);
        }
        else
        {
            characterController.Move(Vector3.zero);
        }
    }
    public void SetMoveDirection(Vector2 moveDirection)
    {
        directionControl.x = moveDirection.x;
        directionControl.z = moveDirection.y;
        directionControl.Normalize();
    }
}
