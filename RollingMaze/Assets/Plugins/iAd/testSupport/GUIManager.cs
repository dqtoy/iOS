using UnityEngine;
using System.Collections.Generic;


public class GUIManager : MonoBehaviour
{
	bool isPad;
	
	void Start()
	{
		// hack to detect iPad 2 until Unity adds official support
		this.isPad = ( Screen.width == 1024 || Screen.height == 1024 );
		
		if( isPad )
		{
			// listen to interstital events for illustration purposes
			AdManager.interstitalAdFailed += delegate( string error )
			{
				Debug.Log( "interstitalAdFailed: " + error );
			};
			
			AdManager.interstitialAdLoaded += delegate()
			{
				Debug.Log( "interstitialAdLoaded" );
			};
		}
	}
	
	
	void OnGUI()
	{
		float yPos = 60.0f;
		float xPos = 60.0f;
		float width = 200.0f;
		float height = 40;
		float heightPlus = 55;
		
		if( GUI.Button( new Rect( xPos, yPos, width, height ), "Create Ad Banner" ) )
		{
			AdBinding.createAdBanner( true );
		}
		
		
		if( GUI.Button( new Rect( xPos, yPos += heightPlus, width, height ), "Destroy Ad Banner" ) )
		{
			AdBinding.destroyAdBanner();
		}
		
		
		if( GUI.Button( new Rect( xPos, yPos += heightPlus, width, height ), "Force Portrait" ) )
		{
			AdBinding.rotateToOrientation( DeviceOrientation.Portrait );
		}
		
		
		if( GUI.Button( new Rect( xPos, yPos += heightPlus, width, height ), "Force Landscape Left" ) )
		{
			AdBinding.rotateToOrientation( DeviceOrientation.LandscapeLeft );
		}

		
		
		if( isPad )
		{
			if( GUI.Button( new Rect( xPos, yPos += heightPlus, width, height ), "Initialize Interstitial" ) )
			{
				bool result = AdBinding.initializeInterstitial();
				Debug.Log( "initializeInterstitial: " + result );
			}
			
			
			if( GUI.Button( new Rect( xPos, yPos += heightPlus, width, height ), "Is Interstitial Loaded?" ) )
			{
				bool result = AdBinding.isInterstitalLoaded();
				Debug.Log( "isInterstitalLoaded: " + result );
			}
			
			
			if( GUI.Button( new Rect( xPos, yPos += heightPlus, width, height ), "Show Interstitial" ) )
			{
				bool result = AdBinding.showInterstitial();
				Debug.Log( "showInterstitial: " + result );
			}
		}

	}
}
