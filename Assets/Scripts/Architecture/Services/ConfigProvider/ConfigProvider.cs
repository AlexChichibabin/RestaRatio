using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ConfigProvider : IConfigProvider
{
	private const string LevelsConfigPath = "Configs/Levels";
	private const string WindowsConfigPath = "Configs/Windows";
	private Dictionary<string, LevelConfig> levels;
	private Dictionary<WindowId, WindowConfig> windows;
	private LevelConfig[] levelList;

	public int LevelAmount => levelList.Length;

	public void Load()
	{
		windows = Resources.LoadAll<WindowConfig>(WindowsConfigPath).ToDictionary(x => x.WindowId, x => x);

		levelList = Resources.LoadAll<LevelConfig>(LevelsConfigPath);

		levels = levelList.ToDictionary(x => x.SceneName, x => x);
	}

	public LevelConfig GetLevel(int index) => levelList[index];
	public LevelConfig GetLevel(string name) => levels[name];
	public WindowConfig GetWindow(WindowId windowId) => windows[windowId];
}