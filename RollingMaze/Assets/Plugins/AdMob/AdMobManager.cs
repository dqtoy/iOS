using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;


public class AdMobManager : MonoBehaviour
{
	// Fired when the ad view receives an ad
	public static event Action adViewDidReceiveAdEvent;
	
	// Fired when the ad view fails to receive an ad
	public static event Action<string> adViewFailedToReceiveAdEvent;
	
	// Fired when an interstitial is ready to show
	public static event Action interstitialDidReceiveAdEvent;
	
	// Fired when the interstitial download fails
	public static event Action<string> interstitialFailedToReceiveAdEvent;


	void Awake()
	{
		// Set the GameObject name to the class name for easy access from Obj-C
		gameObject.name = this.GetType().ToString();
		DontDestroyOnLoad( this );
	}


	public void adViewDidReceiveAd( string empty )
	{
		if( adViewDidReceiveAdEvent != null )
			adViewDidReceiveAdEvent();
	}


	public void adViewFailedToReceiveAd( string error )
	{
		if( adViewFailedToReceiveAdEvent != null )
			adViewFailedToReceiveAdEvent( error );
	}


	public void interstitialDidReceiveAd( string empty )
	{
		if( interstitialDidReceiveAdEvent != null )
			interstitialDidReceiveAdEvent();
	}


	public void interstitialFailedToReceiveAd( string error )
	{
		if( interstitialFailedToReceiveAdEvent != null )
			interstitialFailedToReceiveAdEvent( error );
	}


}

