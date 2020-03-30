using KMFinance.Model;
using KMFinance.ViewModel;
using System.Windows;

namespace KMFinance.View
{
    public partial class CreditInfoWindow : Window
    {
        public CreditInfoWindow(Credit credit)
        {
            InitializeComponent();
            DataContext= new CreditInfoWindowVM(credit);
        }
    }
}
