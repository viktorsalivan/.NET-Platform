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
using WPF_Final.Models;

namespace WPF_Final.View
{
    /// <summary>
    /// Логика взаимодействия для AddWorker.xaml
    /// </summary>
      //https://metanit.com/sharp/entityframework/1.3.php - примеры вополниня 
    public partial class AddWorker : Window
    {
        private Worker _worker; // предстовление для класса Worker
        public AddWorker()
        {
            InitializeComponent();
            _worker = new Worker(); //Создания нового экземпляра класса Worker на форме (инициализация класса)
        }

        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            _worker.SurnameNP = txbSurnameNP.Text;
            _worker.Pasport = txbPasport.Text;
            _worker.Selary = int.Parse(txbSelary.Text);
            _worker.IdWorkshop = int.Parse(txbIdWorkshop.Text);
            _worker.WorkerStatus = bool.Parse(txbWorkerStatus.Text); // нужно сделать выподающий список 
            //using на сколько я помню, это временное пространство (Буфер где хранится наш обьект, после выхода из констукции
            //вызывается деструктор, поправте если ошибаюсь, это вопрос, а не утверждение.
            using (FarmEntities db = new FarmEntities())
            {
                db.Workers.Add(_worker);
                db.SaveChanges();
            }
            // закрыть окно с признаком OK
            DialogResult = true;
            MessageBox.Show("Операция успешно выполнина!", "База данных");
            Close();
        }
    }
}
