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
    /// Логика взаимодействия для AddSbelka.xaml
    /// </summary>
    public partial class AddMaterialPostav : Window
    {
        int idM, idP;

        public AddMaterialPostav()
        {
            InitializeComponent();
            Loaded();
            
            
        }
        public AddMaterialPostav(MaterialPostav item)
        {
            InitializeComponent();
            Loaded();
            cbMaterial.SelectedItem = item.MaterialName;
            cbPostavhik.SelectedItem = item.PostavhikName;
            idP = item.IDPostavhik;
            idM = item.IDMateriala;
        }
        private void bCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void bSave_Click(object sender, RoutedEventArgs e)
        {
            if (cbMaterial.SelectedItem == null || cbPostavhik.SelectedItem == null )
            {
                MessageBox.Show("Все поля должны быть заполнены", "Проверка");
                return;
            }

            MaterialPostav item = new MaterialPostav();
            item.MaterialName = cbMaterial.SelectedItem.ToString();
            item.PostavhikName = cbPostavhik.SelectedItem.ToString();
            try
            {
                if (idM != 0)
                {
                    item.IDMateriala = idM;
                    item.IDPostavhik = idP;
                    MaterialPostavDao.Update(item);
                }
                else
                {
                    MaterialPostavDao.Add(item);
                }

                Close();
            }
            catch
            {
                MessageBox.Show("Не удалось внести изменения в БД,\nпожелуйста проверьте введенные данные", "Ошибка");
            }
        }

        private void Loaded()
        {
            IList<string> postav = new List<string>();

            IList<Postavhik> listP = PostavhikDao.GetAll();

            foreach (Postavhik i in listP)
            {
                postav.Add(i.Name);
            }

            cbPostavhik.ItemsSource = postav;
            cbPostavhik.SelectedItem = null;

            IList<string> material = new List<string>();

            IList<Material> listM = MaterialDao.GetAll();

            foreach (Material i in listM)
            {
                material.Add(i.Name);
            }

            cbMaterial.ItemsSource = material;
            cbMaterial.SelectedItem = null;
        }
    }
}
