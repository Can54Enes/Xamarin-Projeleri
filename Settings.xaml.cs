using System;
using System.IO;
using System.Threading;
using Xamarin.Forms;
using static Pomodoro.MainPage;
using static Pomodoro.App;
using Pomodoro.Helper;
using Plugin;
using Plugin.LocalNotifications;
using Plugin.LocalNotifications.Abstractions;
//using android.support.v4.app.Fragment;
using Android.Support;

using Xamarin.Essentials;

namespace Pomodoro
{
	public partial class Settings : ContentPage
	{
		public Settings()
		{
			InitializeComponent();
			Permissions.RequestAsync<Permissions.CalendarWrite>();
			if (MainPage.PSDB != 0)
			{
			    PSureDk.Text = Convert.ToString(MainPage.PSDB) + " Dakika";
			}
			else if (MainPage.PSDB == 0)
			{
			    PSureDk.Text = Convert.ToString(MainPage.PS) + " Dakika";
			}
			
			if (MainPage.KMSDB != 0)
			{
			    KısaMolaSureDk.Text = Convert.ToString(MainPage.KMSDB) + " Dakika";
			}
			else if (MainPage.KMSDB == 0)
			{
			    KısaMolaSureDk.Text = Convert.ToString(MainPage.KMS) + " Dakika";
			}
			
			if (MainPage.UMdb == 0 || MainPage.UMdb == 1)
			{
			    UzunMola.IsToggled = true;
			}
			else if (MainPage.UMdb == 2)
			{
			    UzunMola.IsToggled = false;
			}
			
			if (MainPage.UMSdb != 0)
			{
			    UzunMolaSureDk.Text = Convert.ToString(MainPage.UMSdb) + " Dakika";
			}
			else if (MainPage.UMSdb == 0)
			{
			    UzunMolaSureDk.Text = Convert.ToString(MainPage.longBreakMinutes) + " Dakika";
			}
			
			if (MainPage.PSayDB == 0)
			{
			    UMPomodoro.Text = "4 Pomodoro";
			}
			else if (MainPage.PSayDB != 0)
			{
			    UMPomodoro.Text = Convert.ToString(MainPage.PSayDB) + " Pomodoro";
			}
		}
		public async void PomodoroSureSec(object o, EventArgs args)
		{
		    
			var PomodoroSure = await DisplayPromptAsync("Pomodoro Süresi", "Pomodor süresi yazınız.","Tamam","İptal", keyboard: Keyboard.Numeric, initialValue: Convert.ToString(MainPage.minutes), maxLength: 2);
			if (Convert.ToString(PomodoroSure) == null || Convert.ToString(PomodoroSure) == "")
			{
			    PSureDk.Text = Convert.ToString(MainPage.minutes) + " Dakika";
			}
			else
			{
			    if (MainPage.breakMinutes < Convert.ToInt32(PomodoroSure))
			    {
        			PSureDk.Text=Convert.ToString(PomodoroSure) + " Dakika";
        			MainPage.PS = Convert.ToInt32(PomodoroSure);
			    }
			    else
			    {
			        DisplayAlert("Geçersiz Süre!","Pomodoro süresi mola süresinden uzun olmalıdır","Tamam");
			    }
			}
		}
		public async void KısaMolaSureSec(object o, EventArgs args)
		{
			var KısaMolaSure = await DisplayPromptAsync("Kısa Mola Süresi", "Mola süresi yazınız.","Tamam","İptal", keyboard: Keyboard.Numeric, initialValue: Convert.ToString(MainPage.breakMinutes), maxLength: 2);
			if (Convert.ToString(KısaMolaSure) == null || Convert.ToString(KısaMolaSure) == "")
			{
			    KısaMolaSureDk.Text = Convert.ToString(MainPage.breakMinutes) + " Dakika";
			}
			else
			{
    			if (MainPage.minutes > Convert.ToInt32(KısaMolaSure))
    			{
    			   MainPage.KMS = Convert.ToInt32(KısaMolaSure);
    			   KısaMolaSureDk.Text = Convert.ToString(KısaMolaSure) + " Dakika";
    			}
    			else
    			{
    			    DisplayAlert("Geçersiz Süre!","Mola süresi pomodoro süresinden kısa olmalıdır.","Tamam");
    			}
			}
		}
		public async void UzunMolaAcKapa(object o, EventArgs args)
		{
		    if (UzunMola.IsToggled == false)
		    {
		        MainPage.uzunMolaAcikMi = false;
		    }
		    else if (UzunMola.IsToggled == true)
		    {
		        MainPage.uzunMolaAcikMi = true;
		        
		    }
		}
	    public async void UzunMolaSureSec(object o, EventArgs args)
		{
		    if (UzunMola.IsToggled == true)
		    {
    			string UzunMolaSure = await DisplayPromptAsync("Uzun Mola Süresi", "Uzun Mola süresi yazınız.","Tamam","İptal", keyboard: Keyboard.Numeric, initialValue: Convert.ToString(longBreakMinutes), maxLength: 2);
    			if (Convert.ToString(UzunMolaSure) == null ||Convert.ToString(UzunMolaSure) == "")
    			{
    			    UzunMolaSureDk.Text = Convert.ToString(MainPage.UMSdb) + " Dakika";
    			}
    			else
    			{
    			    if (Convert.ToInt32(UzunMolaSure) > MainPage.breakMinutes)
        			{
        			    UzunMolaSureDk.Text = Convert.ToString(UzunMolaSure) + " Dakika";
        			    MainPage.longBreakMinutes = Convert.ToInt32(UzunMolaSure);
        			}
        			else
        			{
        			    DisplayAlert("Geçersiz Süre!","Uzun Mola süresi Kısa Mola süresinden fazla olmalıdır","Tamam");
        			}
    			}
		    }
		}
		public async void UMPomodoroSayisi(object o, EventArgs args)
		{
			if (UzunMola.IsToggled == true)
			{
			    string UzunMolaPS = await DisplayPromptAsync("Uzun Mola Pomodoro Sayısı", "Uzun Mola için gereken Pomodoro sayısını yazınız.","Tamam","İptal", keyboard: Keyboard.Numeric, initialValue: "4", maxLength: 2);
    			if (Convert.ToString(UzunMolaPS) == null ||Convert.ToString(UzunMolaPS) == "")
    			{
    			    UMPomodoro.Text = "4 Pomodoro";
    			}
    			else
    			{
    			    UMPomodoro.Text = Convert.ToString(UzunMolaPS) + " Pomodoro";
    			    MainPage.SecilenPomodoroSay = Convert.ToInt32(UzunMolaPS);
    			}
			}
		}
		public async void Kaydet(object o, EventArgs args)
		{
		    PomodoroDB.AddPSkey = MainPage.PS;
		    MainPage.PSDB = PomodoroDB.AddPSkey;
		    
		    PomodoroDB.AddKMSkey = MainPage.KMS;
		    MainPage.KMSDB = PomodoroDB.AddKMSkey;
		    
		    PomodoroDB.AddPSayKey = MainPage.SecilenPomodoroSay;
		    PSayDB = PomodoroDB.AddPSayKey;
		    
		    PomodoroDB.AddUMSkey = MainPage.longBreakMinutes;
		    MainPage.UMSdb = PomodoroDB.AddUMSkey;
		    
		    if (uzunMolaAcikMi)
		    {
		        PomodoroDB.AddUMkey = 1;
		    }
		    else if (!uzunMolaAcikMi)
		    {
		        PomodoroDB.AddUMkey = 2;
		    }
		    
		    MainPage.UMdb = PomodoroDB.AddUMkey;
		    
		    OnBackButtonPressed();
		}
	}
}