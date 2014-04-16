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
    public partial class AddOplata : Window
    {
        int id;

        public AddOplata()
        {
            InitializeComponent();
            Loaded();


        }
        public AddOplata(Oplata s)
        {
            InitializeComponent();
            Loaded();
            date.DisplayDate = s.DataSdelki.Date;
            date.Text = s.DataSdelki.Date.ToString();
            tbschet.Text = s.Schet.ToString();
            id = s.ID_oplati;
        }

        private void bSave_Click(object sender, RoutedEventArgs e)
        {
            Oplata s = new Oplata();
            try
            {
                s.DataSdelki = Convert.ToDateTime(date.Text);//.Add( Convert.ToDateTime(tbTime.Text).TimeOfDay);

            }
            catch { MessageBox.Show("Время введено не верно", "Проверка"); return; }
            s.Schet = Convert.ToInt32(tbschet.Text);
            if (id != 0)
            {
                s.ID_oplati = id;
                OplataDao.Update(s);
            }
            else
            {
                OplataDao.Add(s);
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
