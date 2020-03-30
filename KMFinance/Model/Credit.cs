using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;

namespace KMFinance.Model
{
    [DataContract]
    public class Credit : INotifyPropertyChanged
    {
        [DataMember(Name = "inf_id")]
        public string IdCredit { get; set; }
        [DataMember(Name = "kredit_type")]
        public string TypeCredit { get; set; }
        [DataMember(Name = "group_name_ru")]
        public string NameCredit { get; set; }
        [DataMember(Name = "val_key")]
        public string CurrencyCredit { get; set; }
        [DataMember(Name = "usl_name")]
        public string InterestRateConditionCredit { get; set; }
        [DataMember(Name = "inf_time")]
        public string TermCredit { get; set; }
        [DataMember(Name = "inf_proc_formula")]
        public string IterestRateCredit { get; set; }
        [DataMember(Name = "platName")]
        public string InterestPaymentMethodCredit { get; set; }
        [DataMember(Name = "inf_koe")]
        public string SolvencyRatioCredit
        { get; set; }
        [DataMember(Name = "inf_odolg")]
        public string DeferredPaymentOnPrincipalCredit { get; set; }
        [DataMember(Name = "inf_oproc")]
        public string InterestDeferralCredit { get; set; }
        [DataMember(Name = "inf_max_size")]
        public string MaximumLoanAmountCredit { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
