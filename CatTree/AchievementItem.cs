using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;

namespace CatTree
{
    public class AchievementItem
    {
        public string cellTitle { get; set; }
        public string cellDesc { get; set; }
        public double progress { get; set; }
        public string cellImage { get; set; }
    }
}