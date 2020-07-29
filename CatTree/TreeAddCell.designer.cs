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
    [Register ("TreeAddCell")]
    partial class TreeAddCell
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton add_button { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (add_button != null) {
                add_button.Dispose ();
                add_button = null;
            }
        }
    }
}