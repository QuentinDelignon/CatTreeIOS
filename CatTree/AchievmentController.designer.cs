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
    [Register ("AchievmentController")]
    partial class AchievmentController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UISegmentedControl achievment_type { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel label_money { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITableView tableview { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView title_achievments { get; set; }

        [Action ("AchTypeChanged:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void AchTypeChanged (UIKit.UISegmentedControl sender);

        void ReleaseDesignerOutlets ()
        {
            if (achievment_type != null) {
                achievment_type.Dispose ();
                achievment_type = null;
            }

            if (label_money != null) {
                label_money.Dispose ();
                label_money = null;
            }

            if (tableview != null) {
                tableview.Dispose ();
                tableview = null;
            }

            if (title_achievments != null) {
                title_achievments.Dispose ();
                title_achievments = null;
            }
        }
    }
}