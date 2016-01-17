//
//  NetworkTestController.m
//  WASMiOS
//
//  Created by Pawel Grzmil on 17/01/16.
//  Copyright © 2016 Pawel Grzmil. All rights reserved.
//

#import "NetworkTestController.h"
@interface NetworkTestController()
@property (weak, nonatomic) IBOutlet UILabel *timeLabel;
@property (weak, nonatomic) IBOutlet UIButton *startButton;
@property (weak, nonatomic) IBOutlet UITextField *addressField;
@property (weak, nonatomic) IBOutlet UIActivityIndicatorView *activityIndicator;
@property (weak, nonatomic) IBOutlet UIImageView *ResultPicture;
@property (strong, nonatomic) NSTimer* timer;
@property (strong, nonatomic) NSDate* startTime;

@end
@implementation NetworkTestController

- (void)viewDidLoad {
    [super viewDidLoad];
    self.title = @"Test obsługi sieci";
    self.addressField.text = @"http://cdn.superbwallpapers.com/wallpapers/meme/doge-pattern-27481-2880x1800.jpg";
}

- (void)dealloc
{
    [self.timer invalidate];
}

- (IBAction)startDownloading:(id)sender {
    self.startTime = [NSDate date];
    
    self.activityIndicator.hidden = NO;
    self.timeLabel.hidden = NO;
    self.startButton.hidden = YES;
    self.addressField.userInteractionEnabled = NO;
    
    self.timer = [NSTimer scheduledTimerWithTimeInterval:0.001
                                                  target:self
                                                selector:@selector(updateTimeLabel)
                                                userInfo:nil
                                                 repeats:YES];
    
    dispatch_async( dispatch_get_global_queue(DISPATCH_QUEUE_PRIORITY_DEFAULT, 0), ^{
        NSData * data = [NSData dataWithContentsOfURL:[NSURL URLWithString:self.addressField.text]];
        dispatch_async( dispatch_get_main_queue(), ^{
            self.ResultPicture.image = [UIImage imageWithData:data];
            self.activityIndicator.hidden = YES;
            self.startButton.hidden = NO;
            self.addressField.userInteractionEnabled = YES;
            [self.timer invalidate];
        });
    });
}

-(void)updateTimeLabel{
    NSDate *now = [NSDate date];
    NSTimeInterval executionTime = [now timeIntervalSinceDate:self.startTime];
    self.timeLabel.text = [NSString stringWithFormat:@"%.3f", executionTime];
}
@end
