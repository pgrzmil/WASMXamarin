//
//  FileAccessTestService.m
//  Native.iOS
//
//  Created by Pawel Grzmil on 08/05/16.
//  Copyright © 2016 Pawel Grzmil. All rights reserved.
//

#import "FileAccessTestService.h"

@implementation FileAccessTestService

- (void)writeToFile:(NSString *)fileName text:(NSString *)text{
    NSString *filePath = [NSSearchPathForDirectoriesInDomains(NSDocumentDirectory, NSUserDomainMask, YES) objectAtIndex:0];
    fileName = [NSString stringWithFormat:@"/%@", fileName];
    NSString *fileAtPath = [filePath stringByAppendingString:fileName];
    NSError *error = [NSError new];
    
    if ([[NSFileManager defaultManager] fileExistsAtPath:fileAtPath]) {
        [[NSFileManager defaultManager] removeItemAtPath:fileAtPath error: &error];
    }
    
    [[NSFileManager defaultManager] createFileAtPath:fileAtPath contents:nil attributes:nil];
    [[text dataUsingEncoding:NSUTF8StringEncoding] writeToFile:fileAtPath atomically:NO];
}

- (NSString*)readFromFile:(NSString *)fileName{
    NSString *filePath = [NSSearchPathForDirectoriesInDomains(NSDocumentDirectory, NSUserDomainMask, YES) objectAtIndex:0];
    fileName = [NSString stringWithFormat:@"/%@", fileName];
    NSString *fileAtPath = [filePath stringByAppendingString:fileName];
    
    return [[NSString alloc] initWithData:[NSData dataWithContentsOfFile:fileAtPath] encoding:NSUTF8StringEncoding];
}

@end
