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

@interface PerformanceTestController () <PerformanceTestServiceDelegate>

@property (weak, nonatomic) IBOutlet UIButton *startButton;
@property (weak, nonatomic) IBOutlet UITextField *digitsEntry;
@property (weak, nonatomic) IBOutlet UILabel *timeLabel;
@property (weak, nonatomic) IBOutlet UITextView *resultView;
@property (weak, nonatomic) IBOutlet UIActivityIndicatorView *activityIndicator;

@property (strong, nonatomic) Stopwatch *stopwatch;

@end
@implementation PerformanceTestController

- (void)viewDidLoad{
    [super viewDidLoad];
    self.title = @"Test obliczeń";
    
    self.stopwatch = [Stopwatch new];
    [PerformanceTestService instance].delegate = self;
}

- (IBAction)startCalculation:(id)sender {
    self.resultView.text = @"";
    [self refreshUI:true];
    [self.stopwatch start];
    
    int digits = [self.digitsEntry.text intValue];
    
    dispatch_async( dispatch_get_global_queue(DISPATCH_QUEUE_PRIORITY_DEFAULT, 0), ^{
        [[PerformanceTestService instance] calculatePi:digits];
    });
}

- (void)piCalculationCompleted:(NSString *)result{
    [self.stopwatch stop];
    dispatch_async( dispatch_get_main_queue(), ^{
        self.resultView.text = result;
        self.timeLabel.text = [self.stopwatch getDurationInSeconds];
        [self refreshUI:false];
    });
}

- (void)refreshUI:(BOOL)isCalculating{
    self.activityIndicator.hidden = !isCalculating;
    self.startButton.hidden = isCalculating;
    self.digitsEntry.userInteractionEnabled = !isCalculating;
}

@end
