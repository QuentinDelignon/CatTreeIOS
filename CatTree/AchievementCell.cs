using Foundation;
using System;
using UIKit;

namespace CatTree
{
    public partial class AchievementCell : UITableViewCell
    {
        public AchievementCell(IntPtr handle) : base(handle)
        {
        }
        public AchievementCell(NSString cellId, AchievementItem item) : base(UITableViewCellStyle.Default, cellId)
        {
            AchCellTitle.Text = item.cellTitle;
            cell_image.Image = UIImage.FromFile(item.cellImage);
            cell_sub.Text = item.cellDesc;
            cell_progress.SetProgress(Convert.ToSingle(item.progress),true);
            percent_label.Text = (Math.Truncate(item.progress * 100)).ToString()+" %";
        }
        internal void UpdateCell(AchievementItem item)
        {
            AchCellTitle.Text = item.cellTitle;
            cell_image.Image = UIImage.FromFile(item.cellImage);
            cell_sub.Text = item.cellDesc;
            cell_progress.SetProgress(Convert.ToSingle(item.progress), true);
            percent_label.Text = (Math.Truncate(item.progress * 100)).ToString()+" %";
        }
    }
}