using System;

using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace TripLog.Views
{
	public class DetailPage : ContentPage
	{
		DetailViewModel _vm {
			get { return BindingContext as DetailViewModel; }
		}

		readonly Map _map;

		public DetailPage ()
		{
			BindingContextChanged += (sender, args) =>
			{
				if (_vm == null) return;
				_vm.PropertyChanged += (s, e) => {
					if (e.PropertyName == "Entry")
						UpdateMap ();
				};
			};
			BindingContext = new DetailViewModel (DependencyService.Get<INavService> ());
			Title = "Entry Details";
			var mainLayout = new Grid {
				RowDefinitions = {
					new RowDefinition {
						Height = new GridLength (4, GridUnitType.Star)
					},
					new RowDefinition {
						Height = GridLength.Auto
					},
					new RowDefinition {
						Height = new GridLength (1, GridUnitType.Star)
					}
				}
			};
			_map = new Map ();

			var title = new Label {
				HorizontalOptions = LayoutOptions.Center
			};
			title.SetBinding (Label.TextProperty, "Entry.Title");

			var date = new Label {
				HorizontalOptions = LayoutOptions.Center
			};
			date.SetBinding (Label.TextProperty, "Entry.Date", stringFormat: "{0:M}");

			var rating = new Label {
				HorizontalOptions = LayoutOptions.Center
			};
			rating.SetBinding (Label.TextProperty, "Entry.Rating", stringFormat: "{0} star rating");

			var notes = new Label {
				HorizontalOptions = LayoutOptions.Center
			};
			notes.SetBinding (Label.TextProperty, "Entry.Notes");

			var details = new StackLayout {
				Padding = 10,
				Children = {
					title, date, rating, notes
				}
			};
			var detailsBg = new BoxView {
				BackgroundColor = Color.White,
				Opacity = .8
			};
			mainLayout.Children.Add (_map);
			mainLayout.Children.Add (detailsBg, 0, 1);
			mainLayout.Children.Add (details, 0, 1);
			Grid.SetRowSpan (_map, 3);
			Content = mainLayout;

		}
		void UpdateMap ()
		{
			if (_vm.Entry == null)
				return;
			// Center the map around the log entry's location
			_map.MoveToRegion (MapSpan.FromCenterAndRadius (
				new Position (_vm.Entry.Latitude,
					_vm.Entry.Longitude),
				Distance.FromMiles (.5)
			));
			// Place a pin on the map for the log entry's location
			_map.Pins.Add (new Pin {
				Type = PinType.Place,
				Label = _vm.Entry.Title,
				Position = new Position (_vm.Entry.Latitude,
					_vm.Entry.Longitude)
			});
		}
	}

}


