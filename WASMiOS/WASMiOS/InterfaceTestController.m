//
//  InterfaceTestController.m
//  WASMiOS
//
//  Created by Pawel Grzmil on 17/01/16.
//  Copyright © 2016 Pawel Grzmil. All rights reserved.
//

#import "InterfaceTestController.h"
#import "InterfaceTestCell.h"

@interface InterfaceTestController()<UITableViewDataSource, UITableViewDelegate>
@property (weak, nonatomic) IBOutlet UILabel *fpsLabel;
@property (weak, nonatomic) IBOutlet UITableView *tableView;
@property (nonatomic, strong) CADisplayLink *displayLink;
@property (nonatomic) CFTimeInterval startTime;
@property (nonatomic) NSInteger frameCount;
@property (nonatomic) NSArray* items;

@end;
@implementation InterfaceTestController
static NSString *simpleTableIdentifier = @"TableCell";

-(void)viewDidLoad{
    [super viewDidLoad];
    self.title = @"Test interfejsu";
    self.items = [NSArray arrayWithObjects:@"Vegetables", @"Fruits", @"Flower Buds", @"Legumes", @"Bulbs", @"Tubers",@"Vegetables", @"Fruits", @"Flower Buds", @"Legumes", @"Bulbs", @"Tubers",@"Vegetables", @"Fruits", @"Flower Buds", @"Legumes", @"Bulbs", @"Tubers",@"Vegetables", @"Fruits", @"Flower Buds", @"Legumes", @"Bulbs", @"Tubers",@"Vegetables", @"Fruits", @"Flower Buds", @"Legumes", @"Bulbs", @"Tubers",@"Vegetables", @"Fruits", @"Flower Buds", @"Legumes", @"Bulbs", @"Tubers", nil];
    [self startDisplayLink];
    
    }

- (NSInteger)tableView:(UITableView *)tableView numberOfRowsInSection:(NSInteger)section{
    return self.items.count;
}

- (UITableViewCell *)tableView:(UITableView *)tableView cellForRowAtIndexPath:(NSIndexPath *)indexPath{

    UITableViewCell *cell = [tableView dequeueReusableCellWithIdentifier:@"TableCell"];
    
    if (cell == nil) {
        cell = [[InterfaceTestCell alloc] initWithStyle:UITableViewCellStyleDefault reuseIdentifier:@"TableCell"];
    }
    
    [((InterfaceTestCell*)cell) updateCell:self.items[indexPath.row]];
    return cell;
}

- (void)startDisplayLink
{
    self.displayLink = [CADisplayLink displayLinkWithTarget:self selector:@selector(handleDisplayLink:)];
    self.startTime = CACurrentMediaTime();
    [self.displayLink addToRunLoop:[NSRunLoop currentRunLoop] forMode:NSRunLoopCommonModes];
}

- (void)stopDisplayLink
{
    [self.displayLink invalidate];
    self.displayLink = nil;
}

- (void)handleDisplayLink:(CADisplayLink *)displayLink
{
    self.frameCount++;
    
    CFTimeInterval now = CACurrentMediaTime();
    CFTimeInterval elapsed = now - self.startTime;
    
    if (elapsed >= 1.0) {
        CGFloat frameRate = self.frameCount / elapsed;
        self.fpsLabel.text = [NSString stringWithFormat:@"%.0f fps", frameRate];
        
        self.frameCount = 0;
        self.startTime = now;
    }
}
@end
