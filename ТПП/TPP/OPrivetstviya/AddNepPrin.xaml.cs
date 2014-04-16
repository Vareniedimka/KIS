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
using TPPDAO;
using ClassBD;

namespace Web
{
    /// <summary>
    /// Логика взаимодействия для ONepPrin.xaml
    /// </summary>
    public partial class AddNepPrim : Window
    {
        bool flag;
        private void detal()
        {
            InitializeComponent();

            IList<DSE> dsechto = DSEDAO.GetAll();
            IList<DSE> dsekuda = DSEDAO.GetAll();

            foreach (DSE ch in dsechto)
            {
                cbchto.Items.Add(ch.Naimenovanie);
            }

            foreach (DSE k in dsekuda)
            {
                cbkuda.Items.Add(k.Naimenovanie);
            }
            cbchto.SelectedIndex = 0;
            cbkuda.SelectedIndex = 1;
        }

        public AddNepPrim()
        {
            detal();
            flag = false;
            
        }
        public AddNepPrim(ClassBD.NepPrem np)
        {
            detal();
            cbchto.SelectedValue = np.name_chto;
            cbkuda.SelectedValue = np.name_kuda;
            tbKol.Text = np.Kolichestvo.ToString();
            tbPrim.Text = np.Primichanie.ToString();
            flag = true;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            NepPrem nep = new NepPrem();

            if (string.IsNullOrEmpty(tbKol.Text))
            {
                MessageBox.Show("Введите значение в строку количество");
                return;
            }

            int k;
            if (!int.TryParse(tbKol.Text, out k))
            {
                MessageBox.Show("Количество должно быть целым числом");
                return;
            }

            nep.name_chto = cbchto.SelectedValue.ToString();
            nep.name_kuda = cbkuda.SelectedValue.ToString();
            nep.Kolichestvo = int.Parse(tbKol.Text);
            nep.Primichanie = tbPrim.Text;
            nep.IDdse = cbchto.SelectedIndex;
            if (flag)
            {
                NepPrim.Update(nep);
            }
            else
                NepPrim.Add(nep);
            Close();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }


    }
}
