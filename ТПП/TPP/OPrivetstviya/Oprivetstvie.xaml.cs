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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SqlClient;

namespace Web
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class Oprivetstvie : Window
    {
        public Oprivetstvie()
        {

            InitializeComponent();
            connect();
        }

        private static void connect()
        {
            try
            {
                //DK13-06\SQLEXPRESS
                string DS = "DK13-05\\SQLEXPRESS"; //Заполнить для базы
                string IC = "AvtoKran";//имя базы
                string IS = "true";
                string user = "proverka";
                //s = "Data Source=" + tbServer.Text + "; Initial Catalog=" + tbBD.Text + ";";
                string s = "Data Source=" + DS + "; Initial Catalog=" + IC + ";Integrated Security=" + IS + ";User ID=" + user + ";Password=" + "1" ;
                SqlConnection sql = new SqlConnection(s);
                sql.Open();
                sql.Close(); //Для проверки соеденения
                TPPDAO.Connect.ConnectSave(s);
            }
            catch 
            {
                MessageBox.Show("Соеденение с базой не удалось");
            }
        }

        private void btnDse_Click(object sender, RoutedEventArgs e)
        {
            Odse win = new Odse();
            win.Show();
        }

        private void btnNepPrim_Click(object sender, RoutedEventArgs e)
        {
            ONepPrim win = new ONepPrim();
            win.ShowDialog();
        }

        private void btnPolPrim_Click(object sender, RoutedEventArgs e)
        {
            OPolPrim win = new OPolPrim();
            win.ShowDialog();
        }
    }
}
