using System;

namespace KMFinance.ViewModel
{
	class MainViewModel : ViewModelBase
	{
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
