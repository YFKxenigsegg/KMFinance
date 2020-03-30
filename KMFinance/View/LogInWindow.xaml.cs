using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Xml.Serialization;
using System.Runtime.Serialization.Json;
using Newtonsoft.Json;

namespace KMFinance
{
    public partial class LogInWindow : Window
    {
        SqlConnection connection;
        InfoClnt infoClnt = new InfoClnt();
        public LogInWindow()
        {
            InitializeComponent();
            //getChckBxInfoXml();
            getChckBxInfoJson();
        }

        #region authorization; gets value: passtortNumber, name, login, surname, email; "Remember me" - XML and JSON Serializ/deSerializ
        private async void butLogin_Click(object sender, RoutedEventArgs e)
        {
            string login = fldLogin.Text;
            string password = fldPassword.Text;
            if ((bool)boxCheckRemember.IsChecked) //SOLVVE
            {
                //SerializeXml(login, password);
                SerializeJson(login, password);
            }
            string connecStr = @"Data Source=DESKTOP-RJ9ED1F\SQLEXPRESS;Initial Catalog=ClientsDB;Integrated Security=True";
            connection = new SqlConnection(connecStr);
            await connection.OpenAsync();
            SqlDataReader sqlReader = null;
            SqlCommand command = new SqlCommand("SELECT * FROM [UserClients] WHERE UserLogin = @log AND Password = @pass", connection);
            command.Parameters.Add("@log", SqlDbType.VarChar).Value = login;
            command.Parameters.Add("@pass", SqlDbType.VarChar).Value = password;

            try
            {
                sqlReader = await command.ExecuteReaderAsync();
                while (await sqlReader.ReadAsync())
                {
                    infoClnt.NameClnt = Convert.ToString(sqlReader["Name"]);
                    infoClnt.Surname = Convert.ToString(sqlReader["Surname"]);
                    infoClnt.Email = Convert.ToString(sqlReader["Email"]);
                    infoClnt.PassportNumber = Convert.ToString(sqlReader["PassportNumber"]);
                    infoClnt.Login = login;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString());
            }
            finally
            {
                if (sqlReader != null)
                    sqlReader.Close();
            }
            if (infoClnt.PassportNumber == null)
            {
                MessageBox.Show("Были ввведены некорректные данные.", "Ошибка авторизации");
                boxCheckRemember.IsChecked = false;
                return;
            }
            if (connection != null && connection.State != ConnectionState.Closed)
                connection.Close();

            StartWindow startWin = new StartWindow(infoClnt);
            startWin.Show();
            this.Close();
        }

        #region Serialization, deserialization(XML);
        private void SerializeXml(string log, string pass)
        {
            var dataRemember = new InfoCheckBox { Login = log, Password = pass };
            var xmlFormatter = new XmlSerializer(typeof(InfoCheckBox));
            using (var file = new FileStream("checkBoxXml.xml", FileMode.OpenOrCreate))
                xmlFormatter.Serialize(file, dataRemember);
        }
        private void getChckBxInfoXml()
        {
            XmlDocument xDoc = new XmlDocument();
            if (File.Exists("checkBoxXml.xml"))
            {
                xDoc.Load("checkBoxXml.xml");
                XmlElement xRoot = xDoc.DocumentElement;
                foreach (XmlNode xnode in xRoot)
                {
                    fldLogin.Background = Brushes.Black;
                    fldLogin.Text = xnode.InnerText;
                    fldPassword.Background = Brushes.Black;
                    fldPassword.Text = xnode.InnerText;
                }
            }
        }
        #endregion

        #region Serialization, deserialization(JSON);
        private void SerializeJson(string log, string pass)
        {
            var dataRemember = new InfoCheckBox { Login = log, Password = pass };
            var jsonFormatter = new DataContractJsonSerializer(typeof(InfoCheckBox));
            using (var file = new FileStream("checkBoxJson.json", FileMode.OpenOrCreate))
                jsonFormatter.WriteObject(file, dataRemember);

        }
        private void getChckBxInfoJson()
        {
            if (File.Exists("checkBoxJson.json"))
            {
                var infclnt = JsonConvert.DeserializeObject<InfoCheckBox>(File.ReadAllText("checkBoxJson.json"));
                fldLogin.Foreground = Brushes.Black;
                fldLogin.Text = infclnt.Login;
                fldPassword.Foreground = Brushes.Black;
                fldPassword.Text = infclnt.Password;
            }
            else return;

        }
        #endregion

        #endregion

        private void butSignup_Click(object sender, RoutedEventArgs e)
        {
            SignUpWindow signupWin = new SignUpWindow();
            signupWin.Show();
            this.Close();
        }

        private void fldLogin_MouseEnter(object sender, MouseEventArgs e)
        {
            if (fldLogin.Text == "Input login")
            {
                fldLogin.Text = "";
                fldLogin.Background = Brushes.Transparent;
                fldLogin.Foreground = new SolidColorBrush(Color.FromRgb(226, 169, 11));
            }
        }
        private void fldPassword_MouseEnter(object sender, MouseEventArgs e)
        {
            if (fldPassword.Text == "Input password")
            {
                fldPassword.Text = "";
                fldPassword.Background = Brushes.Transparent;
                fldPassword.Foreground = new SolidColorBrush(Color.FromRgb(226, 169, 11));
            }
        }
    }
}

