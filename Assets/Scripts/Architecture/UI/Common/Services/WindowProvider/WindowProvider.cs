using UnityEngine;

public class WindowProvider : IWindowProvider
{
	private IUIFactory uIFactory;
	private IConfigProvider configProvider;

	public WindowProvider(IUIFactory uIFactory, IConfigProvider configProvider)
	{
		this.uIFactory = uIFactory;
		this.configProvider = configProvider;
	}

	public void Open(WindowId windowId)
	{
		if (uIFactory.UIRoot == null)
			uIFactory.CreateUIRoot();

		WindowConfig windowConfig = configProvider.GetWindow(windowId);

		if (windowId == WindowId.VictoryWindow || windowId == WindowId.LoseWindow)
			uIFactory.CreateLevelResultWindowAsync(windowConfig);

		if (windowId == WindowId.MainMenuWindow)
			uIFactory.CreateMainMenuWindowAsync(windowConfig);
	}
}