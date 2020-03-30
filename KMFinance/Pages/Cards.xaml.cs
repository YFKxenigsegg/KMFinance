using System;
using KMFinance.ViewModel;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace KMFinance.Pages
{
    public partial class Cards : Page
    {
        public Cards()
        {
            //
            InitializeComponent();
        }
        public Cards(string cardNo, string name, string surname)
        {
            InitializeComponent();
            DataContext = new CardsPageVM(cardNo, name, surname);
        }
    }
}
