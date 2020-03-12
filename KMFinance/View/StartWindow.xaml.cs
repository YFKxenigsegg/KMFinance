using KMFinance.ViewModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace KMFinance
{
    public partial class StartWindow : Window
    {
        public StartWindow(InfoClnt infclnt)
        {
            InitializeComponent();
            DataContext = new StartWindowVM(infclnt.PassportNumber);
        }

    }
}
