using System;
using UnityEngine;
using UnityEngine.UI;


public class RewardedAdsItem : MonoBehaviour
{
	[SerializeField] private Button showAdsButton;
	[SerializeField] private int rewardAmount;

	//private IAdsService adsService;
	//private IProgressProvider progressProvider;
	//private IProgressSaver progressSaver;

	//[Inject]
	//public void Construct(IAdsService adsService, IProgressProvider progressProvider, IProgressSaver progressSaver)
	//{
	//	this.adsService = adsService;
	//	this.progressProvider = progressProvider;
	//	this.progressSaver = progressSaver;
	//}

	//private void Start()
	//{
	//	showAdsButton.onClick.AddListener(OnShowAdsButtonClicked);
	//}
	//private void OnDestroy()
	//{
	//	showAdsButton.onClick.RemoveListener(OnShowAdsButtonClicked);
	//}
	//private void Update()
	//{
	//	bool isVideoAvailable = adsService.IsRewardedVideoReady == true 
	//		&& Application.internetReachability == NetworkReachability.ReachableViaLocalAreaNetwork
	//		|| Application.internetReachability == NetworkReachability.ReachableViaCarrierDataNetwork;

	//	showAdsButton.gameObject.SetActive(isVideoAvailable);
	//}
	//private void OnShowAdsButtonClicked()
	//{
	//	adsService.ShowRewarded(() =>
	//	{
	//		progressProvider.PlayerProgress.HeroWallet.Coins += rewardAmount;
	//		progressSaver.SaveProgress();
	//	});
	//}
}