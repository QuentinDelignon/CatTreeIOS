using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;

namespace CatTree
{
    public class SessionItem
    {
        public DateTime Date { get; set; }
        public TimeSpan Duration { get; set; }
        public int CoinsEarned { get; set; }
    }
}