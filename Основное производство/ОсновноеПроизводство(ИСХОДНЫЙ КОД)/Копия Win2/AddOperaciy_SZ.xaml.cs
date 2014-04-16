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
    public partial class AddOperaciy_SZ : Window
    {
        int id;

        public AddOperaciy_SZ()
        {
            InitializeComponent();
        }

        public AddOperaciy_SZ(Operaciy_SZ i)
        {
            InitializeComponent();
            tbID_operacii.Text = i.ID_operacii.ToString();
            tbID_marshrut.Text = i.ID_marshrut.ToString();
            tbNaimenovanie_operacii.Text = i.Naimenovanie_operacii;
            tbTime_shtuchn.Text = i.Time_shtuchn.ToString();
            tbTimePZ.Text = i.TimePZ.ToString();
        }

        private void bClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void bSave_Click(object sender, RoutedEventArgs e)
        {
            Operaciy_SZ i = new Operaciy_SZ();
            if (tbID_operacii.Text == "" || tbID_marshrut.Text == "" || tbNaimenovanie_operacii.Text == "" || tbTime_shtuchn.Text==""|| tbTimePZ.Text=="")
            {
                MessageBox.Show("Все поля должны быть заполнены", "Проверка");
                return;
            }

            i.ID_operacii = Int32.Parse(tbID_operacii.Text);
            i.ID_marshrut = Int32.Parse(tbID_marshrut.Text);
            i.Naimenovanie_operacii = tbNaimenovanie_operacii.Text;
            i.Time_shtuchn = Int32.Parse(tbTime_shtuchn.Text);
            i.TimePZ = Int32.Parse(tbTimePZ.Text);

            if (id == 0)
            {
                Operaciy_SZDAO.Add(i);
            }
            else
            {
                i.ID_operacii = id;
                Operaciy_SZDAO.Update(i);
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
