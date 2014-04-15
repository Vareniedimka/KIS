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
    /// Логика взаимодействия для addTovar.xaml
    /// </summary>
    public partial class AddPokupka : Window
    {
        int id;
        public AddPokupka()
        {
            InitializeComponent();
        }

        public AddPokupka(Pokupki tov)
        {
            InitializeComponent();
            tbname.Text = tov.Nomer_raschetnogo_platesha.ToString();
            tbstoim.Text = tov.Count.ToString();
            id = tov.ID_Pokupki;
        }

        private void bClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void bSave_Click(object sender, RoutedEventArgs e)
        {
            Pokupki tov = new Pokupki();
            if (tbname.Text == "")
            {
                MessageBox.Show("Введите номер счет", "Проверка");
                return;
            }
            tov.Nomer_raschetnogo_platesha = Convert.ToInt32(tbname.Text);
            tov.Count = Convert.ToInt32(tbstoim.Text);
  
            try
            {
                if (id == 0)
                {
                    PokupkiDao.Add(tov);
                }
                else
                {
                    tov.ID_Pokupki = id;
                    PokupkiDao.Update(tov);
                }
            }
            catch
            {
                MessageBox.Show("Счет с таким наименованием уже существует", "Проверка");
                return;
            }
            Close();
        }



    }
}
