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
        string thisGrid = "dgRabociy";

        public MainWindow()
        {
            InitializeComponent();
            //получаем параметры запуска
            var args = Environment.GetCommandLineArgs();
            //Вводим параметры подключения
            Connect.setConnectInfo(args[1], args[2], args[3], args[4]);
           
            try
            {
                dgRabociy.ItemsSource =   RabociyDao.GetAll();
            }
            catch
            {
              //  MessageBox.Show("Не удалось подключится к базе данных", "Подключение");
               // this.bConnect_Click(new object(), new RoutedEventArgs());
                try
                {
                    dgRabociy.ItemsSource = RabociyDao.GetAll();
                }
                catch {
                }

            }
            statusLabel.Content = "Работа с таблицей: Рабочий";
        }

        private void bReload_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                switch (thisGrid)
                {
                    case "dgRabociy":
                        {
                            dgRabociy.ItemsSource =  RabociyDao.GetAll();
                            break;
                        }
                    case "dgProfessii":
                        {
                            dgProfessii.ItemsSource =  ProfessiiDao.GetAll();
                            break;
                        }
                    case "dgZarplatnay_vedom":
                        {
                            dgZarplatnay_vedom.ItemsSource = Zarplatnay_vedomDao.GetAll();
                            break;
                        }
                                           
                }
            }
            catch {

                MessageBox.Show("Не удалось подключится к базе данных", "Подключение");
                //this.bConnect_Click(new object(), new RoutedEventArgs());
                //dgPostavhik.ItemsSource = PostavhikDao.GetAll();
            }

        }

        private void bEdit_Click(object sender, RoutedEventArgs e)
        {
            switch (thisGrid)
            {
                case "dgProfessii":
                    {
                        try
                        {
                            Addprofessii win = new Addprofessii(dgProfessii.SelectedItem as Professii);
                            win.ShowDialog();
                            bReload_Click(sender, e);
                        }
                        catch (NullReferenceException)
                        {
                            MessageBox.Show("Выберете запись");
                        }
                        break;
                    }
                case "dgRabociy":
                    {
                        try
                        {
                            AddRabociy win = new AddRabociy(dgRabociy.SelectedItem as Rabociy);
                            win.ShowDialog();
                            bReload_Click(sender, e);
                        }
                        catch (NullReferenceException)
                        {
                            MessageBox.Show("Выберете запись");
                        }
                        break;
                    }
                case "dgZarplatnay_vedom":
                    {
                        try
                        {
                            AddZarplatnay_vedom win = new AddZarplatnay_vedom(dgZarplatnay_vedom.SelectedItem as Zarplatnay_vedom);
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
                case "dgRabociy":
                    {
                        AddRabociy win = new AddRabociy();
                        win.ShowDialog();
                        break;
                    }
                case "dgProfessii":
                    {
                        Addprofessii win = new Addprofessii();
                        win.ShowDialog();
                        break;
                    }
                case "dgZarplatnay_vedom":
                    {
                        AddZarplatnay_vedom win = new AddZarplatnay_vedom();
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
                    case "dgRabociy":
                        {
                            try
                            {
                                RabociyDao.Delete((dgRabociy.SelectedItem as Rabociy));

                            }
                            catch (NullReferenceException)
                            {
                                MessageBox.Show("Выберете запись");
                            }
                            break;
                        }
                    case "dgProfessii":
                        {
                            try
                            {
                                ProfessiiDao.Delete((dgProfessii.SelectedItem as Professii).ID_professii);

                            }
                            catch (NullReferenceException)
                            {
                                MessageBox.Show("Выберете запись");
                            }
                            break;
                        }
                    case "dgZarplatnay_vedom":
                        {
                            try
                            {
                                Zarplatnay_vedomDao.Delete((dgZarplatnay_vedom.SelectedItem as Zarplatnay_vedom));

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
           // ConnectWin conn = new ConnectWin();
          //  conn.ShowDialog();
            System.Diagnostics.Process.Start("LoginApp.exe");
            Close();
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
                    case "dgRabociy":
                        dg = dgRabociy;
                        break;
                    case "dgProfessii":
                        dg = dgProfessii;
                        break;
                    case "dgZarplatnay_vedom":
                        dg = dgZarplatnay_vedom;
                        break;
                   
                }
                dg.SelectAllCells();
                dg.ClipboardCopyMode = DataGridClipboardCopyMode.IncludeHeader;
                ApplicationCommands.Copy.Execute(null, dg);
                dg.UnselectAllCells();
                //string path1 = @"C:\otchet.html";
                string result1 = (string)Clipboard.GetText(TextDataFormat.Html);
                string s = "<style type=\"text/css\">TABLE  {border: 2px solid Black;margin: auto;}TD{border: 2px solid Black;}</style>";
                Clipboard.Clear();
                StreamWriter stream = new StreamWriter(save.OpenFile(),Encoding.UTF8);
              
                // new StreamWriter(save.FileName, false, Encoding.UTF8);
                result1=result1.Replace("<HTML>", "--><HTML>");
                stream.WriteLine(s +"<!--"+ result1);
                
                stream.Close();
                Process.Start(save.FileName);
            };
        }
        private void ExelExporterButton_Click(object sender, RoutedEventArgs e)
        {
            Excel.Application app = new Excel.Application();//создается приложение
            Excel.Workbook book = app.Workbooks.Add();//создается книга
            Excel.Worksheet sheet = (Excel.Worksheet)book.Sheets[1];//создается страница

            DataGrid dg = new DataGrid();
            switch (thisGrid)//в зависимости от того какая таблица используется сейчас выбирается datdGrid
            {
                case "dgRabociy":
                    dg = dgRabociy;
                    break;
                case "dgProfessii":
                    dg = dgProfessii;
                    break;
                case "dgZarplatnay_vedom":
                    dg = dgZarplatnay_vedom;
                    break;
                
            }

            dg.SelectAllCells();//выделяются все ячейки в dataGrid
            dg.ClipboardCopyMode = DataGridClipboardCopyMode.IncludeHeader;
            ApplicationCommands.Copy.Execute(null, dg);//выделенное копируется в буфер
            dg.UnselectAllCells();//снимается выделение
            sheet.Paste(sheet.Range["A1"]);   // вставляются на страницу в excel 
            //дальше выделяются рамки в excel
            /*sheet.Range["A1:" + (char)('A' + dg.Columns.Count - 1) + (dg.Items.Count - 2)].Borders[Excel.XlBordersIndex.xlInsideHorizontal].LineStyle = Excel.XlLineStyle.xlContinuous;
            sheet.Range["A1:" + (char)('A' + dg.Columns.Count - 1) + (dg.Items.Count - 2)].Borders[Excel.XlBordersIndex.xlInsideVertical].LineStyle = Excel.XlLineStyle.xlContinuous;
            sheet.Range["A1:" + (char)('A' + dg.Columns.Count - 1) + (dg.Items.Count - 2)].Borders[Excel.XlBordersIndex.xlEdgeLeft].Weight = 3;
            sheet.Range["A1:" + (char)('A' + dg.Columns.Count - 1) + (dg.Items.Count - 2)].Borders[Excel.XlBordersIndex.xlEdgeTop].Weight = 3;
            sheet.Range["A1:" + (char)('A' + dg.Columns.Count - 1) + (dg.Items.Count - 2)].Borders[Excel.XlBordersIndex.xlEdgeRight].Weight = 3;
            sheet.Range["A1:" + (char)('A' + dg.Columns.Count - 1) + (dg.Items.Count - 2)].Borders[Excel.XlBordersIndex.xlEdgeBottom].Weight = 3;*/
            Clipboard.Clear();//Очищается буфер обмена
            //sheet.Columns.NumberFormat = "@";//устанавливается текстовый формат ячеек
            sheet.Columns.RowHeight = 20;//высота ячеек 20
            sheet.Columns.AutoFit();//авто подбор ширины
            app.Visible = true; //сделать excel видимым


        }

        private void About_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(
@"Программа создана в рамках Предмета КИС 
Дата создания 10.04.2014"
            );
        }

        private void bZakaz_Click(object sender, RoutedEventArgs e)
        {
            thisGrid = "dgRabociy";
            izmGrid();
        }
        private void bPostavhik_Click(object sender, RoutedEventArgs e)
        {
            thisGrid = "dgProfessii";
            izmGrid();

        }
        private void bMaterial_Click(object sender, RoutedEventArgs e)
        {
             thisGrid = "dgZarplatnay_vedom";
            izmGrid();
        }
        
       
       

        private void izmGrid()
        {
            dgRabociy.Visibility = dgProfessii.Visibility = dgZarplatnay_vedom.Visibility = Visibility.Hidden;
            switch (thisGrid)
            {
                case "dgRabociy":
                    {
                        dgRabociy.Visibility = Visibility.Visible;
                        statusLabel.Content = "Работа с таблицей: Рабочий";
                        break;
                        
                    }
                case "dgProfessii":
                    {
                        dgProfessii.Visibility = Visibility.Visible;
                        statusLabel.Content = "Работа с таблицей: Профессии";
                        break;
                    }
                case "dgZarplatnay_vedom":
                    {
                        dgZarplatnay_vedom.Visibility = Visibility.Visible;
                        statusLabel.Content = "Работа с таблицей: Запрлатная ведомость";
                        break;
                    }
               
            }
            bReload_Click(new object(), new RoutedEventArgs());
        }
        
        private void bFind_Click(object sender, RoutedEventArgs e)
        {
            DataGrid dg = new DataGrid();
            switch (thisGrid)
            {
                case "dgRabociy":
                    dg = dgRabociy;
                    break;
                case "dgProfessii":
                    dg = dgProfessii;
                    break;
                case "dgZarplatnay_vedom":
                    dg = dgZarplatnay_vedom;
                    break;
               
            }
            Form1 f = new Form1(dg);
            f.ShowDialog();
            dgRabociy = dg;

        }

        
    }
}