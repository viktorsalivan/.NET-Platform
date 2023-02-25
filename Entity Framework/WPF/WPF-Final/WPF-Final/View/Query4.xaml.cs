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
    /// Логика взаимодействия для Query4.xaml
    /// </summary>
    public partial class Query4 : Window
    {
        public string WName { get; set; }
        private QueriesController _queriesController;
        public Query4()
        {
            InitializeComponent();
            _queriesController = new QueriesController();
        }

        private void BtnOKClick(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            Close();
            WName = txbName.Text;
        }
    }
}
