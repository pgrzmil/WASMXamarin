//
//  LocationTestController.m
//  Native.iOS
//
//  Created by Pawel Grzmil on 08/05/16.
//  Copyright © 2016 Pawel Grzmil. All rights reserved.
//

#import "LocationTestController.h"
#import "Stopwatch.h"

@interface LocationTestController ()
@property (weak, nonatomic) IBOutlet UIButton *startButton;
@property (weak, nonatomic) IBOutlet UILabel *timeLabel;
@property (weak, nonatomic) IBOutlet UILabel *positionLabel;
@property (weak, nonatomic) IBOutlet UIActivityIndicatorView *activityIndicator;
@property (strong, nonatomic) Stopwatch* stopwatch;

@end

@implementation LocationTestController

- (void)viewDidLoad {
    [super viewDidLoad];
    self.title = @"Test pozycji GPS";    
    self.stopwatch = [Stopwatch new];
}

- (IBAction)startPositioning:(id)sender {
    [self.stopwatch start];
}
@end
