using System;

using UIKit;

namespace WASMXamarin.iOS.ViewControllers
{
    public partial class PerformanceTestController : UIViewController
    {
        public PerformanceTestController(IntPtr handle) : base(handle)
        {
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();

            // Release any cached data, images, etc that aren't in use.
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            // Perform any additional setup after loading the view, typically from a nib.
        }
    }
}