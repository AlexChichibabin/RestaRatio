public interface IConfigProvider
{
	int LevelAmount { get; }
	void Load();
	LevelConfig GetLevel(int index);
	LevelConfig GetLevel(string name);
	ItemConfig GetItem(ItemId itemId);
	WindowConfig GetWindow(WindowId windowId);
}