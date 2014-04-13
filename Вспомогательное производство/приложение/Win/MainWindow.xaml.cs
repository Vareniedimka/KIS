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
using System.Windows.Navigation;
using System.Windows.Shapes;
using GLP;
using System.IO;
using System.Diagnostics;
using Microsoft.Win32;
using System.ComponentModel;
using Excel = Microsoft.Office.Interop.Excel;
using System.Reflection;
using VRA;
using ClassLibrary;
namespace Win
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string thisGrid = "dgDetdlyaremk";

      private void izmGrid()
        {
            dgDetdlyaremk.Visibility = dgStanok_na_proizv.Visibility = dgGraficRabot.Visibility = Visibility.Hidden;
            switch (thisGrid)
            {
                // R 
                case "dgDetdlyaremk":
                    {
                        dgDetdlyaremk.Visibility = Visibility.Visible;
                        break;
                    }
                // B 
                case "dgStanok_na_proizv":
                    {
                        dgStanok_na_proizv.Visibility = Visibility.Visible;
                        break;
                    }
                // M 
                case "dgGraficRabot":
                    {
                        dgGraficRabot.Visibility = Visibility.Visible;
                        break;
                    }
                 }
            bReload_Click(new object(), new RoutedEventArgs());
        }
        public MainWindow()
        {
            InitializeComponent();
            try
            {
                dgDetdlyaremk.ItemsSource = DetdlyaremDao.GetAll();
            }
            catch
            {
                MessageBox.Show("Не удалось подключится к базе данных", "Подключение");
                this.bConnect_Click(new object(), new RoutedEventArgs());
                try
                {
                    dgDetdlyaremk.ItemsSource = DetdlyaremDao.GetAll();
                }
                catch {
                }

            }
            statusLabel.Content = "Работа с таблицей: Покупатель";
        }

        private void bReload_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                switch (thisGrid)
                {
                    case "dgDetdlyaremk":
                        {
                            dgDetdlyaremk.ItemsSource = DetdlyaremDao.GetAll();
                            break;
                        }
                    case "dgGraficRabot":
                        {
                            dgGraficRabot.ItemsSource = GraficRabotDao.GetAll();
                            break;
                        }
                    case "dgStanok_na_proizv":
                        {
                            dgStanok_na_proizv.ItemsSource = Stanok_na_proizvDao.GetAll();
                            break;
                        }
                   
                }
            }
            catch {

                MessageBox.Show("Не удалось подключится к базе данных", "Подключение");
                this.bConnect_Click(new object(), new RoutedEventArgs());
                //dgDetdlyarem.ItemsSource = DetdlyaremDao.GetAll();
            }

        }

        private void bEdit_Click(object sender, RoutedEventArgs e)
        {
            switch (thisGrid)
            {
                case "dgGraficRabot":
                    {
                        try
                        {
                            AddGraficRabot win = new AddGraficRabot(dgGraficRabot.SelectedItem as GraficRabot);
                            win.ShowDialog();
                           // bDetdlyarem_Click(sender, e);
                        }
                        catch (NullReferenceException)
                        {
                            MessageBox.Show("Выберете запись");
                        }
                        break;
                    }
                case "dgStanok_na_proizv":
                    {
                        try
                        {
                            AddStanok_na_proizv win = new AddStanok_na_proizv(dgStanok_na_proizv.SelectedItem as Stanok_na_proizv);
                            win.ShowDialog();
                            bReload_Click(sender, e);
                        }
                        catch (NullReferenceException)
                        {
                            MessageBox.Show("Выберете запись");
                        }
                        break;
                    }
                         case "dgDetdlyaremk":
                    {
                        try
                        {
                            AddDetdlyarem win = new AddDetdlyarem(dgDetdlyaremk.SelectedItem as Detdlyarem);
                            win.ShowDialog();
                            bReload_Click(sender, e);
                        }
                        catch (NullReferenceException)
                        {
                            MessageBox.Show("Выберете запись");
                        }
                        break;}
            }}
                
                
           

        
        private void bAdd_Click(object sender, RoutedEventArgs e)
        {
            switch (thisGrid)
            {
                case "dgStanok_na_proizv":
                    {
                        AddStanok_na_proizv win = new AddStanok_na_proizv();
                        win.ShowDialog();
                        break;
                    }
                case "dgDetdlyaremk":
                    {
                        AddDetdlyarem win = new AddDetdlyarem();
                        win.ShowDialog();
                        break;
                    }
                case "dgGraficRabot":
                    {
                        AddGraficRabot win = new AddGraficRabot();
                        win.ShowDialog();
                        break;
                    }
                
            }
            bReload_Click(sender, e);
        }
        private void bDelet_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                switch (thisGrid)
                {
                    case "dgDetdlyaremk":
                        {
                            try
                            {
                                DetdlyaremDao.Delete(dgDetdlyaremk.SelectedItem as Detdlyarem);

                            }
                            catch (NullReferenceException)
                            {
                                MessageBox.Show("Выберете запись");
                            }
                            break;
                        }
                    case "dgGraficRabot":
                        {
                            try
                            {
                                GraficRabotDao.Delete(dgGraficRabot.SelectedItem as GraficRabot);

                            }
                            catch (NullReferenceException)
                            {
                                MessageBox.Show("Выберете запись");
                            }
                            break;
                        }
                    case "dgStanok_na_proizv":
                        {
                            try
                            {
                                Stanok_na_proizvDao.Delete(dgStanok_na_proizv.SelectedItem as Stanok_na_proizv);

                            }
                            catch (NullReferenceException)
                            {
                                MessageBox.Show("Выберете запись");
                            }
                            break;
                        }
                    
                    
                    

                }
                bReload_Click(sender, e);
            }
            catch
            {
                MessageBox.Show("Не удалось удалить запись", "Удаление");
            }
        }

        private void bConnect_Click(object sender, RoutedEventArgs e)
        {
            ConnectWin conn = new ConnectWin();
            conn.ShowDialog();
            
        }

        private void HtmlExporterButton_Click(object sender, RoutedEventArgs e)
        {
            
        }
        private void ExelExporterButton_Click(object sender, RoutedEventArgs e)
        {                             
            }

            

        private void dgZapas_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        
        }

         


        

        private void About_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(
@"Программа создана в рамках Предмета КИС 
Дата создания 16.03.2014"
            );
        }

        private void bDetdlyarem_Click(object sender, RoutedEventArgs e)
        {
            thisGrid = "dgDetdlyaremk";
            izmGrid();
        }
        private void bGraficRabot_Click(object sender, RoutedEventArgs e)
        {
            thisGrid ="bGraficRabot";
            izmGrid();

        }
        private void bStanok_na_proizv_Click(object sender, RoutedEventArgs e)
        {
            thisGrid =  "bStanok_na_proizv" ;
            izmGrid();
        }
        
        
              
        private void bFind_Click(object sender, RoutedEventArgs e)
        {
            DataGrid b = new DataGrid();
            switch (thisGrid)
            {
                case "dgDetdlyaremk":
                    b = dgDetdlyaremk;
                    break;
                case "dgGraficRabot":
                    b = dgGraficRabot;
                    break;
                case "dgStanok_na_proizv":
                    b = dgStanok_na_proizv;
                    break;
                
            }
            Form1 f = new Form1(b);
            f.ShowDialog();
           // bDetdlyarem = b;

        }

       
    }
}