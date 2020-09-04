using Foundation;
using UIKit;

namespace DemoCamara.iOS
{
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            global::Xamarin.Forms.Forms.Init();

            MediaManager.CrossMediaManager.Current.Init();

            LoadApplication(new App());

            return base.FinishedLaunching(app, options);
        }
    }
}
