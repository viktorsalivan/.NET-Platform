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
    /// Логика взаимодействия для ChengeWorker.xaml
    /// </summary>
    //https://metanit.com/sharp/entityframework/1.3.php - примеры вополниня 

    public partial class ChengeWorker : Window
    {
        FarmEntities db = new FarmEntities();
       
        public ChengeWorker(int index)
        {
            InitializeComponent();
            

        }

        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
          
            using (FarmEntities db = new FarmEntities())
            {
                Worker _worker = db.Workers.FirstOrDefault();
                _worker.SurnameNP = txbSurnameNP.Text;
                _worker.Pasport = txbPasport.Text;
                _worker.Selary = int.Parse(txbSelary.Text);
                _worker.IdWorkshop = int.Parse(txbIdWorkshop.Text);
                _worker.WorkerStatus = bool.Parse(txbWorkerStatus.Text);
                db.SaveChanges();
            }
            // закрыть окно с признаком OK
            DialogResult = true;
            MessageBox.Show("Операция успешно выполнина!","База данных");
            Close();
        }
    }
}
