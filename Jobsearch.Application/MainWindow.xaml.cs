using MySql.Data.MySqlClient;
using System.Data;
using System.Windows;

namespace Jobsearch.Application
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();

            ConnectDb();
        }

        private void ConnectDb()
        {
            const string myConString =
                "User ID=root;Password=root321;Host=localhost;Port=3306;Database=job_search;";
            //Direct=true;Protocol=TCP;Compress=false;Pooling=true;Min Pool Size=0;Max Pool Size=100;Connection Lifetime=0;";

            const string sql = "SELECT Name, Contact, Phone, Email, Details, Url FROM Client ORDER BY Name";

            var connection = new MySqlConnection(myConString);
            using (var cmd = new MySqlCommand(sql, connection))
            {
                var dt = new DataTable();

                var da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
                _grid.DataContext = dt;
            }
            connection.Close();

        }
    }
}
