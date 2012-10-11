using System.Windows.Input;
using Jobsearch.Model;
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
        readonly Database _db = new Database();

        public MainWindow()
        {
            InitializeComponent();

            ConnectDb();
        }

        private void ConnectDb()
        {
            //_grid.DataContext = _db.ClientJobs;
            _grid.DataContext = _db.Clients;

        }

        private void RowRightButtonUp(object sender, MouseButtonEventArgs e)
        {
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void OnNewRoleClick(object sender, RoutedEventArgs e)
        {
            var newRoleWnd = new NewRoleWindow { DataContext = _db };

            newRoleWnd.ShowDialog();
        }
    }
}
