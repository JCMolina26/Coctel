using Coctel.ViewModel.Helpers;
using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Coctel
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void ExitApp_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Conexion_Click(object sender, RoutedEventArgs e)
        {
            testing.Text = "Getting Connection ...";
            SqlConnection conn = DatabaseVM.GetDBConnection();
            try
            {
                testing.Text = "Openning Connection ...";
                                conn.Open();
                testing.Text = "Connection successful!";
                testing.Foreground = Brushes.Green;
            }
            catch (Exception)
            {
                testing.Text = "Pasaron cosas";
                testing.Foreground = Brushes.Red;
            }
            Console.Read();
        }
    }
}
