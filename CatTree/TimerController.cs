using Foundation;
using System;
using UIKit;
using System.Timers;
using UserNotifications;

namespace CatTree
{
    public partial class TimerController : UIViewController
    {
        DateTime endDate = DateTime.Now.AddHours(TimerInfo.hour).AddMinutes(TimerInfo.min);
        TimeSpan totalSpan = TimeSpan.FromSeconds(TimerInfo.hour*3600+TimerInfo.min*60);
        Timer timer = new System.Timers.Timer();
        public TimerController (IntPtr handle) : base (handle){
        }
        public void CreateNotification()
        {
            // Get current notification settings
             UNUserNotificationCenter.Current.GetNotificationSettings((settings) => {
                var alertsAllowed = (settings.AlertSetting == UNNotificationSetting.Enabled);
            });
            var content = new UNMutableNotificationContent();
            content.Title = "Beau Travail !";
            content.Subtitle = "Ta session de travail a duré "+TimerInfo.hour.ToString()+" h et "+TimerInfo.min.ToString()+" minutes !";
            content.Body = "";
            content.Badge = 1;
            var trigger = UNTimeIntervalNotificationTrigger.CreateTrigger(1, false);

            var requestID = "sampleRequest";
            var request = UNNotificationRequest.FromIdentifier(requestID, content, trigger);

            UNUserNotificationCenter.Current.AddNotificationRequest(request, (err) => {
                if (err != null)
                {
                    // Do something with error...
                }
            });


        }
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // 1000= 1 second , the timer will run every second 
            label_support.Text = "C'est Parti !";
            timer_progress.SetProgress(0,false);
            timer.Interval = 1000;
            timer.Enabled = true;
            timer.Elapsed += Timer_Elapsed;
            timer.Start();
            }
        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            DateTime myDate = DateTime.Now;
            TimeSpan remaining = endDate.Subtract(myDate);
            double percent = 1 - remaining.Divide(totalSpan);
            InvokeOnMainThread(() => {
                timer_label.Text = remaining.Hours.ToString() + " h " + remaining.Minutes.ToString() + " min " + remaining.Seconds.ToString()+" s";
                label_percent.Text = Math.Truncate(percent * 100).ToString()+" %";
                timer_progress.SetProgress(Convert.ToSingle(percent), true);
                if (percent >=1)
                {
                    timer.Stop();
                    label_support.Text = "Super !";
                    TimerInfo.is_completed = true;
                    CreateNotification();
                }

            });
        }
        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.  
        }
        public override void ViewWillDisappear(bool animated)
        {
            base.ViewWillDisappear(animated);

            //get the back button press
            if (this.IsMovingFromParentViewController)
            {
                NavigationController.PopToRootViewController(true);
            }

        }
    }
}