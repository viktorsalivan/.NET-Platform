using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Linq;
using System.Runtime;
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
using TV_Project.Controller;
using TV_Project.Modes;
using TV_Project.View;

namespace TV_Project
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private TvController _tvController; //Передача контроллера на форму 


        //для работы с файлами
        private OpenFileDialog _ofd;

        private SaveFileDialog _sfd;

        public MainWindow()
        {
            
            InitializeComponent();
            _tvController = new TvController(); //Создание нового экземпляра 
            _tvController.InitializeTvs(); //Инициализация данных
            DgMain.ItemsSource = _tvController.DataTV; //Выбор колеции источк данных
            

        }

        private void command_sortBy_screen(object sender, RoutedEventArgs e)
        {
            DgMain.ItemsSource = _tvController.DataTV.OrderBy(item => item.Screen);
        }

        private void command_sortBy_price(object sender, RoutedEventArgs e)
        {
            DgMain.ItemsSource = _tvController.DataTV.OrderBy(item => item.Price);
        }


        private void command_sortBy_brand(object sender, RoutedEventArgs e)
        {
            DgMain.ItemsSource = _tvController.DataTV.OrderBy(item => item.Brand);
        }

        private void command_addTV_form_show(object sender, RoutedEventArgs e)
        {
            addTV addTV = new addTV();
            if (addTV.ShowDialog() == true)
            {
                _tvController.DataTV.Add(addTV.NewTVModel);
               
            }
        }

        private void command_delete_tv(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Удалить выбранную запись?", "Подтверждение",
             MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                _tvController.deleteTv(DgMain.SelectedIndex);
            } // if
        }

        private void command_editTv_show_form(object sender, RoutedEventArgs e)
        {

            addTV editTv = new addTV(_tvController.DataTV[DgMain.SelectedIndex]);
            if (editTv.ShowDialog() == true)
            {
                _tvController.DataTV[DgMain.SelectedIndex] = editTv.NewTVModel;

            }
        }

        private void command_load(object sender, RoutedEventArgs e)
        {
            //создали 
            _ofd = TvController.Ofd();
            if (_ofd.ShowDialog() == true)
            {
                try
                {
                    //предупреждаем
                    if (MessageBoxResult.Yes == MessageBox.Show("При чтении удалится текущий список, продолжить?",
                        "Предупреждение!",
                        MessageBoxButton.YesNo, MessageBoxImage.Warning))
                    {
                        //чистим
                        _tvController.DataTV.Clear();
                        //передаем в метод имя файла и получаем контролер
                        _tvController = _tvController.Deserial(_ofd.FileName);
                        //делаем привязку
                        DgMain.ItemsSource = _tvController.DataTV;
                    }
                    else
                        throw new Exception();

                    //if
                }
                catch (Exception)
                {
                    MessageBox.Show("Чтение не выполнено", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                } // try-catch
            }//if
        }

        private void command_save(object sender, RoutedEventArgs e)
        {
            //создали 
            _sfd = TvController.Sfd();
            //стандартный диалог
            if (_sfd.ShowDialog() == true)
            {
                //попытка сериализации
                try
                {
                    //проверка
                    if (_tvController == null)
                        throw new Exception();
                    //передаем в метод
                   _tvController.Serial(_tvController, _sfd.FileName);
                    MessageBox.Show("Сохранение выполнено", "Предупреждение", MessageBoxButton.OK,
                        MessageBoxImage.Information, MessageBoxResult.OK);
                }
                catch (Exception)
                {
                    MessageBox.Show("Сохранение не возможно", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                } // try-catch
            }//if
        }

        private void command_exsit(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
