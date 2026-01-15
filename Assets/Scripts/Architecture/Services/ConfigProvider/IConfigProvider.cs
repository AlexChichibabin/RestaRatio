public interface IConfigProvider
{
	int LevelAmount { get; }
	void Load();
	//EnemyConfig GetEnemy(EnemyId enemyId);
	//EnemyConfig[] GetAllEnemies();
	LevelConfig GetLevel(int index);
	LevelConfig GetLevel(string name);
	//WindowConfig GetWindow(WindowId windowId);

}