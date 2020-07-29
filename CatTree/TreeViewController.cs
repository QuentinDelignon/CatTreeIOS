using CoreGraphics;
using Foundation;
using System;
using System.Collections.Generic;
using UIKit;

namespace CatTree
{
    public partial class TreeViewController : UIViewController
    {
        public TreeViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            try { AppData.TreeItems.LoadCats(); AppData.TreeItems.LoadPatterns(); } catch { }
            money_label.Text = AppData.Coins.myCoins[0].ToString();
            var source = new TreeSource();
            UICollectionViewFlowLayout mylayout = myCollection.CollectionViewLayout as UICollectionViewFlowLayout;
            mylayout.ItemSize = new CGSize(myCollection.Frame.Width/3.0f-5f, myCollection.Frame.Width/3.0f - 5f);
            mylayout.MinimumInteritemSpacing = 5f;
            mylayout.MinimumLineSpacing = 5f;
            myCollection.CollectionViewLayout = mylayout;
            myCollection.DataSource = source;
            var longPressGesture = new UILongPressGestureRecognizer(gesture =>
            {
                // Take action based on state
                switch (gesture.State)
                {
                    case UIGestureRecognizerState.Began:
                        var selectedIndexPath = myCollection.IndexPathForItemAtPoint(gesture.LocationInView(myCollection));
                        if (selectedIndexPath != null)
                            myCollection.BeginInteractiveMovementForItem(selectedIndexPath);
                        break;
                    case UIGestureRecognizerState.Changed:
                        myCollection.UpdateInteractiveMovement(gesture.LocationInView(myCollection));
                        break;
                    case UIGestureRecognizerState.Ended:
                        myCollection.EndInteractiveMovement();
                        break;
                    default:
                        myCollection.CancelInteractiveMovement();
                        break;
                }
            });
            myCollection.AddGestureRecognizer(longPressGesture);
        }
        private void OnSelectedButtonTapped(object sender, EventArgs e)
        {
           
        }
        public override void ViewDidAppear(bool animated)
        {
            base.ViewDidAppear(animated);
            try { AppData.TreeItems.LoadCats(); AppData.TreeItems.LoadPatterns(); } catch { }
            var source = new TreeSource();
            money_label.Text = AppData.Coins.myCoins[0].ToString();
            UICollectionViewFlowLayout mylayout = myCollection.CollectionViewLayout as UICollectionViewFlowLayout;
            mylayout.ItemSize = new CGSize(myCollection.Frame.Width / 3.0f - 5f, myCollection.Frame.Width / 3.0f - 5f);
            mylayout.MinimumInteritemSpacing = 5f;
            mylayout.MinimumLineSpacing = 5f;
            myCollection.CollectionViewLayout = mylayout;
            myCollection.DataSource = source;
        }
    }

}
