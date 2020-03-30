using GalaSoft.MvvmLight;
using KMFinance.Model;
using KMFinance.View;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Windows.Data;

namespace KMFinance.ViewModel
{
    class CreditsPageVM : ViewModelBase, INotifyPropertyChanged
    {
        public string[] typeTypeCredit { get; set; } = { "потребительский", "на образование", "на недвижимость", "автокредитование" };
        public ObservableCollection<Credit> CreditsFromAPI { get; set; }
        public ICollectionView CreditsCollection { get; set; }
        private Credit selectedCredit;
        
        public CreditsPageVM()
        {
        
            CreditsFromAPI = LoadCreditsFromAPI();
            CreditsCollection = CollectionViewSource.GetDefaultView(CreditsFromAPI);
        }

        
        private ObservableCollection<Credit> LoadCreditsFromAPI()
        {
            var jsomFormatter = new DataContractJsonSerializer(typeof(ObservableCollection<Credit>));
            WebClient wv = new WebClient();
            wv.Encoding = Encoding.UTF8;
            string responce = wv.DownloadString("https://belarusbank.by/api/kredits_info");
            var creditsFromAPI = JsonConvert.DeserializeObject<ObservableCollection<Credit>>(responce);
            return creditsFromAPI;
        }


        public Credit CreditInfo
        {
            get { return selectedCredit; }
            set
            {
                selectedCredit = value;
                OnPropertyChanged("SelectedCredit");
                CreditInfoWindow creditInfo = new CreditInfoWindow(selectedCredit);
                creditInfo.Show();
            }
        }


        public new event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }


        #region Filter for display credits
        private bool Filter(object depos)
        {
            Credit credit = depos as Credit;
            if (!string.IsNullOrEmpty(TypeCreditFltr))
                return credit.TypeCredit.Contains(TypeCreditFltr);
            else return false;

        }

        private string _typeCredit = string.Empty;
        public string TypeCreditFltr
        {
            get { return _typeCredit; }
            set
            {
                _typeCredit = value;
                CreditsCollection.Filter += Filter;
            }
        }
        #endregion
    }
}
