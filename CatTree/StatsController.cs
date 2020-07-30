using System;
using UIKit;
using Microcharts;
using CoreGraphics;
using Microcharts.iOS;
using System.Linq;
using System.Collections.Generic;

namespace CatTree
{
    public partial class StatsController : UIViewController
    {
        public StatsController (IntPtr handle) : base (handle)
        {
        }
        public void MakeCanvas(ChartEntry[] entries)
        {
            var chart = new LineChart() { Entries = entries };
            chart.LabelTextSize = 30;
            var chartView = new ChartView
            {
                Frame = new CGRect(0, 400, this.View.Bounds.Width, 240 ),
                AutoresizingMask = UIViewAutoresizing.FlexibleWidth,
                Chart = chart
            };
            this.View.AddSubview(chartView);
        }
        partial void SegmentControl_ValueChanged(UISegmentedControl sender)
        {
            var index = plot_type.SelectedSegment;
            MakeCanvas(AppData.SessionItems.MakeData(index));

        }
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.
            try { AppData.SessionItems.Load(); } catch { }
            MakeCanvas(AppData.SessionItems.MakeData(0));
            money_label.Text = AppData.Coins.myCoins[0].ToString();
            List<int> HourCount = AppData.SessionItems.GetHours();
            thour_count.Text = HourCount[2].ToString();
            mhour_count.Text = HourCount[1].ToString();
            whour_count.Text = HourCount[0].ToString();
            
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}