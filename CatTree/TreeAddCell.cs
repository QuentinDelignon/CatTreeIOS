using Foundation;
using System;
using UIKit;

namespace CatTree
{
    public partial class TreeAddCell : UICollectionViewCell
    {
        public event EventHandler<EventArgs> AddButtonTapped;
        private void OnSelectedButtonTapped(object sender, EventArgs e)
        {
            if (AddButtonTapped != null) { AddButtonTapped(sender, e); }
        }
        public TreeAddCell (IntPtr handle) : base (handle)
        {
        }
        public TreeAddCell(NSString cellId, StoreItem item)
        {         
            add_button.TouchUpInside -= OnSelectedButtonTapped;
            add_button.TouchUpInside += OnSelectedButtonTapped;
            add_button.SetImage(UIImage.FromBundle("Buttons/MagicWand.png"), UIControlState.Normal);
            add_button.SetImage(UIImage.FromBundle("Buttons/MagicWand_Highlight.png"), UIControlState.Highlighted);
            add_button.SetImage(UIImage.FromBundle("Buttons/MagicWand_On.png"), UIControlState.Selected);
        }
        internal void UpdateCell()
        {
            add_button.TouchUpInside -= OnSelectedButtonTapped;
            add_button.TouchUpInside += OnSelectedButtonTapped;
            add_button.SetImage(UIImage.FromFile("add.png"), UIControlState.Normal);
            add_button.SetImage(UIImage.FromFile("add.png"), UIControlState.Highlighted);
            add_button.SetImage(UIImage.FromFile("add.png"), UIControlState.Selected);
        }
    }
}