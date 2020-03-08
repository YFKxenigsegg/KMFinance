using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace KMFinance.ViewModel
{
	class MainViewModel : ViewModelBase//,DependencyObject
	{
		//public int MyProperty
		//{
		//	get { return (int)GetValue(MyPropertyProperty); }
		//	set { SetValue(MyPropertyProperty, value); }
		//}

		//// Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
		//public static readonly DependencyProperty MyPropertyProperty =
		//	DependencyProperty.Register("MyProperty", typeof(int), typeof(MainViewModel), new PropertyMetadata(0));


		private Page Home;
		private Page Cards;
		private Page Deposits;
		private Page Credits;
		private Page Settings;


		public MainViewModel()
		{
			Home = new Pages.Home();
			Cards = new Pages.Cards();
			Deposits = new Pages.Deposits();
			Credits = new Pages.Credits();
			Settings = new Pages.Settings();
		}
	}
}



