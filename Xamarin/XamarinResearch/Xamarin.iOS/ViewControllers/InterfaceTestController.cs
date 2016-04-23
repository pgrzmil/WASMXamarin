using CoreAnimation;
using CoreGraphics;
using Foundation;
using System;

using UIKit;

namespace Xamarin.iOS.ViewControllers
{
    public partial class InterfaceTestController : UIViewController
    {
        public int frameCount { get; set; }
        public CADisplayLink displayLink { get; set; }
        public double startTime { get; set; }

        public InterfaceTestController(IntPtr handle) : base(handle)
        {
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            Title = "Test interfejsu";
            string[] tableItems = new string[] { "Vegetables", "Fruits", "Flower Buds", "Legumes", "Bulbs", "Tubers", "Fruits", "Flower Buds", "Legumes", "Bulbs", "Fruits", "Flower Buds", "Legumes", "Bulbs", "Fruits", "Flower Buds", "Legumes", "Bulbs", "Fruits", "Flower Buds", "Legumes", "Bulbs", "Fruits", "Flower Buds", "Legumes", "Bulbs", "Fruits", "Flower Buds", "Legumes", "Bulbs", "Fruits", "Flower Buds", "Legumes", "Bulbs", "Fruits", "Flower Buds", "Legumes", "Bulbs", "Fruits", "Flower Buds", "Legumes", "Bulbs", "Fruits", "Flower Buds", "Legumes", "Bulbs", "Fruits", "Flower Buds", "Legumes", "Bulbs", "Fruits", "Flower Buds", "Legumes", "Bulbs", "Fruits", "Flower Buds", "Legumes", "Bulbs", "Fruits", "Flower Buds", "Legumes", "Bulbs", "Vegetables", "Fruits", "Flower Buds", "Legumes", "Bulbs", "Tubers", "Fruits", "Flower Buds", "Legumes", "Bulbs", "Fruits", "Flower Buds", "Legumes", "Bulbs", "Fruits", "Flower Buds", "Legumes", "Bulbs", "Fruits", "Flower Buds", "Legumes", "Bulbs", "Fruits", "Flower Buds", "Legumes", "Bulbs", "Fruits", "Flower Buds", "Legumes", "Bulbs", "Fruits", "Flower Buds", "Legumes", "Bulbs", "Fruits", "Flower Buds", "Legumes", "Bulbs", "Fruits", "Flower Buds", "Legumes", "Bulbs", "Fruits", "Flower Buds", "Legumes", "Bulbs", "Fruits", "Flower Buds", "Legumes", "Bulbs", "Fruits", "Flower Buds", "Legumes", "Bulbs", "Fruits", "Flower Buds", "Legumes", "Bulbs", "Fruits", "Flower Buds", "Legumes", "Bulbs" };
            tableView.Source = new TableSource(tableItems);
            startFpsCounter();
        }

        void startFpsCounter()
        {
            displayLink = CADisplayLink.Create(updateFpsCounter);
            startTime = CAAnimation.CurrentMediaTime();
            displayLink.AddToRunLoop(NSRunLoop.Current, NSRunLoopMode.Common);
        }

        void stopFpsCounter()
        {
            displayLink.Invalidate();
            displayLink = null;
        }

        void updateFpsCounter()
        {
            frameCount++;
            double now = CAAnimation.CurrentMediaTime();
            double elapsed = now - startTime;

            if (elapsed >= 1.0)
            {
                double frameRate = this.frameCount / elapsed;
                fpsLabel.Text = string.Format("{0} fps", Math.Round(frameRate));
                frameCount = 0;
                startTime = now;
            }
        }

    }
}