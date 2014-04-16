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
    /// Логика взаимодействия для OPolPrim.xaml
    /// </summary>
    public partial class OPolPrim : Window
    {
        public OPolPrim()
        {
            InitializeComponent();
            PolPrim pp = new PolPrim();
            pp.Update()  ;
            dgPP.ItemsSource = PolPrim.GetAll();
        }

        private void btUpdate_Click(object sender, RoutedEventArgs e)
        {
            dgPP.ItemsSource = PolPrim.GetAll() ;
        }

        private void btBack_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
