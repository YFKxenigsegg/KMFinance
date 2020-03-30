using KMFinance.ViewModel;
using System.Windows;

namespace KMFinance
{
    public partial class StartWindow : Window
    {
        public StartWindow()
        {
            //
            InitializeComponent();
            DataContext = new StartWindowVM();
        }
        public StartWindow(InfoClnt infclnt)
        {
            InitializeComponent();
            DataContext = new StartWindowVM(infclnt.PassportNumber);
        }

    }
}
