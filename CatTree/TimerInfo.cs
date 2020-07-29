using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;

namespace CatTree
{
    public static class TimerInfo
    {
        public static int hour=0;
        public static int min=0;
        public static int coins=0;
        public static bool is_completed=false;

        public static void Reset()
        {
            hour = 0;
            min = 0;
            coins = 0;
            is_completed = false;
        }

    }
}