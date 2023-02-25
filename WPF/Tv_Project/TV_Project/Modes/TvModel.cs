using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace TV_Project.Modes
{
    [Serializable]
    public class TvModel : DependencyObject
    {
        /// <TvModel>
        /// Описание товара для работы
        /// </TvModel>
       
        // Название бренда 
        public string Brand
        {
            get { return (string)GetValue(BrandProperty); }
            set { SetValue(BrandProperty, value); }
        }

        public static readonly DependencyProperty BrandProperty =
            DependencyProperty.Register("Brand", typeof(string), typeof(TvModel));

        // Диагональ экрана

        public int Screen
        {
            get { return (int)GetValue(ScreenProperty); }
            set { SetValue(ScreenProperty, value); }
        }

        public static readonly DependencyProperty ScreenProperty =
            DependencyProperty.Register("Screen", typeof(int), typeof(TvModel));


        public int Vertical
        {
            get { return (int)GetValue(VerticalProperty); }
            set { SetValue(VerticalProperty, value); }
        }

        public static readonly DependencyProperty VerticalProperty =
            DependencyProperty.Register("Vertical", typeof(int), typeof(TvModel));



        public int Horizontal
        {
            get { return (int)GetValue(HorizontalProperty); }
            set { SetValue(HorizontalProperty, value); }
        }

        public static readonly DependencyProperty HorizontalProperty =
            DependencyProperty.Register("Horizontal", typeof(int), typeof(TvModel));

        // Цена 
        public int Price
        {
            get { return (int)GetValue(PriceProperty); }
            set { SetValue(PriceProperty, value); }
        }

        public static readonly DependencyProperty PriceProperty =
            DependencyProperty.Register("Price", typeof(int), typeof(TvModel));


        public string Type
        {
            get { return (string)GetValue(TypeProperty); }
            set { SetValue(TypeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Type.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TypeProperty =
            DependencyProperty.Register("Type", typeof(string), typeof(TvModel));



        //Констукторы

        public TvModel()
        { }

        public TvModel(string brand, int screen, int vertical, int horizontal, int price, string type)
        {
            Brand = brand;
            Screen = screen;
            Vertical = vertical;
            Horizontal = horizontal;
            Price = price;
            Type = type;
        }
    }








    
}
