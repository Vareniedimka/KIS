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
using GLP;
using System.Collections;
using System.Data.SqlClient;
using System.Data;

namespace Win
{
    /// <summary>
    /// Логика взаимодействия для WindowZapros.xaml
    /// </summary>
    public partial class WindowZapros : Window
    {
        
        public WindowZapros()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            string s = "exec rasKof " + tbText.Text;
            using (var conn = Connect.GetConnect())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    try
                    {
                        using (SqlDataAdapter adapter = new SqlDataAdapter(s, conn))
                        {
                            DataTable t = new DataTable();
                            adapter.Fill(t);
                            dg.ItemsSource = t.DefaultView;
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Не удалось выполнить запрос"); return;
                    }
                }
            }
            button1.Visibility = Visibility.Hidden;
            tbText.Visibility = Visibility.Hidden;
            l.Visibility = Visibility.Hidden;
            dg.Visibility = Visibility.Visible;

            this.ResizeMode = ResizeMode.CanResize;
            this.Width = 800;
            this.Height = 480;            
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
