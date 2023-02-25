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
using WPF_Final.Controllers;
using WPF_Final.Models;
using WPF_Final.View;

namespace WPF_Final
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private QueriesController _queriesController;
        FarmEntities db = new FarmEntities();
        public MainWindow()
        {
            InitializeComponent();
            _queriesController = new QueriesController();
            dataGridBreed.ItemsSource = db.Breeds.ToList(); //Вывод таблицы Breed
            dataGridChicken.ItemsSource = db.Chickens.ToList(); //Вывод таблицы Chicken
            dataGridWorkshop.ItemsSource = db.Workshops.ToList(); //Вывод таблицы Workshop
           

        }

        private void command_Query1(object sender, RoutedEventArgs e)
        {
            Query1 query1 = new Query1();
            if (query1.ShowDialog() == true)
                dvgQ1.ItemsSource = _queriesController.Query1(query1.BName,query1.CAge,query1.CWeight);
        }

        private void command_Query3(object sender, RoutedEventArgs e)
        {
            Query3  query3 = new Query3();
            if (query3.ShowDialog() == true)
            dvgQ3.ItemsSource = _queriesController.Query3(query3.BDiet,query3.CAge);
               
        }

        private void command_QueryDismissed(object sender, RoutedEventArgs e)
        {
            dataGridWorker.ItemsSource = _queriesController.QueryDismissed();
        }

        private void command_Query4(object sender, RoutedEventArgs e)
        {
            Query4 query4 = new Query4();
            if (query4.ShowDialog() == true)
                MessageBox.Show($"{_queriesController.Query4(query4.WName)}");
         
        }

        private void Worker_TM_Loaded(object sender, RoutedEventArgs e)
        {
            dataGridWorker.ItemsSource = _queriesController.QueryFilterWorker();
        }

        private void command_Query2(object sender, RoutedEventArgs e)
        {
                Query2 query2 = new Query2();
                if (query2.ShowDialog() == true)
                dvgQ2.ItemsSource = _queriesController.Query2(query2.Bname);
        }

        private void command_Query5(object sender, RoutedEventArgs e)
        {
            dvgQ5.ItemsSource = _queriesController.Query5();
        }

        private void command_Query7(object sender, RoutedEventArgs e)
        {
            dvgQ7.ItemsSource = _queriesController.Query7();
        }

        private void command_Query8(object sender, RoutedEventArgs e)
        {
            dvgQ8.ItemsSource = _queriesController.Query8();
        }

        private void command_Query9(object sender, RoutedEventArgs e)
        {
            dvgQ9.ItemsSource = _queriesController.Query9();
        }

        private void command_Query6(object sender, RoutedEventArgs e)
        {
            dvgQ6.ItemsSource = _queriesController.Query6();
        }

        private void command_AddWorker(object sender, RoutedEventArgs e)
        {
            AddWorker addWorker = new AddWorker();
           addWorker.ShowDialog();

        }

        private void command_coutСhicken(object sender, RoutedEventArgs e)
        {
            MessageBox.Show($"{_queriesController.Query2Advanced()}");
        }

        private void command_coutEgss(object sender, RoutedEventArgs e)
        {
            MessageBox.Show($"{_queriesController.Query3Advanced()}");
        }

        private void command_exit(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void command_Query10(object sender, RoutedEventArgs e)
        {
            dvgQ10.ItemsSource = _queriesController.Query1Advanced();
        }

        private void command_ChengeWorker(object sender, RoutedEventArgs e)
        {
            int index = dataGridWorker.SelectedIndex;
            Worker worker = db.Workers.First();
            ChengeWorker chengeWorker = new ChengeWorker(index);
            chengeWorker.ShowDialog();

        }
    }
}
