using System;
using UIKit;

namespace CatTree
{
    public partial class AchievmentController : UIViewController
    {
        public AchievmentController(IntPtr handle) : base(handle)
        {
        }
        partial void AchTypeChanged(UISegmentedControl sender)
        {
            var index = achievment_type.SelectedSegment;
            if (index == 1)
            {
                try
                {
                    AppData.AchievementItems.LoadDone();
                }
                catch
                {

                }
                tableview.Source = new AchievedSource(AppData.AchievementItems.Done);
                tableview.RowHeight = UITableView.AutomaticDimension;
                tableview.EstimatedRowHeight = 40f;
            }
            if (index == 0)
            {
                try
                {
                    AppData.AchievementItems.LoadOngoing();
                }
                catch
                {

                }
                tableview.Source = new AchievementSource(AppData.AchievementItems.Ongoing);
                tableview.RowHeight = UITableView.AutomaticDimension;
                tableview.EstimatedRowHeight = 40f;
            }

        }
        public override void ViewDidAppear(bool animated)
        {
            base.ViewDidAppear(animated);
            achievment_type.SelectedSegment = 0;
            try { AppData.ComputeAchievements(); } catch { }
            try { AppData.AchievementItems.LoadOngoing(); } catch { }
            tableview.Source = new AchievementSource(AppData.AchievementItems.Ongoing);
            label_money.Text = AppData.Coins.myCoins[0].ToString();
        }
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            AppData.ComputeAchievements();
            try{AppData.AchievementItems.LoadOngoing();}catch{}
            tableview.Source = new AchievementSource(AppData.AchievementItems.Ongoing);
            label_money.Text = AppData.Coins.myCoins[0].ToString();
        }
    }
}