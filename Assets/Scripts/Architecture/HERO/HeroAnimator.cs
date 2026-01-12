using UnityEngine;

public class HeroAnimator : MonoBehaviour
{
    private const string IsMoving = "IsMoving";
    private const string AttackTrigger = "Attack";
    private const float MovementThreshold = 0.05f;

    [SerializeField] private CharacterController characterController;
    [SerializeField] private Animator animator;

    private void Update()
    {
        // velocity и magnitude равны 0, если Update HeroАниматора вызывается до HeroMovement. Временно исправил через ExecutionOrder в Unity
        animator.SetBool(IsMoving, characterController.velocity.magnitude >= MovementThreshold);
    }
    public void Attack()
    {
        animator.SetTrigger(AttackTrigger);
    }
}