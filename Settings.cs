using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using Plugin.Settings;
using static Pomodoro.MainPage;
using Plugin.Settings.Abstractions;

namespace Pomodoro.Helper
{
    public class PomodoroDB
    {
        static ISettings getSetting => CrossSettings.Current;
        
        public static int AddPSkey
        {
            get => CrossSettings.Current.GetValueOrDefault(App.PSkey,0);
            set =>CrossSettings.Current.AddOrUpdateValue(App.PSkey, value);
            
            //Eklerken => PomDB.Key = eklenecek veri;
        }
        
        public static int AddKMSkey
        {
            get => CrossSettings.Current.GetValueOrDefault(App.KMSkey,0);
            set =>CrossSettings.Current.AddOrUpdateValue(App.KMSkey, value);
            
            //Eklerken => PomDB.Key = eklenecek veri;
        }
        
        public static int AddUMkey
        {
            get => CrossSettings.Current.GetValueOrDefault(App.UMkey,0);
            set =>CrossSettings.Current.AddOrUpdateValue(App.UMkey, value);
            
            /*
            0 : Değer Eklenmemiş
            1 : Uzun Mola Açık
            2 : Uzun Mola Kapalı
            */
            
            //Eklerken => PomDB.Key = eklenecek veri;
        }
        
        public static int AddUMSkey
        {
            get => CrossSettings.Current.GetValueOrDefault(App.UMSkey,0);
            set =>CrossSettings.Current.AddOrUpdateValue(App.UMSkey, value);
            
            //Eklerken => PomDB.Key = eklenecek veri;
        }
        
        public static int AddPSayKey
        {
            get => CrossSettings.Current.GetValueOrDefault(App.PSayKey,0);
            set =>CrossSettings.Current.AddOrUpdateValue(App.PSayKey, value);
            
            //Eklerken => PomDB.Key = eklenecek veri;
        }
    }
}