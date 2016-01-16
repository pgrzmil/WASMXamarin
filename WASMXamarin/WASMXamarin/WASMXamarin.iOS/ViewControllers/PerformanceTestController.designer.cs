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

namespace WASMXamarin.iOS.ViewControllers
{
	[Register ("PreformanceTestController")]
	partial class PerformanceTestController
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIActivityIndicatorView activityIndicator { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITextField DigitsTextfield { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITextView ResultView { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton StartButton { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel TimeLabel { get; set; }

		void ReleaseDesignerOutlets ()
		{
			if (activityIndicator != null) {
				activityIndicator.Dispose ();
				activityIndicator = null;
			}
			if (DigitsTextfield != null) {
				DigitsTextfield.Dispose ();
				DigitsTextfield = null;
			}
			if (ResultView != null) {
				ResultView.Dispose ();
				ResultView = null;
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
