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
    [Register ("SelectViewController")]
    partial class SelectViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton cancel_select { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton exit_select { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        CatTree.SelectCollectionVIew SelectCollection { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        CatTree.SelectionView SelectSubView { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (cancel_select != null) {
                cancel_select.Dispose ();
                cancel_select = null;
            }

            if (exit_select != null) {
                exit_select.Dispose ();
                exit_select = null;
            }

            if (SelectCollection != null) {
                SelectCollection.Dispose ();
                SelectCollection = null;
            }

            if (SelectSubView != null) {
                SelectSubView.Dispose ();
                SelectSubView = null;
            }
        }
    }
}