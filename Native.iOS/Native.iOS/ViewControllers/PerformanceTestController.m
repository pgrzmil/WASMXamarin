//
//  PerformanceTestController.m
//  Native.iOS
//
//  Created by Pawel Grzmil on 17/01/16.
//  Copyright © 2016 Pawel Grzmil. All rights reserved.
//

#import "PerformanceTestController.h"
#import "PerformanceTestService.h"
#import "Stopwatch.h"

@interface PerformanceTestController ()
@property (weak, nonatomic) IBOutlet UIButton *startButton;
@property (weak, nonatomic) IBOutlet UITextField *digitsEntry;
@property (weak, nonatomic) IBOutlet UILabel *timeLabel;
@property (weak, nonatomic) IBOutlet UITextView *resultView;
@property (weak, nonatomic) IBOutlet UIActivityIndicatorView *activityIndicator;
@property (strong, nonatomic) Stopwatch* stopwatch;

@end
@implementation PerformanceTestController

-(void)viewDidLoad{
    [super viewDidLoad];
    self.title = @"Test obliczeń";
    self.stopwatch = [Stopwatch new];
}

- (IBAction)startCalculation:(id)sender {
    [self.stopwatch start];
    [self refreshUI:true];
    
    int digits = [self.digitsEntry.text intValue];
    
    dispatch_async( dispatch_get_global_queue(DISPATCH_QUEUE_PRIORITY_DEFAULT, 0), ^{
        NSString* pi = [[PerformanceTestService instance] calculatePi:digits];
        [self.stopwatch stop];
        dispatch_async( dispatch_get_main_queue(), ^{
            self.resultView.text = pi;
            self.timeLabel.text = [self.stopwatch getDurationInSeconds];
            [self refreshUI:false];
        });
    });
    
}

- (void)refreshUI: (BOOL)isDownloading{
    self.activityIndicator.hidden = !isDownloading;
    self.startButton.hidden = isDownloading;
    self.digitsEntry.userInteractionEnabled = !isDownloading;
}

@end
