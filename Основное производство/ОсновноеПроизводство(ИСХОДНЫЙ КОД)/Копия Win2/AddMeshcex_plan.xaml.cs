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
    public partial class AddMeshcex_plan: Window
    {
        DateTime id;

        public AddMeshcex_plan()
        {
            InitializeComponent();
        }

        public AddMeshcex_plan (Meshcex_plan i)
        {
            InitializeComponent();
            tbData_nach_vip_plan_na_mesyc.Text = i.Data_nach_vip_plan_na_mesyc.ToString();
            tbData_okonch_vip_plan_na_mesyc.Text = i.Data_okonch_vip_plan_na_mesyc.ToString();
            tbID_DCE.Text = i.ID_DCE.ToString();
            tbNaimenovanie_det.Text = i.Naimenovanie_det;
            tbPoryadok_vip_det.Text = i.Poryadok_vip_det.ToString();
            tbObhee_zaplan_kol.Text = i.Obhee_zaplan_kol.ToString();
            tbObhee_fact_kol.Text = i.Obhee_fact_kol.ToString();
            tbPlan_det_den.Text = i.Plan_det_den.ToString();
            tbFact_det_den.Text = i.Fact_det_den.ToString();
            tbOstatok_sklad.Text = i.Ostatok_sklad.ToString();
            tbNeobh_vip.Text = i.Neobh_vip.ToString();


           }

        private void bClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void bSave_Click(object sender, RoutedEventArgs e)
        {
            Meshcex_plan i = new Meshcex_plan();
            if (tbData_nach_vip_plan_na_mesyc.Text == "" || tbData_okonch_vip_plan_na_mesyc.Text == "" || tbID_DCE.Text == ""|| tbID_DCE.Text==""|| tbNaimenovanie_det.Text=="" ||tbPoryadok_vip_det.Text=="" ||tbObhee_zaplan_kol.Text=="" ||tbObhee_fact_kol.Text=="" ||tbPlan_det_den.Text==""|| tbFact_det_den.Text==""|| tbOstatok_sklad.Text=="" ||tbNeobh_vip.Text=="")
            {
                MessageBox.Show("Все поля должны быть заполнены", "Проверка"); 
                return;
            }

            i.Data_nach_vip_plan_na_mesyc = DateTime.Parse(tbData_nach_vip_plan_na_mesyc.Text);
            i.Data_okonch_vip_plan_na_mesyc =DateTime.Parse(tbData_okonch_vip_plan_na_mesyc.Text);
            i.ID_DCE = Int32.Parse(tbID_DCE.Text);
            i.Naimenovanie_det = tbNaimenovanie_det.Text;
            i.Poryadok_vip_det = Int32.Parse(tbPoryadok_vip_det.Text);
            i.Obhee_zaplan_kol = Int32.Parse(tbObhee_zaplan_kol.Text);
            i.Obhee_fact_kol = Int32.Parse(tbObhee_fact_kol.Text);
            i.Plan_det_den = Int32.Parse(tbPlan_det_den.Text);
            i.Fact_det_den = Int32.Parse(tbFact_det_den.Text);
            i.Ostatok_sklad = Int32.Parse(tbOstatok_sklad.Text);
            i.Neobh_vip = Int32.Parse(tbNeobh_vip.Text);

            if (id == null)
            {
                Meshcex_planDAO.Add(i);
            }
            else
            {
                i.Data_nach_vip_plan_na_mesyc = id;
                Meshcex_planDAO.Update(i);
            }
            Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }
        /*
        private void tbTelefon_KeyUp(object sender, KeyEventArgs e)
        {
            e.Handled = true;

            if ((e.Key>=Key.D0&&e.Key<=Key.D9)||(e.Key>=Key.NumPad0&&e.Key<=Key.NumPad9)) { e.Handled = false; }
        }*/

    }

}




