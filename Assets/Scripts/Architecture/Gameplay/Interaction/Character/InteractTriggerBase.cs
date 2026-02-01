using System.Collections.Generic;
using UnityEngine;

public abstract class InteractTriggerBase : MonoBehaviour
{
	public abstract IList<IInteractable> Candidates { get; }
	//public abstract IInteractable Interactable { get; }
}
