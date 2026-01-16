using System;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using Zenject;

public class LevelResultPresenter : WindowPresenterBase<LevelResultWindow>
{
	private IGameStateSwitcher gameStateSwitcher;
	//private IAdsService adsService;

	private LevelResultWindow window;

	public LevelResultPresenter(
		IGameStateSwitcher gameStateSwitcher/*,
		IAdsService adsService*/)
	{
		this.gameStateSwitcher = gameStateSwitcher;
		//this.adsService = adsService;
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
		//adsService.ShowInterstitial();
	}
}