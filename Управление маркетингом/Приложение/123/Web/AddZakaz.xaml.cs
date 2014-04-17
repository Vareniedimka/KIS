using System;
using System.Windows;
using System.Windows.Controls;
using build;
using System.Collections.Generic;
using СlassLib;
using ClassLib;

namespace Web
{
    /// <summary>
    /// Логика взаимодействия для AddZakaz.xaml
    /// </summary>
    public partial class AddZakaz : Window
    {   
         int id;
        public AddZakaz()
        {
            InitializeComponent();
            loaded();
            loaded1();
        }

        public AddZakaz(Zakaz i)
        {
            
            InitializeComponent();
            cbNaimenovanie.SelectedItem = i.NaimenovanieDCE;
            cbNameKlient.SelectedItem = i.KlientName;
            tbAvans.Text = i.Avans.ToString() ;
            id = i.ID_zakaza;
            loaded();
            loaded1();
        }

        private void bClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void bSave_Click(object sender, RoutedEventArgs e)
        {
            Zakaz s = new Zakaz();
            int? death = null;
            if (string.IsNullOrEmpty(cbNaimenovanie.Text))
            {
                MessageBox.Show("Поле \"ФИО\" клиента не должно быть пустым", "Проверка");
                return;
            }
            //Создаем объект для передачи данных

            if (string.IsNullOrEmpty(cbNameKlient.Text))
            {
                MessageBox.Show("Поле \"Наименование\"  не должно быть пустым", "Проверка");
                return;
            }
            int intDeath;
            if (!int.TryParse(tbAvans.Text, out intDeath))
            {
                MessageBox.Show("Поле \"Аванс\" должен быть целым числом", "Проверка");
                return;
            }

            death = intDeath;
            //Заполняем объект данными
            s.Avans = Convert.ToInt32(tbAvans.Text);
            s.KlientName = cbNameKlient.SelectedItem.ToString();
            s.NaimenovanieDCE = cbNaimenovanie.SelectedItem.ToString();
            
            //если это новый объект - сохраняем его

            try
            {
                if (id == 0)
                {
                    s.ID_zakaza = id;
                    //обновляем
                    ZakazDao.Add(s);
                    
                }
            
            
                else
                {//Сохраняем  обращения
                    s.ID_zakaza = id;
                    ZakazDao.Update(s);
                   
                }//и закрываем форму
                Close();
             }
             catch
            {
                MessageBox.Show("Не удалось внести изменения в БД,\nпожелуйста проверьте введенные данные", "Ошибка");
            }

        }
        private void loaded()
        {
            //Инициализация комбобокса пациент
            IList<string> pocup = new List<string>();
            IList<Klient> l = KlientDao.GetAll();
            foreach (Klient poc in l)
            {
                pocup.Add(poc.Name_klienta);
            }
            cbNameKlient.ItemsSource = pocup;
            cbNameKlient.SelectedIndex = 0;
        }
        private void loaded1()
        {
            //Инициализация комбобокса пациент
            IList<string> pocup = new List<string>();
            IList<DCE> l = DCEDao.GetAll();
            foreach (DCE poc in l)
            {
                pocup.Add(poc.Naimenovanie);
            }
            cbNaimenovanie.ItemsSource = pocup;
            cbNaimenovanie.SelectedIndex = 0;
        }

        private void tbAvans_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
