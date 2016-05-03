
using System;
using System.Drawing;

using Foundation;
using UIKit;

namespace Xamarin.Native.iOS.ViewControllers
{
    public partial class MenuController : UIViewController
    {
        public MenuController(IntPtr handle) : base(handle)
		{
        }

        public override void DidReceiveMemoryWarning()
        {
            // Releases the view if it doesn't have a superview.
            base.DidReceiveMemoryWarning();
		}
    }
}