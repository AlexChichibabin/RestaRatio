using System.Collections.Generic;
using UnityEngine;

public class ItemCapability : MonoBehaviour, IItem, IActionProvider
{
	public ItemAbilityFlags AbilityFlags => config != null ? config.GetAllowedAbilities(stateFlags) : abilityFlags;
	public ItemStateFlags StateFlags => stateFlags;
	public bool HasState(ItemStateFlags s) => (stateFlags & s) == s;
	public bool HasAbility(ItemAbilityFlags a) => (AbilityFlags & a) == a;

	[Header("Data")]
	[SerializeField] private ItemConfig config;

	[Header("States and abilities")]
	[SerializeField] private ItemAbilityFlags abilityFlags;
	[SerializeField] private ItemStateFlags stateFlags;

	[Header("View")]
	[SerializeField] private Transform viewRoot;
	[SerializeField] private GameObject defaultViewPrefab;

	private GameObject currentView;

	public void AddState(ItemStateFlags s)
	{
		if (HasState(s)) return;
		stateFlags |= s;
		RefreshView();
	}
	public void SetState(ItemStateFlags s)
	{
		stateFlags = s;
		RefreshView();
	}

	public IEnumerable<IGameAction> GetActionsByCapability()
	{
		yield break;
	}


	private void RefreshView()
	{
		if (currentView != null)
		{
			Destroy(currentView);
			//currentView.SetActive(false);
			currentView = null;
		}

		GameObject prefab = null;

		if (config != null && config.TryGetView(stateFlags, out var cfgPrefab))
			prefab = cfgPrefab;

		if (prefab == null && config != null && config.TryGetView(ItemStateFlags.None, out var nonePrefab))
			prefab = nonePrefab;

		if (prefab == null)
			prefab = defaultViewPrefab;

		if (prefab == null) return;

		currentView = Instantiate(prefab, viewRoot);
		currentView.transform.localPosition = Vector3.zero;
		currentView.transform.localRotation = Quaternion.identity;
	}
}
