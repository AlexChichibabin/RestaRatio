using System;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemConfig", menuName = "Configs/Item")]
public class ItemConfig : ScriptableObject
{
	public string Name;

	public ItemId ItemId;

	public ItemAbilityFlags Abilities;

	public StateView[] Views;

	public StateRule[] Rules;

	[Serializable]
	public struct StateView
	{
		public ItemStateFlags State;
		public GameObject ViewPrefab;
	}

	/// <summary>
	/// Какие возможности есть с этим объектом при таком состоянии
	/// </summary>
	[Serializable]
	public struct StateRule
	{
		public ItemStateFlags State;
		public ItemAbilityFlags AllowedAbilities;
		public bool IsServable;
	}

	public bool TryGetView(ItemStateFlags state, out GameObject prefab)
	{
		for (int i = 0; i < Views.Length; i++)
		{
			if (Views[i].State == state)
			{
				prefab = Views[i].ViewPrefab;
				return prefab != null;
			}
		}

		for (int i = 0; i < Views.Length; i++)
		{
			if (Views[i].State == ItemStateFlags.None)
			{
				prefab = Views[i].ViewPrefab;
				return prefab != null;
			}
		}

		prefab = null;
		return false;
	}

	public bool GetServableByState(ItemStateFlags state)
	{
		if (TryGetRule(state, out var rule))
			return rule.IsServable;
		return false;
	}

	public ItemAbilityFlags GetAllowedAbilities(ItemStateFlags state)
	{
		if (TryGetRule(state, out var rule))
			return rule.AllowedAbilities;

		return Abilities;
	}

	public bool TryGetRule(ItemStateFlags state, out StateRule rule)
	{
		for (int i = 0; i < Rules.Length; i++)
		{
			if (Rules[i].State == state)
			{
				rule = Rules[i];
				return true;
			}
		}

		for (int i = 0; i < Rules.Length; i++)
		{
			if (Rules[i].State == ItemStateFlags.None)
			{
				rule = Rules[i];
				return true;
			}
		}

		rule = default;
		return false;
	}
}
