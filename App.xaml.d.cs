using System;
using Xamarin.Forms;
namespace Pomodoro
{
	public partial class App
	{
		public void InitializeComponent()
		{
			Xamarin.Forms.Xaml.Extensions.LoadFromXaml(this, typeof(App));
		}
	}
}
