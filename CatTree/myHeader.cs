using Foundation;
using System;
using UIKit;

namespace CatTree
{
    public partial class myHeader : UICollectionReusableView
    {
        public myHeader (IntPtr handle) : base (handle)
        {
        }
        public void setText(string text)
        {
            header_label.Text = text;
        }
    }
}