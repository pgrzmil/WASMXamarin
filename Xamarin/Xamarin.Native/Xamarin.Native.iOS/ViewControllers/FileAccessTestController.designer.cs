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
	[Register ("FileAccessTestController")]
	partial class FileAccessTestController
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIActivityIndicatorView activityIndicator { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton readButton { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITextView resultView { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel timeLabel { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton writeButton { get; set; }

		[Action ("StartReading:")]
		[GeneratedCode ("iOS Designer", "1.0")]
		partial void StartReading (UIButton sender);

		[Action ("StartWriting:")]
		[GeneratedCode ("iOS Designer", "1.0")]
		partial void StartWriting (UIButton sender);

		void ReleaseDesignerOutlets ()
		{
			if (activityIndicator != null) {
				activityIndicator.Dispose ();
				activityIndicator = null;
			}
			if (readButton != null) {
				readButton.Dispose ();
				readButton = null;
			}
			if (resultView != null) {
				resultView.Dispose ();
				resultView = null;
			}
			if (timeLabel != null) {
				timeLabel.Dispose ();
				timeLabel = null;
			}
			if (writeButton != null) {
				writeButton.Dispose ();
				writeButton = null;
			}
		}
	}
}
