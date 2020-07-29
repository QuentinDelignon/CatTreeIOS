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
    [Register ("StatsController")]
    partial class StatsController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel mhour_count { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel money_label { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UISegmentedControl plot_type { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITabBarItem tab { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel thour_count { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel thour_label { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView title_stats { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel whour_count { get; set; }

        [Action ("SegmentControl_ValueChanged:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void SegmentControl_ValueChanged (UIKit.UISegmentedControl sender);

        void ReleaseDesignerOutlets ()
        {
            if (mhour_count != null) {
                mhour_count.Dispose ();
                mhour_count = null;
            }

            if (money_label != null) {
                money_label.Dispose ();
                money_label = null;
            }

            if (plot_type != null) {
                plot_type.Dispose ();
                plot_type = null;
            }

            if (tab != null) {
                tab.Dispose ();
                tab = null;
            }

            if (thour_count != null) {
                thour_count.Dispose ();
                thour_count = null;
            }

            if (thour_label != null) {
                thour_label.Dispose ();
                thour_label = null;
            }

            if (title_stats != null) {
                title_stats.Dispose ();
                title_stats = null;
            }

            if (whour_count != null) {
                whour_count.Dispose ();
                whour_count = null;
            }
        }
    }
}