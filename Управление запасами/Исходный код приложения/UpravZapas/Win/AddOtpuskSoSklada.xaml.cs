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
    /// Логика взаимодействия для AddOtpuskSoSklada.xaml
    /// </summary>
    public partial class AddOtpuskSoSklada : Window
    {
        int id;

        public AddOtpuskSoSklada()
        {
            Loaded();

        }

        public AddOtpuskSoSklada(OtpuskSoSklada i)
        {
            Loaded();
         
            cbMaterial.SelectedItem = i.MaterialName;
            tbKolich.Text = i.Kolichestvo.ToString();
            dpOtdr.SelectedDate = i.DataOtgruzk;
            tbTimeOtgr.Text = i.DataOtgruzk.ToString("H:m:s");
            id=i.IDOtpusk;
        }

        private void bCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void bSave_Click(object sender, RoutedEventArgs e)
        {
            OtpuskSoSklada i = new OtpuskSoSklada();
            if (tbKolich.Text == ""||tbTimeOtgr.Text==""||dpOtdr.SelectedDate==null||cbMaterial.SelectedItem==null){
                MessageBox.Show("Не все поля затопленны", "Проверка");
                return;}

            i.Kolichestvo = Convert.ToInt32(tbKolich.Text);
            i.MaterialName = cbMaterial.SelectedItem.ToString();
            i.DataOtgruzk = Convert.ToDateTime(dpOtdr.Text + " " + tbTimeOtgr.Text);
            try
            {
                if (id == 0)
                {
                    OtpuskSoSkladaDao.Add(i);
                }
                else
                {
                    i.IDOtpusk = id;
                    OtpuskSoSkladaDao.Update(i);
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

            dpOtdr.SelectedDate = DateTime.Now.Date;
            tbTimeOtgr.Text = DateTime.Now.ToString("H:m:s");
        }

        private void tbTimeOtgr_KeyDown(object sender, KeyEventArgs e)
        {
        //    e.Handled = true;

        //    if ((e.Key >= Key.D0 && e.Key <= Key.D9) || (e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9)||Convert.ToChar(e.Key) ==':') { e.Handled = false; }
        //
        }

        private void tbKolich_KeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = true;

            if ((e.Key >= Key.D0 && e.Key <= Key.D9) || (e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9)) { e.Handled = false; }
        }

       /* private void tbKolich_KeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = true;

            if ((e.Key>=Key.D0&&e.Key<=Key.D9)||(e.Key>=Key.NumPad0&&e.Key<=Key.NumPad9)) { e.Handled = false; }
        
        }*/
    }
}
