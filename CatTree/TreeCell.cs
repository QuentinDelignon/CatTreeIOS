using Foundation;
using System;
using UIKit;

namespace CatTree
{
    public partial class TreeCell : UICollectionViewCell
    {
        public TreeCell (IntPtr handle) : base (handle)
        {
        }
        public TreeCell (NSString cellId, StoreItem CatItem ,StoreItem PatternItem)
        {
            cell_back.Image = UIImage.FromFile(PatternItem.cellImagePath);
            cell_front.Image = UIImage.FromFile(CatItem.cellImagePath);
        }
        internal void UpdateCell(StoreItem CatItem,StoreItem PatternItem)
        {
            cell_back.Image = UIImage.FromFile(PatternItem.cellImagePath);
            cell_front.Image = UIImage.FromFile(CatItem.cellImagePath);
        }
    }
}