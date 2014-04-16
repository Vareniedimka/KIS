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
    public partial class AddOtchet_o_vip_tov_plan : Window
    {
        DateTime id;

        public AddOtchet_o_vip_tov_plan()
        {
            InitializeComponent();
        }

        public AddOtchet_o_vip_tov_plan(Otchet_o_vip_tov_plan i)
        {
            InitializeComponent();
            tbData_eshednevno.Text = i.Data_eshednevno.ToString();
            tbKolichestvo.Text = i.Kolichestvo.ToString();
            tbNomer_izg_det.Text = i.Nomer_izg_det.ToString();
            tbID_Izg_SE.Text = i.ID_Izg_SE.ToString();
           
        }

        private void bClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void bSave_Click(object sender, RoutedEventArgs e)
        {
            Otchet_o_vip_tov_plan i = new Otchet_o_vip_tov_plan();
            if (tbData_eshednevno.Text == "" || tbKolichestvo.Text == "" || tbNomer_izg_det.Text == "" ||tbID_Izg_SE.Text=="")
            {
                MessageBox.Show("Все поля должны быть заполнены", "Проверка");
                return;
            }

            i.Data_eshednevno = DateTime.Parse(tbData_eshednevno.Text);
            i.Kolichestvo = Int32.Parse(tbKolichestvo.Text);
            i.Nomer_izg_det = Int32.Parse(tbNomer_izg_det.Text);
            i.ID_Izg_SE = Int32.Parse(tbID_Izg_SE.Text);

            if (id == null)
            {
                Otchet_o_vip_tov_planDAO.Add(i);
            }
            else
            {
                i.Data_eshednevno = id;
                Otchet_o_vip_tov_planDAO.Update(i);
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

