using System;
using Plugin;
using System.IO;
using Xamarin.Forms;

namespace Pomodoro
{
	public partial class App : Application
	{
	    public static string PSkey = "PSkey";
	    public static string KMSkey = "KMSkey";
	    public static string UMSkey = "UMSkey";
	    public static string UMkey = "UMkey";
	    public static string PSayKey = "PSayKey";
		public App()
		{
			InitializeComponent();
			
			this.MainPage = new MainPage();
		}
	}
}