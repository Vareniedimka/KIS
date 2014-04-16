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
    public partial class AddPostavhik : Window
    {
        int id;

        public AddPostavhik()
        {
            InitializeComponent();
        }

        public AddPostavhik(Postavhik i)
        {
            InitializeComponent();
            tbAdres.Text = i.Adres;
            tbName.Text = i.Name;
            tbNomerSch.Text = i.NomerScheta;
            tbPhone.Text = i.Phone;
            id = i.IDPostavhik;
        }

        private void bClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void bSave_Click(object sender, RoutedEventArgs e)
        {
            Postavhik i = new Postavhik();
            if (tbAdres.Text == "" || tbName.Text == "" || tbPhone.Text == "" || tbNomerSch.Text == "")
            {
                MessageBox.Show("Все поля должны быть заполнены", "Проверка");
                return;
            }
            
            i.Adres = tbAdres.Text;
            i.Name = tbName.Text;
            i.NomerScheta = tbNomerSch.Text;
            i.Phone = tbPhone.Text;
            try
            {
                if (id == 0)
                {
                    PostavhikDao.Add(i);
                }
                else
                {
                    i.IDPostavhik = id;
                    PostavhikDao.Update(i);
                }
                Close();
            }
            catch
            {
                MessageBox.Show("Не удалось внести изменения в БД,\nпожелуйста проверьте введенные данные", "Ошибка");
            }
        }

        private void tbPhone_KeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = true;

            if ((e.Key >= Key.D0 && e.Key <= Key.D9) || (e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9)) { e.Handled = false; }
        }
        /*
        private void tbTelefon_KeyUp(object sender, KeyEventArgs e)
        {
            e.Handled = true;

            if ((e.Key>=Key.D0&&e.Key<=Key.D9)||(e.Key>=Key.NumPad0&&e.Key<=Key.NumPad9)) { e.Handled = false; }
        }*/

    }
}
