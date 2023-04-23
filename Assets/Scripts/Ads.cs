using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using GoogleMobileAds.Api;
using UnityEngine.SceneManagement;
public class Ads : MonoBehaviour
{

    
    private InterstitialAd interstitial;
    void Start()
    {
        RequestInterstitial();
        GameOver();

       
    }



    private void RequestInterstitial()
    {
        string adUnitId = "ca-app-pub-6800551873518899/8657500162";

        // Initialize an InterstitialAd.
        this.interstitial = new InterstitialAd(adUnitId);

        AdRequest request = new AdRequest.Builder().Build();
        // Load the interstitial with the request.
        this.interstitial.LoadAd(request);



       

    }

    private void GameOver()
    {
        if (this.interstitial.IsLoaded())
        {
            this.interstitial.Show();
        }
    }

}
