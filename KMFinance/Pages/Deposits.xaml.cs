using KMFinance.Model;
using KMFinance.ViewModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace KMFinance.Pages
{
    public partial class Deposits : Page
    {
        public Deposits()
        {
            //
            InitializeComponent();
            DataContext = new DepositsPageVM();

        }
        public Deposits(int amount)
        {
            InitializeComponent();
            DataContext = new DepositsPageVM(amount);
        }
    }
}
