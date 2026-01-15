using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ConfigProvider : IConfigProvider
{
	private const string EnemiesConfigPath = "Configs/Enemies";
	private const string LevelsConfigPath = "Configs/Levels";
	private const string WindowsConfigPath = "Configs/Windows";
	//private Dictionary<EnemyId, EnemyConfig> enemies;
	private Dictionary<string, LevelConfig> levels;
	//private Dictionary<WindowId, WindowConfig> windows;
	private LevelConfig[] levelList;

	public int LevelAmount => levelList.Length;

	public void Load()
	{
		//enemies = Resources.LoadAll<EnemyConfig>(EnemiesConfigPath).ToDictionary(x => x.enemyId, x => x);
		//windows = Resources.LoadAll<WindowConfig>(WindowsConfigPath).ToDictionary(x => x.WindowId, x => x);

		levelList = Resources.LoadAll<LevelConfig>(LevelsConfigPath);
		levels = levelList.ToDictionary(x => x.SceneName, x => x);
	}

	//public EnemyConfig GetEnemy(EnemyId enemyId)
	//{
	//	return enemies[enemyId];
	//}

	public LevelConfig GetLevel(int index)
	{
		return levelList[index];
	}

	public LevelConfig GetLevel(string name)
	{
		return levels[name];
	}

	//public WindowConfig GetWindow(WindowId windowId)
	//{
	//	return windows[windowId];
	//}

	/*public EnemyConfig[] GetAllEnemies()
	{
		return enemies.Values.ToArray();
	}*/
}