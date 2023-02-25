using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_Final.Models;

namespace WPF_Final.Controllers
{
    
    public class QueriesController
    {
        

        private FarmEntities _db;
        //Конструктор - создан для удобства, но можно было обойтись и без него 
        public QueriesController()
        {
            _db = new FarmEntities();
          

        } // констуктор 
        

        #region фильтер для работников
        public IEnumerable QueryFilterWorker() =>

             _db.Workers.Select(x => new
             {
                 x.id,
                 x.SurnameNP,
                 x.Pasport,
                 x.Selary,
                 x.IdWorkshop,
                 x.WorkerStatus
           
             }).Where(x => x.WorkerStatus == true)
         .ToList();

        #endregion
        #region Запросы на выборку по заданию 
        public IEnumerable Query1(string tempName, int tempAge, int tempWeight) =>


                // 1.Какое количество яиц получают от каждой курицы данного веса, породы, возраста?
                _db.Chickens
                .Select(x => new
                {
                    x.Breed.Name,
                    x.Weight,
                    x.Age,
                
                }).Where(x => x.Name.Contains(tempName) && (x.Weight == tempWeight) && (x.Age == tempAge))
                .ToList();

        //Query1

        
        public IEnumerable Query3(int tempDiet, int tempAge) =>

           //3.В каких клетках находятся куры указанного возраста с заданным номером диеты?

           _db.Chickens.Select(x => new
           {
               x.Breed.Name,
               x.Age,
               x.Breed.Diet,
               x.IdWorkshop,
        
           }).Where(x => x.Age == tempAge && (x.Diet == tempDiet))
            .ToList();

        public IEnumerable Query9() =>

          //9 Какова для каждой породы разница между показателями породы и средними показателями по птицефабрике? 

          _db.Chickens.Select(x => new
          {
              x.Breed.Avgeggs,
              x.Breed.Avgweight,
              x.Eggs,
              x.Weight,

              differenceEggs = x.Breed.Avgeggs - x.Eggs,
              differenceWeight = x.Breed.Avgweight - x.Weight,

          }).ToList();

        #endregion

        #region АгрегатныеФункции по заданию 
        public int Query4(string tempName) =>


           //4.Сколько яиц в день приносят куры указанного работника?
           _db.Chickens.Select(x => new
           {
               x.Eggs,
               x.Worker

           }).Where(x => x.Worker.SurnameNP == tempName && (x.Worker.WorkerStatus == true))
            .Sum(x => x.Eggs);

       
              



        #endregion

        #region Групировка по заданию

        public IEnumerable Query5() =>
          //5.Среднее количество яиц, которое получает в день каждый работник от обслуживаемых им кур? (НЕ Проходит тест на сценарий, не забудь исправить)
          _db.Chickens.GroupBy(x => x.Worker.SurnameNP, (key, group)
              => new
              {
                  SurnameNP = key,
                  AvgEgss = group.Average(x => x.Eggs),

              }).ToList();
       
        //2.В каком цехе наибольшее количество кур определенной породы? 
        public IEnumerable Query2(string tempName) =>
         _db.Chickens.Select(x => new
        {
          x.Breed.Name,
          x.IdWorkshop,


        }).GroupBy(t => t.Name)
         .Select(newGroup => new
        {
            name = newGroup.Key,
            MAXChicken = newGroup.Max(x => x.IdWorkshop),

         }).Where(x => x.name == tempName)
          .ToList();

        //6. В каком цехе находится курица, от которой получают больше всего яиц?
        public IEnumerable Query6() =>

          _db.Chickens.GroupBy(x => x.IdWorkshop, (key, group)
              => new
              {
                  Workshop = key,
                  MaxEgss = group.Max(x => x.Eggs),

              }).ToList();

        // 7.	Сколько кур каждой породы в каждом цехе? -- не уверен, что это правельно
        public IEnumerable Query7() =>
         
         _db.Chickens.GroupBy(x => x.Breed.Name, (key, group)
             => new
             {
                Name = key,
                 Count = group.Count()

             }).ToList();

        //8.Какое количество кур обслуживает каждый работник?

        public IEnumerable Query8() =>

        _db.Chickens.GroupBy(x => x.Worker.SurnameNP, (key, group)
            => new
            {
                Name = key,
                Count = group.Count()

            }).ToList();

        #endregion
        #region Остольное 
        // Вывод всех работников с WorkStatus => 0
        public IEnumerable QueryDismissed() =>
       _db.Workers.Select(x => new
       {
           
           x.id,
           x.SurnameNP,
           x.Pasport,
           x.Selary,
           x.IdWorkshop,
           x.WorkerStatus

       }).Where(x => x.WorkerStatus == false)
         .ToList();
      
        // 1.средняя производительность по каждой породе,
        public IEnumerable Query1Advanced() =>
             _db.Breeds.Select(x => new
             {
                 x.Name,
                 x.Avgeggs
        
             }).ToList();
        //2.общее количество кур на фабрике,    
        public int Query2Advanced() =>
            _db.Chickens.Select(x => new
            {
                x.id

            }).Count();

        //3.общее количество яиц, полученное птицефабрикой за отчетный месяц, !!!!!!!
        public int Query3Advanced() =>
            _db.Chickens.Select(x => new
            {
                x.Eggs
            }).Sum(x => x.Eggs);
        #endregion

    } //QueriesController
} // end 

