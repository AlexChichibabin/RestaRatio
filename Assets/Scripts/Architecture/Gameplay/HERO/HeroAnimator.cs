using UnityEngine;

public class HeroAnimator : MonoBehaviour
{
	private const string NormMoveY = "Normalize Movement Y";

    [SerializeField] private CharacterController characterController;
    [SerializeField] private Animator animator;

    private void LateUpdate() // TODO
    {
		animator.SetFloat(NormMoveY, Mathf.Clamp01(characterController.velocity.magnitude));
	}
}