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
using System.Windows.Navigation;
using System.Windows.Shapes;
using ClassBD;
using OPDao;

namespace Win
{
    /// <summary>
    /// Логика взаимодействия для AddMaterial.xaml
    /// </summary>
    public partial class AddIzg_SE : Window
    {
        int id;

        public AddIzg_SE()
        {
            InitializeComponent();
        }

        public AddIzg_SE(Izg_SE i)
        {
            InitializeComponent();
            tbNomer_izg_det.Text = i.Nomer_izg_det.ToString();
            tbID_Izg_SE.Text = i.ID_Izg_SE.ToString();
            tbInvertarniy_nomer.Text = i.Invertarniy_nomer.ToString();
            tbDate_izg.Text = i.Date_izg.ToString();
            tbViyavl_brak.Text = i.Viyavl_brak.ToString();
            tbNomer_partii.Text = i.Nomer_partii.ToString();
            tbTabeln_nomer.Text = i.Tabeln_nomer.ToString();
        }

        private void bClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void bSave_Click(object sender, RoutedEventArgs e)
        {
            Izg_SE i = new Izg_SE();
            if (tbNomer_izg_det.Text == "" || tbID_Izg_SE.Text == "" || tbInvertarniy_nomer.Text == "" || tbDate_izg.Text == "" || tbViyavl_brak.Text == "" || tbNomer_partii.Text == "" || tbTabeln_nomer.Text=="")
            {
                MessageBox.Show("Все поля должны быть заполнены", "Проверка");
                return;
            }

            i.Nomer_izg_det = Int32.Parse(tbNomer_izg_det.Text);
            i.ID_Izg_SE = Int32.Parse(tbID_Izg_SE.Text);
            i.Invertarniy_nomer = Int32.Parse(tbInvertarniy_nomer.Text);
            i.Date_izg = DateTime.Parse(tbInvertarniy_nomer.Text);
            i.Viyavl_brak = Int32.Parse(tbInvertarniy_nomer.Text);
            i.Nomer_partii = Int32.Parse(tbInvertarniy_nomer.Text);
            i.Tabeln_nomer = Int32.Parse(tbInvertarniy_nomer.Text);

            if (id == 0)
            {
                Izg_SEDAO.Add(i);
            }
            else
            {
                i.Nomer_izg_det = id;
                Izg_SEDAO.Update(i);
            }
            Close();
        }

             /*
        private void tbTelefon_KeyUp(object sender, KeyEventArgs e)
        {
            e.Handled = true;

            if ((e.Key>=Key.D0&&e.Key<=Key.D9)||(e.Key>=Key.NumPad0&&e.Key<=Key.NumPad9)) { e.Handled = false; }
        }*/

    }

}