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
    [Register ("TreeViewController")]
    partial class TreeViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel money_label { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UICollectionView myCollection { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView title_tree { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView title_tree2 { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (money_label != null) {
                money_label.Dispose ();
                money_label = null;
            }

            if (myCollection != null) {
                myCollection.Dispose ();
                myCollection = null;
            }

            if (title_tree != null) {
                title_tree.Dispose ();
                title_tree = null;
            }

            if (title_tree2 != null) {
                title_tree2.Dispose ();
                title_tree2 = null;
            }
        }
    }
}