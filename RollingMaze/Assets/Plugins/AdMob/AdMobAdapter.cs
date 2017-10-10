using UnityEngine;
using System.Collections;


public class AdMobAdapter : MonoBehaviour
{
	public bool autorotateAds = true;
	public bool isLandscape = true;
	public string publisherId = "a14d3e67dfeb7ba";
	
	
	void Start()
	{
		AdMobBinding.init( publisherId );

		// center the banner.  this is a basic setup with centered banners
		if( isLandscape )
		{
			if( iPhoneSettings.generation == iPhoneGeneration.iPad1Gen )
				AdMobBinding.createBanner( AdMobBannerType.iPad_728x90, ( Screen.width - 728 ) / 2, 0 );
			else
				AdMobBinding.createBanner( AdMobBannerType.iPhone_320x50, ( Screen.width - 320 ) / 2, 0 );
				
			// rotate to our desired orientation, in this case landscape left
			AdMobBinding.rotateToOrientation( DeviceOrientation.LandscapeLeft );
			Screen.orientation = ( ScreenOrientation )DeviceOrientation.LandscapeLeft;
		}
		else
		{
			if( iPhoneSettings.generation == iPhoneGeneration.iPad1Gen )
				AdMobBinding.createBanner( AdMobBannerType.iPad_728x90, 0, 0 );
			else
				AdMobBinding.createBanner( AdMobBannerType.iPhone_320x50, 0, 0 );
		}
		
		// if we are not autorotating ads we can get out of here and destroy ourself
		if( !autorotateAds )
			Destroy( gameObject );
	}
	

	void Update()
	{
		// only update if we switched orientation
		if( Screen.orientation != ( ScreenOrientation )Input.deviceOrientation )
		{
			if( isLandscape )
			{
				// Allow rotating to landscape left/right
				if( Input.deviceOrientation == DeviceOrientation.LandscapeLeft || Input.deviceOrientation == DeviceOrientation.LandscapeRight )
				{
					AdMobBinding.rotateToOrientation( Input.deviceOrientation );
					Screen.orientation = ( ScreenOrientation )Input.deviceOrientation;;
				}
			}
			else
			{
				// Allow rotating to portrait and portrait upsideDown
				if( Input.deviceOrientation == DeviceOrientation.Portrait || Input.deviceOrientation == DeviceOrientation.PortraitUpsideDown )
				{
					// no need to swap orientation for these because device and screen are the same
					AdMobBinding.rotateToOrientation( Input.deviceOrientation );
					Screen.orientation = ( ScreenOrientation )Input.deviceOrientation;
				}
			}
		}
	}

}
