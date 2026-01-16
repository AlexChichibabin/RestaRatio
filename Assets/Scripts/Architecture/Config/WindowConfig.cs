using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

[CreateAssetMenu(fileName = "WindowConfig", menuName = "Configs/Window")]
public class WindowConfig : ScriptableObject
{
	public WindowId WindowId;
	public string Title;
	public AssetReferenceGameObject PrefabReference;
}