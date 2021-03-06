using System;
using System.Collections.Generic;
using System.Linq;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MonoTouch.JavaScriptCore;

namespace JavascriptExample
{
	// The UIApplicationDelegate for the application. This class is responsible for launching the
	// User Interface of the application, as well as listening (and optionally responding) to
	// application events from iOS.
	[Register ("AppDelegate")]
	public partial class AppDelegate : UIApplicationDelegate
	{
		// class-level declarations
		UIWindow window;
		//
		// This method is invoked when the application has loaded and is ready to run. In this
		// method you should instantiate the window, load the UI into it and then make the window
		// visible.
		//
		// You have 17 seconds to return from this method, or iOS will terminate your application.
		//
		public override bool FinishedLaunching (UIApplication app, NSDictionary options)
		{
			// Example 1
			JSContext context = new JSContext ();
			JSValue result = context.EvaluateScript ("2 + 2");
			Console.WriteLine (result);

			// Example 2
			context.EvaluateScript ("var square = function (x) { return x * x; }");
			JSValue function = context [(NSString)"square"];
			JSValue input = JSValue.From (3, context);
			result = function.Call (input);
			Console.WriteLine (result);

			// Example 3
			JSValue value = context.EvaluateScript ("a = 3");
			context.EvaluateScript ("var square = function (x) { return x * x; }");
			function = context [(NSString)"square"];
			result = function.Call (context [(NSString) "a"]);
			Console.WriteLine (result);

			// create a new window instance based on the screen size
			window = new UIWindow (UIScreen.MainScreen.Bounds);
			
			// If you have defined a root view controller, set it here:
			// window.RootViewController = myViewController;
			
			// make the window visible
			window.MakeKeyAndVisible ();
			
			return true;
		}
	}
}

