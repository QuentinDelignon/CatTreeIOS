using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;

namespace CatTree
{
    public class TreeSource : UICollectionViewDataSource
    {
        string cellID = "basic_cell";
        string AddcellID = "add_cell";
        public event EventHandler<EventArgs> AddButtonTapped;

        public TreeSource ()
        {
        }
        public override UICollectionViewCell GetCell(UICollectionView CollectionView, NSIndexPath indexPath)
        {
            try
            {
                TreeCell cell = CollectionView.DequeueReusableCell(cellID, indexPath) as TreeCell;
                StoreItem Cat = AppData.TreeItems.Cats[indexPath.Row];
                StoreItem Pattern = AppData.TreeItems.Patterns[indexPath.Row];
                cell.UpdateCell(Cat, Pattern);
                return cell;
            }
            catch
            {
                TreeAddCell add_cell = CollectionView.DequeueReusableCell(AddcellID, indexPath) as TreeAddCell;
                add_cell.AddButtonTapped -= NewItemButtonTapped;
                add_cell.AddButtonTapped += NewItemButtonTapped;
                add_cell.UpdateCell();
                return add_cell;
            }
        }
        void NewItemButtonTapped(object sender, EventArgs e)
        {
            if (AddButtonTapped != null)
            {
                AddButtonTapped(sender, e);
            }
        }
        public override nint GetItemsCount(UICollectionView collectionView, nint section)
        {
            return AppData.TreeItems.Cats.Count+1;
        }
        public override bool CanMoveItem(UICollectionView collectionView, NSIndexPath indexPath)
        {
            return true;
        }
        public override void MoveItem(UICollectionView collectionView, NSIndexPath sourceIndexPath, NSIndexPath destinationIndexPath)
        {
            var Cat = AppData.TreeItems.Cats[(int)sourceIndexPath.Item];
            var Pattern = AppData.TreeItems.Patterns[(int)sourceIndexPath.Item];
            AppData.TreeItems.Cats.RemoveAt((int)sourceIndexPath.Item);
            AppData.TreeItems.Patterns.RemoveAt((int)sourceIndexPath.Item);
            AppData.TreeItems.Cats.Insert((int)destinationIndexPath.Item, Cat);
            AppData.TreeItems.Patterns.Insert((int)destinationIndexPath.Item, Pattern);
            AppData.TreeItems.SaveCats();
            AppData.TreeItems.SavePatterns();
        }
    }
}