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
using ClassBD;
using TPPDAO;

namespace Web
{
    /// <summary>
    /// Логика взаимодействия для AddMarKart.xaml
    /// </summary>
    public partial class AddMarKart : Window
    {
        int dseid, mid;
        private void loaded()
        {
            InitializeComponent();
            IList<Prof> pp = ProfDao.GetAll();
            IList<InvN> inn = InvNomer.GetAll();
            foreach (Prof i in pp)
            {
                cbProf.Items.Add(i.name);
            }
            foreach (InvN j in inn)
            {
                cbInvN.Items.Add(j.model);
            }
            cbProf.SelectedItem = 0;
            cbInvN.SelectedItem = 0;
            cbCex.ItemsSource = cex;
        }
        private static readonly string[] cex = { "1","2" }; 
        
        public AddMarKart()
        {
            loaded();
            cbCex.SelectedIndex = 0;
            dseid = Storonee.IDDseMK;


        }
        public AddMarKart(MarshrytKarta mk)
        {
            loaded();
            
            cbCex.SelectedValue = mk.Cex;
            cbInvN.SelectedValue = mk.model;
            cbProf.SelectedValue = mk.name;
            dseid = mk.ID_DCE; 
            //Сохраняем ID
            mid = mk.IdMarshrut;
            tbTsch.Text = mk.TimeSht.ToString();
            tbTimePZ.Text = mk.TimePZ.ToString();
            cbCex.SelectedItem = mk.Cex;
            cbInvN.SelectedItem = mk.InvNom;
            cbProf.SelectedIndex=mk.IdProf;
            tbOper.Text = mk.IdOperacii.ToString();

        } 

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            MarshrytKarta mark = new MarshrytKarta();
            if (string.IsNullOrEmpty(tbOper.Text))
            {
                MessageBox.Show("поле номер операции не должно быть пустым");
                return;
            }
            int op;
            if (!int.TryParse(tbOper.Text, out op))
            {
                MessageBox.Show("поле номер операции должно быть целым числом");
                return;
            }
            if (string.IsNullOrEmpty(tbTsch.Text))
            {
                MessageBox.Show("поле время штучное не должно быть пустым ");
                return;
            }

            double tsht;
            if (!double.TryParse(tbTsch.Text,out tsht))
            {
                MessageBox.Show("поле время штучное должно быть  числом");
                return;
            }

            if (string.IsNullOrEmpty(tbTimePZ.Text))
            {
                MessageBox.Show("поле время pz не должно быть пустым");
                return;
            }
            double tpz;
            if (!double.TryParse(tbTimePZ.Text,out tpz))
            {
                MessageBox.Show(" Поле время pz должно быть числом");
                return;
            }
            mark.Cex = cbCex.SelectedValue.ToString();
            mark.IdOperacii = int.Parse(tbOper.Text);
            mark.name = cbProf.SelectedValue.ToString();
            mark.model = cbInvN.SelectedValue.ToString();
            mark.TimePZ = int.Parse(tbTimePZ.Text);
            mark.TimeSht = int.Parse(tbTsch.Text);
            mark.ID_DCE = dseid;
            if (mid == 0)
                TPPDAO.MKDA.Add(mark);
            else
            {
                MKDA.Update(mark);
                mark.IdMarshrut = mid;
            }
            Close();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

    }
}
