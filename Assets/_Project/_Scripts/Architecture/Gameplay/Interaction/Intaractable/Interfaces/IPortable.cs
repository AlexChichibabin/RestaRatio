using UnityEngine;

public interface IPortable
{
	Transform Parent { get; }
	void Take(Transform hand);
	void Put(Transform place);
	void Drop(Transform world);
}
