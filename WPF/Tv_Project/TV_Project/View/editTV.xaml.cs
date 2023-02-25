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
using TV_Project.Modes;

namespace TV_Project.View
{
    /// <summary>
    /// Логика взаимодействия для editTV.xaml
    /// </summary>
    public partial class editTV : Window
    {
        public TvModel EditModel { get; set; }
        public editTV()
        {
            InitializeComponent();
            EditModel = new TvModel();

        }

        private void editBtn_click(object sender, RoutedEventArgs e)
        {  
            txbBrand.Text = EditModel.Brand.ToString();
            txbScreen.Text = EditModel.Screen.ToString();
            txbVertical.Text = EditModel.Vertical.ToString();
            txbHorizontal.Text = EditModel.Horizontal.ToString();
            txbPrice.Text = EditModel.Price.ToString();
            txbType.Text = EditModel.Type.ToString();
            
        }
    }
}
