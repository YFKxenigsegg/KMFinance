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
using System.Windows.Shapes;

namespace KMFinance
{
    public partial class SignUpWindow : Window
    {
        public SignUpWindow()
        {
            InitializeComponent();
            DataContext = new SUWinValidationRule();
        }
        
        private void butSignup_Click(object sender, RoutedEventArgs e)
        {
            var user = new UserClient();
            using (var db = new DB())
            {
                try
                {
                    user = new UserClient()
                    {
                        Name = fldName.Text,
                        Surname = fldSurname.Text,
                        PassportNumber = fldPassportNo.Text,
                        UserLogin = fldLoginUp.Text,
                        Password = fldPasswordUp.Text,
                        Email = fldEmail.Text,
                        RegistrationDate = DateTime.Now.ToString()

                    };
                }
                catch (ArgumentNullException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                db.UserClients.Add(user);
                db.SaveChanges();

                LogInWindow loginWin = new LogInWindow();
                loginWin.Show();
                this.Close();
            }
        }
    }
}
