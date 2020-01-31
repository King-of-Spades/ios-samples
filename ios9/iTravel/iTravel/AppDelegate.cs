using System;
using Foundation;
using UIKit;

namespace iTravel {
	[Register("AppDelegate")]
	public partial class AppDelegate : UIApplicationDelegate {
		public override UIWindow Window { get; set; }

        [Export("application:didFinishLaunchingWithOptions:")]
        public override bool FinishedLaunching(UIApplication application, NSDictionary launchOptions)
        {
#if DEBUG
            Xamarin.Calabash.Start();
            Console.WriteLine("Calabash should be started now");
#endif
            return true;
        }
    }
}


