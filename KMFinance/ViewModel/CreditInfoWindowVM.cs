using KMFinance.Model;

namespace KMFinance.ViewModel
{
    class CreditInfoWindowVM
    {
        Credit credit;
        public CreditInfoWindowVM(Credit crdt) //crdt - выбранный item, который я передаю во ViewModel
        {
            credit = crdt; //здесь будет null, тк уже "выбранный" до изменения поля 'Тип кредита' элемент не соответствует с новым содержанием поля 'Тип кредита' 
        }

        public string NameCredit { get { return credit.NameCredit; } }  //и здесь, соотвественно, обращение к null. Исключение: System.NullReferenceException: "Ссылка на объект не указывает на экземпляр объекта."
        public string TypeCredit { get { return credit.TypeCredit; } }     //... 
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
