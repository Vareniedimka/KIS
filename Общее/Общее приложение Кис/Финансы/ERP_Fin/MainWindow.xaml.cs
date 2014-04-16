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
using System.Reflection;
using ClassLibrary;
namespace Win
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        char thisGrid = 'B';

        public MainWindow()
        {
            
            InitializeComponent();
            //получаем параметры запуска
            var args = Environment.GetCommandLineArgs();
            //Вводим параметры подключения
            Connect.setConnectInfo(args[1], args[2], args[3], args[4]);
            try
            {
                dgBuhgalterski_balans.ItemsSource = Buhgalterski_balansDao.GetAll();

            }
            catch
            {
               // MessageBox.Show("Не удалось подключится к базе данных", "Подключение");
            //    this.bConnect_Click(new object(), new RoutedEventArgs());
                try
                {
                    dgBuhgalterski_balans.ItemsSource = Buhgalterski_balansDao.GetAll();
                }
                catch
                {

                }

            }
            statusLabel.Content = "Работа с таблицей: Бухгалтерский баланс";
            thisGrid = 'B';
            izmGrid();
        }

        private void bReload_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                switch (thisGrid)
                {
                    case 'B':
                        {
                            dgBuhgalterski_balans.ItemsSource = Buhgalterski_balansDao.GetAll();
                            break;
                        }
                    case 'K':
                        {
                            dgKredit.ItemsSource = KreditDao.GetAll();
                            break;
                        }
                    case 'O':
                        {
                            dgOplata.ItemsSource = OplataDao.GetAll();
                            break;
                        }
                    case 'P':
                        {
                            dgPokupki.ItemsSource = PokupkiDao.GetAll();
                            break;
                        }
                    case 'p':
                        {
                            dgprodazhi.ItemsSource = prodazhiDao.GetAll();
                            break;
                        }
                    case 'A':
                        {
                            dgProvodka.ItemsSource = ProvodkaDao.GetAll();
                            break;
                        }
                }
            }
            catch
            {

            //    MessageBox.Show("Не удалось подключится к базе данных", "Подключение");
             //   this.bConnect_Click(new object(), new RoutedEventArgs());

            }

        }
        private void bEdit_Click(object sender, RoutedEventArgs e)
        {
            switch (thisGrid)
            {
                case 'p':
                    {
                        try
                        {
                            addprodazi win = new addprodazi(dgprodazhi.SelectedItem as prodazhi);
                            win.ShowDialog();
                            bReload_Click(sender, e);
                        }
                        catch (NullReferenceException)
                        {
                            MessageBox.Show("Выберете Продажу");
                        }
                        break;
                    }
                case 'P':
                    {
                        try
                        {
                            AddPokupka win = new AddPokupka(dgPokupki.SelectedItem as Pokupki);
                            win.ShowDialog();
                            bReload_Click(sender, e);
                        }
                        catch (NullReferenceException)
                        {
                            MessageBox.Show("Выберете Покупки");
                        }
                        break;
                    }
                case 'O':
                    {
                        try
                        {
                            AddOplata win = new AddOplata(dgOplata.SelectedItem as Oplata);
                            win.ShowDialog();
                            bReload_Click(sender, e);
                        }
                        catch (NullReferenceException)
                        {
                            MessageBox.Show("Выберете Оплату");
                        }
                        break;
                    }
                case 'A':
                    {
                        try
                        {
                            AddProvodki win = new AddProvodki(dgProvodka.SelectedItem as Provodka);
                            win.ShowDialog();
                            bReload_Click(sender, e);
                        }
                        catch (NullReferenceException)
                        {
                            MessageBox.Show("Выберете Проводку");
                        }
                        break;
                    }
            }


        }
        private void bAdd_Click(object sender, RoutedEventArgs e)
        {
            switch (thisGrid)
            {
                case 'p':
                    {
                        addprodazi win = new addprodazi();
                        win.ShowDialog();
                        break;
                    }
                case 'P':
                    {
                        AddPokupka win = new AddPokupka();
                        win.ShowDialog();
                        break;
                    }
                case 'O':
                    {
                        AddOplata win = new AddOplata();
                        win.ShowDialog();
                        break;
                    }
                case 'A':
                    {
                        AddProvodki win = new AddProvodki();
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
                    case 'p':
                        {
                            try
                            {
                                prodazhiDao.Delete((dgprodazhi.SelectedItem as prodazhi).ID_prodazhi);

                            }
                            catch (NullReferenceException)
                            {
                                MessageBox.Show("Выберете Продажу");
                            }
                            break;
                        }
                    case 'P':
                        {
                            try
                            {
                                PokupkiDao.Delete((dgPokupki.SelectedItem as Pokupki).ID_Pokupki);

                            }
                            catch (NullReferenceException)
                            {
                                MessageBox.Show("Выберете Покупку");
                            }
                            break;
                        }
                    case 'O':
                        {
                            try
                            {
                                OplataDao.Delete((dgOplata.SelectedItem as Oplata).ID_oplati);

                            }
                            catch (NullReferenceException)
                            {
                                MessageBox.Show("Выберете Оплату");
                            }
                            break;
                        }
                    case 'A':
                        {
                            try
                            {
                                ProvodkaDao.Delete((dgProvodka.SelectedItem as Provodka).ID_provodki);

                            }
                            catch (NullReferenceException)
                            {
                                MessageBox.Show("Выберете Проводку");
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

      //  private void bConnect_Click(object sender, RoutedEventArgs e)
  //      {
       //     ConnectWin conn = new ConnectWin();
      //      conn.ShowDialog();

     //   }
//        private void HtmlExporterButton_Click(object sender, RoutedEventArgs e)
//        {
//            SaveFileDialog save = new SaveFileDialog();
//            //save.Filter = "|*.html";
//            save.AddExtension = true;
//            save.DefaultExt = ".html";
//            save.OverwritePrompt = true;
//            //save.FilterIndex = 0;
//            if (save.ShowDialog() == true)
//            {

//                DataGrid dg = new DataGrid();
//                switch (thisGrid)
//                {
//                    case 'P':
//                        dg = dgPocup;
//                        break;
//                    case 'T':
//                        dg = dgTovar;
//                        break;
//                    case '*':
//                        dg = dgTovarVS;
//                        break;
//                    case 'S':
//                        dg = dgSdelka;
//                        break;

//                }
//                dg.SelectAllCells();
//                dg.ClipboardCopyMode = DataGridClipboardCopyMode.IncludeHeader;
//                ApplicationCommands.Copy.Execute(null, dg);
//                dg.UnselectAllCells();
//                //string path1 = @"C:\otchet.html";
//                string result1 = (string)Clipboard.GetText(TextDataFormat.Html);
//                string s = "<style type=\"text/css\">TABLE  {border: 2px solid Black;margin: auto;}TD{border: 2px solid Black;}</style>";
//                Clipboard.Clear();
//                StreamWriter stream = new StreamWriter(save.OpenFile(), Encoding.UTF8);

//                // new StreamWriter(save.FileName, false, Encoding.UTF8);
//                result1 = result1.Replace("<HTML>", "--><HTML>");
//                stream.WriteLine(s + "<!--" + result1);

//                stream.Close();
//                Process.Start(save.FileName);
//            };
//        }
//        //private void ExelExporterButton_Click(object sender, RoutedEventArgs e)
//        //{
//        //    Excel.Application app = new Excel.Application();//создается приложение
//        //    Excel.Workbook book = app.Workbooks.Add();//создается книга
//        //    Excel.Worksheet sheet = (Excel.Worksheet)book.Sheets[1];//создается страница

//        //    DataGrid dg = new DataGrid();
//        //    switch (thisGrid)//в зависимости от того какая таблица используется сейчас выбирается datdGrid
//        //    {
//        //        case 'P':
//        //            dg = dgPocup;
//        //            break;
//        //        case 'T':
//        //            dg = dgTovar;
//        //            break;
//        //        case '*':
//        //            dg = dgTovarVS;
//        //            break;
//        //        case 'S':
//        //            dg = dgSdelka;
//        //            break;
//        //    }

//        //    dg.SelectAllCells();//выделяются все ячейки в dataGrid
//        //    dg.ClipboardCopyMode = DataGridClipboardCopyMode.IncludeHeader;
//        //    ApplicationCommands.Copy.Execute(null, dg);//выделенное копируется в буфер
//        //    dg.UnselectAllCells();//снимается выделение
//        //    sheet.Paste(sheet.Range["A1"]);   // вставляются на страницу в excel 
//        //    //дальше выделяются рамки в excel
//        //    sheet.Range["A1:" + (char)('A' + dg.Columns.Count - 1) + (dg.Items.Count - 2)].Borders[Excel.XlBordersIndex.xlInsideHorizontal].LineStyle = Excel.XlLineStyle.xlContinuous;
//        //    sheet.Range["A1:" + (char)('A' + dg.Columns.Count - 1) + (dg.Items.Count - 2)].Borders[Excel.XlBordersIndex.xlInsideVertical].LineStyle = Excel.XlLineStyle.xlContinuous;
//        //    sheet.Range["A1:" + (char)('A' + dg.Columns.Count - 1) + (dg.Items.Count - 2)].Borders[Excel.XlBordersIndex.xlEdgeLeft].Weight = 3;
//        //    sheet.Range["A1:" + (char)('A' + dg.Columns.Count - 1) + (dg.Items.Count - 2)].Borders[Excel.XlBordersIndex.xlEdgeTop].Weight = 3;
//        //    sheet.Range["A1:" + (char)('A' + dg.Columns.Count - 1) + (dg.Items.Count - 2)].Borders[Excel.XlBordersIndex.xlEdgeRight].Weight = 3;
//        //    sheet.Range["A1:" + (char)('A' + dg.Columns.Count - 1) + (dg.Items.Count - 2)].Borders[Excel.XlBordersIndex.xlEdgeBottom].Weight = 3;
//        //    Clipboard.Clear();//Очищается буфер обмена
//        //    sheet.Columns.NumberFormat = "@";//устанавливается текстовый формат ячеек
//        //    sheet.Columns.RowHeight = 20;//высота ячеек 20
//        //    sheet.Columns.AutoFit();//авто подбор ширины
//        //    app.Visible = true; //сделать excel видимым


//        //}
//        private void About_Click(object sender, RoutedEventArgs e)
//        {
//            MessageBox.Show(@"Программа создана в рамках курсового проекта 
//Дата создания 22.05.2013
//Разработчик: Власов С.
//Руководитель: Галиаскаров Э. Г.", "О программе");
//        }

//        private void bTovar_Click(object sender, RoutedEventArgs e)
//        {
//            thisGrid = 'T';
//            izmGrid();
//        }
//        private void bPocupatel_Click(object sender, RoutedEventArgs e)
//        {
//            thisGrid = 'P';
//            izmGrid();

//        }
//        private void bSdelka_Click(object sender, RoutedEventArgs e)
//        {
//            thisGrid = 'S';
//            izmGrid();
//        }
//        private void bTovarVS_Click(object sender, RoutedEventArgs e)
//        {
//            thisGrid = '*';
//            izmGrid();
//        }

//        private void izmGrid()
//        {
//            dgPocup.Visibility = dgSdelka.Visibility = dgTovar.Visibility = dgTovarVS.Visibility = Visibility.Hidden;
//            switch (thisGrid)
//            {
//                case 'T':
//                    {
//                        dgTovar.Visibility = Visibility.Visible;
//                        statusLabel.Content = "Работа с таблицей: Товар";
//                        break;

//                    }
//                case 'S':
//                    {
//                        dgSdelka.Visibility = Visibility.Visible;
//                        statusLabel.Content = "Работа с таблицей: Сделка";
//                        break;
//                    }
//                case 'P':
//                    {
//                        dgPocup.Visibility = Visibility.Visible;
//                        statusLabel.Content = "Работа с таблицей: Покупатель";
//                        break;
//                    }
//                case '*':
//                    {
//                        dgTovarVS.Visibility = Visibility.Visible;
//                        statusLabel.Content = "Работа с таблицей: Товар в сделке";
//                        break;
//                    }
//            }
//            bReload_Click(new object(), new RoutedEventArgs());
//        }

        private void bFind_Click(object sender, RoutedEventArgs e)
        {
            DataGrid dg = new DataGrid();
            switch (thisGrid)
            {
                case 'B':
                    dg = dgBuhgalterski_balans;
                    break;
                case 'K':
                    dg = dgKredit;
                    break;
                case 'O':
                    dg = dgOplata;
                    break;
                case 'P':
                    dg = dgPokupki;
                    break;
                case 'p':
                    dg = dgprodazhi;
                    break;
                case 'A':
                    dg = dgProvodka;
                    break;
            }
            dgBuhgalterski_balans = dg;

        }
        private void btBalans(object sender, RoutedEventArgs e)
        {
            thisGrid = 'B';
            izmGrid();
        }
        private void btKredit(object sender, RoutedEventArgs e)
        {
            thisGrid = 'K';
            izmGrid();
        }
        private void btOplata(object sender, RoutedEventArgs e)
        {
            thisGrid = 'O';
            izmGrid();
        }
        private void btPokypki(object sender, RoutedEventArgs e)
        {
            thisGrid = 'P';
            izmGrid();
        }
        private void btProdazi(object sender, RoutedEventArgs e)
        {
            thisGrid = 'p';
            izmGrid();
        }
        private void btProvodki(object sender, RoutedEventArgs e)
        {
            thisGrid = 'A';
            izmGrid();
        }
        private void izmGrid()
        {
            dgBuhgalterski_balans.Visibility = dgKredit.Visibility = dgOplata.Visibility = dgPokupki.Visibility = dgprodazhi.Visibility = dgProvodka.Visibility = Visibility.Hidden;
            switch (thisGrid)
            {
                case 'B':
                    {
                        dgBuhgalterski_balans.Visibility = Visibility.Visible;
                        statusLabel.Content = "Работа с таблицей: Баланса";
                        break;

                    }
                case 'K':
                    {
                        dgKredit.Visibility = Visibility.Visible;
                        statusLabel.Content = "Работа с таблицей: Кредит";
                        break;
                    }
                case 'O':
                    {
                        dgOplata.Visibility = Visibility.Visible;
                        statusLabel.Content = "Работа с таблицей: Оплата";
                        break;
                    }
                case 'P':
                    {
                        dgPokupki.Visibility = Visibility.Visible;
                        statusLabel.Content = "Работа с таблицей: Покупки";
                        break;
                    }
                case 'p':
                    {
                        dgprodazhi.Visibility = Visibility.Visible;
                        statusLabel.Content = "Работа с таблицей: Продажи";
                        break;
                    }
                case 'A':
                    {
                        dgProvodka.Visibility = Visibility.Visible;
                        statusLabel.Content = "Работа с таблицей: Проводки";
                        break;
                    }
            }
            bReload_Click(new object(), new RoutedEventArgs());
        }

        private void Glavn(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("LoginApp.exe");
            Close();
        }

////        private void ClickCena(object sender, RoutedEventArgs e)
////        {
////            int id = (dgSdelka.SelectedItem as Sdelka).IDSdelki;
////            using (var conn = Connect.GetConnect())
////            {

////                conn.Open();
////                using (var cmd = conn.CreateCommand())
////                {
////                    cmd.Parameters.AddWithValue("@id", id);
////                    cmd.CommandText = @"select Cena
////from CenaSdelki
////where IDSdelki=@id";

////                    var dataReader = cmd.ExecuteReader();
////                    dataReader.Read();
////                    string a = dataReader["Cena"].ToString();

////                    /*dataReader["Cena"]
////                    {
////                        return !dataReader.Read() ? null : Load(dataReader);
////                    }*/
////                    MessageBox.Show(@"Цена
////сделки " + a, "Цена");

////                }
////            }

////        }
    }
}