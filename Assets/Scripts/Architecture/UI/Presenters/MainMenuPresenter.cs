using System;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class MainMenuPresenter : WindowPresenterBase<MainMenuWindow>
{
	private IGameStateSwitcher gameStateSwitcher;
	//private IProgressProvider progressProvider;
	private IConfigProvider configProvider;

	private MainMenuWindow window;

	public MainMenuPresenter(
		IGameStateSwitcher gameStateSwitcher/*, 
			IProgressProvider progressProvider*/,
		IConfigProvider configProvider)
	{
		this.gameStateSwitcher = gameStateSwitcher;
		//this.progressProvider = progressProvider;
		this.configProvider = configProvider;
	}

	public override void SetWindow(MainMenuWindow window)
	{
		this.window = window;

		//int currentLevelIndex = progressProvider.PlayerProgress.CurrentLevelIndex;

		/*if (currentLevelIndex == configProvider.LevelAmount)
			window.HidePlayButton();
		else
			window.SetLevelIndex(currentLevelIndex);*/

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