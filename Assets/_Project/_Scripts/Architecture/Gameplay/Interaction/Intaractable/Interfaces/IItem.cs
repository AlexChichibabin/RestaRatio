using UnityEngine;
public interface IItem
{
    bool TryGetItemData(out ItemData itemData);
    ItemAbilityFlags AbilityFlags { get; }
    ItemStateFlags StateFlags { get; }
    bool IsServable { get; }

    bool HasState(ItemStateFlags s);
    bool HasAbility(ItemAbilityFlags a);
    void AddState(ItemStateFlags s);
    void SetState(ItemStateFlags s);
}
