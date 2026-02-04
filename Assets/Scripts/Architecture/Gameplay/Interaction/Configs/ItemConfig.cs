using System;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemConfig", menuName = "Configs/Item")]
public class ItemConfig : ScriptableObject
{
	public string Id;

	[Header("Base abilities (fallback for None or if no rules)")]
	public ItemAbilityFlags Abilities;

	[Header("Views per state (visuals)")]
	public StateView[] Views;

	[Header("Rules per state (what is allowed at each state)")]
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

		[Tooltip("Abilities allowed when the item is in this State.")]
		public ItemAbilityFlags AllowedAbilities;

		[Header("Optional transitions (if you want data-driven state changes)")]
		public ItemStateFlags OnCutResult;    // set None if no transition
		public ItemStateFlags OnRoastResult;
		public ItemStateFlags OnBakeResult;
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

		// fallback: Если нет вьюшки
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


	public ItemAbilityFlags GetAllowedAbilities(ItemStateFlags state)
	{
		if (TryGetRule(state, out var rule))
			return rule.AllowedAbilities;

		// fallback: если правил нет, то возвращает дефолтные абилки. Может стоит возвращать None
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

		// fallback: правило если None или false
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


	public bool TryGetNextState(ItemStateFlags currentState, ItemAbilityFlags actionAbility, out ItemStateFlags nextState) // data-driven. На потом
	{
		nextState = ItemStateFlags.None;

		if (!TryGetRule(currentState, out var rule))
			return false;

		if (actionAbility == ItemAbilityFlags.Cuttable && rule.OnCutResult != ItemStateFlags.None)
		{
			nextState = rule.OnCutResult;
			return true;
		}

		if (actionAbility == ItemAbilityFlags.Roastable && rule.OnRoastResult != ItemStateFlags.None)
		{
			nextState = rule.OnRoastResult;
			return true;
		}

		if (actionAbility == ItemAbilityFlags.Bakable && rule.OnBakeResult != ItemStateFlags.None)
		{
			nextState = rule.OnBakeResult;
			return true;
		}

		return false;
	}
}
