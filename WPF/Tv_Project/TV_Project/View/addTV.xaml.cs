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
using TV_Project.Controller;
using TV_Project.Modes;

namespace TV_Project.View
{
    /// <summary>
    /// Окно для добовления данных, служит для передачи данных в коллекцию 
    /// </summary>
    public partial class addTV : Window
    {
        public TvModel NewTVModel  { get; set; }
        public addTV()
        {
            InitializeComponent();
        }
        //Конструктор для формы изменить
        public addTV(TvModel tvModel)
        {
            InitializeComponent();
            modif(tvModel);
        }
        private void addBtn_click(object sender, RoutedEventArgs e)
        {
            NewTVModel = new TvModel
            {
                Brand = txbBrand.Text,
                Screen = int.Parse(txbScreen.Text),
                Vertical = int.Parse(txbVertical.Text),
                Horizontal = int.Parse(txbHorizontal.Text),
                Price = int.Parse(txbPrice.Text),
                Type = txbType.Text
        }; //NewTVModel
            DialogResult = true;
           
        }// addBtnclick

        public void modif(TvModel tvModel)
        {
            Title = "Изменение записи";
            addBtn.Content = "Сохранить";
            txbBrand.Text = tvModel.Brand.ToString();
            txbScreen.Text = tvModel.Screen.ToString();
            txbVertical.Text = tvModel.Vertical.ToString();
            txbHorizontal.Text = tvModel.Horizontal.ToString();
            txbPrice.Text = tvModel.Price.ToString();
            txbType.Text = tvModel.Type.ToString();
        } //end


    } // class end

}
