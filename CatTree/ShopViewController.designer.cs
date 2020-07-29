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
    [Register ("ShopViewController")]
    partial class ShopViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UISegmentedControl item_type { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel money_label { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITableView ShopTableView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView title_shop { get; set; }

        [Action ("ShopTypeChanged:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void ShopTypeChanged (UIKit.UISegmentedControl sender);

        void ReleaseDesignerOutlets ()
        {
            if (item_type != null) {
                item_type.Dispose ();
                item_type = null;
            }

            if (money_label != null) {
                money_label.Dispose ();
                money_label = null;
            }

            if (ShopTableView != null) {
                ShopTableView.Dispose ();
                ShopTableView = null;
            }

            if (title_shop != null) {
                title_shop.Dispose ();
                title_shop = null;
            }
        }
    }
}