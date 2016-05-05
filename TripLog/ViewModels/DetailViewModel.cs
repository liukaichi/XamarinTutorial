using System;
using System.Threading.Tasks;

namespace TripLog
{
	public class DetailViewModel : BaseViewModel<TripLogEntry>
	{
		public DetailViewModel () : base()
		{
			
		}

		public override async Task Init (TripLogEntry logEntry)
		{
			Entry = logEntry;
		}

		TripLogEntry _entry;
		public TripLogEntry Entry
		{
			get { return _entry; }
			set {
				_entry = value;
				OnPropertyChanged ();
			}
		}
	}
}

