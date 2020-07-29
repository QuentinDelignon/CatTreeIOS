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
    [Register ("ViewController")]
    partial class ViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView coin_image { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel coin_label { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel dev_info { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView hearts { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel money_label { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UISlider slider { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton start_button { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView time_image { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel time_label { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView title_main { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (coin_image != null) {
                coin_image.Dispose ();
                coin_image = null;
            }

            if (coin_label != null) {
                coin_label.Dispose ();
                coin_label = null;
            }

            if (dev_info != null) {
                dev_info.Dispose ();
                dev_info = null;
            }

            if (hearts != null) {
                hearts.Dispose ();
                hearts = null;
            }

            if (money_label != null) {
                money_label.Dispose ();
                money_label = null;
            }

            if (slider != null) {
                slider.Dispose ();
                slider = null;
            }

            if (start_button != null) {
                start_button.Dispose ();
                start_button = null;
            }

            if (time_image != null) {
                time_image.Dispose ();
                time_image = null;
            }

            if (time_label != null) {
                time_label.Dispose ();
                time_label = null;
            }

            if (title_main != null) {
                title_main.Dispose ();
                title_main = null;
            }
        }
    }
}