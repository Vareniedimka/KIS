using System;
using System.Windows;
using System.Windows.Controls;
using build;
using ClassLib;
namespace Web
{
    /// <summary>
    /// Логика взаимодействия для AddKlient.xaml
    /// </summary>
    public partial class AddKlient : Window
    {
        int id;
        public AddKlient()
        {
            InitializeComponent();
        }
          public AddKlient(Klient i)
        {
            InitializeComponent();
            tbFamilia.Text = i.Name_klienta;
        //    tbLs.Text = i.LS;
            id = i.ID_klienta;
        }

        private void bClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void bSave_Click(object sender, RoutedEventArgs e)
        {
            Klient i = new Klient();

            if ( tbFamilia.Text == "" )
            {
                MessageBox.Show("Поле должен быть заполнен", "Проверка");
                return;
            }

            i.Name_klienta = tbFamilia.Text;
          //  i.LS = tbLs.Text;
           
                if (id == 0)
                {
                    KlientDao.Add(i);
                }
                else
                {
                    i.ID_klienta = id;
                    KlientDao.Update(i);
                }
                Close();
        
        }
    }
}
