using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;

namespace CatTree
{
    public class AchievementSource : UITableViewSource{
        string cellIdentifier = "ach_cell";
        List<AchievementItem> items;
        public AchievementSource(List<AchievementItem> items)
        {
            this.items = items;
        }
        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            AchievementCell cell = tableView.DequeueReusableCell(cellIdentifier, indexPath) as AchievementCell ;
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