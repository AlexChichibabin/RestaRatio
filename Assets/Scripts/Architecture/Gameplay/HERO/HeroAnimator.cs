using UnityEngine;

public class HeroAnimator : MonoBehaviour
{
    private const string IsMoving = "IsMoving";
    private const string AttackTrigger = "Attack";
	private const string NormMoveX = "Normalize Movement X";
	private const string NormMoveY = "Normalize Movement Y";
	private const float MovementThreshold = 0.05f;

    [SerializeField] private CharacterController characterController;
    [SerializeField] private Animator animator;

    private void LateUpdate()
    {
        // velocity и magnitude равны 0, если Update HeroАниматора вызывается до HeroMovement. Временно исправил через ExecutionOrder в Unity
        //animator.SetBool(IsMoving, characterController.velocity.magnitude >= MovementThreshold);
		//animator.SetFloat(NormMoveX, characterController.velocity.normalized.x);
		animator.SetFloat(NormMoveY, Mathf.Clamp01(characterController.velocity.magnitude));
	}
    public void Attack()
    {
        animator.SetTrigger(AttackTrigger);
    }
}