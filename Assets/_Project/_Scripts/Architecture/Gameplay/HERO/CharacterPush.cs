using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class CharacterPush : MonoBehaviour
{
	[SerializeField] float pushPower = 3f;

	private void OnControllerColliderHit(ControllerColliderHit hit)
	{
		var rb = hit.collider.attachedRigidbody;
		if (rb == null || rb.isKinematic) return;

		var dir = new Vector3(hit.moveDirection.x, 0f, hit.moveDirection.z);
		if (dir.sqrMagnitude < 0.001f) return;

		rb.AddForce(dir.normalized * pushPower, ForceMode.Impulse);
	}
}
