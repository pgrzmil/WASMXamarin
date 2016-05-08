//
//  FileAccessTestController.m
//  Native.iOS
//
//  Created by Pawel Grzmil on 08/05/16.
//  Copyright © 2016 Pawel Grzmil. All rights reserved.
//

#import "FileAccessTestController.h"
#import "Stopwatch.h"

@interface FileAccessTestController ()
@property (weak, nonatomic) IBOutlet UIButton *readButton;
@property (weak, nonatomic) IBOutlet UIButton *writeButton;
@property (weak, nonatomic) IBOutlet UILabel *timeLabel;
@property (weak, nonatomic) IBOutlet UITextView *resultView;
@property (weak, nonatomic) IBOutlet UIActivityIndicatorView *activityIndicator;
@property (strong, nonatomic) Stopwatch* stopwatch;

@end

@implementation FileAccessTestController

- (void)viewDidLoad {
    [super viewDidLoad];
    self.title = @"Test dostępu do pliku";
    self.stopwatch = [Stopwatch new];
}

- (IBAction)startReading:(id)sender {
    [self.stopwatch start];
}

- (IBAction)startWriting:(id)sender {
    [self.stopwatch start];
}
@end
