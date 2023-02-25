using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebFinal.ViewModels
{
    public class Query3ViewModel
    {
        //Название породы 
        public  string Bname { get; set; }
        //Диета 
        public int BDiet { get; set; }
        //Возраст 
        public int CAge { get; set; }
        // Номер цеха
        public int Idw { get; set; }
    }
}