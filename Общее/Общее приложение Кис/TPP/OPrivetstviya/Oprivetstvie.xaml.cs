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
using TPPDAO;

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
            //получаем параметры запуска
            var args = Environment.GetCommandLineArgs();
            //Вводим параметры подключения
            Connect.setConnectInfo(args[1], args[2], args[3], args[4]);
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

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("LoginApp.exe");
            Close();
            /* ConnectWin conn = new ConnectWin();
             conn.ShowDialog();*/
        }
    }
}
