using System;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemConfig", menuName = "Configs/Item")]
public class ItemConfig : ScriptableObject
{
    public string Id;

    [Header("Abilities")]
    public ItemAbilityFlags Abilities;

    [Header("Views per state")]
    public StateView[] Views;

    [Serializable]
    public struct StateView
    {
        public ItemStateFlags State;     // например None, Cutted, Roasted...
        public GameObject ViewPrefab;    // префаб визуала (меш+материалы)
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

        prefab = null;
        return false;
    }
}
