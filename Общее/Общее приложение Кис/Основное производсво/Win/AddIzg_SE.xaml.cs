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
            tbInvertatniy_nomer.Text = i.Invertatniy_nomer.ToString();
            tbDate_izg.Text = i.Date_izg.ToString();
            tbViyavl_brak.Text = i.Viyavl_brak.ToString();
            tbNomer_partii.Text = i.Nomer_partii.ToString();
            tbTabeln_nom.Text = i.Tabeln_nom.ToString();
        }

        private void bClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void bSave_Click(object sender, RoutedEventArgs e)
        {
            Izg_SE i = new Izg_SE();
            if (tbNomer_izg_det.Text == "" || tbID_Izg_SE.Text == "" || tbInvertatniy_nomer.Text == "" || tbDate_izg.Text == "" || tbViyavl_brak.Text == "" || tbNomer_partii.Text == "" || tbTabeln_nom.Text=="")
            {
                MessageBox.Show("Все поля должны быть заполнены", "Проверка");
                return;
            }

            i.Nomer_izg_det = Int32.Parse(tbNomer_izg_det.Text);
            i.ID_Izg_SE = Int32.Parse(tbID_Izg_SE.Text);
            i.Invertatniy_nomer = Int32.Parse(tbInvertatniy_nomer.Text);
            i.Date_izg = DateTime.Parse(tbDate_izg.Text);
            i.Viyavl_brak =(tbViyavl_brak.Text).ToString();
            i.Nomer_partii = Int32.Parse(tbNomer_partii.Text);
            i.Tabeln_nom = Int32.Parse(tbTabeln_nom.Text);

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