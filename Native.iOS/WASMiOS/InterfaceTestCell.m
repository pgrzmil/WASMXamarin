//
//  InterfaceTestCell.m
//  WASMiOS
//
//  Created by Pawel Grzmil on 17/01/16.
//  Copyright © 2016 Pawel Grzmil. All rights reserved.
//

#import "InterfaceTestCell.h"
@import AVKit;
@import AVFoundation;

@interface InterfaceTestCell()
@property (weak, nonatomic) IBOutlet UILabel *label;
@property (weak, nonatomic) IBOutlet UIView *playerView;
@property (weak, nonatomic) IBOutlet UIImageView *icon;

@end

@implementation InterfaceTestCell
AVAsset* avAsset;
AVPlayerItem* avPlayerItem;
AVPlayerLayer* avPlayerLayer;
AVPlayer* avPlayer;

-(void)awakeFromNib{
    [super awakeFromNib];
    
    NSString *path = [[NSBundle mainBundle] pathForResource:@"video" ofType:@"mp4"];
    NSURL *url = [NSURL fileURLWithPath:path];
    avAsset = [AVAsset assetWithURL:url];
    avPlayerItem =[[AVPlayerItem alloc]initWithAsset:avAsset];
    avPlayer = [[AVPlayer alloc]initWithPlayerItem:avPlayerItem];
    avPlayerLayer =[AVPlayerLayer playerLayerWithPlayer:avPlayer];
    avPlayer.externalPlaybackVideoGravity = AVLayerVideoGravityResizeAspectFill;

    CGRect a= CGRectMake(-105,0, self.frame.size.width-10, self.frame.size.height-40);
    [avPlayerLayer setFrame:a];
    [self.playerView.layer addSublayer:avPlayerLayer];
}

-(void)layoutSubviews{
    [super layoutSubviews];
    
    CABasicAnimation* rotationAnimation;
    rotationAnimation = [CABasicAnimation animationWithKeyPath:@"transform.rotation.z"];
    rotationAnimation.toValue = [NSNumber numberWithFloat: M_PI * 2.0 ];
    rotationAnimation.duration = 1;
    rotationAnimation.cumulative = YES;
    rotationAnimation.repeatCount = CGFLOAT_MAX;
    [self.icon.layer addAnimation:rotationAnimation forKey:@"rotationAnimation"];
}

-(void)updateCell:(NSString*)labelText{
    self.label.text = labelText;
    [avPlayer seekToTime:kCMTimeZero];
    [avPlayer play];
}

@end
