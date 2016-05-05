using System;

using Xamarin.Forms;
using TripLog.Views;

namespace TripLog
{
	public class App : Application
	{
		public App ()
		{
			var mainPage = new NavigationPage( new TripLog.Views.MainPage()); 
			var navService = DependencyService.Get<INavService>() as XamarinFormsNavService;
			navService.XamarinFormsNav = mainPage.Navigation;
			navService.RegisterViewMapping (typeof(MainViewModel), typeof(MainPage));
			navService.RegisterViewMapping (typeof(DetailViewModel),
				typeof(DetailPage));
			navService.RegisterViewMapping (typeof(NewEntryViewModel),
				typeof(NewEntryPage));
			MainPage = mainPage;
		}

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}

