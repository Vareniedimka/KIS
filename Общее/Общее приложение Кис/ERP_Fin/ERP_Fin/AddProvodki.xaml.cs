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
    /// Логика взаимодействия для AddTovarVS.xaml
    /// </summary>
    public partial class AddProvodki : Window
    {
        int ids, idt;
        private void Loaded()
        {
            InitializeComponent();

        }
        public AddProvodki()
        {
            Loaded();

        }
        public AddProvodki(Provodka tvs)
        {
            Loaded();

            tbpeodazi.Text = tvs.ID_prodazhi.ToString();
            tbpokypki.Text = tvs.ID_Pokupki.ToString();
            tboplata.Text = tvs.ID_Oplaty.ToString();
            tbsumm.Text = tvs.Summa.ToString();
            ids = tvs.ID_provodki;
        }

        private void bCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void bSave_Click(object sender, RoutedEventArgs e)
        {
            Provodka tvs = new Provodka();
            if (tbsumm.Text == "")
            {
                MessageBox.Show("Введите количество", "Проверка");
                return;
            }
            if (0 == Convert.ToInt32(tbsumm.Text))
            {
                MessageBox.Show("Количество не может быть 0", "Проверка");
                return;
            }
            tvs.ID_prodazhi = Convert.ToInt32(tbpeodazi.Text);
            tvs.ID_Pokupki = Convert.ToInt32(tbpokypki.Text);
            tvs.ID_Oplaty = Convert.ToInt32(tboplata.Text);
            tvs.Summa = Convert.ToInt32(tbsumm.Text);
            Close();
        }

        private void tbKolich_KeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = true;

            if ((e.Key >= Key.D0 && e.Key <= Key.D9) || (e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9)) { e.Handled = false; }

        }
    }
}
