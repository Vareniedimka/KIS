using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using build;
using ClassLib;
using Excel = Microsoft.Office.Interop.Excel;
using Form = System.Windows.Forms;
using System.Collections.Generic;
namespace Web
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Указывает чаровский тип для управлаении датагрид.
        /// </summary>
        char thisGrid = 'K';

        public MainWindow()
        {
            InitializeComponent();
            
            //получаем параметры запуска
            var args = Environment.GetCommandLineArgs();
            //Вводим параметры подключения
            Connect.setConnectInfo(args[1], args[2], args[3], args[4]);
            
            dgKlient.Visibility = Visibility.Visible;

            // Панель показывает с какой таблице мы работаем 
            statusLabel.Content = "Работа с таблицей:  Пациентов";
            
           // Соединение с сервером . Если не существует база то пишет не удалось подключиться.
            try
            {
                dgKlient.ItemsSource = ZakazDao.GetAll();
            }
            catch
            {
                MessageBox.Show("Не удалось подключится к базе данных", "Подключение");
                this.bConnect_Click(new object(), new RoutedEventArgs());
            }

        }

        /// <summary>
        /// Если база не существует то появляется окно чтоб заполнить для соединение база данных.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bConnect_Click(object sender, RoutedEventArgs e)
        {
            //ConnectWin conn = new ConnectWin();
          //  conn.ShowDialog();
        }

        /// <summary>
        /// Создаем конструктор для управление датагридами
        /// </summary>
        private void izmGrid()
        {
            dgKlient.Visibility = dgZakaz.Visibility = dgTovarnPlan.Visibility = Visibility.Hidden;
            switch (thisGrid)
            {
                    // Р- Это пациент
                case 'K':
                    {
                        dgKlient.Visibility = Visibility.Visible;
                        break;
                    }
                    // V - Это врач
                case 'Z':
                    {
                        dgZakaz.Visibility = Visibility.Visible;
                        break;
                    }
                    // О - это обрашение 
                case 'T':
                    {
                        dgTovarnPlan.Visibility = Visibility.Visible;
                        break;
                    }
                    // N - это направление можно сказать прием врача
              /*  case 'N':
                    {
                        dgNapravlenie.Visibility = Visibility.Visible;
                        break;
                    }*/
            }
            bReload_Click(new object(), new RoutedEventArgs());
        }
        /// <summary>
        /// Конструктор для добавление
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bAdd_Click(object sender, RoutedEventArgs e)
        {


            
            switch (thisGrid)
            {
                case 'K':
                    {
                        AddKlient win = new AddKlient();
                        win.ShowDialog();
                        break;
                    }
                case 'Z':
                    {
                        AddZakaz win = new AddZakaz();
                        win.ShowDialog();
                        break;
                    }
               case 'T':
                    {
                        AddTovarnPlan win = new AddTovarnPlan();
                        win.ShowDialog();
                        break;
                    }
               /* case 'N':
                    {
                        AddNapravlenie win = new AddNapravlenie();
                        win.ShowDialog();
                        break;
                    }*/

            }
            bReload_Click(sender, e);
        }

        /// <summary>
        /// Конструктор  изменение 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bEdit_Click(object sender, RoutedEventArgs e)
        {
            //Получаем выделенную строку с объектом  один из ниже перечисленных 
            switch (thisGrid)
            {
                case 'K':
                    {
                        
                        try
                        {
                            AddKlient win = new AddKlient(dgKlient.SelectedItem as Klient);
                            win.ShowDialog();
                            bReload_Click(sender, e);
                        }
                        catch (NullReferenceException)
                        {
                            MessageBox.Show("Выберите запись");
                        }
                        break;
                    }
                case 'Z':
                    {
                        try
                        {
                            AddZakaz win = new AddZakaz(dgZakaz.SelectedItem as Zakaz);
                            win.ShowDialog();
                            bReload_Click(sender, e);
                        }
                        catch (NullReferenceException)
                        {
                            MessageBox.Show("Выберите запись");
                        }
                        break;
                    }
                case 'T':
                    {
                        try
                        {
                            AddTovarnPlan win = new AddTovarnPlan(dgTovarnPlan.SelectedItem as TovarnPlan);
                            win.ShowDialog();
                            bReload_Click(sender, e);
                        }
                        catch (NullReferenceException)
                        {
                            MessageBox.Show("Выберите запись");
                        }
                        break;
                    }
               /* case 'N':
                    {
                        try
                        {
                            AddNapravlenie win = new AddNapravlenie(dgNapravlenie.SelectedItem as Napravlenie);
                            win.ShowDialog();
                            bReload_Click(sender, e);
                        }
                        catch (NullReferenceException)
                        {
                            MessageBox.Show("Выберите запись");
                        }
                        break;
                    }*/
               
                   
            }
            

        }
        /// <summary>
        /// Конструктор удаление
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bDelete_Click(object sender, RoutedEventArgs e)
        {
            //Получаем выделенную строку с объектом  один из ниже перечисленных 
            try
            {
                switch (thisGrid)
                {
                    case 'K':
                        {
                            try
                            {
                                KlientDao.Delete((dgKlient.SelectedItem as Klient).ID_klienta);

                            }
                            catch (NullReferenceException)
                            {
                                MessageBox.Show("Выберите запись");
                            }
                            break;
                        }
                    case 'Z':
                        {
                            try
                            {
                                ZakazDao.Delete((dgZakaz.SelectedItem as Zakaz).ID_zakaza);

                            }
                            catch (NullReferenceException)
                            {
                                MessageBox.Show("Выберите запись");
                            }
                            break;
                        }
                    case 'T':
                        {
                            try
                            {
                                TovarnPlanDao.Delete((dgTovarnPlan.SelectedItem as TovarnPlan).ID_plana);

                            }
                            catch (NullReferenceException)
                            {
                                MessageBox.Show("Выберите запись");
                            }
                            break;
                        }
                    /*case 'N':
                        {
                            {
                                try
                                {
                                    NapravlenieDao.Delete((dgNapravlenie.SelectedItem as Napravlenie).IDObrasheniya, (dgNapravlenie.SelectedItem as Napravlenie).IDVrach);

                                }
                                catch (NullReferenceException)
                                {
                                    MessageBox.Show("Выберите запись");
                                }
                                break;
                            }
                        }*/

                }
                bReload_Click(sender, e);
            }
            catch
            {
                MessageBox.Show("Не удалось удалить запись ", "Удаление");
            }

        }
        /// <summary>
        /// Конструктор обновление
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bReload_Click(object sender, RoutedEventArgs e)
        {
            string s = "Работа с таблицей: ";
            statusLabel.Content = s + " Клиентов";

            switch (thisGrid)
            {
                case 'Z':
                    {
                        bDelete.IsEnabled = true;
                        dgZakaz.ItemsSource = ZakazDao.GetAll();
                        statusLabel.Content = s + " Заказов";
                        break;
                    }
                case 'K':
                    {
                        bDelete.IsEnabled = true;
                        dgKlient.ItemsSource = KlientDao.GetAll();
                        statusLabel.Content = s + " Клиентов";
                        break;
                    }
                case 'T':
                    {
                        bDelete.IsEnabled = true;
                       
                        dgTovarnPlan.ItemsSource = TovarnPlanDao.GetAll();
                        statusLabel.Content = s + " Товарных План";
                        break;
                    }
               /* case 'N':
                    {
                        bDelete.IsEnabled = true;
                        dgNapravlenie.ItemsSource = NapravlenieDao.GetAll();
                        statusLabel.Content = s + " Дата приема ";
                        break;
                    }*/
            }
        }
        /// <summary>
        /// Конструктор база данных 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        public void DataBaseS_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("LoginApp.exe");
            Close();
            //ConnectWin con = new ConnectWin();
         //   con.ShowDialog();
        }
        /// <summary>
        ///  Конструктор поиска
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bSearch_Click(object sender, RoutedEventArgs e)
        {
            DataGrid dg = new DataGrid();
            switch (thisGrid)
            {
                case 'K':
                    dg = dgKlient;
                    break;
                case 'Z':
                    dg = dgZakaz;
                    break;
               case 'T':
                    dg = dgTovarnPlan;
                    break;
                /*case 'N':
                    dg = dgNapravlenie;
                    break;*/
            }
            Form1 f = new Form1(dg);
            f.ShowDialog();
            
        }

        private void btnKlient_Click(object sender, RoutedEventArgs e)
        {
            thisGrid = 'K';
            izmGrid();
        }

        private void btnZakaz_Click(object sender, RoutedEventArgs e)
        {
            thisGrid = 'Z';
            izmGrid();
        }



        private void btnTovarnPlan_Click_1(object sender, RoutedEventArgs e)
        {
          thisGrid = 'T';
            izmGrid();
        }

        private void btnVrach_Click_1(object sender, RoutedEventArgs e)
        {
            thisGrid = 'V';
            izmGrid();
           
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {

        }
        /// <summary>
        /// Конструктор export в Excel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExportExcel_click(object sender, RoutedEventArgs e)
        {
            Excel.Application app = new Excel.Application();
            Excel.Workbook book = app.Workbooks.Add();
            Excel.Worksheet sheet = (Excel.Worksheet)book.Sheets[1];

            DataGrid dg = new DataGrid();
            switch (thisGrid)
            {
                case 'K':
                    dg = dgKlient;
                    break;
                case 'Z':
                    dg = dgZakaz;
                    break;
                case 'T':
                    dg = dgTovarnPlan;
                    break;
                /*case 'N':
                    dg = dgNapravlenie;
                    break;*/
            }

            dg.SelectAllCells();
            dg.ClipboardCopyMode = DataGridClipboardCopyMode.IncludeHeader;
            ApplicationCommands.Copy.Execute(null, dg);
            dg.UnselectAllCells();
            sheet.Paste(sheet.Range["A1"]);
            sheet.Range["A1:" + (char)('A' + dg.Columns.Count - 1) + (dg.Items.Count - 2)].Borders[Excel.XlBordersIndex.xlInsideHorizontal].LineStyle = Excel.XlLineStyle.xlContinuous;
            sheet.Range["A1:" + (char)('A' + dg.Columns.Count - 1) + (dg.Items.Count - 2)].Borders[Excel.XlBordersIndex.xlInsideVertical].LineStyle = Excel.XlLineStyle.xlContinuous;
            sheet.Range["A1:" + (char)('A' + dg.Columns.Count - 1) + (dg.Items.Count - 2)].Borders[Excel.XlBordersIndex.xlEdgeLeft].Weight = 3;
            sheet.Range["A1:" + (char)('A' + dg.Columns.Count - 1) + (dg.Items.Count - 2)].Borders[Excel.XlBordersIndex.xlEdgeTop].Weight = 3;
            sheet.Range["A1:" + (char)('A' + dg.Columns.Count - 1) + (dg.Items.Count - 2)].Borders[Excel.XlBordersIndex.xlEdgeRight].Weight = 3;
            sheet.Range["A1:" + (char)('A' + dg.Columns.Count - 1) + (dg.Items.Count - 2)].Borders[Excel.XlBordersIndex.xlEdgeBottom].Weight = 3;
            Clipboard.Clear();
            sheet.Columns.NumberFormat = "@";
            sheet.Columns.RowHeight = 20;
            sheet.Columns.AutoFit();
            app.Visible = true;
        }
        /// <summary>
        /// Конструктор export в html
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExportHtml_click(object sender, RoutedEventArgs e)
        {
            
            Microsoft.Win32.SaveFileDialog save = new Microsoft.Win32.SaveFileDialog();
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
                    case 'K':
                        dg = dgKlient;
                        break;
                    case 'Z':
                        dg = dgZakaz;
                        break;
                    case 'T':
                        dg = dgTovarnPlan;
                        break;
                   /* case 'N':
                        dg = dgNapravlenie;
                        break;*/
                }
                dg.SelectAllCells();
                dg.ClipboardCopyMode = DataGridClipboardCopyMode.IncludeHeader;
                ApplicationCommands.Copy.Execute(null, dg);
                dg.UnselectAllCells();
                //string path1 = @"C:\otchet.html";
                string result1 = (string)System.Windows.Clipboard.GetText(System.Windows.TextDataFormat.Html);
                string s = "<style type=\"text/css\">TABLE  {border: 2px solid lightgreen  ;margin: auto;}TD{border: 2px solid lightcyan;}</style>";
                Clipboard.Clear();
                StreamWriter stream = new StreamWriter(save.OpenFile(), Encoding.UTF8);

                // new StreamWriter(save.FileName, false, Encoding.UTF8);
                result1 = result1.Replace("<HTML>", "--><HTML>");
                stream.WriteLine(s + "<!--" + result1);
                stream.Close();
                Process.Start(save.FileName);
            };
        }
        private void OProgramme_click(object sender, RoutedEventArgs e)
        {
            Программе ss = new Программе();
            ss.Show();
        }
        private void dgNapravlenie_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Image_ImageFailed(object sender, ExceptionRoutedEventArgs e)
        {

        }

    }
}
