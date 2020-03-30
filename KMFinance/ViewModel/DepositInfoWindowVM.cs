using KMFinance.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace KMFinance.ViewModel
{
    class DepositInfoWindowVM
    {
        Deposit deposit;
        public DepositInfoWindowVM(Deposit dpst)
        {
            deposit = dpst;
        }

        public string NameDeposit { get { return deposit.NameDeposit; } }
        public string CurrencyDeposit { get { return deposit.CurrencyDeposit; } }
        public string PersentDeposit { get { return deposit.PersentDeposit + " %"; } }
        public string MinimumAmountDeposit { get { return deposit.MinimumAmountDeposit + " " + deposit.CurrencyDeposit; } }
        public string TermTextDeposit { get { return deposit.TermTextDeposit; } }
        public string CapitalDeposit
        {
            get
            {
                switch (deposit.CapitalDeposit)
                {
                    case "1":
                        return "по оконачании срока вклада";
                    case "2":
                        return "ежемесячно (на первое число каждого месяца)";
                    case "3":
                        return "ежеквартально";
                    case "4":
                        return "каждые полгода";
                    case "5":
                        return "ежегодно";
                    case "6":
                        return "ежемесячно (по истечении месяца хранения)";
                    case "7":
                        return "ежемесячно (по истечении месяца хранения)";
                    case "8":
                        return "ежемесячное перечисление на банковскую карту";
                }
                return "";
            }
        }
        
        public string AdditionalInformationDeposit { get { return deposit.AdditionalInformationDeposit.Replace("<br/>", ""); } }
    }
}