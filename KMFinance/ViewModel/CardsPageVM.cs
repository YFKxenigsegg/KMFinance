using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KMFinance.ViewModel
{
    class CardsPageVM
    {
        public string CardNo { get; set; }
        public string NameClnt { get; set; }
        public string Surname { get; set; }

        public CardsPageVM(string cardNo, string name, string surname)
        {
            CardNo = cardNo;
            NameClnt = name;
            Surname = surname;
        }
        public string LblGetNameSurnameCard
        {
            get
            {
                return NameClnt + " " + Surname;
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
