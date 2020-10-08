using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Foundation;
using Newtonsoft.Json;
using UIKit;

namespace CatTree
{
    public static class TimerInfo
    {
        public static int hour = 0;
        public static int min = 0;
        public static int coins = 0;
        public static bool is_completed = false;
        public static bool ongoing = false;
        public static DateTime StartDate = DateTime.Now;
        public static bool is_paused = false;
        public static TimeSpan remaining = new TimeSpan();
        public static TimeSpan length = new TimeSpan();
        public static bool got_killed = false;
        public static DateTime quit_date = DateTime.Now;
        public static DateTime return_date = DateTime.Now;
        public static void Reset()
        {
            hour = 0;
            min = 0;
            coins = 0;
            StartDate = DateTime.Now;
            is_completed = false;
            ongoing = false;
            is_paused = false;
            remaining = new TimeSpan();
            length = new TimeSpan();
            got_killed = false;
            quit_date = DateTime.Now;
            return_date = DateTime.Now;
        }
        public static void Save()
        {
            var obj = new Container();
            obj = obj.Create();
            var json = JsonConvert.SerializeObject(obj, Newtonsoft.Json.Formatting.Indented);
            var documents = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            var filename = Path.Combine(documents, "Timer.json");
            File.WriteAllText(filename, json);
        }
        public static void Load()
        {
            var documents = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            var filename = Path.Combine(documents, "Timer.json");
            string output = File.ReadAllText(filename);
            Container obj = JsonConvert.DeserializeObject<Container>(output);
            hour = obj.hour;
            min = obj.min;
            coins = obj.coins;
            StartDate = obj.StartDate;
            is_completed = obj.is_completed;
            ongoing = obj.ongoing;
            is_paused = obj.is_paused;
            remaining = obj.remaining;
            length = obj.length;
            got_killed = obj.got_killed;
            return_date = obj.return_date;
            quit_date = obj.quit_date;
        }
        public class Container
        {
            public  int hour;
            public  int min;
            public  int coins;
            public  bool is_completed;
            public  bool ongoing;
            public  DateTime StartDate;
            public bool is_paused;
            public TimeSpan remaining;
            public TimeSpan length;
            public bool got_killed;
            public DateTime quit_date;
            public DateTime return_date;
            public Container Create()
            {
                var cont = new Container();
                cont.hour = TimerInfo.hour;
                cont.min = TimerInfo.min;
                cont.coins = TimerInfo.coins;
                cont.is_completed = TimerInfo.is_completed;
                cont.ongoing = TimerInfo.ongoing;
                cont.StartDate = TimerInfo.StartDate;
                cont.is_paused = TimerInfo.is_paused;
                cont.remaining = TimerInfo.remaining;
                cont.length = TimerInfo.length;
                cont.got_killed = TimerInfo.got_killed;
                cont.quit_date = TimerInfo.quit_date;
                cont.return_date = TimerInfo.return_date;
                return cont;
            }
        }
    }
}