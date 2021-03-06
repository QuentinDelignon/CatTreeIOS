﻿using CoreLocation;
using Foundation;
using System;
using System.Collections.Generic;
using UIKit;

namespace CatTree
{
    public partial class ViewController : UIViewController
    {
        public ViewController (IntPtr handle) : base (handle)
        {
        }
        public override void ViewDidAppear(bool animated)
        {
            base.ViewDidAppear(animated);
            money_label.Text = AppData.Coins.myCoins[0].ToString();
            try { TimerInfo.Load(); } catch { }
            if (TimerInfo.ongoing)
            {
                if (TimerInfo.remaining.TotalMilliseconds == 0 || TimerInfo.remaining != TimerInfo.remaining.Duration())
                {
                    SessionItem NewSession = new SessionItem() { CoinsEarned = TimerInfo.coins, Date = DateTime.Now, Duration = new TimeSpan(TimerInfo.hour, TimerInfo.min, 0) };
                    AppData.Coins.Add(TimerInfo.coins);
                    AppData.SessionItems.AddSession(NewSession);
                    AppData.SessionItems.Save();
                    AppData.Coins.Save();

                    money_label.Text = AppData.Coins.myCoins[0].ToString();
                    string message = "Tu as Travaillé " + TimerInfo.hour.ToString() + " h et " + TimerInfo.min.ToString() + " minutes !";
                    var okAlertController = UIAlertController.Create("Bien Joué !", message, UIAlertControllerStyle.Alert);
                    okAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));
                    PresentViewController(okAlertController, true, null);
                    TimerInfo.Reset();
                    TimerInfo.Save();
                }
                else
                {
                    //TimerInfo.got_killed = true;
                    //TimerInfo.return_date = DateTime.Now;
                    UIStoryboard storyboard = UIStoryboard.FromName("Main", null);
                    UIViewController homeViewController = storyboard.InstantiateViewController("timer") as UIViewController;
                    PresentViewController(homeViewController, true, null);
                }
            }
        }
        public override void ViewDidLoad ()
        {
            base.ViewDidLoad ();
            try{AppData.Coins.Load();}catch{}
            if (TimerInfo.is_completed)
            {
                SessionItem NewSession = new SessionItem() { CoinsEarned = TimerInfo.coins , Date = DateTime.Now, Duration = new TimeSpan(TimerInfo.hour, TimerInfo.min, 0)};
                AppData.Coins.Add(TimerInfo.coins);
                AppData.SessionItems.AddSession(NewSession);
                AppData.SessionItems.Save();
                AppData.Coins.Save();

                money_label.Text = AppData.Coins.myCoins[0].ToString();
                string message = "Tu as Travaillé " + TimerInfo.hour.ToString() + " h et " + TimerInfo.min.ToString() + " minutes !";
                var okAlertController = UIAlertController.Create("Bien Joué !", message, UIAlertControllerStyle.Alert);
                okAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));
                PresentViewController(okAlertController, true, null);
                TimerInfo.Reset();
                TimerInfo.Save();
            }
            start_button.UserInteractionEnabled = false;
            slider.MinValue = 0;
            slider.MaxValue = 5;
            slider.Value = 0.5f;
            string strval = slider.Value.ToString();
            float time_val = slider.Value;
            TimerInfo.hour = (int)Math.Truncate(time_val);
            TimerInfo.min = (int)Math.Truncate((time_val - Math.Truncate(time_val)) * 60);
            var quarters = new List<int> { 0, 15, 30, 45, 60 };
            for (int i = 0; i < quarters.Count; i++)
            {
                if (Math.Abs(quarters[i] - TimerInfo.min) <= 12.5)
                {
                    TimerInfo.min = quarters[i];
                    break;
                }
            }
            if (TimerInfo.min == 60)
            {
                TimerInfo.min = 0;
                TimerInfo.hour += 1;
            }
            if (TimerInfo.min == 0 & TimerInfo.hour == 0)
            {
                TimerInfo.min = 1;
            }
            time_label.Text = TimerInfo.hour.ToString() + " h " + TimerInfo.min.ToString() + " min";
            TimerInfo.coins = (int)Math.Truncate((double)TimerInfo.hour * 100 + TimerInfo.min * 100 / 60);
            TimerInfo.length = new TimeSpan(TimerInfo.hour, TimerInfo.min,0);
            TimerInfo.remaining = TimerInfo.length;
            coin_label.Text = TimerInfo.coins.ToString();
            TimerInfo.is_completed = false;
            slider.ValueChanged += (object sender, EventArgs e) =>
            {
                start_button.UserInteractionEnabled = true;
                strval = slider.Value.ToString();
                time_val = slider.Value;
                TimerInfo.hour = (int)Math.Truncate(time_val);
                TimerInfo.min = (int)Math.Truncate((time_val - Math.Truncate(time_val)) * 60);
                for (int i = 0; i < quarters.Count; i++)
                {
                    if (Math.Abs(quarters[i]-TimerInfo.min) <= 12.5)
                    {
                        TimerInfo.min = quarters[i];
                        break;
                    }
                }
                if (TimerInfo.min == 60)
                {
                    TimerInfo.min = 0;
                    TimerInfo.hour += 1;
                }
                if(TimerInfo.min ==0 & TimerInfo.hour == 0)
                {
                    TimerInfo.min = 1;
                }
                time_label.Text = TimerInfo.hour.ToString() + " h " + TimerInfo.min.ToString() + " min";
                TimerInfo.coins = (int)Math.Truncate((double)TimerInfo.hour* 100+TimerInfo.min*100/60);
                TimerInfo.length = new TimeSpan(TimerInfo.hour, TimerInfo.min, 0);
                TimerInfo.remaining = TimerInfo.length;
                coin_label.Text = TimerInfo.coins.ToString();
                TimerInfo.is_completed = false; 
            };

        }

        public override void DidReceiveMemoryWarning ()
        {
            base.DidReceiveMemoryWarning ();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}