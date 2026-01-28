using UnityEngine;
using UnityEngine.XR;

public class Pickupable : MonoBehaviour
{
	private Rigidbody rb;
	private Collider[] cols;

	private void Awake()
	{
		rb = GetComponent<Rigidbody>();
		cols = GetComponentsInChildren<Collider>();
	}

	public void Take(Transform hand)
	{
		rb.linearVelocity = Vector3.zero;
		rb.angularVelocity = Vector3.zero;
		rb.isKinematic = true;

		foreach (var c in cols)
			c.enabled = false;

		transform.SetParent(hand, false);
		transform.localPosition = Vector3.zero;
		transform.localRotation = Quaternion.identity;
	}

	public void Put(Transform place/*, Vector3 impulse*/)
	{
		rb.isKinematic = false;
		rb.linearVelocity = Vector3.zero;
		rb.angularVelocity = Vector3.zero;

		foreach (var c in cols)
			c.enabled = true;

		transform.SetParent(place, false);
		transform.localPosition = Vector3.zero;
		transform.localRotation = Quaternion.identity;
		//transform.SetParent(null);

		//foreach (var c in cols)
		//	c.enabled = true;

		//rb.isKinematic = false;
		//rb.AddForce(impulse, ForceMode.Impulse);
	}
}
