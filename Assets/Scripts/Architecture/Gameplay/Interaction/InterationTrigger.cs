using UnityEngine;

public class InterationTrigger : MonoBehaviour
{
	private IInteractable interactable;
	public IInteractable Interactable => interactable;
	private void OnTriggerEnter(Collider other)
	{
		IInteractable interactable = other.GetComponent<IInteractable>();

		if (interactable != null)
		{
			this.interactable = interactable;
		}
	}
	private void OnTriggerExit(Collider other)
	{
		IInteractable interactable = other.GetComponent<IInteractable>();
		if (interactable != null && interactable == this.interactable)
		{
			this.interactable = null;
		}
	}
}
