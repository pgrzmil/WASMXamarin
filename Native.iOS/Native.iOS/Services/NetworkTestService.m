//
//  NetworkTestService.m
//  Native.iOS
//
//  Created by Pawel Grzmil on 08/05/16.
//  Copyright © 2016 Pawel Grzmil. All rights reserved.
//

#import "NetworkTestService.h"

@implementation NetworkTestService

- (void)downloadImage:(NSString*)urlString{
    NSURL *url = [NSURL URLWithString:urlString];
    NSData *data = [NSData dataWithContentsOfURL:url];
    UIImage *resultImage = [UIImage imageWithData:data];
    
    if ([self.delegate conformsToProtocol:@protocol(NetworkTestServiceDelegate)]) {
        [self.delegate imageDownloadCompleted:resultImage];
    }
}

@end
