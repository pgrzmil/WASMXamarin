//
//  FileAccessTestService.h
//  Native.iOS
//
//  Created by Pawel Grzmil on 08/05/16.
//  Copyright © 2016 Pawel Grzmil. All rights reserved.
//

#import <Foundation/Foundation.h>

@interface FileAccessTestService : NSObject

- (void)writeToFile:(NSString *)fileName text:(NSString *)text;
- (NSString*)readFromFile:(NSString *)fileName;

@end
