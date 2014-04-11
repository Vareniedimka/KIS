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
    public partial class AddGraficRabot : Window
    {
        int id;

        public AddGraficRabot()
        {
            Loaded();

        }

        public AddGraficRabot(GraficRabot i)
        {
            Loaded();

            Invertatniy_nomer.SelectedItem = i.InvertatniyNomer;
            Date_nach_remont.Text = i.DateNachRemont.ToString();
            tbDataOkonchRem = i.DataOkonchRem.ToString();
            Vnepan_rem.Text = i.VnepanRem.ToString("H:m:s");
            Plan_proverk_oborud.Text = i.PlanProverkOborud.ToString();
            Naimenovanie_det.Text = i.NaimenovanieDet.ToString();
            Raschetn_koef = i.Raschetn_koef;
           
        }

        private void bCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void bSave_Click(object sender, RoutedEventArgs e)
        {
            GraficRabot i = new GraficRabot();
            if (Invertatniy_nomer.Text == "" || Date_nach_remont.Text == "" || tbDataOkonchRem.SelectedDate == null || Vnepan_rem.Text == "" || Plan_proverk_oborud.Text == "" || Naimenovanie_det.Text == "" || Raschetn_koef.Text == "")
            {
                MessageBox.Show("Не все поля заполнены", "Проверка");
                return;}

            i.InvertatniyNomer = Convert.ToInt32(Invertatniy_nomer.Text);
            i.DateNachRemont = Date_nach_remont.SelectedDate;
            i.DataOkonchRem = tbDataOkonchRem.ToString() ;
            i.VnepanRem = Vnepan_rem.ToString();
            i.PlanProverkOborud = Plan_proverk_oborud.ToString();
            i.NaimenovanieDet = Naimenovanie_det.ToString();
            i.Raschetn_koef = Convert.ToDouble(  Raschetn_koef);

            if (id == 0)
            {
                GraficRabotDao.Add(i);
            }
            else
            {
                i.IDOtpusk= id;
                GraficRabotDao.Update(i);
            }
            Close();
        }

        private void Loaded()
        {
            InitializeComponent();

            IList<string> material = new List<string>();
            IList<Det> listM = DetdlyaremDao.GetAll();

            foreach (Det i in listM)
            {
                material.Add(i.Name);
            }

            InvertatniyNomer.ItemsSource = Convert.ToInt32(Invertatniy_nomer.Text);
            DateNachRemont.SelectedItem = Date_nach_remont.SelectedDate;
            DataOkonchRem.ItemsSource = tbDataOkonchRem.ToString();
            VnepanRem.Text = VnepanRem.ToString();
            PlanProverkOborud = Plan_proverk_oborud.ToString();
            NaimenovanieDet = Naimenovanie_det.ToString();
            Raschetn_koef = Convert.ToDouble(Raschetn_koef);

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
