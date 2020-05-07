using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using ServiceStack.Text;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Newtonsoft.Json.Linq;

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
		public double FrameOpacity { get; set; }
		public StartWindowVM()
		{
			//
			Deposits = new Pages.Deposits();
			Credits = new Pages.Credits();
			Settings = new Pages.Settings();
			FrameOpacity = 1;
			CurrentPage = Deposits;
		}

		public StartWindowVM(string PassportNumber)
		{
			var infoClnt = getInfo(PassportNumber);
			Home = new Pages.Home(infoClnt);
			Cards = new Pages.Cards(infoClnt.CardNo, infoClnt.NameClnt, infoClnt.Surname);
			Deposits = new Pages.Deposits();
			Credits = new Pages.Credits();
			Settings = new Pages.Settings();

			FrameOpacity = 1;
			CurrentPage = Home;
		}

		#region ICommand buttons menu
		public ICommand butMenuHome_Click
		{
			get
			{
				return new RelayCommand(() => ChangeCurrentPage(Home));
			}
		}
		public ICommand butMenuCards_Click
		{
			get
			{
				return new RelayCommand(() => ChangeCurrentPage(Cards));
			}
		}
		public ICommand butMenuDeposits_Click
		{
			get
			{
				return new RelayCommand(() => ChangeCurrentPage(Deposits));
			}
		}
		public ICommand butMenuCredits_Click
		{
			get
			{
				return new RelayCommand(() => ChangeCurrentPage(Credits));
			}
		}
		public ICommand butMenuSettings_Click
		{
			get
			{
				return new RelayCommand(() => ChangeCurrentPage(Settings));
			}
		}
		private  void ChangeCurrentPage(Page page)
		{
				CurrentPage = page;
		}
        #endregion

        #region request information about client from database
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
		#endregion

		#region currency
		#region set/get purchase/sale USD
		public string setPurchaseDollar
		{
			get
			{
				return GetPurchaseDollar();
			}
		}
		private string GetPurchaseDollar()
		{
			WebClient wv = new WebClient();
			//https://belarusbank.by/api/kursExchange?city=%D0%9C%D0%B8%D0%BD%D1%81%D0%BA
			string responce = wv.DownloadString("https://belarusbank.by/api/kursExchange?city=Минск");
			return Regex.Match(responce, @"USD_in"":""([0-9]+\.[0-9]+)").Groups[1].Value;
		}
		
		public string setSaleDollar
		{
			get
			{
				return GetSaleDollar();
			}
		}
		private string GetSaleDollar()
		{
			WebClient wv = new WebClient();
			string responce = wv.DownloadString("https://belarusbank.by/api/kursExchange?city=%D0%9C%D0%B8%D0%BD%D1%81%D0%BA");
			return Regex.Match(responce, @"USD_out"":""([0-9]+\.[0-9]+)").Groups[1].Value;
		}
		#endregion

		#region set/get purchase/sale EUR
		public string setPurchaseEuro
		{
			get
			{
				return GetPurchaseEuro();
			}
		}
		private string GetPurchaseEuro()
		{
			WebClient wv = new WebClient();
			string responce = wv.DownloadString("https://belarusbank.by/api/kursExchange?city=%D0%9C%D0%B8%D0%BD%D1%81%D0%BA");
			return Regex.Match(responce, @"EUR_in"":""([0-9]+\.[0-9]+)").Groups[1].Value;
		}

		public string setSaleEuro
		{
			get
			{
				return GetSaleEuro();
			}
		}
		private string GetSaleEuro()
		{
			WebClient wv = new WebClient();
			string responce = wv.DownloadString("https://belarusbank.by/api/kursExchange?city=%D0%9C%D0%B8%D0%BD%D1%81%D0%BA");
			return Regex.Match(responce, @"EUR_out"":""([0-9]+\.[0-9]+)").Groups[1].Value;
		}
		#endregion

		#region set/get purchase/sale RUB
		public string setPurchaseRUB
		{
			get
			{
				return GetPurchaseRUB();
			}
		}
		private string GetPurchaseRUB()
		{
			WebClient wv = new WebClient();
			string responce = wv.DownloadString("https://belarusbank.by/api/kursExchange?city=%D0%9C%D0%B8%D0%BD%D1%81%D0%BA");
			return Regex.Match(responce, @"RUB_in"":""([0-9]+\.[0-9]+)").Groups[1].Value;
		}

		public string setSaleRUB
		{
			get
			{
				return GetSaleRUB();
			}
		}
		private string GetSaleRUB()
		{
			WebClient wv = new WebClient();
			string responce = wv.DownloadString("https://belarusbank.by/api/kursExchange?city=%D0%9C%D0%B8%D0%BD%D1%81%D0%BA");
			return Regex.Match(responce, @"RUB_out"":""([0-9]+\.[0-9]+)").Groups[1].Value;
		}
		#endregion

		#region set/get purchase/sale GBP
		public string setPurchaseGBP
		{
			get
			{
				return GetPurchaseGBP();
			}
		}
		private string GetPurchaseGBP()
		{
			WebClient wv = new WebClient();
			string responce = wv.DownloadString("https://belarusbank.by/api/kursExchange?city=%D0%9C%D0%B8%D0%BD%D1%81%D0%BA");
			return Regex.Match(responce, @"GBP_in"":""([0-9]+\.[0-9]+)").Groups[1].Value;
		}

		public string setSaleGBP
		{
			get
			{
				return GetSaleGBP();
			}
		}
		private string GetSaleGBP()
		{
			WebClient wv = new WebClient();
			string responce = wv.DownloadString("https://belarusbank.by/api/kursExchange?city=%D0%9C%D0%B8%D0%BD%D1%81%D0%BA");
			return Regex.Match(responce, @"GBP_out"":""([0-9]+\.[0-9]+)").Groups[1].Value;
		}
        #endregion
        #endregion
    }
}



