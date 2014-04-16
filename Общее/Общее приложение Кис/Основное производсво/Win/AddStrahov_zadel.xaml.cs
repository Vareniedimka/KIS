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
using ClassBD;
using OPDao;

namespace Win
{
    /// <summary>
    /// Логика взаимодействия для AddMaterial.xaml
    /// </summary>
    public partial class AddStrahov_zadel : Window
    {
        DateTime id;

        public AddStrahov_zadel()
        {
            InitializeComponent();
        }

        public AddStrahov_zadel(Strahov_zadel i)
        {
            InitializeComponent();
            tbData_strahovogo_zadela.Text = i.Data_strahovogo_zadela.ToString();
            tbNaimenovanie_det.Text = i.Naimenovanie_det;
            tbKolichestvo.Text = i.Kolichestvo.ToString(); ;
            
        }

        private void bClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void bSave_Click(object sender, RoutedEventArgs e)
        {
            Strahov_zadel i = new Strahov_zadel();
            if (tbData_strahovogo_zadela.Text == "" || tbNaimenovanie_det.Text == "" || tbKolichestvo.Text == "")
            {
                MessageBox.Show("Все поля должны быть заполнены", "Проверка");
                return;
            }

            i.Data_strahovogo_zadela = DateTime.Parse(tbData_strahovogo_zadela.Text);
            i.Naimenovanie_det = tbNaimenovanie_det.Text;
            i.Kolichestvo = Int32.Parse(tbKolichestvo.Text);

            if (id == null)
            {
                Strahov_zadelDAO.Add(i);
            }
            else
            {
                i.Data_strahovogo_zadela = id;
                Strahov_zadelDAO.Update(i);
            }
            Close();
        }
        /*
        private void tbTelefon_KeyUp(object sender, KeyEventArgs e)
        {
            e.Handled = true;

            if ((e.Key>=Key.D0&&e.Key<=Key.D9)||(e.Key>=Key.NumPad0&&e.Key<=Key.NumPad9)) { e.Handled = false; }
        }*/

    }

}