//
//  LocationTestController.m
//  Native.iOS
//
//  Created by Pawel Grzmil on 08/05/16.
//  Copyright © 2016 Pawel Grzmil. All rights reserved.
//

#import "LocationTestController.h"
#import "LocationTestService.h"
#import "Stopwatch.h"


@interface LocationTestController () <LocationTestServiceDelegate>

@property (weak, nonatomic) IBOutlet UIButton *startButton;
@property (weak, nonatomic) IBOutlet UILabel *timeLabel;
@property (weak, nonatomic) IBOutlet UILabel *positionLabel;
@property (weak, nonatomic) IBOutlet UIActivityIndicatorView *activityIndicator;

@property (strong, nonatomic) Stopwatch *stopwatch;
@property (strong, nonatomic) LocationTestService *locationService;

@end

@implementation LocationTestController

- (void)viewDidLoad {
    [super viewDidLoad];
    self.title = @"Test pozycji GPS";
    
    self.stopwatch = [Stopwatch new];
    self.locationService = [LocationTestService new];
    self.locationService.delegate = self;
}

- (IBAction)startPositioning:(id)sender {
    [self refreshUI:true];
    [self.stopwatch start];
    
    [self.locationService getLocation];
}

- (void)locationChanged:(double)latitude longitude:(double)longitude{
    [self.stopwatch stop];
    [self.locationService stop];
    dispatch_async( dispatch_get_main_queue(), ^{
        self.positionLabel.text = [NSString stringWithFormat:@"Długość: %f\nSzerokość: %f", latitude, longitude];
        self.timeLabel.text = [NSString stringWithFormat:@"%@\n%@", [self.stopwatch getDurationInSeconds], [self.stopwatch getDurationInMilliseconds]];
        [self refreshUI:false];
    });
}

- (void)refreshUI:(BOOL)isPositioning{
    self.activityIndicator.hidden = !isPositioning;
    self.startButton.hidden = isPositioning;
}
@end
