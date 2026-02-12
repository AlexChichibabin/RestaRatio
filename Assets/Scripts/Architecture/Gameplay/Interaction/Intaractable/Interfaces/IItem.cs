using UnityEngine;
public interface IItem
{
    ItemAbilityFlags AbilityFlags { get; }
    ItemStateFlags StateFlags { get; }

    bool HasState(ItemStateFlags s);
    bool HasAbility(ItemAbilityFlags a);
    void AddState(ItemStateFlags s);
    void SetState(ItemStateFlags s);
}
