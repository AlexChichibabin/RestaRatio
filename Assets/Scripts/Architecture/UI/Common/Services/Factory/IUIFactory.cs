using Cysharp.Threading.Tasks;
using System.Threading.Tasks;
using UnityEngine;

public interface IUIFactory
{
	Transform UIRoot { get; set; }

	UniTask<LevelResultPresenter> CreateLevelResultWindowAsync(WindowConfig config);
	UniTask<MainMenuPresenter> CreateMainMenuWindowAsync(WindowConfig config);
	void CreateUIRoot();
	UniTask WarmUpAsync();
}