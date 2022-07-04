using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.Events;

public class AdManager : MonoBehaviour, IUnityAdsListener
{
    [SerializeField] private string _androidGameId = 4826621;
    [SerializeField] private string _iOSGameId = 4826620;
    [SerializeField] private string _testMode;

    [SerializeField] private string _androidInterstitialAdId = Interstitial_Android;
    [SerializeField] private string _iOSInterstitialAdId = Interstitial_iOS;

    [SerializeField] private string _androidRewardedAdId = Rewarded_Android;
    [SerializeField] private string _iOSRewardedAdId = Rewarded_iOS;

    [SerializeField] private string _androidBannerAdId = Banner_Android;
    [SerializeField] private string _iOSBannerAdId = Banner_iOSS;

    private string GameId => Application.platform == RuntimePlatform.IphonePlayer ? _iOSGameId : _androidGameId;
    private string InterstitialAdId => Application.platform == RuntimePlatform.IphonePlayer ? _iOSInterstitialAdId : _androidInterstitialAdId;
    private string RewardedAdId => Application.platform == RuntimePlatform.IphonePlayer ? _iOSRewardedAdId : _androidRewardedAdId;
    private string BannerAdId => Application.platform == RuntimePlatform.IphonePlayer ? _iOSBannerAdId : _androidBannerAdId;
   
    private void Awake()
    {
        Advertisement.Initialize(GameId, _testMode, true, this);
        Advertisement.AddListener(this);
        StartCoroutine(WaitForInit());
    }

    private IEnumerator WaitForInit()
    {
        while (!Advertisement.isInitialized)
        {
            yield return null;
        }

        StartInterstitialAd();
    }

    public void StartInterstitialAd()
    {
        if (!Advertisement.isInitialized)
        {
            return;
        }

        Advertisement.Load(InterstitialAdId);
    }

    public void StartRewardedAd()
    {
        if (!Advertisement.isInitialized)
        {
            return;
        }

        Advertisement.Load(RewardedAdId);
    }

    public void StartBannerAd(BannerPosition position = BannerPosition.BOTTOM_CENTER)
    {
        if (!Advertisement.isInitialized)
        {
            return;
        }

        Advertisement.Banner.SetPosition(position);
        Advertisement.Banner.Load(BannerAdId, new BannerLoadOptions()
        {
            errorCallback = OnBannerLoadError,
            loadCallback = OnBannerLoad
        }
            );
    }

    private void OnBannerLoad()
    {
        Advertisement.Banner.Show();
    }

    private void OnBannerLoadError(string message)
    {
        Debug.LogError("Ad banner error: " + message);
    }

    public void StopBannerAd()
    {
        Advertisement.Banner.Hide();
    }

    public void OnUnityAdsReady(string placementId)
    {
        Advertisement.Show(placementId);
    }

    public void OnUnityAdsDidError(string message)
    {
        Debug.LogError("Ad error: " + message);
    }

    public void OnUnityAdsDidStart(string placementId)
    {

    }

    public void OnUnityAdsDidFinish(string placementId, ShowResult showresult)
    {
        if(placementId == RewardedAdId && showresult == showresult.Finished)
        {
            //player reward
        }
    }
}