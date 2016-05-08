//
//  PerformanceTestService.m
//  Native.iOS
//
//  Created by Pawel Grzmil on 08/05/16.
//  Copyright © 2016 Pawel Grzmil. All rights reserved.
//

#import "PerformanceTestService.h"

@implementation PerformanceTestService

+ (instancetype)instance
{
    static dispatch_once_t once;
    static id sharedInstance;
    dispatch_once(&once, ^{
        sharedInstance = [[self alloc] init];
    });
    return sharedInstance;
}


-(NSString*)calculatePi:(int) digits
{
    NSMutableString* result = [[NSMutableString alloc] initWithString:@""];
    digits++;
    
    uint length = digits * 3 + 2;
    uint x [length];
    uint r [length];
    
    for (int j = 0; j < length; j++)
        x[j] = 20;
    
    for (int i = 0; i < digits; i++)
    {
        uint carry = 0;
        for (int j = 0; j < length; j++)
        {
            uint num = (uint)(length - j - 1);
            uint dem = num * 2 + 1;
            
            x[j] += carry;
            
            uint q = x[j] / dem;
            r[j] = x[j] % dem;
            
            carry = q * num;
        }
        if (i < digits - 1)
            result = [NSMutableString stringWithFormat:@"%@%u", result, (x[length - 1] / 10) ];
        
        r[length - 1] = x[length - 1] % 10; ;
        for (int j = 0; j < length; j++)
            x[j] = r[j] * 10;
    }
    
    [result insertString:@"." atIndex:1];
    return result;
}

@end
