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

namespace Xamarin.iOS.ViewControllers
{
	[Register ("InterfaceTestController")]
	partial class InterfaceTestController
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel fpsLabel { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITableView tableView { get; set; }

		void ReleaseDesignerOutlets ()
		{
			if (fpsLabel != null) {
				fpsLabel.Dispose ();
				fpsLabel = null;
			}
			if (tableView != null) {
				tableView.Dispose ();
				tableView = null;
			}
		}
	}
}
