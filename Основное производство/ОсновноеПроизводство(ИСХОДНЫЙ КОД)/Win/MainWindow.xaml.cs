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
using ClassBD;
using OPDao;
using System.IO;
using System.Diagnostics;
using Microsoft.Win32;
using System.ComponentModel;
using System.Reflection;
using System.Data.SqlClient;

namespace Win
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string thisGrid = "dgIzg_SE";

        public MainWindow()
        {
            InitializeComponent();
             try
            {
                //DK13-06\SQLEXPRESS
                string DS = "DK13-06\\SQLEXPRESS"; //Заполнить для базы
                string IC = "OP";//имя базы
                string IS = "true";
                string user = "KIS";
                //s = "Data Source=" + tbServer.Text + "; Initial Catalog=" + tbBD.Text + ";";
                string s = "Data Source=" + DS + "; Initial Catalog=" + IC + ";Integrated Security=" + IS + ";";//"User ID=" + user + ";Password=" + "1" ;
                SqlConnection sql = new SqlConnection(s);
                sql.Open();
                sql.Close(); //Для проверки соеденения
                OPDao.Connect.ConnectSave(s);
            }
            catch 
            {
                MessageBox.Show("Соеденение с базой не удалось");
            }
            try
            {
                dgIzg_SE.ItemsSource = Izg_SEDAO.GetAll();
            }
            catch
            {
                MessageBox.Show("Не удалось подключится к базе данных", "Подключение");
                //this.bConnect_Click(new object(), new RoutedEventArgs());
                try
                {
                    //dgPostavhik.ItemsSource = Izg_SEDAO.GetAll();
                }
                catch
                {
                }

            }
            statusLabel.Content = "Работа с таблицей: Изготовление Сборочной единицы";
        }

        private void bReload_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                switch (thisGrid)
                {
                    case "dgIzg_SE":
                        {
                            dgIzg_SE.ItemsSource = Izg_SEDAO.GetAll();
                            break;
                        }
                    case "dgMeshcex_plan":
                        {
                            dgMeshcex_plan.ItemsSource = Meshcex_planDAO.GetAll();
                            break;
                        }
                    case "dgOperaciy_SZ":
                        {
                            dgOperaciy_SZ.ItemsSource = Operaciy_SZDAO.GetAll();
                            break;
                        }
                    case "dgOtchet_o_vip_tov_plan":
                        {
                            dgOtchet_o_vip_tov_plan.ItemsSource = Otchet_o_vip_tov_planDAO.GetAll();
                            break;
                        }
                    case "dgPlan_mehan_cexa":
                        {
                            dgPlan_mehan_cexa.ItemsSource = Plan_mehan_cexaDAO.GetAll();
                            break;
                        }
                    case "dgPlan_sbor_cexa":
                        {
                            dgPlan_sbor_cexa.ItemsSource = Plan_sbor_cexaDAO.GetAll();
                            break;
                        }
                    case "dgSmenno_sut_zad":
                        {
                            dgSmenno_sut_zad.ItemsSource = Smenno_sut_zadDAO.GetAll();
                            break;
                        }
                    case "dgStrahov_zadel":
                        {
                            dgStrahov_zadel.ItemsSource = Strahov_zadelDAO.GetAll();
                            break;
                        }

                }
            }
            catch
            {

                MessageBox.Show("Не удалось подключится к базе данных", "Подключение");
              //  this.bConnect_Click(new object(), new RoutedEventArgs());
                //dgPostavhik.ItemsSource = PostavhikDao.GetAll();
            }

        }

        private void bEdit_Click(object sender, RoutedEventArgs e)
        {
            switch (thisGrid)
            {
                case "dgIzg_SE":
                    {
                        try
                        {
                            AddIzg_SE win = new AddIzg_SE(dgIzg_SE.SelectedItem as Izg_SE );
                            win.ShowDialog();
                            bReload_Click(sender, e);
                        }
                        catch (NullReferenceException)
                        {
                            MessageBox.Show("Выберете запись");
                        }
                        break;
                    }
                case "dgMeshcex_plan":
                    {
                        try
                        {
                            AddPlan_mehan_cexa win = new AddPlan_mehan_cexa(dgPlan_mehan_cexa.SelectedItem as Plan_mehan_cexa);
                            win.ShowDialog();
                            bReload_Click(sender, e);
                        }
                        catch (NullReferenceException)
                        {
                            MessageBox.Show("Выберете запись");
                        }
                        break;
                    }
                case "dgOperaciy_SZ":
                    {
                        try
                        {
                            AddOperaciy_SZ win = new AddOperaciy_SZ(dgOperaciy_SZ.SelectedItem as Operaciy_SZ);
                            win.ShowDialog();
                            bReload_Click(sender, e);
                        }
                        catch (NullReferenceException)
                        {
                            MessageBox.Show("Выберете запись");
                        }
                        break;
                    }
                case "dgOtchet_o_vip_tov_plan":
                    {
                        try
                        {
                            AddOtchet_o_vip_tov_plan win = new AddOtchet_o_vip_tov_plan(dgOtchet_o_vip_tov_plan.SelectedItem as Otchet_o_vip_tov_plan);
                            win.ShowDialog();
                            bReload_Click(sender, e);
                        }
                        catch (NullReferenceException)
                        {
                            MessageBox.Show("Выберете запись");
                        }
                        break;
                    }
                case "dgPlan_mehan_cexa":
                    {
                        try
                        {
                            AddPlan_mehan_cexa win = new AddPlan_mehan_cexa(dgPlan_mehan_cexa.SelectedItem as Plan_mehan_cexa);
                            win.ShowDialog();
                            bReload_Click(sender, e);
                        }
                        catch (NullReferenceException)
                        {
                            MessageBox.Show("Выберете запись");
                        }
                        break;
                    }
                case "dgPlan_sbor_cexa":
                    {
                        try
                        {
                            AddPlan_sbor_cexa win = new AddPlan_sbor_cexa(dgPlan_sbor_cexa.SelectedItem as Plan_sbor_cexa);
                            win.ShowDialog();
                            bReload_Click(sender, e);
                        }
                        catch (NullReferenceException)
                        {
                            MessageBox.Show("Выберете запись");
                        }
                        break;
                    }
                case "Smenno_sut_zad":
                    {
                        try
                        {
                            AddSmenno_sut_zad win = new AddSmenno_sut_zad(dgSmenno_sut_zad.SelectedItem as Smenno_sut_zad);
                            win.ShowDialog();
                            bReload_Click(sender, e);
                        }
                        catch (NullReferenceException)
                        {
                            MessageBox.Show("Выберете запись");
                        }
                        break;
                    }
                case "Strahov_zadel":
                    {
                        try
                        {
                            AddStrahov_zadel win = new AddStrahov_zadel(dgStrahov_zadel.SelectedItem as Strahov_zadel);
                            win.ShowDialog();
                            bReload_Click(sender, e);
                        }
                        catch (NullReferenceException)
                        {
                            MessageBox.Show("Выберете запись");
                        }
                        break;
                    }
            }

        }
        private void bAdd_Click(object sender, RoutedEventArgs e)
        {
            switch (thisGrid)
            {
                case "dgIzg_SE":
                    {
                        AddIzg_SE win = new AddIzg_SE();
                        win.ShowDialog();
                        break;
                    }
                case "dgPlan_mehan_cexa":
                    {
                        AddPlan_mehan_cexa win = new AddPlan_mehan_cexa();
                        win.ShowDialog();
                        break;
                    }
                case "dgOperaciy_SZ":
                    {
                        AddOperaciy_SZ win = new AddOperaciy_SZ();
                        win.ShowDialog();
                        break;
                    }
                case "dgOtchet_o_vip_tov_plan":
                    {
                        AddOtchet_o_vip_tov_plan win = new AddOtchet_o_vip_tov_plan();
                        win.ShowDialog();
                        break;
                    }
                case "dgMeshcex_plan":
                    {
                        AddMeshcex_plan win = new AddMeshcex_plan();
                        win.ShowDialog();
                        break;
                    }
                case "dgPlan_sbor_cexa":
                    {
                        AddPlan_sbor_cexa win = new AddPlan_sbor_cexa();
                        win.ShowDialog();
                        break;
                    }

                case "Smenno_sut_zad":
                    {
                        AddSmenno_sut_zad win = new AddSmenno_sut_zad();
                        win.ShowDialog();
                        break;
                    }
                case "Strahov_zadel":
                    {
                        AddStrahov_zadel win = new AddStrahov_zadel();
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
                    case "dgIzg_SE":
                        {
                            try
                            {
                                Izg_SEDAO.Delete((dgIzg_SE.SelectedItem as Izg_SE).Nomer_izg_det);

                            }
                            catch (NullReferenceException)
                            {
                                MessageBox.Show("Выберете запись");
                            }
                            break;
                        }
                    case "dgMeshcex_plan":
                        {
                            try
                            {
                                Meshcex_planDAO.Delete((dgMeshcex_plan.SelectedItem as Meshcex_plan).Data_nach_vip_plan_na_mesyc);

                            }
                            catch (NullReferenceException)
                            {
                                MessageBox.Show("Выберете запись");
                            }
                            break;
                        }
                    case "dgOperaciy_SZ":
                        {
                            try
                            {
                                Operaciy_SZDAO.Delete((dgOperaciy_SZ.SelectedItem as Operaciy_SZ).ID_operacii);

                            }
                            catch (NullReferenceException)
                            {
                                MessageBox.Show("Выберете запись");
                            }
                            break;
                        }
                    case "dgOtchet_o_vip_tov_plan":
                        {
                            {
                                try
                                {
                                    Otchet_o_vip_tov_planDAO.Delete((dgOtchet_o_vip_tov_plan.SelectedItem as Otchet_o_vip_tov_plan).Data_eshednevno);

                                }
                                catch (NullReferenceException)
                                {
                                    MessageBox.Show("Выберете запись");
                                }
                                break;
                            }
                        }
                    case "dgPlan_mehan_cexa":
                        {
                            try
                            {
                                Plan_mehan_cexaDAO.Delete((dgPlan_mehan_cexa.SelectedItem as Plan_mehan_cexa).Data_nach_vip_plan);

                            }
                            catch (NullReferenceException)
                            {
                                MessageBox.Show("Выберете запись");
                            }
                            break;
                        }
                    case "dgPlan_sbor_cexa":
                        {
                            try
                            {
                                Plan_sbor_cexaDAO.Delete((dgPlan_sbor_cexa.SelectedItem as Plan_sbor_cexa).Data_nach_vip_plan);

                            }
                            catch (NullReferenceException)
                            {
                                MessageBox.Show("Выберете запись");
                            }
                            break;
                        }

                    case "Smenno_sut_zad":
                        {
                            try
                            {
                                Smenno_sut_zadDAO.Delete((dgSmenno_sut_zad.SelectedItem as Smenno_sut_zad).Nomer_SSZ);
                            }
                            catch (NullReferenceException)
                            {
                                MessageBox.Show("Выберете запись");
                            }
                            break;
                        }
                    case "Strahov_zadel":
                        {
                            try
                            {
                                Strahov_zadelDAO.Delete((dgStrahov_zadel.SelectedItem as Strahov_zadel).Data_strahovogo_zadela);
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

       

        private void HtmlExporterButton_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            //save.Filter = "|*.html";
            save.AddExtension = true;
            save.DefaultExt = ".html";
            save.OverwritePrompt = true;
            //save.FilterIndex = 0;
            if (save.ShowDialog() == true)
            {

                DataGrid dg = new DataGrid();
                switch (thisGrid)
                {
                    case "dgIzg_SE":
                        dg = dgIzg_SE;
                        break;
                    case "dgMeshcex_plan":
                        dg = dgMeshcex_plan;
                        break;
                    case "dgOperaciy_SZ":
                        dg = dgOperaciy_SZ;
                        break;
                    case "dgOtchet_o_vip_tov_plan":
                        dg = dgOtchet_o_vip_tov_plan;
                        break;
                    case "dgPlan_mehan_cexa":
                        {
                            dg = dgPlan_mehan_cexa;
                            break;
                        }
                    case "dgPlan_sbor_cexa":
                        {
                            dg = dgPlan_sbor_cexa;
                            break;
                        }

                    case "Smenno_sut_zad":
                        {
                            dg = dgSmenno_sut_zad;
                            break;
                        }
                    case "Strahov_zadel":
                        {
                            dg = dgStrahov_zadel;
                            break;
                        }
                }
                dg.SelectAllCells();
                dg.ClipboardCopyMode = DataGridClipboardCopyMode.IncludeHeader;
                ApplicationCommands.Copy.Execute(null, dg);
                dg.UnselectAllCells();
                //string path1 = @"C:\otchet.html";
                string result1 = (string)Clipboard.GetText(TextDataFormat.Html);
                string s = "<style type=\"text/css\">TABLE  {border: 2px solid Black;margin: auto;}TD{border: 2px solid Black;}</style>";
                Clipboard.Clear();
                StreamWriter stream = new StreamWriter(save.OpenFile(), Encoding.UTF8);

                // new StreamWriter(save.FileName, false, Encoding.UTF8);
                result1 = result1.Replace("<HTML>", "--><HTML>");
                stream.WriteLine(s + "<!--" + result1);

                stream.Close();
                Process.Start(save.FileName);
            };
        }
       
    

        private void About_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(
@"Программа создана в рамках Предмета КИС 
Дата создания 16.03.2014"
            );
        }

        private void bIzg_SE_Click(object sender, RoutedEventArgs e)
        {
            thisGrid = "dgIzg_SE";
            izmGrid();
        }
        private void bMeshcex_plan_Click(object sender, RoutedEventArgs e)
        {
            thisGrid = "dgMeshcex_plan";
            izmGrid();

        }
        private void bOperaciy_SZ_Click(object sender, RoutedEventArgs e)
        {
            thisGrid = "dgOperaciy_SZ";
            izmGrid();
        }
        private void bOtchet_o_vip_tov_plan_Click(object sender, RoutedEventArgs e)
        {
            thisGrid = "dgOtchet_o_vip_tov_plan";
            izmGrid();
        }
        private void bPlan_mehan_cexa_Click(object sender, RoutedEventArgs e)
        {
            thisGrid = "dgPlan_mehan_cexa";
            izmGrid();
        }
        private void bPlan_sbor_cexa_Click(object sender, RoutedEventArgs e)
        {
            thisGrid = "dgPlan_sbor_cexa";
            izmGrid();
        }
        private void bSmenno_sut_zad_Click(object sender, RoutedEventArgs e)
        {
            thisGrid = "Smenno_sut_zad";
            izmGrid();
        }
        private void bStrahov_zadel_Click(object sender, RoutedEventArgs e)
        {
            thisGrid = "Strahov_zadel";
            izmGrid();
        }

        private void izmGrid()
        {
            dgIzg_SE.Visibility = dgMeshcex_plan.Visibility = dgOperaciy_SZ.Visibility = dgOtchet_o_vip_tov_plan.Visibility = dgPlan_mehan_cexa.Visibility = dgPlan_sbor_cexa.Visibility = dgSmenno_sut_zad.Visibility = dgStrahov_zadel.Visibility = dgStrahov_zadel.Visibility = Visibility.Hidden;
            switch (thisGrid)
            {
                case "dgIzg_SE":
                    {
                        dgIzg_SE.Visibility = Visibility.Visible;
                        statusLabel.Content = "Работа с таблицей: Изготовление сборочной единицы";
                        break;

                    }
                case "dgMeshcex_plan":
                    {
                        dgMeshcex_plan.Visibility = Visibility.Visible;
                        statusLabel.Content = "Работа с таблицей: Межцеховой план";
                        break;
                    }
                case "dgOtchet_o_vip_tov_plan":
                    {
                        dgOtchet_o_vip_tov_plan.Visibility = Visibility.Visible;
                        statusLabel.Content = "Работа с таблицей: Отчет о выполнении товарного плана";
                        break;
                    }
                case "dgPlan_mehan_cexa":
                    {
                        dgPlan_mehan_cexa.Visibility = Visibility.Visible;
                        statusLabel.Content = "Работа с таблицей: План механического цеха";
                        break;
                    }
                case "dgPlan_sbor_cexa":
                    {
                        dgPlan_sbor_cexa.Visibility = Visibility.Visible;
                        statusLabel.Content = "Работа с таблицей: План сборочного цеха";
                        break;
                    }
                case "dgOperaciy_SZ":
                    {
                        dgOperaciy_SZ.Visibility = Visibility.Visible;
                        statusLabel.Content = "Работа с таблицей: Операции";
                        break;
                    }
                case "Smenno_sut_zad":
                    {
                        dgSmenno_sut_zad.Visibility = Visibility.Visible;
                        statusLabel.Content = "Работа с таблицей: Сменно - суточное задание";
                        break;
                    }
                case "Strahov_zadel":
                    dgStrahov_zadel.Visibility = Visibility.Visible;
                    statusLabel.Content = "Работа с таблицей: Страховой задел";
                    break;
            }
            bReload_Click(null, null);
            }
          
         

        private void bFind_Click(object sender, RoutedEventArgs e)
        {
            DataGrid dg = new DataGrid();
            switch (thisGrid)
            {
                case "dgIzg_SE":
                    dg = dgIzg_SE;
                    break;
                case "dgMeshcex_plan":
                    dg = dgMeshcex_plan;
                    break;
                case "dgOperaciy_SZ":
                    dg = dgOperaciy_SZ;
                    break;
                case "dgOtchet_o_vip_tov_plan":
                    dg = dgOtchet_o_vip_tov_plan;
                    break;
                case "dgPlan_mehan_cexa":
                    dg = dgPlan_mehan_cexa;
                    break;
                case "dgPlan_sbor_cexa":
                    dg = dgPlan_sbor_cexa;
                    break;
                case "Smenno_sut_zad":
                    dg = dgSmenno_sut_zad;
                    break;
               case "Strahov_zadel":
                    dg = dgStrahov_zadel;
                     break;    
            }
            
            //f.ShowDialog();
            dgIzg_SE = dg;

        }

       
    }
}

