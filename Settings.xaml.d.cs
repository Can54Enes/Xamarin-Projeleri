using System;
using Xamarin.Forms;
namespace Pomodoro
{
	public partial class Settings
	{
	    public static Label PSureDk, KısaMolaSureDk, UzunMolaSureDk, UMPomodoro;
	    public static Switch UzunMola;
		public void InitializeComponent()
		{
			Xamarin.Forms.Xaml.Extensions.LoadFromXaml(this, typeof(Settings));
			PSureDk = this.FindByName<Label>("PSureDk");
			KısaMolaSureDk = this.FindByName<Label>("KısaMolaSureDk");
			UMPomodoro = this.FindByName<Label>("UMPomodoro");
			UzunMolaSureDk = this.FindByName<Label>("UzunMolaSureDk");

			UzunMola = this.FindByName<Switch>("UzunMola");
		}
	}
}