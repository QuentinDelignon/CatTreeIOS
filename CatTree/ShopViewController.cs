using System;
using System.Collections.Generic;
using UIKit;

namespace CatTree
{
    public partial class ShopViewController : UIViewController
    {
        public static int RowNo;
        
        public ShopViewController(IntPtr handle) : base(handle)
        {
        }
        partial void ShopTypeChanged(UISegmentedControl sender)
        {
            var index = item_type.SelectedSegment;
            if (index == 0) {
                            try
                            {
                                AppData.AvailableItems.LoadCats();
                            }
                            catch
                            {

                            }
                            ShopTableViewSource source = new ShopTableViewSource(AppData.AvailableItems.Cats);
                            source.SelectButtonTapped -= OnSelectedButtonTapped;
                            source.SelectButtonTapped += OnSelectedButtonTapped;
                            ShopTableView.Source = source;
                            ShopTableView.RowHeight = UITableView.AutomaticDimension;
                            ShopTableView.EstimatedRowHeight = 40f;
                            ShopTableView.ReloadData(); }
            if (index == 1) {
                            try
                            {
                                AppData.AvailableItems.LoadPatterns();
                            }
                            catch
                            {

                            }                           
                            ShopTableViewSource source = new ShopTableViewSource(AppData.AvailableItems.Patterns);
                            source.SelectButtonTapped -= OnSelectedButtonTapped;
                            source.SelectButtonTapped += OnSelectedButtonTapped;
                            ShopTableView.Source = source;
                            ShopTableView.RowHeight = UITableView.AutomaticDimension;
                            ShopTableView.EstimatedRowHeight = 100f;
                            ShopTableView.ReloadData();
            }
        }
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            money_label.Text = AppData.Coins.myCoins[0].ToString();
            try
            {
                AppData.AvailableItems.LoadCats();
            }
            catch
            {

            }
            ShopTableViewSource source = new ShopTableViewSource(AppData.AvailableItems.Cats);
            source.SelectButtonTapped -= OnSelectedButtonTapped;
            source.SelectButtonTapped += OnSelectedButtonTapped;
            ShopTableView.Source = source;
            ShopTableView.RowHeight = UITableView.AutomaticDimension;
            ShopTableView.EstimatedRowHeight = 40f;
        }
        private void OnSelectedButtonTapped(object sender, int e)
        {
            var type = (int) item_type.SelectedSegment;
            var number = RowNo;
            if (type == 0)
            {
                if (AppData.Coins.myCoins[0] >= int.Parse(AppData.AvailableItems.Cats[number].cellPrice))
                {
                    string message = "Tu as Acheté : "+ AppData.AvailableItems.Cats[number].cellTitle;
                    AppData.Coins.Substract(int.Parse(AppData.AvailableItems.Cats[number].cellPrice));
                    AppData.Inventory.BuyItem(type, number);
                    ShopTableView.ReloadData();
                    money_label.Text = AppData.Coins.myCoins[0].ToString();
                    var okAlertController = UIAlertController.Create("Super !", message, UIAlertControllerStyle.Alert);
                    okAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));
                    PresentViewController(okAlertController, true, null);
                }
                else
                {
                    var okAlertController = UIAlertController.Create("Heuu ...", "Tu n'as pas assez d'argent !", UIAlertControllerStyle.Alert);
                    okAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));
                    PresentViewController(okAlertController, true, null);
                }
            }
            else
            {
                if (AppData.Coins.myCoins[0] >= float.Parse(AppData.AvailableItems.Patterns[number].cellPrice))
                {

                    string message = "Tu as Acheté : " + AppData.AvailableItems.Patterns[number].cellTitle;
                    AppData.Coins.Substract(int.Parse(AppData.AvailableItems.Patterns[number].cellPrice));
                    AppData.Inventory.BuyItem(type, number);
                    ShopTableView.ReloadData();
                    money_label.Text = AppData.Coins.myCoins[0].ToString();
                    var okAlertController = UIAlertController.Create("Super !", message, UIAlertControllerStyle.Alert);
                    okAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));
                    PresentViewController(okAlertController, true, null);
                }
                else
                {
                    var okAlertController = UIAlertController.Create("Heuu ...", "Tu n'as pas assez d'argent !", UIAlertControllerStyle.Alert);
                    okAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));
                    PresentViewController(okAlertController, true, null);
                }
            }
            
            
        }
    }
}