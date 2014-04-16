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
    public partial class addprodazi : Window
    {
        int id;

        public addprodazi()
        {
            InitializeComponent();
            Loaded();


        }
        public addprodazi(prodazhi s)
        {
            InitializeComponent();
            Loaded();
            date.DisplayDate = s.DataSdelki.Date;
            date.Text = s.DataSdelki.Date.ToString();
            tbnomer.Text = s.Nomer_raschetnogo_platesha.ToString();
            tbopisanie.Text = s.Opisanie;
            id = s.ID_prodazhi;
        }

        private void bSave_Click(object sender, RoutedEventArgs e)
        {
            prodazhi s = new prodazhi();
            try
            {
                s.DataSdelki = Convert.ToDateTime(date.Text);//.Add( Convert.ToDateTime(tbTime.Text).TimeOfDay);

            }
            catch { MessageBox.Show("Время введено не верно", "Проверка"); return; }
            s.Nomer_raschetnogo_platesha = Convert.ToInt32(tbnomer.Text);
            s.Opisanie = tbopisanie.Text;
            if (id != 0)
            {
                s.ID_prodazhi = id;
                prodazhiDao.Update(s);
            }
            else
            {
                prodazhiDao.Add(s);
            }



            Close();
        }

        private void Loaded()
        {
            //Инициализация комбобокса покупатель
            date.SelectedDate = DateTime.Now.Date;
        }

        private void bClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }




    }
}
