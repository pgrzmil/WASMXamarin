//
//  Stopwatch.h
//  Native.iOS
//
//  Created by Pawel Grzmil on 08/05/16.
//  Copyright © 2016 Pawel Grzmil. All rights reserved.
//

#import <Foundation/Foundation.h>

@interface Stopwatch : NSObject

-(void)start;
-(void)stop;
-(NSString*)getDurationInMilliseconds;
-(NSString*)getDurationInSeconds;

@end
