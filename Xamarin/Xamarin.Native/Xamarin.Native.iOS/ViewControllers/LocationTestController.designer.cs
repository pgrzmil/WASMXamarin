// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace Xamarin.Native.iOS.ViewControllers
{
	[Register ("LocationTestController")]
	partial class LocationTestController
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIActivityIndicatorView activityIndicator { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel positionLabel { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton startButton { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel timeLabel { get; set; }

		[Action ("StartPositioning")]
		[GeneratedCode ("iOS Designer", "1.0")]
		partial void StartPositioning ();

		[Action ("StartPositioning:")]
		[GeneratedCode ("iOS Designer", "1.0")]
		partial void StartPositioning (UIButton sender);

		void ReleaseDesignerOutlets ()
		{
			if (activityIndicator != null) {
				activityIndicator.Dispose ();
				activityIndicator = null;
			}
			if (positionLabel != null) {
				positionLabel.Dispose ();
				positionLabel = null;
			}
			if (startButton != null) {
				startButton.Dispose ();
				startButton = null;
			}
			if (timeLabel != null) {
				timeLabel.Dispose ();
				timeLabel = null;
			}
		}
	}
}
