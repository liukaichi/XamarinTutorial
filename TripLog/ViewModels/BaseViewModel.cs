﻿using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace TripLog
{
	public abstract class BaseViewModel : INotifyPropertyChanged
	{
		protected BaseViewModel ()
		{ 
		
		}
		public event PropertyChangedEventHandler PropertyChanged;
		protected virtual void OnPropertyChanged( [CallerMemberName] string	propertyName = null)
		{
			var handler = PropertyChanged;
			if (handler != null)
				handler(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}

