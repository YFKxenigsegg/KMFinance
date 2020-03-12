using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace KMFinance.ViewModel
{
	class StartWindowVM : ViewModelBase
	{
		SqlConnection connection;
		InfoClnt infoClnt = new InfoClnt();
		private Page Home;
		private Page Cards;
		private Page Deposits;
		private Page Credits;
		private Page Settings;

		private Page _currentPage;
		public Page CurrentPage { get { return _currentPage; } set { _currentPage = value; RaisePropertyChanged(() => CurrentPage); } }

		private double _frameOpacity;
		public double FrameOpacity { get { return _frameOpacity; } set { _frameOpacity = value; } }

		public StartWindowVM(string PassportNumber)
		{
			var infoClnt = getInfo(PassportNumber);
			Home = new Pages.Home(infoClnt.Amount, infoClnt.CardNo);
			Cards = new Pages.Cards(infoClnt.CardNo, infoClnt.NameClnt, infoClnt.Surname);
			Deposits = new Pages.Deposits();
			Credits = new Pages.Credits();
			Settings = new Pages.Settings();
			

			FrameOpacity = 1;
			CurrentPage = Home;
		}
		public ICommand butMenuHome_Click
		{
			get
			{
				return new RelayCommand(() => SlowOpacity(Home));
			}
		}
		public ICommand butMenuCards_Click
		{
			get
			{
				return new RelayCommand(() => SlowOpacity(Cards));
			}
		}
		public ICommand butMenuDeposits_Click
		{
			get
			{
				return new RelayCommand(() => SlowOpacity(Deposits));
			}
		}
		public ICommand butMenuCredits_Click
		{
			get
			{
				return new RelayCommand(() => SlowOpacity(Credits));
			}
		}
		public ICommand butMenuSettings_Click
		{
			get
			{
				return new RelayCommand(() => SlowOpacity(Settings));
			}
		}
		private async void SlowOpacity(Page page)
		{
			await Task.Factory.StartNew(() =>
			{
				for (double i = 1.0; i > 0.0; i -= 0.1)
				{
					FrameOpacity = i;
					Thread.Sleep(30);
				}
				CurrentPage = page;
				for (double i = 0.0; i < 1.1; i += 0.1)
				{
					FrameOpacity = i;
					Thread.Sleep(30);
				}
			});
		}


		private InfoClnt getInfo(string psrtNo)
		{
			string connecStr = @"Data Source=DESKTOP-RJ9ED1F\SQLEXPRESS;Initial Catalog=BankClientsDB;Integrated Security=True";
			connection = new SqlConnection(connecStr);
			connection.Open();
			SqlDataReader sqlReader = null;
			SqlCommand command = new SqlCommand("SELECT * FROM [Clients] WHERE PassportNumber = @psrtNofld", connection);
			command.Parameters.Add("@psrtNofld", SqlDbType.VarChar).Value = psrtNo;

			try
			{
				sqlReader = command.ExecuteReader();
				while (sqlReader.Read())
				{
					infoClnt.Amount = Convert.ToInt32(sqlReader["Amount"]);
					infoClnt.ScoreNumber = Convert.ToString(sqlReader["ScoreNumber"]);
					infoClnt.CardNo = Convert.ToString(sqlReader["CardNo"]);
					infoClnt.Expire = Convert.ToString(sqlReader["Expire"]);
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message.ToString(), ex.Source.ToString());
			}
			finally
			{
				if (sqlReader != null)
					sqlReader.Close();
			}
			if (connection != null && connection.State != ConnectionState.Closed)
				connection.Close();


			connecStr = @"Data Source=DESKTOP-RJ9ED1F\SQLEXPRESS;Initial Catalog=ClientsDB;Integrated Security=True";
			connection = new SqlConnection(connecStr);
			connection.Open();
			sqlReader = null;
			command = new SqlCommand("SELECT * FROM [UserClients] WHERE PassportNumber = @psrtNofld", connection);
			command.Parameters.Add("@psrtNofld", SqlDbType.VarChar).Value = psrtNo;

			try
			{
				sqlReader = command.ExecuteReader();
				while (sqlReader.Read())
				{
					infoClnt.NameClnt = Convert.ToString(sqlReader["Name"]);
					infoClnt.Surname = Convert.ToString(sqlReader["Surname"]);
					infoClnt.Email = Convert.ToString(sqlReader["Email"]);
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message.ToString(), ex.Source.ToString());
			}
			finally
			{
				if (sqlReader != null)
					sqlReader.Close();
			}
			if (connection != null && connection.State != ConnectionState.Closed)
				connection.Close();

			return infoClnt;
		}
	}
}



