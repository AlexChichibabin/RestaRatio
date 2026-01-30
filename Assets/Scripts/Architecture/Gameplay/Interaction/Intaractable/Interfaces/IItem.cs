using UnityEngine;

public interface IItem
{
    ItemFlags ItemFlags { get; }
    Transform Parent { get; }
    void Take(Transform hand);
    void Put(Transform place);
    void Drop(Transform world);
}
