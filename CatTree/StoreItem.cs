using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;

namespace CatTree
{
    public class StoreItem
    {
        public string cellTitle { get; set; }
        public string cellDesc { get; set; }
        public string cellPrice { get; set; }
        public string cellImagePath { get; set; }
        public StoreItem() { }
    }
}