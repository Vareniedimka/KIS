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
         InitializeComponent();

        }

        public AddGraficRabot(GraficRabot i)
        {
            Loaded();
           
            InitializeComponent();
            Invertatniy_nomer.SelectedItem = i.InvertatniyNomer;
            cbDate_nach_remont.Text = i.DateNachRemont.ToString();
            cbDate_okonch_remont.Text = i.DataOkonchRem.ToString();
            cbVnepan_Rem.Text = i.VnepanRem.ToString("H:m:s");
            Plan_proverk_oborud.Text = i.PlanProverkOborud.ToString();
            cbNaimenovanie_det.SelectedItem = i.NaimenovanieDet.ToString();
            id = i.InvertatniyNomer;
           
        }

        private void bCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void bSave_Click(object sender, RoutedEventArgs e)
        {
            GraficRabot i = new GraficRabot();
            if (Invertatniy_nomer.Text == "" || cbDate_nach_remont.Text == "" || cbDate_okonch_remont.SelectedDate == null || cbVnepan_Rem.Text == "" || Plan_proverk_oborud.Text == "" || cbNaimenovanie_det.Text == "" )
            {
                MessageBox.Show("Не все поля заполнены", "Проверка");
                return;}

            i.InvertatniyNomer = Convert.ToInt32(Invertatniy_nomer.Text);
            i.DateNachRemont = (DateTime)cbDate_nach_remont.SelectedDate;
            i.DataOkonchRem = (DateTime)cbDate_okonch_remont.SelectedDate;
            i.VnepanRem = (DateTime)cbVnepan_Rem.SelectedDate; ;
            i.PlanProverkOborud = Plan_proverk_oborud.ToString();
            i.NaimenovanieDet = cbNaimenovanie_det.SelectedItem.ToString();
           

            if (id == 0)
            {
                GraficRabotDao.Add(i);
            }
            else
            {
             
                GraficRabotDao.Update(i);
            }
            Close();
        }

        private new void  Loaded()
        {
            InitializeComponent();

            IList<string> inv = new List<string>();
            IList<Stanok_na_proizv> listM = Stanok_na_proizvDao.GetAll();

            foreach (Stanok_na_proizv i in listM)
            {
                inv.Add(i.Invertatniy_nomer.ToString());
            }
            Invertatniy_nomer.ItemsSource = inv;
            Invertatniy_nomer.SelectedIndex = 0;
            
            InitializeComponent();

            IList<string> naim = new List<string>();
            IList<Detdlyarem> list = DetdlyaremDao.GetAll();

            foreach (Detdlyarem i in list)
            {
                naim.Add(i.NaimenovanieDet.ToString());
            }
            cbNaimenovanie_det.ItemsSource = naim;
            cbNaimenovanie_det.SelectedIndex = 0;
            
        }
       
        

      
       

       /* private void tbKolich_KeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = true;

            if ((e.Key>=Key.D0&&e.Key<=Key.D9)||(e.Key>=Key.NumPad0&&e.Key<=Key.NumPad9)) { e.Handled = false; }
        
        }*/
    }
}
