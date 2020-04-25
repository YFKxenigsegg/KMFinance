using KMFinance.ViewModel;
using System;
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
    public partial class Home : Page
    {
        InfoClnt client;
        public Home()
        {
            //
            InitializeComponent();
        }
        public Home(InfoClnt clnt)
        {
            InitializeComponent();
            client = clnt;
            DataContext = new HomePageVM(clnt);
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (int.Parse(something.Text) <= client.Amount)
            {
                client.Amount -= int.Parse(something.Text);
                MessageBox.Show($"Сумма в {something.Text}" + " обрабытввается для отправки.");
                lblAmount.Content = client.Amount;
            }
            else MessageBox.Show("Ошибка. Некорректная сумма перевода или недостаточно средств.");
        }
    }
}
