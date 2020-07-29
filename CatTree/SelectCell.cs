using Foundation;
using System;
using UIKit;

namespace CatTree
{
    public partial class SelectCell : UICollectionViewCell
    {
        public StoreItem item;
        public SelectCell (IntPtr handle) : base (handle)
        {
        }
        public SelectCell(StoreItem item)
        {
            cell_image.Image = UIImage.FromFile(item.cellImagePath);
            this.item = item;
        }
        internal void UpdateCell(StoreItem item)
        {
            cell_image.Image = UIImage.FromFile(item.cellImagePath);
            this.item = item;
        }
    }
}