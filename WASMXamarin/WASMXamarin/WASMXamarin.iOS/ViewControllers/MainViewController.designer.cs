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

namespace WASMXamarin.iOS
{
	[Register ("MainViewController")]
	partial class MainViewController
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton PerformanceTestButton { get; set; }

		void ReleaseDesignerOutlets ()
		{
			if (PerformanceTestButton != null) {
				PerformanceTestButton.Dispose ();
				PerformanceTestButton = null;
			}
		}
	}
}
