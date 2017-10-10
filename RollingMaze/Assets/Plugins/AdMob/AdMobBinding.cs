using UnityEngine;
using System.Collections;
using System.Runtime.InteropServices;


public enum AdMobBannerType
{
	iPhone_320x50,
	iPad_728x90,
	iPad_468x60,
	iPad_320x250
}



public class AdMobBinding
{
	[DllImport("__Internal")]
	private static extern void _adMobInit( string publisherId );

	// Sets the publiser Id and prepares AdMob for action.  Must be called before any other methods!
	public static void init( string publisherId )
	{
		if( Application.platform == RuntimePlatform.IPhonePlayer )
			_adMobInit( publisherId );
	}


	[DllImport("__Internal")]
	private static extern void _adMobCreateBanner( int bannerType, float xPos, float yPos );

	// Creates a banner of the given type with the x and y offset of the top-left corner of the ad
	public static void createBanner( AdMobBannerType bannerType, float xPos, float yPos )
	{
		if( Application.platform == RuntimePlatform.IPhonePlayer )
			_adMobCreateBanner( (int)bannerType, xPos, yPos );
	}


	[DllImport("__Internal")]
	private static extern void _adMobDestroyBanner();

	// Destroys the banner and removes it from view
	public static void destroyBanner()
	{
		if( Application.platform == RuntimePlatform.IPhonePlayer )
			_adMobDestroyBanner();
	}


	[DllImport("__Internal")]
	private static extern void _adMobRotateToOrientation( int orientation );

	// Switches the orientation of the ad view
	public static void rotateToOrientation( DeviceOrientation orientation )
	{
		if( Application.platform == RuntimePlatform.IPhonePlayer )
			_adMobRotateToOrientation( (int)orientation );
	}


	[DllImport("__Internal")]
	private static extern void _adMobRequestInterstitalAd( string interstitialUnitId );

	// Starts loading an interstitial ad
	public static void requestInterstitalAd( string interstitialUnitId )
	{
		if( Application.platform == RuntimePlatform.IPhonePlayer )
			_adMobRequestInterstitalAd( interstitialUnitId );
	}


	[DllImport("__Internal")]
	private static extern bool _adMobIsInterstitialAdReady();

	// Checks to see if the interstitial ad is loaded and ready to show
	public static bool isInterstitialAdReady()
	{
		if( Application.platform == RuntimePlatform.IPhonePlayer )
			return _adMobIsInterstitialAdReady();

		return false;
	}


	[DllImport("__Internal")]
	private static extern void _adMobShowInterstitialAd();

	// If an interstitial ad is loaded this will take over the screen and show the ad
	public static void showInterstitialAd()
	{
		if( Application.platform == RuntimePlatform.IPhonePlayer )
			_adMobShowInterstitialAd();
	}
	
	
	[DllImport("__Internal")]
	private static extern void _adMobRegisterAppDownloadWithiTunesAppId( string iTunesAppId );

	// Reports an app download to AdMob.  Will only send the request if the app download has not yet been reported
	public static void registerAppDownloadWithiTunesAppId( string iTunesAppId )
	{
		if( Application.platform == RuntimePlatform.IPhonePlayer )
			_adMobRegisterAppDownloadWithiTunesAppId( iTunesAppId );
	}



	[DllImport("__Internal")]
	private static extern void _adMobRegisterAppDownloadWithAdMobSiteId();

	// Reports an app download to AdMob.  Will only send the request if the app download has not yet been reported
	public static void registerAppDownloadWithAdMobSiteId()
	{
		if( Application.platform == RuntimePlatform.IPhonePlayer )
			_adMobRegisterAppDownloadWithAdMobSiteId();
	}

}

