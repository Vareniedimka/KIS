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
using ClassLibrary;

namespace Win
{
    /// <summary>
    /// Логика взаимодействия для AddPostavhik.xaml
    /// </summary>
    public partial class AddZarplatnay_vedom : Window
    {
        int id;

        public AddZarplatnay_vedom()
        {  
            Loaded();
            InitializeComponent();
        }

        public AddZarplatnay_vedom(Zarplatnay_vedom i)
        {
            InitializeComponent();
            tbZarabotnPl.Text= i.Zarabotn_Plata.ToString();
            id = i.Zarabotn_Plata;
            Loaded();
            
            //tbRaschetZp.Text = i.Raschet_zarabotn_platy.ToString();


        }

        private void bClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void bSave_Click(object sender, RoutedEventArgs e)
        {
            Zarplatnay_vedom i = new Zarplatnay_vedom();
            if ( cbFio.Text == "" || tbZarabotnPl.Text == "")
            {
                MessageBox.Show("Все поля должны быть заполнены", "Проверка");
                return;
            }
           
  
            i.FIO = cbFio.SelectedItem.ToString();
            //i.Raschet_zarabotn_platy = Convert.ToInt32(tbRaschetZp.Text);
            i.Zarabotn_Plata = Convert.ToInt32(tbZarabotnPl.Text);


            if (id == 0)
            {
                Zarplatnay_vedomDao.Add(i);
            }
            else
            {
                i.Tabeln_nom = id;
                Zarplatnay_vedomDao.Update(i);
            }
            Close();
        }

        private void Loaded()
        {
            InitializeComponent();


            //Инициализация комбобокса 
            IList<string> tab = new List<string>();
            IList<Rabociy> ls = RabociyDao.GetAll();
            foreach (Rabociy s in ls)
            {
                tab.Add(s.FIO);
            }
            cbFio.ItemsSource = tab;
            cbFio.SelectedIndex = 0;


            /*
            private void tbTelefon_KeyUp(object sender, KeyEventArgs e)
            {
                e.Handled = true;

                if ((e.Key>=Key.D0&&e.Key<=Key.D9)||(e.Key>=Key.NumPad0&&e.Key<=Key.NumPad9)) { e.Handled = false; }
            }*/

        }
    }
}
