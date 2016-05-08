//
//  NetworkTestService.h
//  Native.iOS
//
//  Created by Pawel Grzmil on 08/05/16.
//  Copyright © 2016 Pawel Grzmil. All rights reserved.
//

#import <Foundation/Foundation.h>
#import <UIKit/UIKit.h>

@interface NetworkTestService : NSObject

-(UIImage*)downloadImage:(NSString*)urlString;

@end
