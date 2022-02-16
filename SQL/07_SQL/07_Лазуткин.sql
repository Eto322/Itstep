

--1. Вывести все заказы по произвольной категории, упорядочив их по дате заказа
SELECT*
FROM Categories AS CAT
    JOIN Products AS PR 
	ON CAT.CategoryID=PR.CategoryID
    JOIN [Order Details] AS OD 
	ON OD.ProductID=PR.ProductID
    JOIN [Orders] AS O 
	ON OD.OrderID=O.OrderID
WHERE CAT.CategoryID=1
ORDER BY O.OrderDate DESC


--2. Вывести информацию о пеhвом заказанном товаре.
SELECT TOP 1*
FROM Products AS PR
    JOIN [Order Details] AS OD 
	ON OD.ProductID=PR.ProductID
    JOIN Orders AS O 
	ON OD.OrderID=O.OrderID
ORDER BY O.OrderDate ASC

--3. Вывести категории товаров, выручка от продажи которых больше 1000.
--Очень не уверен в этом запросе но надеюсь что работает
SELECT  CAT.CategoryName
FROM Products AS PR
    JOIN Categories AS CAT 
	ON PR.CategoryID=CAT.CategoryID
where 1000<(
			select sum(PR.UnitsOnOrder*PR.UnitPrice)
			from Products as PR
			WHERE PR.CategoryID=CAT.CategoryID)
GROUP BY CAT.CategoryName
			

--4. Вывести количество сотрудников по каждому региону.
SELECT REG.RegionDescription,COUNT(DISTINCT ET.EmployeeID) as 'Number of Employees'
FROM Territories AS T
JOIN EmployeeTerritories AS ET
 ON T.TerritoryID=ET.TerritoryID
JOIN Region AS REG
 ON REG.RegionID=T.RegionID
 GROUP BY (REG.RegionDescription)




--5. Вывести наиболее часто заказываемую категорию товаров (по объему продаж)
SELECT TOP 1 SUM(OD.Quantity) AS 'Sum of Quanity' ,CAT.CategoryName
FROM Products AS PR
    JOIN Categories AS CAT 
	ON PR.CategoryID=CAT.CategoryID
    JOIN [Order Details] AS OD 
	ON OD.ProductID=PR.ProductID
GROUP BY CAT.CategoryName
ORDER BY [Sum of Quanity]DESC


---
SELECT  SUM(OD.Quantity) AS SUMOFQUANITY ,CAT.CategoryName
FROM Products AS PR
    JOIN Categories AS CAT 
	ON PR.CategoryID=CAT.CategoryID
    JOIN [Order Details] AS OD 
	ON OD.ProductID=PR.ProductID
GROUP BY CAT.CategoryName
ORDER BY SUMOFQUANITY DESC




	  	


--6. Вывести информацию о количестве заказов по каждой категории и количество заказов за 97й год

SELECT COUNT(DISTINCT OD.OrderID ) AS 'Order Count',CAT.CategoryName--считал с DISTINCT поскольку нам же надо посчитать отдельные заказы , и нас не должно волновать сколько товаров внутри заказа
FROM [Order Details] AS OD
    JOIN Orders AS O 
	ON O.OrderID=OD.OrderID
    JOIN Products AS PR 
	ON OD.ProductID=PR.ProductID
    JOIN Categories AS CAT 
	ON PR.CategoryID=CAT.CategoryID
WHERE O.OrderDate BETWEEN '1997-01-01' AND '1998-01-01'
GROUP BY CAT.CategoryName

--7. Вывести список сотрудников, которые продали товаров менее чем на 1000 за 98й год
-- Может я не правильно посчитал , но вроде правильно получаеться (цена*количество*скидку) и я в итоге получил очень страшние числа , поэтому тут 50 на 50 или у меня ошибка или в задание
-- для наглядности выполнения поменял 1000 на  50000


SELECT EMP.EmployeeID,EMP.FirstName,EMP.LastName,SUM(OD.UnitPrice*OD.Quantity*(1-OD.Discount)) AS 'ALL SUM'
FROM Employees EMP
    JOIN Orders AS O 
	ON EMP.EmployeeID=O.EmployeeID
    JOIN [Order Details] AS OD 
	ON OD.OrderID=O.OrderID
WHERE O.OrderDate  BETWEEN '1998-01-01' AND '1999-01-01' 
GROUP BY EMP.EmployeeID,EMP.FirstName,EMP.LastName
HAVING SUM(OD.UnitPrice*OD.Quantity*(1-OD.Discount))>50000




--8. Вывести информацию о количестве товаров проданных по каждой категории и доход по ним за 98й год  

SELECT COUNT (OD.ProductID) AS 'Count of products',CAT.CategoryName --или так 
FROM Categories AS CAT
   JOIN Products AS PR 
   ON CAT.CategoryID=PR.CategoryID
   JOIN [Order Details] AS OD 
   ON OD.ProductID=PR.ProductID
   JOIN Orders AS O 
   ON OD.OrderID=O.OrderID
WHERE O.OrderDate  BETWEEN '1998-01-01' AND '1999-01-01' 
GROUP BY CAT.CategoryName


SELECT SUM (OD.Quantity) AS 'Quanity',CAT.CategoryName --или так 
FROM Categories AS CAT
  JOIN Products AS PR 
  ON CAT.CategoryID=PR.CategoryID
  JOIN [Order Details] AS OD 
  ON OD.ProductID=PR.ProductID
  JOIN Orders AS O ON OD.OrderID=O.OrderID
WHERE O.OrderDate  BETWEEN '1998-01-01' AND '1999-01-01' 
GROUP BY CAT.CategoryName

--9. Вывести иноформацию о покупателях, сделавших заказы в 98м году с указанием количества заказов

SELECT CUS.CompanyName,COUNT(CUS.CustomerID) AS 'Number Of Orders'
FROM Orders AS O
  JOIN Customers AS CUS 
  ON O.CustomerID=CUS.CustomerID
WHERE O.OrderDate BETWEEN '1998-01-01' AND '1999-01-01'
GROUP BY CUS.CompanyName






--10. Вывести информацию о товарах и названиях городов в которые эти товары были заказаны по категории Beverages

SELECT PR.ProductName,PR.UnitPrice,OD.Quantity,O.ShipCity
FROM ORDERS AS O
  JOIN [Order Details] AS OD 
  ON O.OrderID=OD.OrderID
  JOIN Products AS PR 
  ON PR.ProductID=OD.ProductID
  JOIN Categories AS CAT 
  ON CAT.CategoryID=PR.CategoryID
WHERE CAT.CategoryName='Beverages'

-- вопрос по стилю , я сначала писал JOIN как JOIN [] ON [] , я так увидел на w3school в примере(https://www.w3schools.com/sql/sql_join.asp) но самое что интересное что на других примерах на в3 было написано 
--так как я переделал --INNER JOIN table2
--ON table1.column_name = table2.column_name;
--с enterom 
--в итоге перешел на 2 вариант посмотрев этот сайт(https://www.sqlstyle.guide/)