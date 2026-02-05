public class MainMenuPresenter : WindowPresenterBase<MainMenuWindow>
{
	private IGameStateSwitcher gameStateSwitcher;
	private IConfigProvider configProvider;

	private MainMenuWindow window;

	public MainMenuPresenter(
		IGameStateSwitcher gameStateSwitcher,
		IConfigProvider configProvider)
	{
		this.gameStateSwitcher = gameStateSwitcher;
		this.configProvider = configProvider;
	}

	public override void SetWindow(MainMenuWindow window)
	{
		this.window = window;

		window.playButtonClicked += OnPlayButtonClicked;
		window.Cleanuped += OnCleanuped;
	}

	private void OnCleanuped()
	{
		window.playButtonClicked -= OnPlayButtonClicked;
		window.Cleanuped -= OnCleanuped;
	}

	private void OnPlayButtonClicked()
	{
		gameStateSwitcher.Enter<LoadNextLevelState>();
	}
}