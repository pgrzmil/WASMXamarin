using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using UIKit;

namespace WASMXamarin.iOS
{
	// The UIApplicationDelegate for the application. This class is responsible for launching the 
	// User Interface of the application, as well as listening (and optionally responding) to 
	// application events from iOS.
	[Register("AppDelegate")]
	public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
	{
        UIWindow window;
        public static UIStoryboard Storyboard = UIStoryboard.FromName("MainInterface", null);
        public static UIViewController initialViewController;

             //
        // This method is invoked when the application has loaded and is ready to run. In this 
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application.
        //
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
		{
			global::Xamarin.Forms.Forms.Init ();
			LoadApplication (new WASMXamarin.App ());

            window = new UIWindow(UIScreen.MainScreen.Bounds);

            initialViewController = Storyboard.InstantiateInitialViewController() as UIViewController;

            window.RootViewController = initialViewController;
            window.MakeKeyAndVisible();
            return true;
        }
	}
}
