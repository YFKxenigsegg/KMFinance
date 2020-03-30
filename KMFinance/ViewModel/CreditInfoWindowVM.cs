using KMFinance.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KMFinance.ViewModel
{
    class CreditInfoWindowVM
    {
        Credit credit;
        public CreditInfoWindowVM(Credit crdt)
        {
            credit = crdt;
        }

        public string NameCredit { get { return credit.NameCredit; } }
        public string TypeCredit { get { return credit.TypeCredit; } }
        public string CurrencyCredit { get { return credit.CurrencyCredit; } }
        public string InterestRateConditionCredit { get { return credit.InterestRateConditionCredit; } }
        public string TermCredit { get { return credit.TermCredit; } }
        public string IterestRateCredit { get { return credit.IterestRateCredit + " " + "%"; } }
        public string InterestPaymentMethodCredit { get { return credit.InterestPaymentMethodCredit; } }
        public string MaximumLoanAmountCredit
        {
            get
            {
                if (credit.MaximumLoanAmountCredit == "0") return "Не ограничен";
                return credit.MaximumLoanAmountCredit;
            }
        }
    }
}
