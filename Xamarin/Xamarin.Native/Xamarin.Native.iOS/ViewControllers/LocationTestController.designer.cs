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
		UIActivityIndicatorView ActivityIndicator { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel PositionLabel { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton StartButton { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel TimeLabel { get; set; }

		[Action ("StartButton_TouchUpInside:")]
		[GeneratedCode ("iOS Designer", "1.0")]
		partial void StartPositioning (UIButton sender);

		void ReleaseDesignerOutlets ()
		{
			if (ActivityIndicator != null) {
				ActivityIndicator.Dispose ();
				ActivityIndicator = null;
			}
			if (PositionLabel != null) {
				PositionLabel.Dispose ();
				PositionLabel = null;
			}
			if (StartButton != null) {
				StartButton.Dispose ();
				StartButton = null;
			}
			if (TimeLabel != null) {
				TimeLabel.Dispose ();
				TimeLabel = null;
			}
		}
	}
}
