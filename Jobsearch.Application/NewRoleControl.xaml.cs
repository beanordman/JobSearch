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
using Jobsearch.Model;

namespace Jobsearch.Application
{
    /// <summary>
    /// Interaction logic for NewRoleControl.xaml
    /// </summary>
    public partial class NewRoleControl : UserControl
    {
        public NewRoleControl()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded_1(object sender, RoutedEventArgs e)
        {
            //ItemsSource="{Binding Path=Clients}"
            //DisplayMemberPath="{Binding Path=Name}"

            //var db = DataContext as Database;
            //if (db == null)
            //    return;

            //_clientsCombo.ItemsSource = db.Clients.DefaultView;
        }
    }
}
