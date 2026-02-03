using UnityEngine;

public interface IItem
{
    ItemAbilityFlags ItemFlags { get; }
    ItemStateFlags State { get; }
    Transform Parent { get; }
    void Take(Transform hand);
    void Put(Transform place);
    void Drop(Transform world);
    bool HasState(ItemStateFlags s);
    void AddState(ItemStateFlags s);
    void SetState(ItemStateFlags s);
}
