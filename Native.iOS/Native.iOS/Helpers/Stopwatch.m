//
//  Stopwatch.m
//  Native.iOS
//
//  Created by Pawel Grzmil on 08/05/16.
//  Copyright © 2016 Pawel Grzmil. All rights reserved.
//

#import "Stopwatch.h"

@implementation Stopwatch
NSDate* startTime;
NSDate* stopTime;

-(void)start{
    startTime = [NSDate date];
}

-(void)stop{
    stopTime = [NSDate date];
}

-(NSString*)getDurationInMilliseconds{
    NSTimeInterval duration = [stopTime timeIntervalSinceDate:startTime];
    duration *= 1000;
    return [NSString stringWithFormat:@"Czas wykonania: %.3f ms", duration];    
}

-(NSString*)getDurationInSeconds{
    NSTimeInterval duration = [stopTime timeIntervalSinceDate:startTime];
    return [NSString stringWithFormat:@"Czas wykonania: %.3f s", duration];
}


@end
