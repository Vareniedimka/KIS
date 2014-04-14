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
    /// Логика взаимодействия для AddMaterial.xaml
    /// </summary>
    public partial class AddDetdlyarem : Window
    {
        double id;

        public AddDetdlyarem()
        {
            InitializeComponent();
        }

        public AddDetdlyarem(Detdlyarem i)
        {
            InitializeComponent();
            tbNaimenovanieDet.Text = i.NaimenovanieDet.ToString();
            tbKolichestvText = i.Kolichestv;
            id = i.Kolichestv;
            
        }

        private void bClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void bSave_Click(object sender, RoutedEventArgs e)
        {
            Detdlyarem i = new Detdlyarem();
            if (tbNaimenovanieDet.Text == "" || tbKolichestv.Text == "" )
            {
                MessageBox.Show("Все поля должны быть заполнены", "Проверка");
                return;
            }

            i.Kolichestv = Double.Parse(tbKolichestv.Text);
            i.NaimenovanieDet = tbNaimenovanieDet.Text;

            if (id == 0)
            {
                DetdlyaremDao.Add(i);
            }
            else
            {

                DetdlyaremDao.Update(i);
            }
            Close();
            
        }
        /*
        private void tbTelefon_KeyUp(object sender, KeyEventArgs e)
        {
            e.Handled = true;

            if ((e.Key>=Key.D0&&e.Key<=Key.D9)||(e.Key>=Key.NumPad0&&e.Key<=Key.NumPad9)) { e.Handled = false; }
        }*/


        public double tbKolichestvText { get; set; }
    }
    
}
