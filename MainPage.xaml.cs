using System;
using System.IO;
using System.Threading;
using Xamarin.Forms;
using Plugin.Settings.Abstractions;
using Plugin.Settings;
using Xamarin.Essentials;
using System.Diagnostics;
using Pomodoro.Helper;
using SQLite;
//using static Pomodoro.DataBase;
using Plugin.LocalNotifications;
using Plugin.LocalNotifications.Abstractions;

namespace Pomodoro
{
	public partial class MainPage : ContentPage
	{
	    public static bool run = true;
	    public static bool breakRun = true;
	    public static bool uzunMolaAcikMi = true;
	    public static int PS;
	    public static int UMdb = PomodoroDB.AddUMkey; 
	    public static int PSDB = PomodoroDB.AddPSkey;
	    public static int KMS = 15;
	    public static int UMS;
	    public static int UMSdb = PomodoroDB.AddUMSkey;
	    public static int PomdoroSay = 0;
	    public static int PSayDB = PomodoroDB.AddPSayKey;
	    public static int SecilenPomodoroSay;
	    public static int KMSDB = PomodoroDB.AddKMSkey;
	    public static int second = 0;
	    public static int minutes;
	    public static int breakMinutes;
	    public static int longBreakMinutes;
	    public static int breakSecond = 0;
	    public static bool uzunMola = true;
	    
	    
		public MainPage()
		{
			InitializeComponent();
			
			var status = Permissions.RequestAsync<Permissions.LocationWhenInUse>();
			
			if (PSDB == 0)
			{
			    PS = 45;
			    minutes = PS;
			}
			else
			{
			    PS = PSDB;
			    minutes = PSDB;
			}
			
			if (UMSdb == 0)
			{
			    UMS = 20;
			    longBreakMinutes = UMS;
			}
			else
			{
			    UMS = UMSdb;
			    longBreakMinutes = UMSdb;
			}
			
			if (KMSDB == 0)
			{
			    KMS = 15;
			    breakMinutes = KMS;
			}
			else
			{
			    KMS = KMSDB;
			    breakMinutes = KMSDB;
			}
			
			if (UMdb == 0 || UMdb == 1)
			{
			    uzunMolaAcikMi = true;
			}
			else if (UMdb == 2)
			{
			    uzunMolaAcikMi = false;
			}
			
			if (PSayDB == 0)
			{
			    SecilenPomodoroSay = 4;
			}
			else
			{
			    SecilenPomodoroSay = PSayDB;
			}
			
			//CrossSettings.Current.Remove(App.UMSkey);
		}
		public void StopWatch()
		{
	        //minutes = 45;
	        Dakika.Text = Convert.ToString(minutes);
    	    Device.StartTimer(TimeSpan.FromSeconds(1), () => {
    	        if (!run)
                {
                    return false;
                }
                if (second == 0 && minutes == 0)
                {
                    PomodoroBitti();
                    return false;
                }
                second -= 1;
                
                if (second <= 0)
                {
                    second = 60;
                    minutes--;
                    return true;
                }
                
                if (second < 10 && minutes < 10)
                {
                    Dakika.Text = "0" + Convert.ToString(minutes);
                    Saniye.Text = "0" + Convert.ToString(second);
                }
                else if (second < 10 && minutes >= 10)
                {
                    Dakika.Text = Convert.ToString(minutes);
                    Saniye.Text = "0" + Convert.ToString(second);
                }
                else if (second >= 10 && minutes < 10)
                {
                    Saniye.Text = Convert.ToString(second);
                    Dakika.Text = "0" + Convert.ToString(minutes);
                }
                else
                {
                    Saniye.Text = Convert.ToString(second);
                    Dakika.Text = Convert.ToString(minutes);
                }
                
                return true;
            });
		}
		public void BreakStopWatch()
		{
		    Device.StartTimer(TimeSpan.FromSeconds(1), () => {
		        if (breakSecond == 0)
		        {
		            breakMinutes--;
		            breakSecond = 60;
		        }
		        breakSecond--;
		        
		        if (!breakRun || (breakSecond == 0 && breakMinutes == 0))
		        {
		            Saniye.Text = "00";
		            Dakika.Text = "00";
		            
		            return false;
		        }
		        
		        if (breakSecond < 10 && breakMinutes >= 10)
		        {
		            Saniye.Text = "0" + Convert.ToString(breakSecond);
		            Dakika.Text = Convert.ToString(breakMinutes);
		        }
		        else if (breakMinutes < 10 && breakSecond >= 10)
		        {
		            Dakika.Text = "0" + Convert.ToString(breakMinutes);
		            Saniye.Text = Convert.ToString(breakSecond);
		        }
		        else if (breakSecond >= 10 && breakMinutes >= 10)
		        {
		            Saniye.Text = Convert.ToString(breakSecond);
		            Dakika.Text = Convert.ToString(breakMinutes);
		        }
		        else if (breakMinutes < 10 && breakSecond < 10)
		        {
		            Saniye.Text = "0" + Convert.ToString(breakSecond);
		            Dakika.Text = "0" + Convert.ToString(breakMinutes);
		        }
		        
		        
		        return true;
		    });
		}
		public void BaslatClick(object sender,EventArgs args)
		{
		    Durdur.IsVisible = true;
		    Baslat.IsVisible = false;
		    run = true;
		    
			if (PSDB == 0)
			{
			    minutes = PS;
			}
			else
			{
			    minutes = PSDB;
			}
		    
		    //CrossLocalNotifications.Current.Show("Title","Body",1735);
		    
		    StopWatch();
		}
		public void DurdurClick(object sender,EventArgs args)
		{
		    Durdur.IsVisible = false;
		    Devam.IsVisible = true;
		    Bitir.IsVisible = true;
		    run = false;
		}
		public void AraVer(object sender, EventArgs args)
		{
		    Ara.IsVisible = false;
		    AraSon.IsVisible = true;
		    breakRun = true;
		    BreakStopWatch();
		    
		    if (PomdoroSay == SecilenPomodoroSay)
		    {
		        breakMinutes = (longBreakMinutes);
		        PomdoroSay = 0;
		    }
		}
		public void BitirClick(object sender, EventArgs args)
		{
		    Ara.IsVisible=true;
		    Bitir.IsVisible=false;
		    Devam.IsVisible=false;
		    
		    Dakika.Text = "00";
		    Saniye.Text = "00";
		    second = 0;
		    
		    if (uzunMolaAcikMi)
		    {
		        PomdoroSay++;
		    }
		    else if (!uzunMolaAcikMi)
		    {
		        PomdoroSay = 0;
		    }
	        
			if (PSDB == 0)
			{
			    minutes = PS;
			}
			else
			{
			    minutes = PSDB;
			}
			
		    run = false;

		}
		public void DevamClick(object sender, EventArgs args)
		{
		    Durdur.IsVisible = true;
		    Bitir.IsVisible = false;
		    Devam.IsVisible = false;
		    run = true;
		    StopWatch();
		}
		public void AraBitirClick(object sender, EventArgs args)
		{
		    Dakika.Text = "00";
		    Saniye.Text = "00";
		    second = 0;
		    minutes = PS;
		    breakMinutes = KMS;
		    breakSecond = 0;
		    AraSon.IsVisible = false;
		    Baslat.IsVisible = true;
		    breakRun = false;
		}
		public void PomodoroSettings(object sender, EventArgs args)
		{
		    ContentPage SettingsPage = new Settings();
		    Navigation.PushModalAsync(SettingsPage);
		}
		public void PomodoroBitti()
		{
		    
		    Ara.IsVisible=true;
		    Bitir.IsVisible=false;
		    Devam.IsVisible=false;
		    
		    Dakika.Text = "00";
		    Saniye.Text = "00";
		    second = 0;
		    minutes = PS;
		    run = false;
		    
		}
		protected override bool OnBackButtonPressed()
        {
            Device.BeginInvokeOnMainThread(async() => {
                var result = await this.DisplayAlert("Uyarı!", "Uygulamadan Çıkmak İstediğinize Emin Misiniz?", "Evet", "Hayır");
                if (result) await this.Navigation.PushAsync(new TabbedPage(),false);
                });      
           return true;
           return base.OnBackButtonPressed();    
        }
	}
}