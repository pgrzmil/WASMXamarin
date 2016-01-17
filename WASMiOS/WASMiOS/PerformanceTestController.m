//
//  PerformanceTestController.m
//  WASMiOS
//
//  Created by Pawel Grzmil on 17/01/16.
//  Copyright © 2016 Pawel Grzmil. All rights reserved.
//

#import "PerformanceTestController.h"
@interface PerformanceTestController ()
@property (weak, nonatomic) IBOutlet UIButton *startButton;
@property (weak, nonatomic) IBOutlet UITextField *digitsField;
@property (weak, nonatomic) IBOutlet UILabel *timeLabel;
@property (weak, nonatomic) IBOutlet UITextView *resultView;
@property (weak, nonatomic) IBOutlet UIActivityIndicatorView *activityIndicator;
@property (strong, nonatomic) NSTimer* timer;
@property (strong, nonatomic) NSDate* startTime;

@end
@implementation PerformanceTestController

-(void)viewDidLoad{
    [super viewDidLoad];
    self.digitsField.text = @"10000";
    self.title = @"Test wydajnoci obliczeń";
}

- (void)dealloc
{
    [self.timer invalidate];
}

- (IBAction)startCalculation:(id)sender {
    self.startTime = [NSDate date];
    
    self.activityIndicator.hidden = NO;
    self.timeLabel.hidden = NO;
    self.startButton.hidden = YES;
    
    self.timer = [NSTimer scheduledTimerWithTimeInterval:0.001
                                     target:self
                                   selector:@selector(updateTimeLabel)
                                   userInfo:nil
                                    repeats:YES];
    int digits = [self.digitsField.text intValue];
    
    dispatch_async( dispatch_get_global_queue(DISPATCH_QUEUE_PRIORITY_DEFAULT, 0), ^{
        NSString* pi = [self calculatePi:digits];
        dispatch_async( dispatch_get_main_queue(), ^{
            self.resultView.text = pi;
            self.activityIndicator.hidden = YES;
            self.startButton.hidden = NO;
            [self.timer invalidate];
        });
    });
    
}

-(NSString*)calculatePi:(int) digits
{
    NSString* result = @"";
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
        if (i < digits - 1){
            if(i==1)
                result = [NSString stringWithFormat:@"%@.", result ];
            result = [NSString stringWithFormat:@"%@%u", result, (x[length - 1] / 10) ];
        }
        r[length - 1] = x[length - 1] % 10; ;
        for (int j = 0; j < length; j++)
            x[j] = r[j] * 10;
    }
    
    return result;
}

-(void)updateTimeLabel{
    NSDate *now = [NSDate date];
    NSTimeInterval executionTime = [now timeIntervalSinceDate:self.startTime];
    self.timeLabel.text = [NSString stringWithFormat:@"%.3f", executionTime];
}

@end
