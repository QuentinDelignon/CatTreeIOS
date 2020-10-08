// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace CatTree
{
    [Register ("TimerController")]
    partial class TimerController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel label_percent { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel label_support { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton pause_button { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton stop_timer_button { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel timer_label { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIProgressView timer_progress { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView title_timer { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (label_percent != null) {
                label_percent.Dispose ();
                label_percent = null;
            }

            if (label_support != null) {
                label_support.Dispose ();
                label_support = null;
            }

            if (pause_button != null) {
                pause_button.Dispose ();
                pause_button = null;
            }

            if (stop_timer_button != null) {
                stop_timer_button.Dispose ();
                stop_timer_button = null;
            }

            if (timer_label != null) {
                timer_label.Dispose ();
                timer_label = null;
            }

            if (timer_progress != null) {
                timer_progress.Dispose ();
                timer_progress = null;
            }

            if (title_timer != null) {
                title_timer.Dispose ();
                title_timer = null;
            }
        }
    }
}