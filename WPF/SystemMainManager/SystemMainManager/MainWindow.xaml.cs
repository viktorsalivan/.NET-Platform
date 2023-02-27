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
using System.Windows.Navigation;
using System.Windows.Shapes;
using SystemMainManager.Controllers;

namespace SystemMainManager
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Controller _controller;
        public MainWindow()
        {
            InitializeComponent();
            _controller = new Controller();
        }

        private void command_exit(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void btStart_command(object sender, RoutedEventArgs e)
        {
            if (cbApplicationprelaunch.IsChecked == true)
            {
                _controller.applicationprelaunchDisable();
                cbApplicationprelaunch.IsEnabled = false;
            } //if
            
            if (cbApplicationlaunchprefetching.IsChecked == true)
            {
                _controller.applicationlaunchprefetchingDisable();
                cbApplicationlaunchprefetching.IsEnabled = false;
            } // if
            if (cbMemorycompression.IsChecked == true)
            {
                _controller.memorycompressionDisable();
                cbMemorycompression.IsEnabled = false;
            }
            if (cbPagecombining.IsChecked == true)
            {
                _controller.pagecombiningDisable();
                cbPagecombining.IsEnabled = false;
            }
            if (cbOperationapi.IsChecked == true)
            {
                _controller.operationapiDisable();
                cbOperationapi.IsEnabled = false;
            }

        }//btStart_command
    }
}
