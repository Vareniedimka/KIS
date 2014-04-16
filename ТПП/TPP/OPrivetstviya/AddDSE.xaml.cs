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
using System.Windows.Shapes;
using ClassBD;
using TPPDAO;


namespace Web
{
    /// <summary>
    /// Логика взаимодействия для AddDSE.xaml
    /// </summary>
    public partial class AddDSE : Window
    {
        int id;
        int IdDse;
        public AddDSE()
        {
            
            InitializeComponent();
            Loaded();
        }

        public AddDSE(DSE i)
        {
            Loaded();
            InitializeComponent();
            Naimenovanie.Text = i.Naimenovanie.ToString();
            cbMat.SelectedValue = i.material ;
            Norma_rashoda.Text = i.Norma_rashoda.ToString();
            if (i.Detal == 1)
            {
                Detal.IsChecked = true;
            }
            if (i.PE == 1)
            {
                Pokupnoe_izd.IsChecked = true;
            }
            if (i.SE == 1)
            {
                Sborochnaya_ed.IsChecked = true;
            }
            id = i.ID_DCE;

        }

        private void Loaded()
        {
            InitializeComponent();
            IList<Materialy> dd = materialDAO.GetAll();

            foreach (Materialy i in dd)
            {
                cbMat.Items.Add(i.Name);
            }
            //cbMat.ItemsSource = dd;
            cbMat.SelectedItem = 0;

        } 
        

        private void OK_Click(object sender, RoutedEventArgs e)
        {
           DSE  dse= new DSE();

            if (string.IsNullOrEmpty(Naimenovanie.Text))
            {
                MessageBox.Show("Наименование не должно быть пустым");
                return;
            }

            if (string.IsNullOrEmpty(Naimenovanie.Text))
            {
                MessageBox.Show("Норма расхода не должно быть пустым");
                return;
            }
            double number;
            bool result = Double.TryParse(Norma_rashoda.Text,out number);
            if (!result)
            {
                MessageBox.Show("Норма расхода должна быть числом");
                return;
            }

            //заполняем объект данными  
            dse.material=cbMat.SelectedValue.ToString();

            if (Detal.IsChecked == true)
            {
                dse.Detal = 1;
                dse.PE = 0;
                dse.SE = 0;
            }
            else
            {
                dse.Detal = 0;
                if (Pokupnoe_izd.IsChecked == true)
                {
                    dse.PE = 1;
                    dse.SE = 0;
                }
                else
                {
                    dse.PE = 0;
                    dse.SE = 1;
                }
            }
            dse.Norma_rashoda = int.Parse(Norma_rashoda.Text);
            dse.Naimenovanie = Naimenovanie.Text.ToString();
            dse.ID_DCE =IdDse;
            if (id == 0)
            {
                //Сохраняем Вид станка
               DSEDAO.Add(dse);
            }
            else
            {
                //Обновляем
                dse.ID_DCE = id;
                DSEDAO.Update(dse);
            }
            //закрываем форму
            Close();
            }

        private void cancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

    }
}






/* int IdDse = 1;

private static readonly string[] material = { "Железо", "Никель", "Метал" }; 

public AddDSE()
{
    InitializeComponent();
    cbMat.ItemsSource = material; //вызываем комбобокс
    cbMat.SelectedIndex = 0;
            
}
        
public AddDSE(DSE aa)
{
          
    InitializeComponent();
    cbMat.ItemsSource = material;
    cbMat.SelectedIndex = 0;
    //сохраняем данные о дсе
    id = aa.ID_DCE;
    Naimenovanie.Text = aa.Naimenovanie;
    Norma_rashoda.Text = Convert.ToString(aa.Norma_rashoda);
    cbMat.SelectedItem = aa.ID_materiala;
          
    if (aa.Detal == 1)
    {
        Detal.IsChecked = true;
    }
    if (aa.PE == 1)
    {
        Pokupnoe_izd.IsChecked = true;
    }
    if (aa.SE == 1)
    {
        Sborochnaya_ed.IsChecked = true;
    }

}
*/