using System;
using System.Windows;
using System.Windows.Controls;
using build;
using System.Collections.Generic;
using ClassLib;
namespace Web
{
    /// <summary>
    /// Логика взаимодействия для AddTovarnPlan.xaml
    /// </summary>
    public partial class AddTovarnPlan : Window
    {
        public AddTovarnPlan()
        {
            InitializeComponent();
            DateTime dt = DateTime.Now;
            tbDataProiz.Text = dt.ToString();
            InitializeComponent();
            loaded();
            loaded1();
        }
         int id;
       

        public AddTovarnPlan(TovarnPlan i)
        {
            
            InitializeComponent();
            cbImyaKlient.SelectedItem = i.KlientName;
            cbNaimenovanieDet.SelectedItem = i.NameIdDcE;
    
            tbCenaDetal.Text = i.Cena_detaly.ToString();
            tbDataProiz.Text = i.Data_proizv.ToString();
            tbKolichestvo.Text = i.Kolichestvo.ToString();
        
            tbObshayaStoim.Text = i.Obhaya_stoimos.ToString();
            tbPrioritet.Text = i.Prioritet;
            tbIdProduct.Text = i.ID_producta.ToString();

            id = i.ID_plana;
            loaded();
            loaded1();

        }

        private void bClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void bSave_Click(object sender, RoutedEventArgs e)
        {
            TovarnPlan i = new TovarnPlan();
            int? obshayastoim = null;
            int? kolichestvo = null;
            int? cenadet = null;
            if (string.IsNullOrEmpty(cbImyaKlient.Text))
            {
                MessageBox.Show("Поле \"Имя клиента\" клиента не должно быть пустым", "Проверка");
                return;
            }
            //Создаем объект для передачи данных

            if (string.IsNullOrEmpty(cbNaimenovanieDet.Text))
            {
                MessageBox.Show("Поле \"Наименование деталей\"  не должно быть пустым", "Проверка");
                return;
            }
         
            //Создаем объект для передачи данных

            int intCenaDetal;
            if (!int.TryParse(tbCenaDetal.Text, out intCenaDetal))
            {
                MessageBox.Show("Поле \"Цена деталей\" должен быть целым числом", "Проверка");
                return;
            }
            if (string.IsNullOrEmpty(tbDataProiz.Text))
            {
                MessageBox.Show("Поле \"Дата произведение \"  не должно быть пустым", "Проверка");
                return;
            }
            //Создаем объект для передачи данных
            int intKolichestvo;
            if (!int.TryParse(tbKolichestvo.Text, out intKolichestvo))
            {
                MessageBox.Show("Поле \"Количество\" должен быть целым числом", "Проверка");
                return;
            }
            int intObshayastoim;
            if (!int.TryParse(tbObshayaStoim.Text, out intObshayastoim))
            {
                MessageBox.Show("Поле \"Общая стоимость\" должен быть целым числом", "Проверка");
                return;
            }
            //Создаем объект для передачи данных

            
            if (string.IsNullOrEmpty(tbPrioritet.Text))
            {
                MessageBox.Show("Поле \"Приоритет \"  не должно быть пустым", "Проверка");
                return;
            }
            //Создаем объект для передачи данных

            if (string.IsNullOrEmpty(tbIdProduct.Text))
            {
                MessageBox.Show("Поле \"Айди  продукта\"  не должно быть пустым", "Проверка");
                return;
            }
            
             kolichestvo = intKolichestvo;
             obshayastoim= intObshayastoim;
             cenadet = intCenaDetal;
            //Заполняем объект данными
                i.KlientName= cbImyaKlient.Text;
                i.NameIdDcE =cbNaimenovanieDet.Text;
                i.Data_proizv = Convert.ToDateTime(tbDataProiz.Text);
                i.Prioritet = tbPrioritet.Text;
                i.Kolichestvo = Convert.ToInt32(tbKolichestvo.Text);
                i.Cena_detaly = Convert.ToInt32(tbCenaDetal.Text);
                i.Obhaya_stoimos = Convert.ToInt32(tbObshayaStoim.Text);
                i.Naimenovanie_produkta = "77";
                i.ID_producta = 12;
            
            //tbIdProduct.Text = i.ID_producta.ToString();
            
            //если это новый объект - сохраняем его

            try
            {
                if (id != 0)
                {
                    //Сохраняем  обращения
                    i.ID_plana = id;
                    TovarnPlanDao.Update(i);
                }
            
            
                else
                {
                    i.ID_zakaza = id;
                    //обновляем
                    TovarnPlanDao.Add(i);
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
            cbImyaKlient.ItemsSource = pocup;
            cbImyaKlient.SelectedIndex = 0;
        }
        private void loaded1()
        {
            //Инициализация комбобокса пациент
            IList<string> pocup = new List<string>();
            IList<СlassLib.DCE> l = DCEDao.GetAll();
            foreach (СlassLib.DCE poc in l)
            {
                pocup.Add(poc.Naimenovanie);
            }
            cbNaimenovanieDet.ItemsSource = pocup;
            cbNaimenovanieDet.SelectedIndex =0 ;
            
        }
       
    }
}
