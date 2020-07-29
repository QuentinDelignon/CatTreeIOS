using Foundation;
using System;
using UIKit;

namespace CatTree
{
    public partial class AchievedCell : UITableViewCell
    {
        public AchievedCell (IntPtr handle) : base (handle)
        {
        }
        public AchievedCell(NSString cellId, AchievementItem item) : base(UITableViewCellStyle.Default, cellId)
        {
            cell_title.Text = item.cellTitle;
            cell_image.Image = UIImage.FromFile(item.cellImage);
            cell_sub.Text = item.cellDesc;
        }
        internal void UpdateCell(AchievementItem item)
        {
            cell_title.Text = item.cellTitle;
            cell_image.Image = UIImage.FromFile(item.cellImage);
            cell_sub.Text = item.cellDesc;
        }
    }
}