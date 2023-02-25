using Microsoft.Win32;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using TV_Project.Modes;

namespace TV_Project.Controller
{
    [Serializable]
    public class TvController
    {
        //Колекция для хранения данных +
        public ObservableCollection<TvModel> DataTV { get; set; }
        //Констукторы 
        public TvController() { }

        public TvController(ObservableCollection<TvModel> dataTV)
        {
            DataTV = dataTV;
        }


        //Метод для храниения колеции 
        public void InitializeTvs()
        {
            DataTV = new ObservableCollection<TvModel>
            {
               
            };
        } //InitializeTvs
        public void deleteTv(int index)
        {
            DataTV.RemoveAt(index);

        }


        public static OpenFileDialog Ofd()
        {
            OpenFileDialog ofd = new OpenFileDialog
            {
                Multiselect = false,
                Title = "Файл данных для загрузки",
                Filter = "Файлы XML (*.xml)|*.xml|Все файлы (*.*)|*.*",
                FilterIndex = 0,
                //нашел что бы в корень проекта попадало
                InitialDirectory = Environment.CurrentDirectory
            };
            return ofd;
        }//Ofd

        //вынес создание Sfd в контролер
        public static SaveFileDialog Sfd()
        {
            SaveFileDialog sfd = new SaveFileDialog
            {
                FileName = @"Data.xml",
                Title = "Файл данных для сохранения",
                Filter = "Файлы XML (*.xml)|*.xml|Все файлы (*.*)|*.*",
                FilterIndex = 0,
                //что бы в корень проекта попадало
                InitialDirectory = Environment.CurrentDirectory
            };
            return sfd;
        }//Sfd


        public TvController Deserial(string fileName)
        {
            //конструктор форматтера
            XmlSerializer formatter = new XmlSerializer(typeof(TvController));
            //создаем контролер для возрата его в форму
            TvController controller;
            using (FileStream fs = new FileStream(fileName, FileMode.Open))
            {
                controller = (TvController) formatter.Deserialize(fs);
            } // using
            return controller;
        }//Deserial

        //сериализация
        public void Serial(TvController controller, string fileName)
        {
            //если список пустой, нечего сериализовать
            if (controller.DataTV.Count == 0)
                throw new Exception();
            //конструктор форматтера
            XmlSerializer formatter = new XmlSerializer(typeof(TvController));
            using (FileStream fs = new FileStream(fileName, FileMode.Create))
            {
                formatter.Serialize(fs, controller);
            } // using
        }//Serial
    }
}
