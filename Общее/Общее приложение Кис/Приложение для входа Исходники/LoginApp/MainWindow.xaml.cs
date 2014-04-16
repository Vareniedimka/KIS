using System;
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
                                  "Вспомогательное производство" , "Финансы", "Управление персоналом", "Управление качеством","ТПП"};

        /// <summary>
        /// префикс для логина. должен соответствовать подсистеме 
        /// </summary>
        string[] prefixList = { "UZ/", "OsProi/", "Ma/", "VsP/", "Fin/", "UPer/", "UK/","TPP/" };

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
            cbPodSis.SelectedIndex = 0;
       
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        
            tbPrefix.Text = prefixList[cbPodSis.SelectedIndex];
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string connectString = "Data Source=" + server.Text + "; Initial Catalog=" + dataBase.Text + "; Integrated Security=true; User ID=" + /*tbPrefix.Text +*/ login.Text + ";Password=" + pass.Password;
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
                            pathApp = "OsPr\\Win.exe";
                            break;
                        }
                    case 3:
                        {
                            pathApp = "VSp\\win.exe";
                            break;
                        }
                    case 4:
                        {
                            pathApp = "Fin\\ERP_Fin.exe";
                            break;
                        }
                    case 5:
                        {
                            pathApp = "Up\\Win.exe";
                            break;
                        }
                    case 6:
                        {
                            pathApp = "UPer\\Win.exe";
                            break;
                        }
                    case 7:
                        {
                            pathApp = "Tpp\\OPrivetstviya.exe";
                            break;
                        }
                   

                }
                //запускаем нужное приложение с параметрамми
                System.Diagnostics.Process.Start(pathApp, server.Text + " " + dataBase.Text + " " + login.Text + " " + pass.Password);
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("неудача");
            }
            

            
        }

    
    }
}
