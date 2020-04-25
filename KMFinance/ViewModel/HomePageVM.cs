using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace KMFinance.ViewModel
{
    class HomePageVM : ViewModelBase    
    {
        InfoClnt client;
        public HomePageVM()
        {
            //
        }
        public HomePageVM(InfoClnt clnt)
        {
            client = clnt;
        }

        public string LblGetDateNow
        {
            get
            {
                return DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString();
            }
        }
        public string LblGetAmout
        {
            get
            {
                return client.Amount.ToString();
            }
            set { }
        }
        public string LblGetCardNo
        {
            get
            {
                return  "..." + client.CardNo.Substring(client.CardNo.Length-4);
            }
        }
    }
}
