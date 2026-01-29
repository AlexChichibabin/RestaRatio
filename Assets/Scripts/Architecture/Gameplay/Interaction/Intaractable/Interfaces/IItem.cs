using UnityEngine;

public interface IItem
{
    Transform Parent { get; }
    void Take(Transform hand);
    void Put(Transform place);
    void Drop(Transform world);
}
