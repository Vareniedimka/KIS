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
    /// Логика взаимодействия для 
    /// </summary>
    public partial class AddRabociy : Window
    {
        int id;
        public AddRabociy()
        {
            Loaded();
            InitializeComponent();
        }
        
        public AddRabociy(Rabociy i)
        {
            Loaded();

            InitializeComponent();
            tbTabnom.Text = Convert.ToString(i.Tabeln_nom);
            cbNaimprof.SelectedItem = i.IDProfesii;
            tbZarBr.Text = i.Zareg_brak;
            tbFIO.Text = i.FIO;
            id = i.IDProfesii;
        
        }

        private void bClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void bSave_Click(object sender, RoutedEventArgs e)
        {
            Rabociy i = new Rabociy();

            if (tbZarBr.Text == "" || tbTabnom.Text == "" || cbNaimprof.SelectedItem == null || tbFIO.Text == null )
            {
                MessageBox.Show("Не все поля заполненны", "Проверка");
                return;
            }
            i.FIO = tbFIO.Text;
            i.Tabeln_nom = Convert.ToInt32(tbTabnom.Text) ;
            i.Zareg_brak =  tbZarBr.Text;
            i.Naimenovanie = cbNaimprof.SelectedItem.ToString() ;
          
            if (id == 0)
            {
                RabociyDao.Add(i);
                Close();
            }
            else
            {
                i.IDProfesii = id;
                RabociyDao.Update(i);
            }
            Close();
        }

        private void Loaded()
        {
            InitializeComponent();


            //Инициализация комбобокса покупатель
            IList<string> naim = new List<string>();
            IList<Professii> ls = ProfessiiDao.GetAll();
            foreach (Professii s in ls)
            {
                naim.Add(s.Naimenovanie);
            }
            cbNaimprof.ItemsSource = naim;
            cbNaimprof.SelectedIndex = 0;
           // cbStatus.ItemsSource = s;
         //   cbStatus.SelectedItem = 0;
          //  dpOform.SelectedDate = DateTime.Now.Date;
//tbTimeOform.Text = DateTime.Now.ToString("H:m:s");
//
         //   dpVipol.IsEnabled = false;
          //  tbTimeVipoln.IsEnabled = false;
            
            
        }

        

    }
}
