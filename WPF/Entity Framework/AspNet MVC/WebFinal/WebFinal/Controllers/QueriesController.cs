using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebFinal.Models;
using WebFinal.ViewModels;
// Вдумчиво прочитатать Матареал по теме (Не забыть) - https://metanit.com/sharp/mvc5/3.2.php?ysclid=l34spk7o93
namespace WebFinal.Controllers
{
    //Если нужно передать данные в форму POST - 
    //Если просто ввывод GET
    public class QueriesController : Controller
    {
        private FarmEntities _db; // создаём переменную для получения доступа к бд
        // GET: Queries
        public ActionResult Index()
        {
            _db = new FarmEntities(); // создаём экземпляр бд, для взаимодействия в контроллере 
            return View();
        }
        public ActionResult Query1()
        {
           
            return View();
        }

        #region Запросы на выборку 
        // POST: Query1
        [HttpPost]
        public ActionResult Query1(string tempName, string tempAge, string tempWeight)
        {
            
            _db = new FarmEntities();
            int IntAge = int.Parse(tempAge);
            int IntWeight = int.Parse(tempWeight);

            var query = (from item in _db.Chickens
                         where item.Breed.Name == tempName && item.Weight == IntWeight && item.Age == IntAge
                         select new
                         {
                             item.Breed.Name,
                             item.Age,
                             item.Weight

                         } into q1
                         //Модель предстовления приваемываем Анонимные тип
                         select new Query1ViewModel()
                         {
                             Bname = q1.Name,
                             Cage = q1.Age,
                             Cweight = q1.Weight
                         }).ToList();
                         

                        
            return View(query);
        }

        public ActionResult Query3()
        {

            return View();
        }

        // POST: Query3
        [HttpPost]
        public ActionResult Query3(string tempAge, string tempDiet)
        {
            _db = new FarmEntities(); // Подключаемся к бд
            //Парсми(конвентируем строку в число, для запроса.)
            int IntAge = int.Parse(tempAge);
            int IntDiet = int.Parse(tempDiet);

            var query = (from item in _db.Chickens
                         where item.Age == IntAge && item.Breed.Diet == IntDiet
                         select new
                         {
                             item.Breed.Diet,
                             item.Age,
                             item.IdWorkshop,

                         } into q3
                         //Модель предстовления приваемываем Анонимные тип
                         select new Query3ViewModel()
                         {

                             BDiet = q3.Diet,
                             CAge = q3.Age,
                             Idw = q3.IdWorkshop
                         }).ToList();

            return View(query);
        }

        
       

        // GET: Query 9
        public ActionResult Query9()
        {
            _db = new FarmEntities(); // Подключение к бд 
            var query = (from item in _db.Chickens
                         select new
                         {
                             item.Breed.Avgeggs,
                             item.Breed.Avgweight,
                             item.Eggs,
                             item.Weight,

                             differenceEggs = item.Breed.Avgeggs - item.Eggs,
                             differenceWeight = item.Breed.Avgweight - item.Weight,
                         } into q9
                         //Модель предстовления приваемываем Анонимные тип
                         select new Query9ViewModel()
                         {
                             BAvgEggs = q9.Avgeggs,
                             BAvgWeight = q9.Avgweight,
                             CEggs = q9.Eggs,
                             CWeight = q9.Weight,
                             differenceEggs = q9.Avgeggs - q9.Eggs,
                             differenceWeight = q9.Avgweight - q9.Weight,
                         }).ToList();


            return View(query);
        }
        #endregion
        #region АгрегатныеФункции по заданию 
        public ActionResult Query4()
        {
            return View();
        }

        // POST: Query 4
        [HttpPost]
        public ActionResult Query4(string tempName)
        {
            _db = new FarmEntities(); // Подключение к бд 
            var query = from item in _db.Chickens
                         where item.Worker.SurnameNP == tempName && item.Worker.WorkerStatus == true
                         select new
                         {
                             item.Eggs,
                             item.Worker
                         };
                         
             ViewBag.summa = _db.Chickens.Sum(x => x.Eggs);
            return View(ViewBag.summa);
        }


        #endregion

        // GET: Query 5
        #region Группировка
        public ActionResult Query5()
        {
            _db = new FarmEntities(); // Подключение к бд 
            var query = (from item in _db.Chickens
                         group item by item.Worker.SurnameNP
                         into newGroup
                         select new
                         {
                             SurnameNP = newGroup.Key,
                             AvgEgss = newGroup.Average(x => x.Eggs)
                         } into q5
                         //Модель предстовления приваемываем Анонимные тип
                         select new Query5ViewModel()
                         {
                             SurNameNP = q5.SurnameNP,
                             AvgEgss = q5.AvgEgss,
                         }).ToList();

            return View(query);
        }
        // GET: Query 2
        public ActionResult Query2()
        {

            return View();
        }
        // POST: Query 2
        [HttpPost]
        public ActionResult Query2(string tempName)
        {
            _db = new FarmEntities(); // Подключение к бд 
            var query = (from item in _db.Chickens
                         where item.Breed.Name == tempName
                         group item by item.Breed.Name
                         into newGroup
                         select new
                         {
                             Name = newGroup.Key,
                             MAXChicken = newGroup.Max(x => x.IdWorkshop)
                         } into q2
                         //Модель предстовления приваемываем Анонимные тип
                         select new Query2ViewModel()
                         {
                             Bname = q2.Name,
                             MaxChicken = q2.MAXChicken
                         }).ToList();
            return View(query);
        }

        // GET: Query 6
       
        public ActionResult Query6()
        {
            _db = new FarmEntities(); // Подключение к бд 
            var query = (from item in _db.Chickens
                        group item by item.IdWorkshop
                        into newGroup
                        select new
                        {
                            Workshop = newGroup.Key,
                            MaxEgss = newGroup.Max(x => x.Eggs)
                        } into q6
                         //Модель предстовления приваемываем Анонимные тип
                         select new Query6ViewModel()
                        {
                            WorksShop = q6.Workshop,
                            MaXEgss = q6.MaxEgss
                            
                        }).ToList();

                return View(query);
        }

        // GET: Query 7
       
        public ActionResult Query7()
        {
            _db = new FarmEntities(); // Подключение к бд 
            var query = (from item in _db.Chickens
                         group item by item.Breed.Name
                        into newGroup
                         select new
                         {
                             Name = newGroup.Key,
                             Count = newGroup.Count()
                         } into q7
                         //Модель предстовления приваемываем Анонимные тип
                         select new Query7ViewModel()
                         {
                             Bname = q7.Name,
                             Ccount = q7.Count
                         }).ToList();
            return View(query);
        }

        // GET: Query 8
       
        public ActionResult Query8()
        {
            _db = new FarmEntities(); // Подключение к бд 
            var query = (from item in _db.Chickens
                         group item by item.Worker.SurnameNP
                        into newGroup
                         //Модель предстовления приваемываем Анонимные тип
                         select new
                         {
                             Name = newGroup.Key,
                             Count = newGroup.Count()
                         } into q8
                         select new Query8ViewModel()
                         {
                             SurNameNP = q8.Name,
                             CCount = q8.Count
                         }).ToList();
            return View(query);
        }
        #endregion
        #region Остольное 
        // GET: Query1Advanced
        public ActionResult Query1Advanced()
        {
            _db = new FarmEntities(); // Подключение к бд 
            var query = (from item in _db.Breeds
                         select new
                         {
                             item.Name,
                             item.Avgeggs
                         } into advancedQ1
                         select new Query1AdvancedViewModel()
                         {
                             Cname = advancedQ1.Name,
                             AVG = advancedQ1.Avgeggs


                         }).ToList();

            return View(query);
        }

        // GET: Query2Advanced
        public ActionResult Query2Advanced()
        {
            _db = new FarmEntities(); // Подключение к бд 
            var query = from item in _db.Chickens
                        select new
                        {
                            item.id
                        };
                 @ViewBag.cout = _db.Chickens.Count();
            return View(@ViewBag.cout);
        }

        // GET: Query3Advanced
     
        public ActionResult Query3Advanced()
        {
            _db = new FarmEntities();
            var query = from item in _db.Chickens
                        select new
                        {
                            item.Eggs
                        };
            ViewBag.summa = _db.Chickens.Sum(x=> x.Eggs);
            return View(ViewBag.summa);
        }
        #endregion




    } //class
}//end 