using Foundation;
using System;
using UIKit;
using UserNotifications;

namespace CatTree
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the
    // User Interface of the application, as well as listening (and optionally responding) to application events from iOS.
    [Register ("AppDelegate")]
    public class AppDelegate : UIResponder, IUIApplicationDelegate {
    
        [Export("window")]
        public UIWindow Window { get; set; }

        [Export ("application:didFinishLaunchingWithOptions:")]
        public bool FinishedLaunching (UIApplication application, NSDictionary launchOptions)
        {
            // Override point for customization after application launch.
            // If not required for your application you can safely delete this method
            // Request notification permissions from the user
            UNUserNotificationCenter.Current.RequestAuthorization(UNAuthorizationOptions.Alert, (approved, err) => {
                // Handle approval
            });
            //Pour ne pas afficher la notif si l'appli est ouverte
            UNUserNotificationCenter.Current.Delegate = new UserNotificationCenterDelegate();
            return true;
        }

        // UISceneSession Lifecycle

        [Export ("application:configurationForConnectingSceneSession:options:")]
        public UISceneConfiguration GetConfiguration (UIApplication application, UISceneSession connectingSceneSession, UISceneConnectionOptions options)
        {
            // Called when a new scene session is being created.
            // Use this method to select a configuration to create the new scene with.
            return UISceneConfiguration.Create ("Default Configuration", connectingSceneSession.Role);
        }

        [Export ("application:didDiscardSceneSessions:")]
        public void DidDiscardSceneSessions (UIApplication application, NSSet<UISceneSession> sceneSessions)
        {
            // Called when the user discards a scene session.
            // If any sessions were discarded while the application was not running, this will be called shortly after `FinishedLaunching`.
            // Use this method to release any resources that were specific to the discarded scenes, as they will not return.
        }
        [Export("applicationDidEnterBackground:")]
        public virtual void DidEnterBackground(UIApplication application)
        {
            TimerInfo.Save();
        }

        [Export("applicationWillEnterForeground:")]
        public virtual void WillEnterForeground(UIApplication application)
        {
            try { TimerInfo.Load(); } catch { }
            if (TimerInfo.ongoing)
            {
                TimerInfo.got_killed = true;
                TimerInfo.return_date = DateTime.Now;
                TimerInfo.Save();
            }
        }
    }
}

