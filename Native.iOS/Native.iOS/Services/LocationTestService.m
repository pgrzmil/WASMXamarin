//
//  LocationTestService.m
//  Native.iOS
//
//  Created by Pawel Grzmil on 08/05/16.
//  Copyright © 2016 Pawel Grzmil. All rights reserved.
//

#import "LocationTestService.h"
#import <CoreLocation/CoreLocation.h>

@interface LocationTestService () <CLLocationManagerDelegate>

@property (nonatomic) CLLocationManager *locationManager;

@end

@implementation LocationTestService

- (instancetype)init{
    self = [super init];
    if (self) {
        self.locationManager = [[CLLocationManager alloc] init];
        self.locationManager.delegate = self;
        self.locationManager.distanceFilter = 10.f;
        self.locationManager.desiredAccuracy = kCLLocationAccuracyBest;
    }
    return self;
}

- (void)getLocation{
    [self.locationManager requestWhenInUseAuthorization];
    [self.locationManager startUpdatingLocation];
}

- (void)stop{
    [self.locationManager stopUpdatingLocation];
}

- (void)locationManager:(CLLocationManager *)manager didUpdateToLocation:(CLLocation *)newLocation fromLocation:(CLLocation *)oldLocation {
    if ([self.delegate conformsToProtocol:@protocol(LocationTestServiceDelegate)]) {
        [self.delegate locationChanged:newLocation.coordinate.latitude longitude:newLocation.coordinate.longitude];
    }
}

@end
