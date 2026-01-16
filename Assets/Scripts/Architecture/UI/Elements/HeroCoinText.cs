using System;
using TMPro;
using UnityEngine;
using Zenject;

public class HeroCoinText : MonoBehaviour
{
	//[SerializeField] private TextMeshProUGUI text;

	//private IProgressProvider progressProvider;

	//[Inject]
	//public void Construct(IProgressProvider progressProvider)
	//{
	//	this.progressProvider = progressProvider;
	//}

	//private void Start()
	//{
	//	progressProvider.PlayerProgress.HeroWallet.CoinsValueChanged += OnCoinsValueChanged;

	//	OnCoinsValueChanged(progressProvider.PlayerProgress.HeroWallet.Coins);
	//}
	//private void OnDestroy()
	//{
	//	progressProvider.PlayerProgress.HeroWallet.CoinsValueChanged -= OnCoinsValueChanged;
	//}
	//private void OnCoinsValueChanged(int coinsValue)
	//{
	//	text.text = coinsValue.ToString();
	//	//Debug.Log(coinsValue.ToString());
	//}
}