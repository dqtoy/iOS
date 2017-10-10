//
//  AdManager.h
//  iAd
//
//  Created by Mike on 8/18/10.
//  Copyright 2010 Prime31 Studios. All rights reserved.
//

#import <Foundation/Foundation.h>
#import <iAd/iAd.h>


@interface AdManager : NSObject <ADBannerViewDelegate, ADInterstitialAdDelegate>
{
	UIView *_adViewWrapper;
	ADBannerView *_adView;
	UIViewController *_controller;
	UIViewController *_interstitialController;
	BOOL _fireHideShowEvents;
	ADInterstitialAd *_interstitial;
	
@private
	UIInterfaceOrientation _orientation;
	BOOL _adBannerOnBottom;
	BOOL _bannerIsVisible;
	BOOL _bannerCreatedInPortrait;
}
@property (nonatomic, retain) UIView *adViewWrapper;
@property (nonatomic, retain) UIViewController *controller;
@property (nonatomic, retain) ADBannerView *adView;
@property (nonatomic, assign) BOOL fireHideShowEvents;
@property (nonatomic, retain) ADInterstitialAd *interstitial;


+ (AdManager*)sharedManager;

- (void)createAdBanner;

- (void)destroyAdBanner;

- (void)setBannerIsOnBottom:(BOOL)isBottom;

- (void)rotateToOrientation:(UIInterfaceOrientation)orientation;

- (BOOL)initializeInterstitial;

- (BOOL)interstitialIsLoaded;

- (BOOL)showInterstitial;

@end
