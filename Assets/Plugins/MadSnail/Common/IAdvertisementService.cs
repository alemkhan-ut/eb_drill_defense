using System;

namespace MadSnail.Common
{
	public interface IAdvertisementService
	{
		public event Action AdvertisementOnOpenEvent;
		public event Action AdvertisementOnCloseEvent;

		public void OnCloseHandler();
		public void ShowInterstitialAd();
		public void ShowRewardedAd(string id, Action rewardedAction);
		public void OnRewardedAdHandler(string id = null);
		public void ShowBanner();
	}
}