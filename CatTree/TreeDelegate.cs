using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CoreGraphics;
using Foundation;
using ObjCRuntime;
using UIKit;

namespace CatTree
{
    class TreeDelegate : UICollectionViewDelegate
    {
        public int num = 0;
        public TreeDelegate()
        {
            UIMenuController.SharedMenuController.MenuItems = new UIMenuItem[] { new UIMenuItem() { Action = new Selector("delete"), Title = "Supprimer"} };
        }
        public override bool ShouldShowMenu(UICollectionView collectionView, NSIndexPath indexPath)
        {
            return indexPath.Row != AppData.TreeItems.Cats.Count;
        }
        public override bool CanPerformAction(UICollectionView collectionView, Selector action, NSIndexPath indexPath, NSObject sender)
        {
            if (action.Name == "cut:")
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }
        public override void PerformAction(UICollectionView collectionView, Selector action, NSIndexPath indexPath, NSObject sender)
        {
            if (action.Name == "cut:")
            {
                AppData.TreeItems.Cats.RemoveAt(indexPath.Row);
                AppData.TreeItems.Patterns.RemoveAt(indexPath.Row);
                AppData.TreeItems.SaveCats();
                AppData.TreeItems.SavePatterns();
                collectionView.DataSource = new TreeSource();
                collectionView.ReloadData();
            }
   
        }
        public override NSIndexPath GetTargetIndexPathForMove(UICollectionView collectionView, NSIndexPath originalIndexPath, NSIndexPath proposedIndexPath)
        {
            if (proposedIndexPath.Row == AppData.TreeItems.Cats.Count)
            {
                return originalIndexPath;
            }
            else
            {
                return proposedIndexPath;
            }
        
        }

    }
}