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
    /// Логика взаимодействия для addZakaz.xaml
    /// </summary>
    public partial class AddZakaz : Window
    {
        int id;
        public AddZakaz()
        {
            Loaded();
            InitializeComponent();
        }
        
        public AddZakaz(Zakaz i)
        {
            Loaded();

            InitializeComponent();
            tbKolichestvo.Text = i.Kolichestvo.ToString();
            cbMaterial.SelectedItem = i.MaterialName;
            cbPostavhik.SelectedItem = i.PostavhikName;
            cbStatus.SelectedItem = i.Status;
            tbTimeOform.Text = i.DataOform.Value.ToString("H:m:s");
            dpOform.SelectedDate = i.DataOform;
            if (i.DataVipolneni != null)
            {
                tbTimeVipoln.Text = i.DataVipolneni.Value.ToString("H:m:s");
                dpVipol.SelectedDate = i.DataVipolneni;
            }           
            
            id = i.IDZakaza;

            if (cbStatus.SelectedIndex == 2)
            {
                dpVipol.IsEnabled = true;
                tbTimeVipoln.IsEnabled = true;
            }
        }

        private void bClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void bSave_Click(object sender, RoutedEventArgs e)
        {
            Zakaz i = new Zakaz();

            if(tbKolichestvo.Text==""||tbTimeOform.Text==""||cbStatus.SelectedItem==null||cbPostavhik.SelectedItem==null||cbMaterial.SelectedItem==null){
                MessageBox.Show("Не все поля заполненны", "Проверка");
                return;
            }
            i.Kolichestvo = Convert.ToInt32(tbKolichestvo.Text);
            i.MaterialName = cbMaterial.SelectedItem.ToString();
            i.PostavhikName = cbPostavhik.SelectedItem.ToString();
            i.Status = cbStatus.SelectedItem.ToString();
            i.DataOform =  Convert.ToDateTime(dpOform.Text + " " + tbTimeOform.Text);
            if(tbTimeVipoln.Text==""||dpVipol.Text==""){
                i.DataVipolneni=null;
            }else
            {
                i.DataVipolneni = Convert.ToDateTime(dpVipol.Text + " " + tbTimeVipoln.Text);            
            }

            try
            {
                if (id == 0)
                {
                    ZakazDao.Add(i);
                }
                else
                {
                    i.IDZakaza = id;
                    ZakazDao.Update(i);
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
            InitializeComponent();

            
            IList<string> material = new List<string>();

            IList<Material> listM = MaterialDao.GetAll();

            foreach (Material i in listM)
            {
                material.Add(i.Name);
            }

            cbMaterial.ItemsSource = material;
            cbMaterial.SelectedItem = null;
            string[] s = {"Ожидает оплаты","Оплачен","Выполнен"};
            cbStatus.ItemsSource = s;
            cbStatus.SelectedItem = 0;
            dpOform.SelectedDate = DateTime.Now.Date;
            tbTimeOform.Text = DateTime.Now.ToString("H:m:s");

            dpVipol.IsEnabled = false;
            tbTimeVipoln.IsEnabled = false;
            
            
        }

        private void tbKolichestvo_KeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = true;

            if ((e.Key >= Key.D0 && e.Key <= Key.D9) || (e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9)) { e.Handled = false; }
        }

        private void cbMaterial_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            IList<string> postav = new List<string>();

            IList<MaterialPostav> listP = MaterialPostavDao.GetAll();



            foreach (MaterialPostav i in listP)
            {
                if (i.MaterialName == ((ComboBox)sender).SelectedItem.ToString())
                { 
                    postav.Add(i.PostavhikName); 
                }
            }

            cbPostavhik.ItemsSource = postav;
            cbPostavhik.SelectedItem = null;
        }

        private void cbStatus_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbStatus.SelectedIndex == 2)
            {
                dpVipol.SelectedDate = DateTime.Now.Date;
                tbTimeVipoln.Text = DateTime.Now.ToString("H:m:s");
                
                dpVipol.IsEnabled = true;
                tbTimeVipoln.IsEnabled = true;
            }
            else
            {
                dpVipol.SelectedDate = null;
                tbTimeVipoln.Text = null;

                dpVipol.IsEnabled = false;
                tbTimeVipoln.IsEnabled = false;
            }
        }

    }
}
