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
	[Register ("InterfaceTestCell")]
	partial class InterfaceTestCell
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIActivityIndicatorView activity { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel label { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIImageView picture { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UISwitch toggle { get; set; }

		void ReleaseDesignerOutlets ()
		{
			if (activity != null) {
				activity.Dispose ();
				activity = null;
			}
			if (label != null) {
				label.Dispose ();
				label = null;
			}
			if (picture != null) {
				picture.Dispose ();
				picture = null;
			}
			if (toggle != null) {
				toggle.Dispose ();
				toggle = null;
			}
		}
	}
}
