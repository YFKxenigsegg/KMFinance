using System;
using MySql.Data.MySqlClient;
using System.Data.Entity;


namespace KMFinance
{
    class DB : DbContext
    {
        MySqlConnection connection = new MySqlConnection(@"Data Source=DESKTOP-RJ9ED1F\SQLEXPRESS;Initial Catalog=ClientsDB;Integrated Security=True");
        public DB() : base("DBConnectonStringUS")
        {

        }
        public DbSet<UserClient> UserClients { get; set; }
        public void openConnection()
        {
            if (connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }
        }

        public void closeConnection()
        {
            if (connection.State == System.Data.ConnectionState.Open)
            {
                connection.Close();
            }
        }
        public MySqlConnection getConnection()
        {
            return connection;
        }
    }
}
