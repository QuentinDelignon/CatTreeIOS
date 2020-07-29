using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;

namespace CatTree
{
    public class SelectSource : UICollectionViewDataSource
    {
        List<StoreItem> Cats;
        List<StoreItem> Patterns;
        string cellID = "SelectCellID";
        string headerID = "HeaderID";

        public SelectSource(List<StoreItem> cats , List<StoreItem> patterns)
        {
            this.Cats = cats;
            this.Patterns = patterns;

        }

        public override UICollectionViewCell GetCell(UICollectionView CollectionView, NSIndexPath indexPath)
        {
            SelectCell cell = CollectionView.DequeueReusableCell(cellID, indexPath) as SelectCell;
            if (indexPath.Section == 0)
            {
                StoreItem Cat = Cats[indexPath.Row];
                cell.UpdateCell(Cat);
                
            }
            if (indexPath.Section == 1)
            {
                StoreItem Pattern = Patterns[indexPath.Row];
                cell.UpdateCell(Pattern);
            }
            return cell;
        }
        public override nint GetItemsCount(UICollectionView collectionView, nint section)
        {
            if (section == 0)
            {
                return Cats.Count;
            }
            if (section == 1)
            {
                return Patterns.Count;
            }
            else
            {
                return 0;
            }

        }
        public override nint NumberOfSections(UICollectionView collectionView)
        {
            return 2;
        }
        public override UICollectionReusableView GetViewForSupplementaryElement(UICollectionView collectionView, NSString elementKind, NSIndexPath indexPath)
        {
            Header headerView = (Header)collectionView.DequeueReusableSupplementaryView(elementKind,headerID, indexPath);
            if (indexPath.Section == 0)
            {
                headerView.Text = "Petits Chattons";
            }
            if (indexPath.Section == 1)
            {
                headerView.Text = "Fonds";
            }
            
            return headerView;
        }

    }
}