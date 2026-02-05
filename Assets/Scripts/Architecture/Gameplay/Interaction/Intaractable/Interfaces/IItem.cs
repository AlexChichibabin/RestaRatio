using UnityEngine;
public interface IItem
{
    ItemAbilityFlags AbilityFlags { get; }
    ItemStateFlags StateFlags { get; }
    Transform Parent { get; }
    void Take(Transform hand);
    void Put(Transform place);
    void Drop(Transform world);
    bool HasState(ItemStateFlags s);
    bool HasAbility(ItemAbilityFlags a);
    void AddState(ItemStateFlags s);
    void SetState(ItemStateFlags s);
}
