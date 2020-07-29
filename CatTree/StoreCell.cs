using Foundation;
using System;
using UIKit;

namespace CatTree
{
    public partial class StoreCell : UITableViewCell
    {
        public int currentIndex;
        public event EventHandler<int> SelectButtonTapped;
        private void OnSelectedButtonTapped(object sender , EventArgs e)
        {
            if (SelectButtonTapped!= null) { SelectButtonTapped(sender, this.currentIndex); }
        }
        public StoreCell (IntPtr handle) : base (handle)
        {
            
        }
        public StoreCell(NSString cellId, StoreItem item) : base (UITableViewCellStyle.Default,cellId)
        {
            cell_price.Text = item.cellPrice;
            cell_title.Text = item.cellTitle;
            cell_desc.Text = item.cellDesc;
            cell_image.Image = UIImage.FromFile(item.cellImagePath);
            coin_image.ClipsToBounds = true;
            coin_image.Image = UIImage.FromFile("coins.png");
            cell_button.TouchUpInside -= OnSelectedButtonTapped;
            cell_button.TouchUpInside += OnSelectedButtonTapped;
        }
        internal void UpdateCell(StoreItem item)
        {
            cell_price.Text = item.cellPrice;
            cell_title.Text = item.cellTitle;
            cell_desc.Text = item.cellDesc;
            cell_image.ClipsToBounds = true;
            cell_image.Image = UIImage.FromFile(item.cellImagePath);
            coin_image.Image = UIImage.FromFile("coins.png");
            cell_button.TouchUpInside -= OnSelectedButtonTapped;
            cell_button.TouchUpInside += OnSelectedButtonTapped;

        }
    }
}