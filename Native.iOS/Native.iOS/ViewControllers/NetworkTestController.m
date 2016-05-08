//
//  NetworkTestController.m
//  Native.iOS
//
//  Created by Pawel Grzmil on 17/01/16.
//  Copyright © 2016 Pawel Grzmil. All rights reserved.
//

#import "NetworkTestController.h"
#import "NetworkTestService.h"
#import "Stopwatch.h"

@interface NetworkTestController()<NetworkTestServiceDelegate>

@property (weak, nonatomic) IBOutlet UILabel *timeLabel;
@property (weak, nonatomic) IBOutlet UIButton *startButton;
@property (weak, nonatomic) IBOutlet UITextField *addressField;
@property (weak, nonatomic) IBOutlet UIActivityIndicatorView *activityIndicator;
@property (weak, nonatomic) IBOutlet UIImageView *downloadedImage;

@property (strong, nonatomic) Stopwatch *stopwatch;
@property (strong, nonatomic) NetworkTestService *networkService;

@end
@implementation NetworkTestController

- (void)viewDidLoad {
    [super viewDidLoad];
    self.title = @"Test obsługi sieci";
    self.addressField.text = @"http://cdn.superbwallpapers.com/wallpapers/meme/doge-pattern-27481-2880x1800.jpg";
    
    self.stopwatch = [Stopwatch new];
    
    self.networkService = [NetworkTestService new];
    self.networkService.delegate = self;
}

- (IBAction)startDownloading:(id)sender {
    self.downloadedImage.image = nil;
    [self refreshUI:true];
    [self.stopwatch start];
    
    dispatch_async( dispatch_get_global_queue(DISPATCH_QUEUE_PRIORITY_DEFAULT, 0), ^{
        [self.networkService downloadImage:self.addressField.text];
    });
}

- (void)imageDownloadCompleted:(UIImage *)image{
    [self.stopwatch stop];
    dispatch_async( dispatch_get_main_queue(), ^{
        self.downloadedImage.image = image;
        self.timeLabel.text = [self.stopwatch getDurationInSeconds];
        [self refreshUI:false];
    });
}

- (void)refreshUI:(BOOL)isDownloading{
    self.activityIndicator.hidden = !isDownloading;
    self.startButton.hidden = isDownloading;
    self.addressField.userInteractionEnabled = !isDownloading;
}

@end
