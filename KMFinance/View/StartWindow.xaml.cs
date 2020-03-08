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
        SqlConnection connection;
        InfoClnt infoClnt = new InfoClnt();
        public StartWindow(InfoClnt infclnt)
        {
            InitializeComponent();
            getInfo(infclnt.PassportNumber);
            //DataContext
        }
        private InfoClnt getInfo(string psrtNo)
        {
            string connecStr = @"Data Source=DESKTOP-RJ9ED1F\SQLEXPRESS;Initial Catalog=BankClientsDB;Integrated Security=True";
            connection = new SqlConnection(connecStr);
            connection.Open();
            SqlDataReader sqlReader = null;
            SqlCommand command = new SqlCommand("SELECT * FROM [Clients] WHERE PassportNumber = @psrtNofld", connection);
            command.Parameters.Add("@psrtNofld", SqlDbType.VarChar).Value = psrtNo;

            try
            {
                sqlReader = command.ExecuteReader();
                while (sqlReader.Read())
                {
                    infoClnt.Amount = Convert.ToInt32(sqlReader["Amount"]);
                    infoClnt.ScoreNumber = Convert.ToString(sqlReader["ScoreNumber"]);
                    infoClnt.CardNo = Convert.ToString(sqlReader["CardNo"]);
                    infoClnt.Expire = Convert.ToString(sqlReader["Expire"]);
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
            if (connection != null && connection.State != ConnectionState.Closed)
                connection.Close();
            return infoClnt;
        }
    }
}
