//
//  NetworkTestService.h
//  Native.iOS
//
//  Created by Pawel Grzmil on 08/05/16.
//  Copyright © 2016 Pawel Grzmil. All rights reserved.
//

#import <Foundation/Foundation.h>
#import <UIKit/UIKit.h>

@protocol NetworkTestServiceDelegate <NSObject>

- (void)imageDownloadCompleted:(UIImage *)image;

@end

@interface NetworkTestService : NSObject

@property(assign, nonatomic) id<NetworkTestServiceDelegate> delegate;

- (void)downloadImage:(NSString *)urlString;

@end
