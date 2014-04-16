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
    /// Логика взаимодействия для ONepPrim.xaml
    /// </summary>
    public partial class ONepPrim : Window
    {
        public ONepPrim()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                AddNepPrim aa = new AddNepPrim();
                aa.ShowDialog();
            }
            catch
            {
                MessageBox.Show("Повтор");
            }
                btnUpdate_Click(sender, e);
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                AddNepPrim dd = new AddNepPrim(dgNEpprim.SelectedItem as NepPrem);
                dd.ShowDialog();
            }
            catch (NullReferenceException)
            {

                MessageBox.Show("Выберете деталь");
            }
            btnUpdate_Click(sender, e);
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            dgNEpprim.ItemsSource = NepPrim.GetAll();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                NepPrim.Delete((dgNEpprim.SelectedItem as NepPrem).IzdChto,((dgNEpprim.SelectedItem as NepPrem).IzdKuda));
                
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Выберете деталь");
            }
            btnUpdate_Click(sender, e);
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            Close();

        }

        

        
    }
}
