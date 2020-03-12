using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace KMFinance.ViewModel
{
    class HomePageVM : ViewModelBase
    {
        public int Amount { get; set; }
        public string CardNo { get; set; }
        public HomePageVM(int amount, string cardNo)
        {
            Amount = amount;
            CardNo = cardNo;
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
                return Amount.ToString() + "$";
            }
        }
        public string LblGetCardNo
        {
            get
            {
                return CardNo;
            }
        }
    }
}
