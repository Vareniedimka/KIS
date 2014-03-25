﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LoginApp
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// отображается в комбобоксе
        /// </summary>
        string[] podsistemList = { "Управление запасами", "Управление производством", "Маркетинг", 
                                  "Вспомогательное производство" , "Финансы", "Управление персоналом", "Управление качеством"};

        /// <summary>
        /// префикс для логина. должен соответствовать подсистеме 
        /// </summary>
        string[] prefixList = { "UZ/", "UPr/", "Ma/", "VsP/", "Fin/", "UPer/", "UK/" };

        /// <summary>
        /// Сохраняет бд и сервер
        /// </summary>
        public void ConnectSave() {
            ConnectInfo c = ConnectInfo.Default;
            c.dataBase = dataBase.Text;
            c.server = server.Text;
            c.Save();
        }

        public MainWindow()
        {
            InitializeComponent();
            //вводим сохранненые ранее данные сервера и бд
            dataBase.Text = ConnectInfo.Default.dataBase;
            server.Text = ConnectInfo.Default.server;
            cbPodSis.ItemsSource = podsistemList;
            pass.IsEnabled = false;
            login.IsEnabled = false;
            bOk.IsEnabled = false;
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            pass.IsEnabled = true;
            login.IsEnabled = true;
            bOk.IsEnabled = true;
            tbPrefix.Text = prefixList[cbPodSis.SelectedIndex];
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string connectString = "Data Source=" + server.Text + "; Initial Catalog=" + dataBase.Text + "; Integrated Security=true; User ID=" + tbPrefix.Text + login.Text + ";Password=" + pass.Password;
                SqlConnection sql = new SqlConnection(connectString);
                sql.Open();
                sql.Close();
                ConnectSave();
            }
            catch
            {
                MessageBox.Show("Соединиться не удалось");
            }
            try
            {
                //Запуск приложения
                string pathApp="";
                switch (cbPodSis.SelectedIndex)
                {
                    case 0:
                        {
                            //адрес запускаемого приложения
                            pathApp = "UZ\\Win.exe";
                            break;
                        }
                    case 1:
                        {
                            pathApp = "";
                            break;
                        }
                    default: { break; }
                }
                //запускаем нужное приложение с параметрамми
                System.Diagnostics.Process.Start(pathApp, server.Text + " " + dataBase.Text + " " + tbPrefix.Text + login.Text + " " + pass.Password);
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("неудача");
            }
            

            
        }
    }
}
