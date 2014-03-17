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
        string thisGrid = "dgPostavhik";

        public MainWindow()
        {
            InitializeComponent();
            try
            {
                dgPostavhik.ItemsSource = PostavhikDao.GetAll();
            }
            catch
            {
                MessageBox.Show("Не удалось подключится к базе данных", "Подключение");
                this.bConnect_Click(new object(), new RoutedEventArgs());
                try
                {
                    dgPostavhik.ItemsSource = PostavhikDao.GetAll();
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
                    case "dgZakaz":
                        {
                            dgZakaz.ItemsSource = ZakazDao.GetAll();
                            break;
                        }
                    case "dgMaterialPostav":
                        {
                            dgMaterialPostav.ItemsSource = MaterialPostavDao.GetAll();
                            break;
                        }
                    case "dgPostavhik":
                        {
                            dgPostavhik.ItemsSource = PostavhikDao.GetAll();
                            break;
                        }
                    case "dgOtpuskSoSklada":
                        {
                            dgOtpuskSoSklada.ItemsSource = OtpuskSoSkladaDao.GetAll();
                            break;
                        }
                    case "dgZapas":
                        {
                            dgZapas.ItemsSource = ZapasDao.GetAll();
                            break;
                        }
                    case "dgMaterial":
                        {
                            dgMaterial.ItemsSource = MaterialDao.GetAll();
                            break;
                        }
                }
            }
            catch {

                MessageBox.Show("Не удалось подключится к базе данных", "Подключение");
                this.bConnect_Click(new object(), new RoutedEventArgs());
                //dgPostavhik.ItemsSource = PostavhikDao.GetAll();
            }

        }

        private void bEdit_Click(object sender, RoutedEventArgs e)
        {
            switch (thisGrid)
            {
                case "dgZakaz":
                    {
                        try
                        {
                            AddZakaz win = new AddZakaz(dgZakaz.SelectedItem as Zakaz);
                            win.ShowDialog();
                            bReload_Click(sender, e);
                        }
                        catch (NullReferenceException)
                        {
                            MessageBox.Show("Выберете запись");
                        }
                        break;
                    }
                case "dgMaterialPostav":
                    {
                        try
                        {
                            AddMaterialPostav win = new AddMaterialPostav(dgMaterialPostav.SelectedItem as MaterialPostav);
                            win.ShowDialog();
                            bReload_Click(sender, e);
                        }
                        catch (NullReferenceException)
                        {
                            MessageBox.Show("Выберете запись");
                        }
                        break;
                    }
                case "dgPostavhik":
                    {
                        try
                        {
                            AddPostavhik win = new AddPostavhik(dgPostavhik.SelectedItem as Postavhik);
                            win.ShowDialog();
                            bReload_Click(sender, e);
                        }
                        catch (NullReferenceException)
                        {
                            MessageBox.Show("Выберете запись");
                        }
                        break;
                    }
                case "dgOtpuskSoSklada":
                    {
                        try
                        {
                            AddOtpuskSoSklada win = new AddOtpuskSoSklada(dgOtpuskSoSklada.SelectedItem as OtpuskSoSklada);
                            win.ShowDialog();
                            bReload_Click(sender, e);
                        }
                        catch (NullReferenceException)
                        {
                            MessageBox.Show("Выберете запись");
                        }
                        break;
                    }
                case "dgZapas":
                    {
                        try
                        {
                            AddZapas win = new AddZapas(dgZapas.SelectedItem as Zapas);
                            win.ShowDialog();
                            bReload_Click(sender, e);
                        }
                        catch (NullReferenceException)
                        {
                            MessageBox.Show("Выберете запись");
                        }
                        break;
                    }
                case "dgMaterial":
                    {
                        try
                        {
                            AddMaterial win = new AddMaterial(dgMaterial.SelectedItem as Material);
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
                case "dgZakaz":
                    {
                        AddZakaz win = new AddZakaz();
                        win.ShowDialog();
                        break;
                    }
                case "dgMaterialPostav":
                    {
                        AddMaterialPostav win = new AddMaterialPostav();
                        win.ShowDialog();
                        break;
                    }
                case "dgPostavhik":
                    {
                        AddPostavhik win = new AddPostavhik();
                        win.ShowDialog();
                        break;
                    }
                case "dgOtpuskSoSklada":
                    {
                        AddOtpuskSoSklada win = new AddOtpuskSoSklada();
                        win.ShowDialog();
                        break;
                    }
                case "dgZapas":
                    {
                        AddZapas win = new AddZapas();
                        win.ShowDialog();
                        break;
                    }
                case "dgMaterial":
                    {
                        AddMaterial win = new AddMaterial();
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
                    case "dgZakaz":
                        {
                            try
                            {
                                ZakazDao.Delete((dgZakaz.SelectedItem as Zakaz).IDZakaza);

                            }
                            catch (NullReferenceException)
                            {
                                MessageBox.Show("Выберете запись");
                            }
                            break;
                        }
                    case "dgMaterialPostav":
                        {
                            try
                            {
                                MaterialPostavDao.Delete((dgMaterialPostav.SelectedItem as MaterialPostav).IDMateriala, (dgMaterialPostav.SelectedItem as MaterialPostav).IDPostavhik);

                            }
                            catch (NullReferenceException)
                            {
                                MessageBox.Show("Выберете запись");
                            }
                            break;
                        }
                    case "dgPostavhik":
                        {
                            try
                            {
                                PostavhikDao.Delete((dgPostavhik.SelectedItem as Postavhik).IDPostavhik);

                            }
                            catch (NullReferenceException)
                            {
                                MessageBox.Show("Выберете запись");
                            }
                            break;
                        }
                    case "dgOtpuskSoSklada":
                        {
                            {
                                try
                                {
                                    OtpuskSoSkladaDao.Delete((dgOtpuskSoSklada.SelectedItem as OtpuskSoSklada).IDOtpusk);

                                }
                                catch (NullReferenceException)
                                {
                                    MessageBox.Show("Выберете запись");
                                }
                                break;
                            }
                        }
                    case "dgZapas": 
                        {
                            try
                            {
                                ZapasDao.Delete((dgZapas.SelectedItem as Zapas).IDMateriala);

                            }
                            catch (NullReferenceException)
                            {
                                MessageBox.Show("Выберете запись");
                            }
                            break;
                        }
                    case "dgMaterial": {
                        try
                        {
                            MaterialDao.Delete((dgMaterial.SelectedItem as Material).IDMateriala);

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
                    case "dgPostavhik":
                        dg = dgPostavhik;
                        break;
                    case "dgZakaz":
                        dg = dgZakaz;
                        break;
                    case "dgOtpuskSoSklada":
                        dg = dgOtpuskSoSklada;
                        break;
                    case "dgMaterialPostav":
                        dg = dgMaterialPostav;
                        break;
                    case "dgZapas":
                        {
                            dg = dgZapas;
                            break;
                        }
                    case "dgMaterial":
                        {
                            dg = dgMaterial;
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
                case "dgPostavhik":
                    dg = dgPostavhik;
                    break;
                case "dgZakaz":
                    dg = dgZakaz;
                    break;
                case "dgOtpuskSoSklada":
                    dg = dgOtpuskSoSklada;
                    break;
                case "dgMaterialPostav":
                    dg = dgMaterialPostav;
                    break;
                case "dgZapas": {
                    dg = dgZapas;
                    break;
                }
                case "dgMaterial": 
                    {
                        dg = dgMaterial;
                        break;
                    }
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
Дата создания 16.03.2014"
            );
        }

        private void bZakaz_Click(object sender, RoutedEventArgs e)
        {
            thisGrid = "dgZakaz";
            izmGrid();
        }
        private void bPostavhik_Click(object sender, RoutedEventArgs e)
        {
            thisGrid ="dgPostavhik";
            izmGrid();

        }
        private void bMaterialPostav_Click(object sender, RoutedEventArgs e)
        {
            thisGrid =  "dgMaterialPostav" ;
            izmGrid();
        }
        private void bOtpuskSoSklada_Click(object sender, RoutedEventArgs e)
        {
            thisGrid = "dgOtpuskSoSklada";
            izmGrid();
        }
        private void bZapas_Click(object sender, RoutedEventArgs e)
        {
            thisGrid = "dgZapas";
            izmGrid();
        }
                private void bMaterial_Click(object sender, RoutedEventArgs e)
        {
            thisGrid =  "dgMaterial";
            izmGrid();
        }

        private void izmGrid()
        {
            dgPostavhik.Visibility = dgMaterialPostav.Visibility = dgZakaz.Visibility = dgOtpuskSoSklada.Visibility = dgZapas.Visibility = dgMaterial.Visibility = dgMaterial.Visibility = Visibility.Hidden;
            switch (thisGrid)
            {
                case "dgZakaz":
                    {
                        dgZakaz.Visibility = Visibility.Visible;
                        statusLabel.Content = "Работа с таблицей: Заказы";
                        break;
                        
                    }
                case "dgMaterialPostav":
                    {
                        dgMaterialPostav.Visibility = Visibility.Visible;
                        statusLabel.Content = "Работа с таблицей: Матерьял у поставщиков";
                        break;
                    }
                case "dgPostavhik":
                    {
                        dgPostavhik.Visibility = Visibility.Visible;
                        statusLabel.Content = "Работа с таблицей: Поставщики";
                        break;
                    }
                case "dgOtpuskSoSklada":
                    {
                        dgOtpuskSoSklada.Visibility = Visibility.Visible;
                        statusLabel.Content = "Работа с таблицей: Отпуск со склада";
                        break;
                    }
                case "dgZapas":
                    {
                        dgZapas.Visibility = Visibility.Visible;
                        statusLabel.Content = "Работа с таблицей: Запасы";
                        break;
                    }
                case "dgMaterial": {
                    dgMaterial.Visibility = Visibility.Visible;
                    statusLabel.Content = "Работа с таблицей: Материалы";
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
                case "dgPostavhik":
                    dg = dgPostavhik;
                    break;
                case "dgZakaz":
                    dg = dgZakaz;
                    break;
                case "dgOtpuskSoSklada":
                    dg = dgOtpuskSoSklada;
                    break;
                case "dgMaterialPostav":
                    dg = dgMaterialPostav;
                    break;
                case "dgZapas":
                    dg = dgZapas;
                    break;
                case "dgMaterial":
                    dg = dgMaterial;
                    break;
            }
            Form1 f = new Form1(dg);
            f.ShowDialog();
            dgPostavhik = dg;

        }
    }
}