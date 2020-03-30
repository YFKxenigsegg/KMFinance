using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;

namespace KMFinance.Model
{
    [DataContract]
    public class Deposit : INotifyPropertyChanged
    {
        [DataMember(Name = "vklad_id")]
        public string IdDeposit { get; set; }
        [DataMember(Name = "vklad_name")]
        public string NameDeposit { get; set; }
        [DataMember(Name = "vklad_val")]
        public string CurrencyDeposit { get; set; }
        [DataMember(Name = "vklad_procent")]
        public string PersentDeposit { get; set; }
        [DataMember(Name = "vklad_procent_formula")]
        public string PrecentFormulaDeposit { get; set; }
        [DataMember(Name = "vklad_kapital")]
        public string CapitalDeposit { get; set; }
        [DataMember(Name = "vklad_minimal")]
        public string MinimumAmountDeposit { get; set; }
        [DataMember(Name = "vklad_srok")]
        public string TermDeposit { get; set; }
        [DataMember(Name = "vklad_srok_type")]
        public string TermTypeDeposit { get; set; }
        [DataMember(Name = "vklad_srok_text")]
        public string TermTextDeposit { get; set; }
        [DataMember(Name = "vklad_dop_dohod")]
        public string PremiumInterestDeposit { get; set; }
        [DataMember(Name = "vklad_info")]
        public string AdditionalInformationDeposit { get; set; }
        [DataMember(Name = "vklad_info_dohod")]
        public string InterestPaymentInformationDeposit { get; set; }
        [DataMember(Name = "vklad_info_preimuchestvo")]
        public string AdvantagesDeposit { get; set; }


        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
