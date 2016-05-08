//
//  LocationTestService.h
//  Native.iOS
//
//  Created by Pawel Grzmil on 08/05/16.
//  Copyright © 2016 Pawel Grzmil. All rights reserved.
//

#import <Foundation/Foundation.h>

@protocol LocationTestServiceDelegate <NSObject>

- (void)locationChanged:(double)latitude longitude:(double)longitude;

@end

@interface LocationTestService : NSObject

@property(assign, nonatomic) id<LocationTestServiceDelegate> delegate;

- (void)getLocation;
- (void)stop;

@end
