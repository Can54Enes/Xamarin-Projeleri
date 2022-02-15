using System;
using Xamarin.Forms;
namespace Pomodoro
{
	public partial class MainPage
	{
		public static StackLayout SaatLayout, ButtonLayout, PomodoroLayout, MainLayout;
        public static Frame SaatFrame, ButtonFrame;
        
		public static Label Dakika, Nokta, Saniye;
		public static Button Baslat, ayarlarBtn, Durdur, Ara, Bitir, Devam, AraSon;
		
		
		public void InitializeComponent()
		{
			Xamarin.Forms.Xaml.Extensions.LoadFromXaml(this, typeof(MainPage));
			
			PomodoroLayout = this.FindByName<StackLayout>("PomodoroLayout");
			MainLayout = this.FindByName<StackLayout>("MainLayout");
			SaatLayout = this.FindByName<StackLayout>("SaatLayout");
			ButtonLayout = this.FindByName<StackLayout>("ButtonLayout");
			SaatFrame = this.FindByName<Frame>("SaatFrame");
			ButtonFrame = this.FindByName<Frame>("ButtonFrame");
			Dakika = this.FindByName<Label>("Dakika");
			Nokta = this.FindByName<Label>("Nokta");
			Saniye = this.FindByName<Label>("Saniye");
			Baslat = this.FindByName<Button>("Baslat");
			Durdur = this.FindByName<Button>("Durdur");
			Ara = this.FindByName<Button>("Ara");
			Bitir = this.FindByName<Button>("Bitir");
			AraSon = this.FindByName<Button>("AraBitir");
			ayarlarBtn = this.FindByName<Button>("ayarlarBtn");
			Devam = this.FindByName<Button>("Devam");
		}
	}
}
