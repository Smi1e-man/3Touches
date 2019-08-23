//
//  ALAdView.h
//  AppLovinSDK
//
//  Created by Basil on 3/1/12.
//  Copyright © 2019 AppLovin Corporation. All rights reserved.
//

#import <UIKit/UIKit.h>

#import "ALSdk.h"
#import "ALAdService.h"
#import "ALAdViewEventDelegate.h"

NS_ASSUME_NONNULL_BEGIN

/**
 * This class represents a view-based ad - i.e. banner, mrec or leader.
 */
@interface ALAdView : UIView

/**
 * @name Ad Delegates
 */

/**
 *  An object conforming to the ALAdLoadDelegate protocol, which, if set, will be notified of ad load events.
 *
 *  Please note: This delegate is retained strongly and might lead to retain cycles if delegate holds strong reference to this ALAdView.
 */
@property (nonatomic, strong, nullable) IBOutlet id<ALAdLoadDelegate> adLoadDelegate;

/**
 *  An object conforming to the ALAdDisplayDelegate protocol, which, if set, will be notified of ad show/hide events.
 *
 *  Please note: This delegate is retained strongly and might lead to retain cycles if delegate holds strong reference to this ALAdView.
 */
@property (nonatomic, strong, nullable) IBOutlet id<ALAdDisplayDelegate> adDisplayDelegate;

/**
 *  An object conforming to the ALAdViewEventDelegate protocol, which, if set, will be notified of ALAdView-specific events.
 *
 *  Please note: This delegate is retained strongly and might lead to retain cycles if delegate holds strong reference to this ALAdView.
 */
@property (nonatomic, strong, nullable) IBOutlet id<ALAdViewEventDelegate> adEventDelegate;

// Primarily for internal use; banners and mrecs cannot contain videos.
@property (nonatomic, strong, nullable) IBOutlet id<ALAdVideoPlaybackDelegate> adVideoPlaybackDelegate;

/**
 * @name Ad View Configuration
 */

/**
 *  The size of ads to be loaded within this ALAdView.
 */
@property (nonatomic, strong) ALAdSize *adSize;

/**
 *  The zone identifier this ALAdView was initialized with and is loading ads for, if any.
 */
@property (nonatomic, copy, readonly, nullable) NSString *zoneIdentifier;

/**
 *  Whether or not this ALAdView should automatically load and rotate banners.
 *
 *  If YES, ads will be automatically loaded and updated. If NO, you are reponsible for this behavior via [ALAdView loadNextAd]. Defaults to YES.
 */
@property (nonatomic, assign, getter=isAutoloadEnabled, setter=setAutoloadEnabled:) BOOL autoload;
@property (nonatomic, assign, getter=isAutoloadEnabled, setter=setAutoloadEnabled:) BOOL shouldAutoload;

/**
 * @name Loading and Rendering Ads
 */

/**
 * Loads AND displays an ad into the view. This method will return immediately.
 *
 * Please note: To load ad but not display it, use `[[ALSdk shared].adService loadNextAd: ... andNotify: ...]` then `[adView renderAd: ...]` to render it.
 */
- (void)loadNextAd;

/**
 * Render a specific ad that was loaded via ALAdService.
 *
 * @param ad Ad to render. Must not be nil.
 */
- (void)render:(ALAd *)ad;

/**
 * @name Initialization
 */

/**
 *  Initialize the ad view with a given size.
 *
 *  @param size ALAdSize representing the size of this ad. For example, [ALAdSize sizeBanner].
 *
 *  @return A new instance of ALAdView.
 */
- (instancetype)initWithSize:(ALAdSize *)size;

/**
 *  Initialize the ad view for a given size and zone.
 *
 *  @param size           ALAdSize representing the size of this ad. For example, [ALAdSize sizeBanner].
 *  @param zoneIdentifier Identifier for the zone this ALAdView should load ads for.
 *
 *  @return A new instance of ALAdView.
 */
- (instancetype)initWithSize:(ALAdSize *)size zoneIdentifier:(nullable NSString *)zoneIdentifier;

/**
 *  Initialize the ad view with a given sdk and size.
 *
 *  @param sdk  Instance of ALSdk to use.
 *  @param size ALAdSize representing the size of this ad. For example, [ALAdSize sizeBanner].
 *
 *  @return A new instance of ALAdView.
 */
- (instancetype)initWithSdk:(ALSdk *)sdk size:(ALAdSize *)size;

/**
 *  Initialize the ad view with a given sdk, size, and zone.
 *
 *  @param sdk            Instance of ALSdk to use.
 *  @param size           ALAdSize representing the size of this ad. For example, [ALAdSize sizeBanner].
 *  @param zoneIdentifier Identifier for the zone this ALAdView should load ads for.
 *
 *  @return A new instance of ALAdView.
 */
- (instancetype)initWithSdk:(ALSdk *)sdk size:(ALAdSize *)size zoneIdentifier:(nullable NSString *)zoneIdentifier;

/**
 * Initialize ad view with a given frame, ad size, and ALSdk instance.
 *
 * @param frame  Frame to use.
 * @param size   Ad size to use.
 * @param sdk    Instance of ALSdk to use.
 *
 * @return A new instance of ALAdView.
 */
- (instancetype)initWithFrame:(CGRect)frame size:(ALAdSize *)size sdk:(ALSdk *)sdk;
- (instancetype)init __attribute__((unavailable("Use one of the other provided initializers")));

@end

@interface ALAdView(ALDeprecated)
@property (strong, atomic, nullable) UIViewController *parentController __deprecated_msg("This property is deprecated and will be removed in a future SDK version.");
- (void)render:(ALAd *)ad overPlacement:(nullable NSString *)placement __deprecated_msg("Placements have been deprecated and will be removed in a future SDK version. Please configure zones from the UI and use them instead.");
@property (readonly, atomic, getter=isReadyForDisplay) BOOL readyForDisplay __deprecated_msg("Checking whether an ad is ready for display has been deprecated and will be removed in a future SDK version. Please use `loadNextAd` or `renderAd:` to display an ad.");
@end

NS_ASSUME_NONNULL_END
