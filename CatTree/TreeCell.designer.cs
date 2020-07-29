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
    [Register ("TreeCell")]
    partial class TreeCell
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView cell_back { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView cell_front { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (cell_back != null) {
                cell_back.Dispose ();
                cell_back = null;
            }

            if (cell_front != null) {
                cell_front.Dispose ();
                cell_front = null;
            }
        }
    }
}