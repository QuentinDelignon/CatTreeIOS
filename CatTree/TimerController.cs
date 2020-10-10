using Foundation;
using System;
using UIKit;
using System.Timers;
using UserNotifications;

namespace CatTree
{
    public partial class TimerController : UIViewController
    { 
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
            var trigger = UNTimeIntervalNotificationTrigger.CreateTrigger(TimerInfo.remaining.TotalSeconds, false);

            var requestID = "sampleRequest";
            var request = UNNotificationRequest.FromIdentifier(requestID, content, trigger);

            UNUserNotificationCenter.Current.AddNotificationRequest(request, (err) => {
                if (err != null)
                {
                    // Do something with error...
                }
            });
        }
        public void DeleteNotification()
        {
            var requests = new string[] { "sampleRequest" };
            UNUserNotificationCenter.Current.RemovePendingNotificationRequests(requests);
        }
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            stop_timer_button.TouchUpInside += (sender, e) => {
                if (TimerInfo.ongoing)
                {
                    TimerInfo.Reset();
                }
                    TimerInfo.Save();
                timer.Stop();
            };
            pause_button.TouchUpInside += (sender, e) => {
                if (TimerInfo.is_paused == false)
                {
                    DeleteNotification();
                    label_support.Text = "Allez On y Retourne !";
                    pause_button.SetBackgroundImage(UIImage.GetSystemImage("play"), UIControlState.Normal);
                    TimerInfo.is_paused = true;
                    TimerInfo.Save();
                }
                else
                {
                    CreateNotification();
                    label_support.Text = "C'est Parti !";
                    pause_button.SetBackgroundImage(UIImage.GetSystemImage("pause"), UIControlState.Normal);
                    TimerInfo.is_paused = false;
                    TimerInfo.Save();
                }
                
            };
            if (TimerInfo.ongoing == false)
            {
                CreateNotification();
                TimerInfo.ongoing = true;
                TimerInfo.StartDate = DateTime.Now;
                // 1000= 1 second , the timer will run every second 
                label_support.Text = "C'est Parti !";
                timer_progress.SetProgress(0, false);
                timer.Interval = 1000;
                timer.Enabled = true;
                timer.Elapsed += Timer_Elapsed;
                timer.Start();
            }
            else
            {
                if (TimerInfo.is_paused == false)
                {
                    label_support.Text = "C'est Parti !";
                    pause_button.SetBackgroundImage(UIImage.GetSystemImage("pause"), UIControlState.Normal);
                    var total = TimerInfo.length;
                    var remaining = TimerInfo.remaining;
                    var prog = (float)remaining.Divide(total);
                    var percent = 1 - prog;
                    label_percent.Text = Math.Truncate(percent * 100).ToString() + " %";
                    timer_progress.SetProgress(Convert.ToSingle(percent), true);
                    timer_label.Text = remaining.Hours.ToString() + " h " + remaining.Minutes.ToString() + " min " + remaining.Seconds.ToString() + " s";
                    timer.Interval = 1000;
                    timer.Enabled = true;
                    timer.Elapsed += Timer_Elapsed;
                    timer.Start();
                }
                else
                {
                    label_support.Text = "Allez On y Retourne !";
                    pause_button.SetBackgroundImage(UIImage.GetSystemImage("play"), UIControlState.Normal);
                    var total = TimerInfo.length;
                    var remaining = TimerInfo.remaining;
                    var prog = (float)remaining.Divide(total);
                    var percent = 1 - prog;
                    label_percent.Text = Math.Truncate(percent * 100).ToString() + " %";
                    timer_progress.SetProgress(Convert.ToSingle(percent), true);
                    timer_label.Text = remaining.Hours.ToString() + " h " + remaining.Minutes.ToString() + " min " + remaining.Seconds.ToString() + " s";
                    timer.Interval = 1000;
                    timer.Enabled = true;
                    timer.Elapsed += Timer_Elapsed;
                }
            }

            }
        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (TimerInfo.is_paused == false)
            {
                double percent = 1 - TimerInfo.remaining.Divide(totalSpan);
                InvokeOnMainThread(() => {
                    if (TimerInfo.got_killed == true)
                    {
                        TimerInfo.remaining = TimerInfo.remaining.Subtract(TimerInfo.return_date - TimerInfo.quit_date);
                        TimerInfo.got_killed = false;
                    }
                    timer_label.Text = TimerInfo.remaining.Hours.ToString() + " h " + TimerInfo.remaining.Minutes.ToString() + " min " + TimerInfo.remaining.Seconds.ToString() + " s";
                    label_percent.Text = Math.Truncate(percent * 100).ToString() + " %";
                    timer_progress.SetProgress(Convert.ToSingle(percent), true);
                    TimerInfo.remaining = TimerInfo.remaining.Subtract(new TimeSpan(0, 0, 0, 0,1000));
                    TimerInfo.quit_date = DateTime.Now;
                    TimerInfo.Save();
                    if (percent >= 1)
                    {
                        timer.Stop();
                        label_support.Text = "Super !";
                        TimerInfo.is_completed = true;
                        TimerInfo.ongoing = false;
                        TimerInfo.Save();
                        UIStoryboard storyboard = UIStoryboard.FromName("Main", null);
                        UIViewController homeViewController = storyboard.InstantiateViewController("home") as UIViewController;
                        PresentViewController(homeViewController, true, null);
                    }
                });
            }
        }
        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.  
        }
    }
}