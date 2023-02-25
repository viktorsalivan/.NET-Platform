-- Техническое описание базы --

-- Breed (порода)
--id
--Name (название породы)
-- Avgeggs (Яйциносность породы) (средние количисво яиц в год)
-- Avgweight (средний вес породы)
--Diet (номер диеты)

-- Chicken (Курица) -- Всё что здесь написанно характерно для определённой курицы
-- Weight (вес)
-- Age (возрост)
-- Eggs (количество яиц)
-- IdBreed (идентификатор породы) -- для связи с Breed
-- IdWorkshop (индетификатор цеха) -- для связи с цехами

-- Worker (Работник)
-- SurnameNP (ИНФ)
-- Pasport (паспорт)
-- Selary (зарплата)
-- IdWorkshop (индетификатор цеха) --  для связи с цехом
-- WorkerStatus (Работает работник или нет)

--Workshop (цех)
-- id 
-- Number -- Номер цеха 

--1.	Какое количество яиц получают от каждой курицы данного веса, породы, возраста?
--2.	В каком цехе наибольшее количество кур определенной породы?
--3.	В каких клетках находятся куры указанного возраста с заданным номером диеты?
--4.	Сколько яиц в день приносят куры указанного работника?
--5.	Среднее количество яиц, которое получает в день каждый работник от обслуживаемых им кур?
--6.	В каком цехе находится курица, от которой получают больше всего яиц?
--7.	Сколько кур каждой породы в каждом цехе?
--8.	Какое количество кур обслуживает каждый работник?
--9.	Какова для каждой породы разница между показателями породы и средними показателями по птицефабрике?
use farm_bd; -- connect 

--1.	Какое количество яиц получают от каждой курицы данного веса, породы, возраста?
	select 
	Breed.Name
	, Chicken.Weight
	, Chicken.Age
	, Chicken.Eggs
	From Chicken join Breed on Chicken.IdBreed = Breed.id
	Where Breed.Name = 'Авиколор' and Chicken.Weight = 3 and Chicken.Age = 2;
go


--2.	В каком цехе наибольшее количество кур определенной породы?
	Select
	Breed.Name
	,MAX(Chicken.IdWorkshop)  as Result
	From  Chicken join Breed on Chicken.IdBreed = Breed.id
	WHERE Breed.Name = 'Загорская лососевая'
	group by Breed.Name;
	go

--3.	В каких клетках находятся куры указанного возраста с заданным номером диеты?
	Select 
	Breed.Name
	, Chicken.Age
	, Breed.Diet
	, Chicken.IdWorkshop
	From Chicken join Breed on Chicken.IdBreed = Breed.id
	WHERE Chicken.Age = 2 and Breed.Diet = 1;
	go
--4.	Сколько яиц в день приносят куры указанного работника?
	Select 
	SUM(Chicken.Eggs) SumEggs
	From Chicken join Worker on Chicken.IdWorker = Worker.id 
	  join Breed on Chicken.IdBreed = Breed.id
	  Where  Worker.SurnameNP = 'Крылова Александра Захаровна' and Worker.WorkerStatus = 1
	  go


--5.	Среднее количество яиц, которое получает в день каждый работник от обслуживаемых им кур?-
	Select 
	Worker.SurnameNP
	,AVG(Chicken.Eggs) as AVGEgss 
	From Chicken join Worker on Chicken.IdWorker = Worker.id 
	  join Breed on Chicken.IdBreed = Breed.id
		Group by Worker.SurnameNP;
	go
	
	--6.	В каком цехе находится курица, от которой получают больше всего яиц?
	Select
	Breed.Name
	,Chicken.IdWorkshop
	,Chicken.Eggs
	From Chicken join Breed on Chicken.IdBreed = Breed.id
	Where Chicken.Eggs = (Select Max(Chicken.Eggs)  From Chicken join Worker on Chicken.IdWorker = Worker.id 
	  join Breed on Chicken.IdBreed = Breed.id);
	  go

	  --7.	Сколько кур каждой породы в каждом цехе? -- не уверен, что это правельно
	Select 
	Breed.id as НомерПороды
	,Count (Chicken.id) as КоличиствоКуриц
	From Chicken join Breed on Chicken.IdBreed = Breed.id
	Group by Breed.id;
 go

	 --8.	Какое количество кур обслуживает каждый работник?
	  Select
	  Worker.SurnameNP
	  ,COUNT (Chicken.id) as 'CountChicken`S'
	  From Chicken join Worker on Chicken.IdWorker = Worker.id 
	  join Breed on Chicken.IdBreed = Breed.id
	  Group by Worker.SurnameNP;
	  go
	  
	  --9.	Какова для каждой породы разница между показателями породы и средними показателями по птицефабрике? - Хранимая процедура?

	  Select
	  Breed.Avgeggs - Chicken.Eggs as differenceEggs,
	  Breed.Avgweight - Chicken.Weight as differenceWeight
	  From Chicken join Breed on Chicken.IdBreed = Breed.id;
		go

	--Отчет должен включать следующую информацию: 
--	количество кур и средняя производительность по каждой породе,
--	общее количество кур на фабрике,
--	общее количество яиц, полученное птицефабрикой за отчетный месяц,
--	общее количество работников и их распределение по цехам. 
	
	--1. количество кур и средняя производительность по каждой породе,
	Select 
	Breed.id,
	Report.IdChicken,
	Breed.Avgeggs
	From Report join Breed on Report.IdBreed = Breed.id;
	go	

	-- 2.общее количество кур на фабрике,    
	Select Chicken.id as Chicken
    From Chicken;
	go
	
	-- 3.общее количество яиц, полученное птицефабрикой за отчетный месяц,
	Select
	Report.CountEggs
	From Report 
	Where Report.Date = '2022-02-24';
	go

	--4.общее количество работников и их распределение по цехам. 
	Select Worker.SurnameNP,
	Worker.IdWorkshop,
	Worker.WorkerStatus
	From Worker
	Where Worker.WorkerStatus = 1;
	go
	
                          
     