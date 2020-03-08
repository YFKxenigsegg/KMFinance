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
         //
        #region <<!!Перемещение окна!!>>, отображение в полях 

        private void fldName_MouseEnter(object sender, MouseEventArgs e)
        {
            if (fldName.Text == "Input your real name")
            {
                fldName.Text = "";
                fldName.Background = Brushes.Transparent;
                fldName.Foreground = new SolidColorBrush(Color.FromRgb(226, 169, 11));
            }
        }
        private void fldSurname_MouseEnter(object sender, MouseEventArgs e)
        {
            if (fldSurname.Text == "Input your real surname")
            {
                fldSurname.Text = "";
                fldSurname.Background = Brushes.Transparent;
                fldSurname.Foreground = new SolidColorBrush(Color.FromRgb(226, 169, 11));
            }
        }
        private void fldPassportNo_MouseEnter(object sender, MouseEventArgs e)
        {
            if (fldPassportNo.Text == "Input your passport number")
            {
                fldPassportNo.Text = "";
                fldPassportNo.Background = Brushes.Transparent;
                fldPassportNo.Foreground = new SolidColorBrush(Color.FromRgb(226, 169, 11));
            }
        }
        private void fldLoginUp_MouseEnter(object sender, MouseEventArgs e)
        {
            if (fldLoginUp.Text == "Input login")
            {
                fldLoginUp.Text = "";
                fldLoginUp.Background = Brushes.Transparent;
                fldLoginUp.Foreground = new SolidColorBrush(Color.FromRgb(226, 169, 11));
            }
        }

        private void fldPasswordUp_MouseEnter(object sender, MouseEventArgs e)
        {
            if (fldPasswordUp.Text == "Input password")
            {
                fldPasswordUp.Text = "";
                fldPasswordUp.Background = Brushes.Transparent;
                fldPasswordUp.Foreground = new SolidColorBrush(Color.FromRgb(226, 169, 11));
            }
        }
        private void fldPasswordUpSecond_MouseEnter(object sender, MouseEventArgs e)
        {
            if (fldPasswordUpSecond.Text == "Repeat password")
            {
                fldPasswordUpSecond.Text = "";
                fldPasswordUpSecond.Background = Brushes.Transparent;
                fldPasswordUpSecond.Foreground = new SolidColorBrush(Color.FromRgb(226, 169, 11));
            }
        }
        private void fldEmail_MouseEnter(object sender, MouseEventArgs e)
        {
            if (fldEmail.Text == "Input email")
            {
                fldEmail.Text = "";
                fldEmail.Background = Brushes.Transparent;
                fldEmail.Foreground = new SolidColorBrush(Color.FromRgb(226, 169, 11));
            }
        }
        #endregion
    }
}
