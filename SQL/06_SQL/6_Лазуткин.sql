--1 Вывести категории продуктов в которых количество товаров от 8 до 12

SELECT CAT.CategoryName
FROM Categories AS CAT
WHERE CAT.CategoryID= ANY  (
							SELECT PR.CategoryID
							FROM Products as PR
							WHERE PR.UnitsInStock BETWEEN 8 AND 12)

--2 Вывести названия товаров которые были заказаны более 5 раз.
SELECT PR.ProductName
FROM Products AS PR
WHERE PR.ProductID=ANY( 
					   SELECT OD.ProductID
					   FROM [Order Details] AS OD
					   WHERE OD.Quantity>5)

							  

--3 Вывести названия категорий, в которых товаров больше среднего значения.
-- Возможно тут надо было считать, с таблички ORDER DETAILS.QUANTITY  но по мне это не логично
-- поскольку нам же надо пoсмотреть где у нас идет перебор товара , а это соотвественно товар который находиться у нас в магазине(Products.UnitsInStock) а не тот что заказали(ORDER DETAILS.QUANTITY) 

SELECT Categories.CategoryName,Products.ProductName,Products.UnitsInStock--Более информативно
FROM Categories,Products
WHERE Products.CategoryID=Categories.CategoryID AND  Products.UnitsInStock>(SELECT AVG(Products.UnitsInStock) 
																			FROM Products)

SELECT distinct Categories.CategoryName--менее информативно но зато как в задании 
FROM Categories,Products
WHERE Products.CategoryID=Categories.CategoryID AND  Products.UnitsInStock>(SELECT AVG(Products.UnitsInStock) 
																			FROM Products)


SELECT AVG(Products.UnitsInStock) --подсчёт avg для проверки
FROM Products

--4 Вывести названия продуктов, объём продаж которых больше среднего значения.
SELECT PR.ProductName,PR.UnitsOnOrder
FROM Products AS PR
WHERE PR.UnitsOnOrder>(
					   SELECT AVG(PRR.UnitsOnOrder)
					   FROM Products as PRR)
--5. Вывести имена сотрудников, у которых меньше 5 территорий.
-- На удивления сработало,хотя я думал что если я просто укажу больше 5 то ничего с этого не получу в самом изначальном select(--1)
SELECT E.EmployeeID,E.FirstName+' '+E.LastName AS FULLNAME--1
FROM Employees AS E
WHERE (
		SELECT COUNT(*)
		FROM EmployeeTerritories AS EMPT
	    WHERE EMPT.EmployeeID=E.EmployeeID)>5


--6.Вывести имена категорий, средняя стоимость товаров по которым выше чем аналогичный показатель по категории Seafood
--очень долго с этим маялся , пытался сделать как можно меньше под запросов что у меня собственно не получилось :( , пришел к вот такому варианту с join
SELECT CATS.CategoryName
FROM Products
 JOIN Categories AS CATS 
  ON Products.CategoryID=CATS.CategoryID 
WHERE (
 SELECT AVG(PR.UnitPrice)
 FROM Products AS PR
 WHERE PR.CategoryID=(SELECT CATT.CategoryID
					 FROM  Categories AS CATT
					 WHERE CATT.CategoryName='Seafood'))<(
														   SELECT AVG(PR.UnitPrice)
															FROM Products AS PR
															WHERE PR.CategoryID=(
																				SELECT CATT.CategoryID
																				FROM  Categories AS CATT
																				WHERE CATT.CategoryID=CATS.CategoryID))
GROUP BY CATS.CategoryName




--7. Вывести названия категорий, выручка по продажам товаров которой выше чем у Dairy Products
--аналогичгие проблемы что и с 6
SELECT CATS.CategoryName
FROM Products
 JOIN Categories AS CATS 
  ON Products.CategoryID=CATS.CategoryID 
WHERE (
 SELECT SUM(PR.UnitPrice*PR.UnitsOnOrder)
 FROM Products AS PR
 WHERE PR.CategoryID=(SELECT CATT.CategoryID
					 FROM  Categories AS CATT
					 WHERE CATT.CategoryName='Dairy Products'))<(
														   SELECT SUM(PR.UnitPrice*PR.UnitsOnOrder)
															FROM Products AS PR
															WHERE PR.CategoryID=(
																				SELECT CATT.CategoryID
																				FROM  Categories AS CATT
																				WHERE CATT.CategoryID=CATS.CategoryID))
GROUP BY CATS.CategoryName


--8. Вывести названия категорий и полные имена сотрудлников, которые сделали по ним максимальную выручку.
--здесь точно не правильно , но я уже начал тут зависать (делал последним)
SELECT SUM(OD.Quantity*OD.UnitPrice*(1-OD.Discount)) , CAT.CategoryName,EMP.FirstName+EMP.LastName
FROM Categories AS CAT
 JOIN Products AS PR
  ON CAT.CategoryID=PR.CategoryID
   JOIN [Order Details] AS OD
    ON OD.ProductID=PR.ProductID
	 JOIN Orders AS O 
	  ON O.OrderID=OD.OrderID
	   JOIN Employees AS EMP
	    ON EMP.EmployeeID=O.EmployeeID
GROUP BY  CAT.CategoryName,EMP.FirstName,EMP.LastName



--9. Вывести название и фамилию контактного лица компании, которая заказала товаров на нибольшую сумму.

SELECT TOP 1 MAX(T.SUMM)AS SUMM , C.ContactName,C.CompanyName
FROM Customers AS C , 
(
  SELECT  SUM(OD.UnitPrice*OD.Quantity) as SUMM,CustomerID--посчитали сумму заказа + вывели кастомер ид
  FROM[Order Details] AS OD
   JOIN Orders AS O 
    ON OD.OrderID = O.OrderID 
  GROUP BY
    CustomerID
) AS T
WHERE C.CustomerID=T.CustomerID
GROUP BY C.ContactName,C.CompanyName
ORDER BY SUMM DESC
--10. Вывести количество товаров проданных в южном регионе.	
--в этом задание на долго завис, проблема оказалась в том поскольку один сотрудник может отвечать за несколько тереторий, и когда я пытался их саджойнить получил декартове 
--в итоге пришел к такому варианту 
SELECT MAX(SUMM) AS Quanity,REG.RegionDescription
FROM  Region AS REG
	JOIN Territories AS TER 
	ON TER.RegionID=REG.RegionID
	 JOIN EmployeeTerritories  AS EMPT
	 ON EMPT.TerritoryID=TER.TerritoryID
	  JOIN Employees AS EMP
	  ON EMP.EmployeeID=EMPT.EmployeeID
	   JOIN(
			SELECT SUM(OD.Quantity) SUMM,EmployeeID
			FROM [Order Details] AS OD
			 JOIN Orders AS O 
			  ON O.OrderID=OD.OrderID
			GROUP BY EmployeeID) T--нужно чтоб вернуть количество продуктов проданых определеным сотрудником и не получить декартовое
				ON EMP.EmployeeID= T.EmployeeID
GROUP BY REG.RegionDescription





	
	
			

