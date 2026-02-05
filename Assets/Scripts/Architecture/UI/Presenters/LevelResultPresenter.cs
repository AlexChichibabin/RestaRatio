public class LevelResultPresenter : WindowPresenterBase<LevelResultWindow>
{
	private IGameStateSwitcher gameStateSwitcher;

	private LevelResultWindow window;

	public LevelResultPresenter(
		IGameStateSwitcher gameStateSwitcher)
	{
		this.gameStateSwitcher = gameStateSwitcher;
	}
	public override void SetWindow(LevelResultWindow window)
	{
		this.window = window;
		window.loadMainMenuButtonClicked += OnLoadMainMenuButtonClicked;
		window.Cleanuped += OnWindowCleanuped;
	}
	private void OnWindowCleanuped()
	{
		window.loadMainMenuButtonClicked -= OnLoadMainMenuButtonClicked;
		window.Cleanuped -= OnWindowCleanuped;
	}
	private void OnLoadMainMenuButtonClicked()
	{
		gameStateSwitcher.Enter<LoadMainMenuState>();
	}
}