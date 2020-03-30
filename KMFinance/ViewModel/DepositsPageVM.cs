using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using KMFinance.Model;
using KMFinance.Pages;
using KMFinance.View;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.Linq;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;

namespace KMFinance.ViewModel
{
    class DepositsPageVM : ViewModelBase, INotifyPropertyChanged
    {
        public string[] typeCurrencyDeposit { get; set; } = { "BYN", "USD", "EUR", "RUB" };      
        public ObservableCollection<Deposit> DepositsFromAPI { get; set; }
        public ICollectionView DepositsCollection { get; set; }
        private Deposit selectedDeposit;
       
        public DepositsPageVM()
        {
            //
            DepositsFromAPI = LoadDepositsFromAPI();
            DepositsCollection = CollectionViewSource.GetDefaultView(DepositsFromAPI);       
        }


        public DepositsPageVM(int amount)
        {
            //Amount = amount;
            //DepositsFromAPI = LoadDepositsFromAPI();
            //DepositsCollection = CollectionViewSource.GetDefaultView(DepositsFromAPI);

        }
        private ObservableCollection<Deposit> LoadDepositsFromAPI()
        {
            var jsomFormatter = new DataContractJsonSerializer(typeof(ObservableCollection<Deposit>));
            WebClient wv = new WebClient();
            wv.Encoding = Encoding.UTF8;
            string responce = wv.DownloadString("https://belarusbank.by/api/deposits_info");
            var depositsFromAPI = JsonConvert.DeserializeObject<ObservableCollection<Deposit>>(responce);  
            return depositsFromAPI;               
        }


        public Deposit DepositInfo
        {
            get { return selectedDeposit; }
            set
            {
                selectedDeposit = value;
                OnPropertyChanged("SelectedDeposit");
                DepositInfoWindow depositInfo = new DepositInfoWindow(selectedDeposit);
                depositInfo.Show();
            }
        }
    

        public new event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }


        #region Filters for display deposits
        private bool Filter(object depos)
        {
            Deposit deposit = depos as Deposit;
            if (!string.IsNullOrEmpty(CurrencyDepositFltr) && !string.IsNullOrEmpty(MinAmountDepositFltr))
                return deposit.MinimumAmountDeposit.Contains(MinAmountDepositFltr) && deposit.CurrencyDeposit.Contains(CurrencyDepositFltr);
            else if (string.IsNullOrEmpty(CurrencyDepositFltr))
                return deposit.MinimumAmountDeposit.Contains(MinAmountDepositFltr);
            else
                return deposit.CurrencyDeposit.Contains(CurrencyDepositFltr);



        }
        private string _minAmountDeposit = string.Empty;
        public string MinAmountDepositFltr
        {
            get { return _minAmountDeposit; }
            set
            {
                _minAmountDeposit = value;
                DepositsCollection.Filter += Filter;
            }
        }
        private string _currencyDeposit = string.Empty;
        public string CurrencyDepositFltr
        {
            get { return _currencyDeposit; }
            set
            {
                _currencyDeposit = value;
                DepositsCollection.Filter += Filter;
            }
        }
        #endregion
    }
}
