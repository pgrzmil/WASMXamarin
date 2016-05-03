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
		UIActivityIndicatorView ActivityIndicator { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton ReadButton { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITextView ResultView { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel TimeLabel { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton WriteButton { get; set; }

		[Action ("ReadButton_TouchUpInside:")]
		[GeneratedCode ("iOS Designer", "1.0")]
		partial void ReadButton_TouchUpInside (UIButton sender);

		[Action ("WriteButton_TouchUpInside:")]
		[GeneratedCode ("iOS Designer", "1.0")]
		partial void StartWritingFile (UIButton sender);

		void ReleaseDesignerOutlets ()
		{
			if (ActivityIndicator != null) {
				ActivityIndicator.Dispose ();
				ActivityIndicator = null;
			}
			if (ReadButton != null) {
				ReadButton.Dispose ();
				ReadButton = null;
			}
			if (ResultView != null) {
				ResultView.Dispose ();
				ResultView = null;
			}
			if (TimeLabel != null) {
				TimeLabel.Dispose ();
				TimeLabel = null;
			}
			if (WriteButton != null) {
				WriteButton.Dispose ();
				WriteButton = null;
			}
		}
	}
}
