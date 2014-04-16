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
    public partial class AddMaterial : Window
    {
        int id;

        public AddMaterial()
        {
            InitializeComponent();
        }

        public AddMaterial(Material i)
        {
            InitializeComponent();
            tbCena.Text = i.Cena.ToString();
            tbEdIzm.Text = i.EdinIzm;
            tbName.Text = i.Name;
            id = i.IDMateriala;
        }

        private void bClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void bSave_Click(object sender, RoutedEventArgs e)
        {
            Material i = new Material();
            if (tbCena.Text == "" || tbEdIzm.Text == "" || tbName.Text == "")
            {
                MessageBox.Show("Все поля должны быть заполнены", "Проверка");
                return;
            }

            i.Cena = Double.Parse(tbCena.Text);
            i.EdinIzm=tbEdIzm.Text;
            i.Name = tbName.Text;
            try
            {
                if (id == 0)
                {
                    MaterialDao.Add(i);
                }
                else
                {
                    i.IDMateriala = id;
                    MaterialDao.Update(i);
                }
                Close();
            }
            catch
            {
                MessageBox.Show("Не удалось внести изменения в БД,\nпожелуйста проверьте введенные данные","Ошибка");
            }
                
        }
        /*
        private void tbTelefon_KeyUp(object sender, KeyEventArgs e)
        {
            e.Handled = true;

            if ((e.Key>=Key.D0&&e.Key<=Key.D9)||(e.Key>=Key.NumPad0&&e.Key<=Key.NumPad9)) { e.Handled = false; }
        }*/

    }
    
}
