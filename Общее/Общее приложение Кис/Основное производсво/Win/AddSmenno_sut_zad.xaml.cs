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
    public partial class AddSmenno_sut_zad : Window
    {
        int id;

        public AddSmenno_sut_zad()
        {
            InitializeComponent();
        }

        public AddSmenno_sut_zad(Smenno_sut_zad i)
        {
            InitializeComponent();
            tbNomer_SSZ.Text = i.Nomer_SSZ.ToString();
            tbTabeln_nomer.Text = i.Tabeln_nomer.ToString();
            tbData_nach_vip_plan.Text = i.Data_nach_vip_plan.ToString();
            tbData_okonch_vip_plan.Text = i.Data_okonch_vip_plan.ToString();
            tbCex.Text = i.Cex.ToString();
            tbID_operacii.Text = i.ID_operacii.ToString();
            tbDate.Text = i.Date.ToString();
            tbSmena.Text = i.Smena.ToString();
            tbNomer_partii.Text = i.Nomer_partii.ToString();
            tbID_DCE.Text = i.ID_DCE.ToString();
        }

        private void bClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void bSave_Click(object sender, RoutedEventArgs e)
        {
            Smenno_sut_zad i = new Smenno_sut_zad();
            if (tbNomer_SSZ.Text == "" || tbTabeln_nomer.Text == "" || tbData_nach_vip_plan.Text == "" || tbData_okonch_vip_plan.Text==""|| tbCex.Text==""|| tbID_operacii.Text==""|| tbDate.Text==""|| tbSmena.Text==""|| tbNomer_partii.Text==""|| tbID_DCE.Text=="")
            {
                MessageBox.Show("Все поля должны быть заполнены", "Проверка");
                return;
            }

            i.Nomer_SSZ = Int32.Parse(tbNomer_SSZ.Text);
            i.Tabeln_nomer = Int32.Parse(tbTabeln_nomer.Text);
            i.Data_nach_vip_plan = DateTime.Parse(tbData_nach_vip_plan.Text);
            i.Data_okonch_vip_plan = DateTime.Parse(tbData_okonch_vip_plan.Text);
            i.Cex = Int32.Parse(tbCex.Text);
            i.ID_operacii = Int32.Parse(tbID_operacii.Text);
            i.Date = DateTime.Parse(tbDate.Text);
            i.Smena = Int32.Parse(tbSmena.Text);
            i.Nomer_partii = Int32.Parse(tbNomer_partii.Text);
            i.ID_DCE = Int32.Parse(tbID_DCE.Text);


            if (id == 0)
            {
                Smenno_sut_zadDAO.Add(i);
            }
            else
            {
                i.Nomer_SSZ = id;
                Smenno_sut_zadDAO.Update(i);
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
