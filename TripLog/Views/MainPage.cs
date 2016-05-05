using System;

using Xamarin.Forms;
using System.Collections.Generic;

namespace TripLog.Views
{
	public class MainPage : ContentPage
	{
		MainViewModel _vm {
			get { return BindingContext as MainViewModel; }
		}
		public MainPage ()
		{
			
			var newButton = new ToolbarItem { 
				Text = "New" 
			}; 
			newButton.SetBinding (ToolbarItem.CommandProperty, "NewCommand");

			ToolbarItems.Add (newButton);

			BindingContext = new MainViewModel (DependencyService.Get<INavService> ());;

			Title = "TripLog";
			var itemTemplate = new DataTemplate (typeof( TextCell));
			itemTemplate.SetBinding (TextCell.TextProperty, "Title");
			itemTemplate.SetBinding (TextCell.DetailProperty, "Notes");

			var entries = new ListView { 
				ItemTemplate = itemTemplate 
			};
			entries.SetBinding (ListView.ItemsSourceProperty, "LogEntries");
			entries.ItemTapped += async (sender, e) => {
				var item = (TripLogEntry)e.Item;
				_vm.ViewCommand.Execute(item);
			};
			Content = entries;
		}
		protected override async void OnAppearing ()
		{
			base.OnAppearing ();
			// Initialize MainViewModel
			if (_vm != null)
				await _vm.Init();
		}	
	}
}