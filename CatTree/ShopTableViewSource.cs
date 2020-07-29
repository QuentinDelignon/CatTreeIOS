using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;

namespace CatTree
{
    public class ShopTableViewSource : UITableViewSource{
        List<StoreItem> items;
        string cellIdentifier = "cell_id";
        public event EventHandler<int> SelectButtonTapped;
        public ShopTableViewSource(List<StoreItem> items)
        {
            this.items = items;
        }
        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            StoreCell cell = tableView.DequeueReusableCell(cellIdentifier, indexPath) as StoreCell;
            StoreItem item = items[indexPath.Row];
            cell.currentIndex = indexPath.Row;
            cell.UpdateCell(item);
            cell.SelectButtonTapped -= OnCellSpeakButtonTapped;
            cell.SelectButtonTapped += OnCellSpeakButtonTapped;


            return cell;
        }
        void OnCellSpeakButtonTapped(object sender, int e)
        {
            int row = e;
            ShopViewController.RowNo = row;
            if (SelectButtonTapped != null)
            {
                SelectButtonTapped(sender, e);
            }
        }
        public override nint RowsInSection(UITableView tableview, nint section)
        {
            return items.Count;
        }
    }
}