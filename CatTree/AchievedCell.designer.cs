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
    [Register ("AchievedCell")]
    partial class AchievedCell
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView cell_image { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel cell_sub { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel cell_title { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView check_image { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (cell_image != null) {
                cell_image.Dispose ();
                cell_image = null;
            }

            if (cell_sub != null) {
                cell_sub.Dispose ();
                cell_sub = null;
            }

            if (cell_title != null) {
                cell_title.Dispose ();
                cell_title = null;
            }

            if (check_image != null) {
                check_image.Dispose ();
                check_image = null;
            }
        }
    }
}