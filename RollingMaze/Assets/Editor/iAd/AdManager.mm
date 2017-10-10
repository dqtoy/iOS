//
//  AdManager.m
//  iAd
//
//  Created by Mike on 8/18/10.
//  Copyright 2010 Prime31 Studios. All rights reserved.
//

#import "AdManager.h"
#import "AdViewController.h"


void UnityPause( bool pause );

void UnitySendMessage( const char * className, const char * methodName, const char * param );


@interface AdManager(Private)
- (void)adjustRequestedAdTypesBasedOnOrientation;
- (void)adjustAdViewFrameToShowAdView:(BOOL)animated;
@end



@implementation AdManager

@synthesize adView = _adView, adViewWrapper = _adViewWrapper, controller = _controller,
			fireHideShowEvents = _fireHideShowEvents, interstitial = _interstitial;

///////////////////////////////////////////////////////////////////////////////////////////////////
#pragma mark NSObject

+ (AdManager*)sharedManager
{
	static AdManager *sharedSingleton;
	
	if( !sharedSingleton )
		sharedSingleton = [[AdManager alloc] init];
	
	return sharedSingleton;
}


- (id)init
{
	// early out if we dont have iOS 4.0 iAd.framework
	if( !NSClassFromString( @"ADBannerView" ) )
		return nil;
	
	if( self = [super init] )
	{
		// sensible defaults
		_adBannerOnBottom = YES;
		
		// grab our orientation
		_orientation = [UIApplication sharedApplication].statusBarOrientation;
	}
	return self;
}


///////////////////////////////////////////////////////////////////////////////////////////////////
#pragma mark Private

- (void)adjustRequestedAdTypesBasedOnOrientation
{
	// set the contentSize and requiredContentSize so the adView knows what it can display
	if( UIInterfaceOrientationIsLandscape( _orientation ) )
	{
		if( _adView )
		{
			[_adView removeFromSuperview];
			[_controller.view bringSubviewToFront:_adViewWrapper];
			[_adViewWrapper addSubview:_adView];
		}
		
		// use the new add banner content size identifiers when available
		if( &ADBannerContentSizeIdentifierLandscape != NULL )
		{
			_adView.requiredContentSizeIdentifiers = [NSSet setWithObject:ADBannerContentSizeIdentifierLandscape];
			_adView.currentContentSizeIdentifier = ADBannerContentSizeIdentifierLandscape;
		}
		else
		{
			_adView.requiredContentSizeIdentifiers = [NSSet setWithObject:ADBannerContentSizeIdentifier480x32];
			_adView.currentContentSizeIdentifier = ADBannerContentSizeIdentifier480x32;
		}
	}
	else
	{
		if( _adView )
		{
			[_adView removeFromSuperview];
			[_controller.view bringSubviewToFront:_adView];
			[_controller.view addSubview:_adView];
		}
		
		// use the new add banner content size identifiers when available
		if( &ADBannerContentSizeIdentifierPortrait != NULL )
		{
			_adView.requiredContentSizeIdentifiers = [NSSet setWithObject:ADBannerContentSizeIdentifierPortrait];
			_adView.currentContentSizeIdentifier = ADBannerContentSizeIdentifierPortrait;
		}
		else
		{
			_adView.requiredContentSizeIdentifiers = [NSSet setWithObject:ADBannerContentSizeIdentifier320x50];
			_adView.currentContentSizeIdentifier = ADBannerContentSizeIdentifier320x50;
		}
	}
}


- (void)adjustAdViewFrameToShowAdView:(BOOL)animated
{
	if( animated )
		[UIView beginAnimations:nil context:nil];
	
	// setup bools for edge case detection
	BOOL isLandscape = UIInterfaceOrientationIsLandscape( _orientation );
	BOOL isLandscapeLeft = _orientation == UIInterfaceOrientationLandscapeLeft;
	BOOL isPortraitUpsideDown = _orientation == UIInterfaceOrientationPortraitUpsideDown;
	
	// when we are landscape right or portraitUpsideDown, the view is totally flipped so we calculate everything opposite
	BOOL calculateForBannerOnBottom = ( isLandscape && !isLandscapeLeft || !isLandscape && isPortraitUpsideDown ) ? !_adBannerOnBottom : _adBannerOnBottom;
	
	// if landscape, everything is reversed (width for height) due to the transform
	if( isLandscape )
	{
		CGFloat xOffset = ( calculateForBannerOnBottom ) ? -_controller.view.frame.size.width : _controller.view.frame.size.width;
		
		// if the banner isn't visible, reverse the offset animation
		if( !_bannerIsVisible )
			xOffset *= -1;
		
		_controller.view.frame = CGRectOffset( _controller.view.frame, xOffset, 0 );
	}
	else
	{
		CGFloat yOffset = ( calculateForBannerOnBottom ) ? -_controller.view.frame.size.height : _controller.view.frame.size.height;
		
		// if the banner isn't visible, reverse the offset animation
		if( !_bannerIsVisible )
			yOffset *= -1;
		
		_controller.view.frame = CGRectOffset( _controller.view.frame, 0, yOffset );
	}
	
	if( animated )
		[UIView commitAnimations];
	
	// Bring the ad back into view in case we were viewing an ad
	_controller.view.hidden = NO;
}


///////////////////////////////////////////////////////////////////////////////////////////////////
#pragma mark Public

- (void)createAdBanner
{
	// if we have an adView dont create one
	if( _adView )
		return;
	
	// save this.  landscape ads won't work if the banner was created in portrait
	_bannerCreatedInPortrait = UIInterfaceOrientationIsPortrait( _orientation );
	
	_adView = [[ADBannerView alloc] initWithFrame:CGRectZero];
	_adView.autoresizingMask = UIViewAutoresizingFlexibleWidth | UIViewAutoresizingFlexibleHeight;
	_adView.delegate = self;
	
	// create a wrapper view to handle landscape to fix the rotation bug in iOS
	_adViewWrapper = [[UIView alloc] initWithFrame:CGRectZero];
	[_adViewWrapper addSubview:_adView];
	
	// Inject a view controller and stick the adViewWrapper in it for safe keeping
	_controller = [[AdViewController alloc] initWithNibName:nil bundle:nil];
	_controller.view.userInteractionEnabled = YES;
	[_controller.view addSubview:_adViewWrapper];
	
	[[UIApplication sharedApplication].keyWindow addSubview:_controller.view];
	[[UIApplication sharedApplication].keyWindow bringSubviewToFront:_controller.view];
	
	// this method will add either add the adView to the controller or the adViewWrapper
	[self adjustRequestedAdTypesBasedOnOrientation];
}


- (void)destroyAdBanner
{
	// destroy the adView
	_adView.delegate = nil;
	[_adView removeFromSuperview];
	[_adView release];
	_adView = nil;
	
	[_adViewWrapper removeFromSuperview];
	[_adViewWrapper release];
	_adViewWrapper = nil;
	
	// kill the view controller
	[_controller.view removeFromSuperview];
	[_controller release];
	_controller = nil;
	
	_bannerIsVisible = NO;
}


- (void)setBannerIsOnBottom:(BOOL)isBottom
{
	_adBannerOnBottom = isBottom;
	
	BOOL isLandscape = UIInterfaceOrientationIsLandscape( _orientation );
	BOOL isLandscapeLeft = _orientation == UIInterfaceOrientationLandscapeLeft;
	BOOL isPortraitUpsideDown = _orientation == UIInterfaceOrientationPortraitUpsideDown;
	
	// when we are landscape right or portraitUpsideDown, the view is totally flipped so we calculate everything opposite
	BOOL calculateForBannerOnBottom = ( isLandscape && !isLandscapeLeft || !isLandscape && isPortraitUpsideDown ) ? !_adBannerOnBottom : _adBannerOnBottom;
	
	CGFloat _screenWidth = [UIScreen mainScreen].bounds.size.width;
	CGFloat _screenHeight = [UIScreen mainScreen].bounds.size.height;
	
	// we use the adViews size for some calculations so set it here and also keep the wrapper in sync
	CGRect desiredAdViewFrame;
	if( UI_USER_INTERFACE_IDIOM() == UIUserInterfaceIdiomPad )
		desiredAdViewFrame = ( isLandscape ) ? CGRectMake( 0, 0, 1024, 66 ) : CGRectMake( 0, 0, 768, 66 );
	else
		desiredAdViewFrame = ( isLandscape ) ? CGRectMake( 0, 0, 480, 32 ) : CGRectMake( 0, 0, 320, 50 );
	
	// Tell the adView what we want to see and position the adView
	CGRect frame = CGRectZero;
	
	if( isLandscape )
	{
		frame = CGRectMake( 0, 0, _adView.frame.size.height, _adView.frame.size.width );
		
		if( isLandscapeLeft )
			_controller.view.transform = CGAffineTransformMake( 0, -1, 1, 0, 0, 0 );
		else
			_controller.view.transform = CGAffineTransformMake( 0, 1, -1, 0, 0, 0 );
		
		// center the view because it is only _adView.width px accross
		frame.origin.y = ( _screenHeight - frame.size.height ) / 2;
		
		if( calculateForBannerOnBottom )
			frame.origin.x = _screenWidth; // full screen width to move it off the screen
		else
			frame.origin.x -= _adView.frame.size.height; // just move off the screen the width of the banner
	}
	else
	{
		frame = CGRectMake( 0, 0, _adView.frame.size.width, _adView.frame.size.height );
		
		// force the identity transform for portrait
		if( isPortraitUpsideDown )
			_controller.view.transform = CGAffineTransformMakeRotation( M_PI );
		else
			_controller.view.transform = CGAffineTransformIdentity;

		// center the view because it is only _adViewWidth px accross
		frame.origin.x = ( _screenWidth - frame.size.width ) / 2;
		
		if( calculateForBannerOnBottom )
			frame.origin.y = _screenHeight;
		else
			frame.origin.y = -_adView.frame.size.height; // just move off the screen the height of the banner
	}
	
	// Set the frames of all our views
	_adViewWrapper.frame = desiredAdViewFrame;
	_controller.view.frame = frame;
	_adView.frame = desiredAdViewFrame;
}


- (void)rotateToOrientation:(UIInterfaceOrientation)orientation
{
	// set the appropriate ivars
	_orientation = orientation;
	
	// Huge hack to handle the landscape issue when the game launches in portrait and changes orientation immediately
	// we destroy and recreate the banner in landscape mode to get touches working.  iPad doesn't need this hack.
	BOOL isPad = ( UI_USER_INTERFACE_IDIOM() == UIUserInterfaceIdiomPad );
	if( _bannerCreatedInPortrait && UIInterfaceOrientationIsLandscape( _orientation ) && !isPad )
	{
		NSLog( @"recreating adView because it was created in portrait and we are now in landscape" );
		[self destroyAdBanner];
		[self createAdBanner];
	}
	
	// adjust requested ad types and relayout the adView
	[self adjustRequestedAdTypesBasedOnOrientation];
	[self setBannerIsOnBottom:_adBannerOnBottom];
	
	if( _bannerIsVisible )
		[self adjustAdViewFrameToShowAdView:NO];
}


// interstitial methods
- (BOOL)initializeInterstitial
{
	// iPad only
	if( UI_USER_INTERFACE_IDIOM() != UIUserInterfaceIdiomPad )
		return NO;
	
	// early out if we dont have iOS 4.3 iAd.framework
	if( !NSClassFromString( @"ADInterstitialAd" ) )
		return NO;
	
	self.interstitial = [[[ADInterstitialAd alloc] init] autorelease];
	_interstitial.delegate = self;
	
	return YES;
}


- (BOOL)interstitialIsLoaded
{
	if( _interstitial )
		return _interstitial.isLoaded;
	return NO;
}


- (BOOL)showInterstitial
{
	if( !_interstitial.isLoaded )
		return NO;
	
	UnityPause( true );
	
	if( _adView )
	{
		NSLog( @"ad banner being destroyed because you cannot display a banner and an interstitial at the same time" );
		[self destroyAdBanner];
	}
	
	// create a temporty ViewController to display the interstitial from
	_interstitialController = [[UIViewController alloc] init];
	_interstitialController.view.backgroundColor = [UIColor clearColor];
	
	[[UIApplication sharedApplication].keyWindow addSubview:_interstitialController.view];
	[[UIApplication sharedApplication].keyWindow bringSubviewToFront:_interstitialController.view];
	
	// show the ad
	[_interstitial presentFromViewController:_interstitialController];
	
	return YES;
}


///////////////////////////////////////////////////////////////////////////////////////////////////
#pragma mark ADBannerViewDelegate

- (void)bannerView:(ADBannerView*)banner didFailToReceiveAdWithError:(NSError*)error
{
	NSLog( @"------ bannerView:didFailToReceiveAdWithError: %@", [error localizedDescription] );
	if( _bannerIsVisible )
    {
		_bannerIsVisible = NO;
		[self adjustAdViewFrameToShowAdView:YES];
    }
	
	// fire the event if we want it
	if( _fireHideShowEvents )
		UnitySendMessage( "AdManager", "adViewDidShow", "0" );
}


- (void)bannerViewDidLoadAd:(ADBannerView*)banner
{
    if( !_bannerIsVisible )
    {
		_bannerIsVisible = YES;
		[self adjustAdViewFrameToShowAdView:YES];
		
		// fire the event if we want it.  we only fire this event when we change from not visible to visible
		if( _fireHideShowEvents )
			UnitySendMessage( "AdManager", "adViewDidShow", "1" );
    }
}


- (BOOL)bannerViewActionShouldBegin:(ADBannerView*)banner willLeaveApplication:(BOOL)willLeave
{
	// Hide the ad while they view it to avoid having it jump position.  Landscape only due to the way Unity does things
	_controller.view.alpha = 0.0f;
	
	UnityPause( true );
	return YES;
}


- (void)bannerViewActionDidFinish:(ADBannerView*)banner
{
	[self setBannerIsOnBottom:_adBannerOnBottom];
	[self adjustAdViewFrameToShowAdView:NO];
	
	// reshow our view
	_controller.view.alpha = 1.0f;
	
	UnityPause( false );
}


///////////////////////////////////////////////////////////////////////////////////////////////////
#pragma mark ADInterstitialAdDelegate

- (void)interstitialAdDidUnload:(ADInterstitialAd*)interstitialAd
{
	// release the interstitial and init a new one
	_interstitial.delegate = nil;
	self.interstitial = nil;
	
	[self performSelector:@selector(releaseAndCleanupInterstitialController) withObject:nil afterDelay:2.0];
}


- (void)releaseAndCleanupInterstitialController
{
	[_interstitialController.view removeFromSuperview];
	[_interstitialController release];
	_interstitialController = nil;
	
	UnityPause( false );
}


- (void)interstitialAdActionDidFinish:(ADInterstitialAd*)interstitialAd
{
	UnityPause( false );
}


- (void)interstitialAd:(ADInterstitialAd*)interstitialAd didFailWithError:(NSError*)error
{
	UnitySendMessage( "AdManager", "interstitialFailed", [[error localizedDescription] UTF8String] );
	
	_interstitial.delegate = nil;
	self.interstitial = nil;
}


- (void)interstitialAdDidLoad:(ADInterstitialAd*)interstitialAd
{
	UnitySendMessage( "AdManager", "interstitialLoaded", "" );
}


@end
