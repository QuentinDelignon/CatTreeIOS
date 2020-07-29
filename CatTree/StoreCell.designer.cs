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
    [Register ("StroreCell")]
    partial class StoreCell
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton cell_button { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel cell_desc { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView cell_image { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel cell_price { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel cell_title { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView coin_image { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (cell_button != null) {
                cell_button.Dispose ();
                cell_button = null;
            }

            if (cell_desc != null) {
                cell_desc.Dispose ();
                cell_desc = null;
            }

            if (cell_image != null) {
                cell_image.Dispose ();
                cell_image = null;
            }

            if (cell_price != null) {
                cell_price.Dispose ();
                cell_price = null;
            }

            if (cell_title != null) {
                cell_title.Dispose ();
                cell_title = null;
            }

            if (coin_image != null) {
                coin_image.Dispose ();
                coin_image = null;
            }
        }
    }
}