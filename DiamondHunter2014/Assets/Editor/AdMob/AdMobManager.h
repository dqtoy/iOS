//
//  AdMobManager.h
//  AdMobTest
//
//  Created by Mike on 1/27/11.
//  Copyright 2011 Prime31 Studios. All rights reserved.
//

#import <Foundation/Foundation.h>
#import "GADBannerView.h"
#import "GADInterstitial.h"


typedef enum
{
	AdMobBannerTypeiPhone_320x50,
	AdMobBannerTypeiPad_728x90,
	AdMobBannerTypeiPad_468x60,
	AdMobBannerTypeiPad_320x250
} AdMobBannerType;


@interface AdMobManager : NSObject <GADBannerViewDelegate, GADInterstitialDelegate>
{
	GADBannerView *_adView;
	GADInterstitial *_interstitialAd;
	UIViewController *_controller;
	
@private
	AdMobBannerType _bannerType;
	NSString *_publisherId;
	CGPoint _originPoint;
	CGPoint _originalCenter;
	CGFloat _adViewWidth;
	CGFloat _adViewHeight;
	UIInterfaceOrientation _orientation;
}
@property (nonatomic, retain) UIViewController *controller;
@property (nonatomic, retain) GADBannerView *adView;
@property (nonatomic, retain) GADInterstitial *interstitialAd;
@property (nonatomic, retain) NSString *publisherId;


+ (AdMobManager*)sharedManager;


- (void)createBanner:(AdMobBannerType)bannerType withOrigin:(CGPoint)originPoint;

- (void)destroyBanner;

- (void)rotateToOrientation:(UIInterfaceOrientation)orientation;

- (void)requestInterstitalAd:(NSString*)interstitialUnitId;

- (void)showInterstitialAd;

- (void)registerAppDownloadWithiTunesAppId:(NSString*)appId;

- (void)registerAppDownloadWithAdMobSiteId;

@end
