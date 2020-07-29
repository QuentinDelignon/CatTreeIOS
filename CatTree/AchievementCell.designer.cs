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
    [Register ("AchievementCell")]
    partial class AchievementCell
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel AchCellTitle { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView cell_image { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIProgressView cell_progress { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel cell_sub { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel percent_label { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (AchCellTitle != null) {
                AchCellTitle.Dispose ();
                AchCellTitle = null;
            }

            if (cell_image != null) {
                cell_image.Dispose ();
                cell_image = null;
            }

            if (cell_progress != null) {
                cell_progress.Dispose ();
                cell_progress = null;
            }

            if (cell_sub != null) {
                cell_sub.Dispose ();
                cell_sub = null;
            }

            if (percent_label != null) {
                percent_label.Dispose ();
                percent_label = null;
            }
        }
    }
}