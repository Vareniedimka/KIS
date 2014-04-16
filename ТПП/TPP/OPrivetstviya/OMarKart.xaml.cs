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
using ClassBD;
using TPPDAO;

namespace Web
{
    /// <summary>
    /// Логика взаимодействия для OMarKart.xaml
    /// </summary>
    public partial class OMarKart : Window
    {
        public OMarKart()
        {
            InitializeComponent();
        }

        private void btAdd_Click(object sender, RoutedEventArgs e)
        {
            AddMarKart dd = new AddMarKart();
            dd.ShowDialog();
            btUpdate_Click(sender, e);
        }

        private void btUpdate_Click(object sender, RoutedEventArgs e)
        {
            dgMKarta.ItemsSource = MKDA.GetAll();
        }

        private void btEdit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                AddMarKart win2 = new AddMarKart((dgMKarta.SelectedItem as MarshrytKarta));
                win2.ShowDialog();
                btUpdate_Click(sender, e);
            }
            catch
            {
                MessageBox.Show("Выберите элемент");
            }
            btUpdate_Click(sender, e);
        }

        private void btDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MKDA.Delete((dgMKarta.SelectedItem as MarshrytKarta).IdMarshrut);
            }
            catch
            {
                MessageBox.Show("Выберите элемент");
            }
            btUpdate_Click(sender, e);
        }

        private void btBack_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
