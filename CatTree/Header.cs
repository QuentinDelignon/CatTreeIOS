using CoreGraphics;
using Foundation;
using System;
using UIKit;

namespace CatTree
{
    public partial class Header : UICollectionReusableView
    {
        public Header (IntPtr handle) : base (handle)
        {
        }
    
        UILabel label;

        public string Text
        {
            get
            {
                return label.Text;
            }
            set
            {
                label.Text = value;
                label.TextAlignment = UITextAlignment.Left;
                SetNeedsDisplay();
            }
        }

        [Export("initWithFrame:")]
        public Header(CGRect frame) : base(frame)
        {
            
            label = new UILabel() { Frame = new CGRect(0, 0, 300, 50), BackgroundColor = UIColor.White };
            AddSubview(label);
        }
    }
}