using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ConfigProvider : IConfigProvider
{
    private Dictionary<string, LevelConfig> levels;
	private Dictionary<WindowId, WindowConfig> windows;
	private Dictionary<ItemId, ItemConfig> items;
	private LevelConfig[] levelList;

	public int LevelAmount => levelList.Length;

	public void Load()
	{
		windows = Resources.LoadAll<WindowConfig>(AssetAddress.WindowsConfigPath).ToDictionary(x => x.WindowId, x => x);

		items = Resources.LoadAll<ItemConfig>(AssetAddress.ItemsConfigPath).ToDictionary(x => x.ItemId, x => x);

		levelList = Resources.LoadAll<LevelConfig>(AssetAddress.LevelsConfigPath);

		levels = levelList.ToDictionary(x => x.SceneName, x => x);
	}

	public LevelConfig GetLevel(int index) => levelList[index];
	public LevelConfig GetLevel(string name) => levels[name];
	public WindowConfig GetWindow(WindowId windowId) => windows[windowId];
}