using CoreGraphics;
using Foundation;
using System;
using System.Collections.Generic;
using UIKit;

namespace CatTree
{
    public partial class SelectViewController : UIViewController
    {
        public SelectViewController (IntPtr handle) : base (handle)
        {
        }
        public SelectViewController()
        {
            
        }
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            try { AppData.Inventory.LoadCats();AppData.Inventory.LoadPatterns(); } catch { }
            SelectCollection.RegisterClassForSupplementaryView(typeof(Header), UICollectionElementKindSection.Header, "HeaderID");
            SelectCollection.DataSource = new SelectSource(AppData.Inventory.Cats,AppData.Inventory.Patterns);
            SelectCollection.AllowsMultipleSelection = true;
            SelectCollection.Delegate = new SelectDelegate();

            exit_select.TouchUpInside += (sender, e) =>
            {
                NSIndexPath[] SelectedItems = SelectCollection.GetIndexPathsForSelectedItems();
                if (SelectedItems.Length != 2)
                {
                    var okAlertController = UIAlertController.Create("Attention !", "Tu dois choisir 2 éléments ...", UIAlertControllerStyle.Alert);
                    okAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));
                    PresentViewController(okAlertController, true, null);
                }
                else
                {
                    if (SelectedItems[0].Section == SelectedItems[1].Section)
                    {
                        var okAlertController = UIAlertController.Create("Attention !", "Tu dois choisir des éléments de 2 catégories différentes ...", UIAlertControllerStyle.Alert);
                        okAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));
                        PresentViewController(okAlertController, true, null);
                    }
                    else
                    {
                        var CatCell = SelectCollection.CellForItem(SelectedItems[0]) as SelectCell;
                        StoreItem CatItem = CatCell.item;
                        var PatternCell = SelectCollection.CellForItem(SelectedItems[1]) as SelectCell;
                        StoreItem PatternItem = PatternCell.item;
                        if (CatCell.item.cellImagePath.Contains("cat/"))
                        {
                            AppData.TreeItems.AddItems(CatItem, PatternItem);
                        }
                        else
                        {
                            AppData.TreeItems.AddItems(PatternItem, CatItem);
                        }
                        var okAlertController = UIAlertController.Create("Super !", "Tu as Choisis "+CatItem.cellTitle+" et "+PatternItem.cellTitle+" !", UIAlertControllerStyle.Alert);
                        okAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));
                        PresentViewController(okAlertController, true, null);
                        

                    }
                }
            };
            cancel_select.TouchUpInside += (sender, e) => {
                DismissViewController(true, null);
            };
        }

    }
    
}