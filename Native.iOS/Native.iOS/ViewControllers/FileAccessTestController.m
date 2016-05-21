//
//  FileAccessTestController.m
//  Native.iOS
//
//  Created by Pawel Grzmil on 08/05/16.
//  Copyright © 2016 Pawel Grzmil. All rights reserved.
//

#import "FileAccessTestController.h"
#import "FileAccessTestService.h"
#import "PerformanceTestService.h"
#import "Stopwatch.h"

@interface FileAccessTestController ()

@property (weak, nonatomic) IBOutlet UIButton *readButton;
@property (weak, nonatomic) IBOutlet UIButton *writeButton;
@property (weak, nonatomic) IBOutlet UILabel *timeLabel;
@property (weak, nonatomic) IBOutlet UITextView *resultView;
@property (weak, nonatomic) IBOutlet UIActivityIndicatorView *activityIndicator;

@property (strong, nonatomic) Stopwatch *stopwatch;
@property (strong, nonatomic) FileAccessTestService *fileAccessService;

@end

@implementation FileAccessTestController
int digits = 10000;
NSString *fileName = @"testFile.txt";
static NSString *contentToWrite;

- (void)viewDidLoad {
    [super viewDidLoad];
    self.title = @"Test dostępu do pliku";
    
    self.stopwatch = [Stopwatch new];
    self.fileAccessService = [FileAccessTestService new];
    
    if (contentToWrite == nil) {
        [self refreshUI:true];
        dispatch_async( dispatch_get_global_queue(DISPATCH_QUEUE_PRIORITY_DEFAULT, 0), ^{
            contentToWrite = [[PerformanceTestService instance] calculatePi:digits];
            dispatch_async( dispatch_get_main_queue(), ^{ [self refreshUI:false]; });
        });
    }
}

- (IBAction)startReading:(id)sender {
    self.resultView.text = @"";
    [self.stopwatch start];
    
    NSString *fileContents = [self.fileAccessService readFromFile:fileName];
    
    [self.stopwatch stop];
    
    self.resultView.text = fileContents;
    self.timeLabel.text = [self.stopwatch getDurationInMilliseconds];
}

- (IBAction)startWriting:(id)sender {
    self.resultView.text = @"";
    [self.stopwatch start];
    
    [self.fileAccessService writeToFile:fileName text:contentToWrite];
    
    [self.stopwatch stop];
    self.timeLabel.text = [self.stopwatch getDurationInMilliseconds];
}

- (void)refreshUI:(BOOL)isCalculating{
    self.activityIndicator.hidden = !isCalculating;
    self.readButton.hidden = isCalculating;
    self.writeButton.hidden = isCalculating;
}

@end
