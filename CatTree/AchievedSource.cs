using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;

namespace CatTree
{
    public class AchievedSource : UITableViewSource{
        string cellIdentifier = "achieved_cell";
        List<AchievementItem> items;
        public AchievedSource(List<AchievementItem> items)
        {
            this.items = items;
        }
        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            AchievedCell cell = tableView.DequeueReusableCell(cellIdentifier, indexPath) as AchievedCell ;
            AchievementItem item = items[indexPath.Row];
            cell.UpdateCell(item);
            return cell;
        }
        public override nint RowsInSection(UITableView tableview, nint section)
        {
            return items.Count;
        }
    }
}