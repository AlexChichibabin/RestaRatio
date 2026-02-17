using System;

[Serializable]
public readonly struct ItemData : IEquatable<ItemData>
{
	public readonly ItemStateFlags StateFlags;
	public readonly ItemId Id;

	public ItemData(ItemStateFlags stateFlags, ItemId id)
	{
		StateFlags = stateFlags;
		Id = id;
	}

	public bool Equals(ItemData other) => StateFlags == other.StateFlags && Equals(Id, other.Id);
	public override bool Equals(object obj) => obj is ItemData other && Equals(other);
	public override int GetHashCode() => HashCode.Combine(StateFlags, Id);
}
