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
    /// Логика взаимодействия для Odse.xaml
    /// </summary>
    public partial class Odse : Window
    {

        public Odse()
        {
            InitializeComponent();
            btnUpdate_Click(new object(), new RoutedEventArgs());
        }

        private void btnMK_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Storonee.IDDseMK = (dgDSE.SelectedItem as DSE).ID_DCE;
                OMarKart win1 = new OMarKart();
                win1.ShowDialog();
            }
            catch
            {
                MessageBox.Show("произошла ошибка, повторите ввод");
            }
            

        }
        
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            AddDSE win1 = new AddDSE();
            win1.ShowDialog();
            btnUpdate_Click(sender, e);
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                AddDSE win1 = new AddDSE((dgDSE.SelectedItem as DSE));
                win1.ShowDialog();
                btnUpdate_Click(sender, e);
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Выберете деталь");
            }
            btnUpdate_Click(sender, e);

        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            dgDSE.ItemsSource = DSEDAO.GetAll();
            
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DSEDAO.Delete((dgDSE.SelectedItem as DSE).ID_DCE);
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Выберете деталь");
            }
            catch
            {
                MessageBox.Show("Не удалось удалить");
            }
            btnUpdate_Click(sender, e);
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

       

        
    }
}
