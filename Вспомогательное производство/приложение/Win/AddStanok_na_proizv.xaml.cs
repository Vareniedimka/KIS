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
    /// Логика взаимодействия для AddSbelka.xaml
    /// </summary>
    public partial class AddStanok_na_proizv : Window
    {

        int id;
        public AddStanok_na_proizv()
        {
            InitializeComponent();
            // Loaded();


        }
        public AddStanok_na_proizv(Stanok_na_proizv item)
        {
            InitializeComponent();
            id = Convert.ToInt32( item.Invertatniy_nomer);
            tbInvNom.Text = item.Invertatniy_nomer;
            cbGod_vipuska.Text = item.God_vipuska.ToString();
            tbMod.Text = item.Model;
            cbGod_vvedeniya_v_expluat.Text = item.God_vvedeniya_v_expluat;
        }
        private void bCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void bSave_Click(object sender, RoutedEventArgs e)
        {
            if (tbInvNom == null || tbMod == null || cbGod_vvedeniya_v_expluat == null || cbGod_vipuska == null)
            {
                MessageBox.Show("Все поля должны быть заполнены", "Проверка");
                return;
            }

            Stanok_na_proizv item = new Stanok_na_proizv();
            item.God_vipuska = Convert.ToDouble(cbGod_vipuska.Text);
            item.Invertatniy_nomer = tbInvNom.Text.ToString();
            item.Model = tbMod.Text.ToString();
            item.God_vvedeniya_v_expluat = cbGod_vvedeniya_v_expluat.Text.ToString();


            if (id != 0)
            {
                item.Invertatniy_nomer = id.ToString(); ;

                Stanok_na_proizvDao.Update(item);
                Close();
            }
            else
            {
                Stanok_na_proizvDao.Add(item);
                Close();
            }

            Close();
        }

        /*private void Loaded()
        {
            IList<string> postav = new List<string>();

            IList<Postavhik> listP = PostavhikDao.GetAll();

            foreach (Postavhik i in listP)
            {
                postav.Add(i.Name);
            }

            cbPostavhik.ItemsSource = postav;
            cbPostavhik.SelectedItem = null;

            IList<string> material = new List<string>();

            IList<Det> listM = DetdlyaremDao.GetAll();

            foreach (Det i in listM)
            {
                material.Add(i.Name);
            }

            cbMaterial.ItemsSource = material;
            cbMaterial.SelectedItem = null;
        }*/


    }
}
