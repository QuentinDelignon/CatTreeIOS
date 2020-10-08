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
        public static DateTime EndDate = DateTime.Now;
        public static bool ongoing = false;
        public static DateTime StartDate = DateTime.Now;
        public static bool is_paused = false;
        public static void Reset()
        {
            hour = 0;
            min = 0;
            coins = 0;
            EndDate = DateTime.Now;
            StartDate = DateTime.Now;
            is_completed = false;
            ongoing = false;
            is_paused = false;
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
            EndDate = obj.EndDate;
            StartDate = obj.StartDate;
            is_completed = obj.is_completed;
            ongoing = obj.ongoing;
            is_paused = obj.is_paused;
        }
        public class Container
        {
            public  int hour;
            public  int min;
            public  int coins;
            public  bool is_completed;
            public  DateTime EndDate;
            public  bool ongoing;
            public  DateTime StartDate;
            public bool is_paused;
            public Container Create()
            {
                var cont = new Container();
                cont.hour = TimerInfo.hour;
                cont.min = TimerInfo.min;
                cont.coins = TimerInfo.coins;
                cont.is_completed = TimerInfo.is_completed;
                cont.EndDate = TimerInfo.EndDate;
                cont.ongoing = TimerInfo.ongoing;
                cont.StartDate = TimerInfo.StartDate;
                cont.is_paused = TimerInfo.is_paused;
                return cont;
            }
        }
    }
}