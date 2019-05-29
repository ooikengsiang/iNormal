using Foundation;
using UIKit;

namespace iNormal.FluentAutoLayout.Sample
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the
    // User Interface of the application, as well as listening (and optionally responding) to application events from iOS.
    [Register("AppDelegate")]
    public class AppDelegate : UIApplicationDelegate
    {
        public override UIWindow Window { get; set; }

        public override bool FinishedLaunching(UIApplication application, NSDictionary launchOptions)
        {
            // create the first view controller here
            var firstViewController = new MainViewController();

            // wrap the view controller inside a navigation controller
            UINavigationController navController = new UINavigationController(firstViewController);

            // create a new window instance based on the screen size
            Window = new UIWindow(UIScreen.MainScreen.Bounds);
            Window.RootViewController = navController;

            // make the window visible
            Window.MakeKeyAndVisible();

            return true;
        }
    }
}

