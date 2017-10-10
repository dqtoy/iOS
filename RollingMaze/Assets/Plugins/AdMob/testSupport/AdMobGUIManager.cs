using UnityEngine;
using System.Collections.Generic;


public class AdMobGUIManager : MonoBehaviour
{
	void OnGUI()
	{
		float yPos = 5.0f;
		float xPos = 5.0f;
		float width = 180.0f;
		float height = 35.0f;
		float heightPlus = height + 10.0f;
	
	
		if( GUI.Button( new Rect( xPos, yPos, width, height ), "Initialize AdMob" ) )
		{
			AdMobBinding.init( "YOUR_PUBLISHER_ID" );
		}
	
	
		if( GUI.Button( new Rect( xPos, yPos += heightPlus, width, height ), "Destroy Banner" ) )
		{
			AdMobBinding.destroyBanner();
		}
	

		yPos += heightPlus;	

		
		if( iPhoneSettings.generation != iPhoneGeneration.iPad1Gen )
		{
			if( GUI.Button( new Rect( xPos, yPos += heightPlus, width, height ), "320x50 Banner" ) )
			{
				AdMobBinding.createBanner( AdMobBannerType.iPhone_320x50, ( Screen.width - 320 ) / 2, 0 );
			}
		}
		else
		{
			if( GUI.Button( new Rect( xPos, yPos += heightPlus, width, height ), "320x250 Banner" ) )
			{
				AdMobBinding.createBanner( AdMobBannerType.iPad_320x250, ( Screen.width - 320 ) / 2, 0 );
			}
			
			
			if( GUI.Button( new Rect( xPos, yPos += heightPlus, width, height ), "468x60 Banner" ) )
			{
				AdMobBinding.createBanner( AdMobBannerType.iPad_468x60, ( Screen.width - 488 ) / 2, 0 );
			}
			
			
			if( GUI.Button( new Rect( xPos, yPos += heightPlus, width, height ), "728x90 Banner" ) )
			{
				AdMobBinding.createBanner( AdMobBannerType.iPad_728x90, ( Screen.width - 748 ) / 2, 0 );
			}
		}
		
		
		if( GUI.Button( new Rect( xPos, yPos += heightPlus, width, height ), "Report App Download" ) )
		{
			AdMobBinding.registerAppDownloadWithiTunesAppId( "ITUNES_APP_ID" );
			AdMobBinding.registerAppDownloadWithAdMobSiteId();
		}

	
	
		xPos = Screen.width - width - 5.0f;
		yPos = 5.0f;
		
		if( GUI.Button( new Rect( xPos, yPos, width, height ), "Force Portrait Banner" ) )
		{
			AdMobBinding.rotateToOrientation( DeviceOrientation.Portrait );
		}
		
		
		if( GUI.Button( new Rect( xPos, yPos += heightPlus, width, height ), "Force LandcapeLeft Banner" ) )
		{
			AdMobBinding.rotateToOrientation( DeviceOrientation.LandscapeLeft );
		}
		
		
		if( GUI.Button( new Rect( xPos, yPos += heightPlus, width, height ), "Force LandcapeRight Banner" ) )
		{
			AdMobBinding.rotateToOrientation( DeviceOrientation.LandscapeRight );
		}
		
		
		if( GUI.Button( new Rect( xPos, yPos += heightPlus + 20, width, height ), "Request Interstitial" ) )
		{
			AdMobBinding.requestInterstitalAd( "a14d3e67dfeb7ba" );
			//AdMobBinding.requestInterstitalAd( "YOUR_INTERSTITIAL_UNIT_ID" );
		}
		
		
		if( GUI.Button( new Rect( xPos, yPos += heightPlus, width, height ), "Is Interstial Loaded?" ) )
		{
			Debug.Log( "is interstitial loaded: " + AdMobBinding.isInterstitialAdReady() );
		}
		
		
		if( GUI.Button( new Rect( xPos, yPos += heightPlus, width, height ), "Show Interstitial" ) )
		{
			AdMobBinding.showInterstitialAd();
		}

	}


}
