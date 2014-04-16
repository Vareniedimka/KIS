using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Data.SqlClient;
using System.Configuration;
using GLP;

namespace Win
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class ConnectWin : Window
    {
        public ConnectWin()
        {
            InitializeComponent();
        }

        private void btnConnect_Click(object sender, RoutedEventArgs e)
        {
            string s = "";//хранит временную строку подключения
            try
            {
                s = "Data Source=" + tbServer.Text + "; Initial Catalog=" + tbBD.Text + ";";
                if (!(bool)cbAut.IsChecked)
                {
                    s += "Integrated Security=true";


                }
                else s += "Integrated Security=false; User ID=" + tbUser.Text + ";Password=" + tbPass.Text;
                SqlConnection sql = new SqlConnection(s);
                sql.Open();
                sql.Close();
                Connect.ConnectSave(s);
                Close();

            }
            catch
            {
                MessageBox.Show("Не удалось подключится");
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void cbAut_Click(object sender, RoutedEventArgs e)
        {

            if ((bool)cbAut.IsChecked)
            {
                tbPass.IsEnabled = tbUser.IsEnabled = true;
            }
            else
            {
                tbPass.IsEnabled = tbUser.IsEnabled = false;
            }
        }
    }
}
