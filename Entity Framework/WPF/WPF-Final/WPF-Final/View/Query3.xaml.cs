using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WPF_Final.Controllers;

namespace WPF_Final.View
{
    /// <summary>
    /// Логика взаимодействия для Query3.xaml
    /// </summary>
    public partial class Query3 : Window
    {
        private QueriesController _queriesController;
        public int BDiet { get; set; }
        public int CAge { get; set; }
        public Query3()
        {
            InitializeComponent();
            _queriesController = new QueriesController();
        }

        private void BtnOKClick(object sender, RoutedEventArgs e)
        {
            BDiet = int.Parse(txbDiet.Text);
            CAge = int.Parse(txbAge.Text);
            
            // закрыть окно с признаком OK
            DialogResult = true;
            Close();
        }
    }
}
