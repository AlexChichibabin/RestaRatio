using System.Threading.Tasks;
using UnityEngine;

public interface IUIFactory
{
	Transform UIRoot { get; set; }

	Task<LevelResultPresenter> CreateLevelResultWindowAsync(WindowConfig config);
	Task<MainMenuPresenter> CreateMainMenuWindowAsync(WindowConfig config);
	void CreateUIRoot();
	Task WarmUpAsync();
}