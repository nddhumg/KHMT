using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdsManager : PersistentSingleton<AdsManager>, IUnityAdsInitializationListener ,IUnityAdsLoadListener, IUnityAdsShowListener
{
    [SerializeField] string _androidAdURewarded = "Rewarded_Android";
    [SerializeField] string gameId ;
    [SerializeField] bool _testMode = true;

    public Action adsShowComplete;
    protected override void Awake()
    {
        base.Awake();
        InitializeAds();
    }

    public void InitializeAds()
    {
        if (!Advertisement.isInitialized && Advertisement.isSupported)
        {
            Advertisement.Initialize(gameId, _testMode, this);
        }
    }
    [Button]
    public void LoadAd()
    {
        Advertisement.Load(_androidAdURewarded, this);
    }

    [Button]
    public void ShowAdRewaded() 
    { 
        Advertisement.Show(_androidAdURewarded, this);
    }

    public void OnInitializationComplete()
    {
        Debug.Log("Unity Ads initialization complete.");
    }

    public void OnInitializationFailed(UnityAdsInitializationError error, string message)
    {
        Debug.Log($"Unity Ads Initialization Failed: {error.ToString()} - {message}");
    }

    public void OnUnityAdsAdLoaded(string adUnitId)
    {
        // Optionally execute code if the Ad Unit successfully loads content.
    }

    public void OnUnityAdsFailedToLoad(string _adUnitId, UnityAdsLoadError error, string message)
    {
        Debug.Log($"Error loading Ad Unit: {_adUnitId} - {error.ToString()} - {message}");
        // Optionally execute code if the Ad Unit fails to load, such as attempting to try again.
    }

    public void OnUnityAdsShowFailure(string _adUnitId, UnityAdsShowError error, string message)
    {
        Debug.Log($"Error showing Ad Unit {_adUnitId}: {error.ToString()} - {message}");
        // Optionally execute code if the Ad Unit fails to show, such as loading another ad.
    }

    public void OnUnityAdsShowStart(string placementId)
    {
    }

    public void OnUnityAdsShowClick(string placementId)
    {
    }

    public void OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState showCompletionState)
    {
        this.adsShowComplete?.Invoke();
    }
}
