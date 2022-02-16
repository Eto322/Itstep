-- 1.Вывести количество товаров по категории Dairy Products
SELECT COUNT(*) AS 'DAIIRY PRDUCT COUNT'
FROM Products
WHERE Products.CategoryID=(
						   SELECT Categories.CategoryID
						   FROM Categories
						   WHERE Categories.CategoryName='Dairy Products')
--2. Вывести количество территорий по которым работает Andrew Fuller
SELECT COUNT(*) AS 'NUMBER OF TERITORIES'
FROM EmployeeTerritories
WHERE EmployeeTerritories.EmployeeID=( 
									   SELECT Employees.EmployeeID
									   FROM Employees
									   WHERE Employees.FirstName='Andrew' AND Employees.LastName='Fuller')

--3 Вывести имя  региона и количество территорий по каждому.
SELECT RegionDescription
 ,COUNT(Territories.RegionID) AS 'NUMBER OF REGION'
FROM Region,Territories
WHERE Region.RegionID=Territories.RegionID
GROUP BY RegionDescription
 
 --4 Вывести средний возраст сотрудников.
 -- У сотрудников не оказалось поля возраст , для вичисления использовал вот такую штуку ( нашли количество дней между днем рождения и текущей датой и поделили на 356.25 - для учёта еще высокосных)
 SELECT AVG(FLOOR(DATEDIFF(DAY, Employees.BirthDate, GETDATE()) / 365.25)) AS  'AVARAGE AGE'
 FROM Employees

 -- Пример подсчёта 
SELECT FLOOR(DATEDIFF(DAY, Employees.BirthDate, GETDATE()) / 365.25) AS 'AGE', 
Employees.BirthDate,Employees.FirstName,Employees.LastName
FROM Employees

--5  Вывести катигорию и средний возраст покупателей по каждой.
-- Это выполнить невозможно поскольку у покупателя даже нет даты рождения

--6 Вывести количество единиц товара обаботанных перевозчиком United Package.
--Количество имметься ввиду count или sum сделал оба варианта
 SELECT COUNT(*) as 'number of orders'--Вывели количество ордеров которые выполнила компания 
 FROM Orders
 where Orders.ShipVia=(
					   SELECT Shippers.ShipperID
					   FROM Shippers
					   WHERE Shippers.CompanyName='United Package')

 
 SELECT SUM([Order Details].Quantity) as 'number of orders'--количество едениц товара --вот это более правильно 
 FROM Orders
 ,[Order Details]
 where Orders.ShipVia=(
					   SELECT Shippers.ShipperID
					   FROM Shippers
					   WHERE Shippers.CompanyName='United Package') 
																	AND Orders.OrderID=[Order Details].OrderID--не уверен тут по стилистике , может лучше было оставить сразу напротив  вложеного, а лучше просто с начала написать





--7 Вывести минимальное и максимальное количество наименований товаров в категорях.
SELECT MAX(CAT.COUNTT)AS MaxValue
       , MIN(CAT.COUNTT)AS MinValue
FROM (
	 SELECT COUNT(P.CategoryID) AS [COUNTT] 
     FROM Products AS P 
     JOIN Categories AS CAT 
     ON P.CategoryID = CAT.CategoryID 
     GROUP BY CAT.CategoryName) AS CAT
       

--8 Вывести среднее количество територий на сотрудника.
SELECT AVG(T.[count])  AS 'MIDDLE'
FROM (
	   SELECT COUNT(TER.TerritoryID) AS 'count'
	   FROM Territories AS TER
	   JOIN EmployeeTerritories AS EMPTER
	   ON EMPTER.TerritoryID=TER.TerritoryID
	   JOIN Employees AS EMP
	   ON EMP.EmployeeID=EMPTER.EmployeeID
	    GROUP BY (EMP.FirstName+' '+EMP.LastName))as T


--9 Вывести полные имена сотрудников и количество регионов по которым они работают.
 SELECT EMP.EmployeeID, 
 CONCAT_WS(' ', EMP.FirstName ,EMP.LastName) AS FULLNAME,
 (
 SELECT COUNT(*)
 FROM EmployeeTerritories AS EMPT
 WHERE EMPT.EmployeeID=EMP.EmployeeID) AS COUNT
 FROM Employees AS EMP


--10 Вывести стоимость остатков на складе для категории Condiments.
-- тут я до конца был уверен что это сработать не должно , не был уверен посчитает ли PR.UnitsInStock*PR.UnitPrice  , ну я в итоге результат в ручную посчитал и получилось ЧУДО как йогурт
SELECT SUM(PR.UnitsInStock*PR.UnitPrice)
FROM Products AS PR
WHERE PR.CategoryID=( 
					 SELECT Categories.CategoryID
                     FROM Categories
                     WHERE Categories.CategoryName='Condiments')



							
 