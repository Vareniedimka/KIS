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
    /// Логика взаимодействия для addZapas.xaml
    /// </summary>
    public partial class AddZapas : Window
    {
        int id;
        public AddZapas()
        {
            Load();
            
        }
        
        public AddZapas(Zapas i)
        {
            Load();

            id = i.IDMateriala;
            cbMaterial.SelectedItem = i.MaterialName;
            tbKolich.Text = i.Kolichestvo.ToString();
        }

        private void bClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void bSave_Click(object sender, RoutedEventArgs e)
        {
            Zapas i = new Zapas();
            if (tbKolich.Text == "" || cbMaterial.SelectedItem == null)
            {
                MessageBox.Show("Не все поля заполненны", "Проверка");
                return;
            }
            i.Kolichestvo = Convert.ToInt32(tbKolich.Text);
            i.MaterialName = cbMaterial.SelectedItem.ToString();
            if (id == 0)
            {
                ZapasDao.Add(i);
            }
            else
            {
                i.IDMateriala = id;
                ZapasDao.Update(i);
            }
            Close();
        }
        private void Load()
        {
            InitializeComponent();

            IList<string> material = new List<string>();
            IList<Material> listM = MaterialDao.GetAll();

            foreach (Material i in listM)
            {
                material.Add(i.Name);
            }

            cbMaterial.ItemsSource = material;
            cbMaterial.SelectedItem = null;

        }

        private void tbKolich_KeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = true;

            if ((e.Key >= Key.D0 && e.Key <= Key.D9) || (e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9)) { e.Handled = false; }
        }
    }
}
