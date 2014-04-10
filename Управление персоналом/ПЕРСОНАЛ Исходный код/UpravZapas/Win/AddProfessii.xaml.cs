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
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Addprofessii : Window
    {int id;
       
    public Addprofessii()
        {
            
            InitializeComponent();
        }

        public Addprofessii(Professii i)
        {
            
            InitializeComponent();
            tbNaimenov.Text=i.Naimenovanie;
            tbRazryad.Text=i.Razryad_rabochego;
            tbStavka.Text= i.Stavka_v_chas.ToString();
            id=i.ID_professii;
        }

        private void bClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void bSave_Click(object sender, RoutedEventArgs e)
        {
            
            Close();
        }

        private void bSave_Click_1(object sender, RoutedEventArgs e)
        {
            Professii i = new Professii();
            if (tbNaimenov.Text == "" || tbRazryad.Text == "" || tbStavka.Text == "")
            {
                MessageBox.Show("Все поля должны быть заполнены", "Проверка");
                return;
            }

            i.Naimenovanie = tbNaimenov.Text;
            i.Razryad_rabochego = tbRazryad.Text;
            i.Stavka_v_chas = Convert.ToInt32( tbStavka.Text) ;
            try
            {
                if (id == 0)
                {
                    ProfessiiDao.Add(i);
                    Close();
                }
                else
                {
                    i.ID_professii = id;
                    ProfessiiDao.Update(i);
                }
            }

            catch { MessageBox.Show("Не удалось добавить запись", "Проверка"); return; }
        }

        private void bClose_Click_1(object sender, RoutedEventArgs e)
        {
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