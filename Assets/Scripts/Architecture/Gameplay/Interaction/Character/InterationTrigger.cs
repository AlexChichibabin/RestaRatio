using UnityEngine;

//public class InterationTrigger : InteractTriggerBase
//{
//	private IInteractable interactable;
//	public override IInteractable Interactable => interactable;
//	private void OnTriggerEnter(Collider other)
//	{
//		IInteractable interactable = other.GetComponent<IInteractable>();

//		if (interactable != null)
//		{
//			this.interactable = interactable;
//			Debug.Log(this.interactable);
//		}
//	}
//	private void OnTriggerExit(Collider other)
//	{
//		IInteractable interactable = other.GetComponent<IInteractable>();
//		if (interactable != null && interactable == this.interactable)
//		{
//			this.interactable = null;
//            Debug.Log(this.interactable);
//        }
//	}
//}
