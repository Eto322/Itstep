--1. Вывести все возможные пары строк регионов и територий.
-- Тут как я понял надо просто сделать с них декартовое произведения ?
SELECT  Territories.TerritoryDescription , Region.RegionDescription
from Territories,Region


--2. Вывести названия продуктов, остаток которых на складе меньше чем количество на заказ (UnitsOnOrder)

SELECT Products.ProductName,Products.UnitsInStock,Products.UnitsOnOrder
FROM Products
WHERE UnitsInStock<UnitsOnOrder

--3 Вывести названия продуктов, их стоимость в таблице продуктов, их стоимость в ордерах. Для тех продуктов, цена которых отличается в этих таблицах.
-- Тут мне сначало показалось что я вызвал декартовое произведения но если посмотреть на таблицу то там есть много почти одинаковых записей с одинаковой ценой , и в итоге мне кажеться что получилось правильно 
-- дальше указал пример 
SELECT Products.ProductName,Products.UnitPrice AS 'PRODUCT UNIT PRICE',[Order Details].UnitPrice AS 'ORDER UNIT PRICE'
FROM Products,[Order Details]
WHERE Products.UnitPrice<>[Order Details].UnitPrice AND Products.ProductID=[Order Details].ProductID

--пример
SELECT*
FROM [Order Details]
WHERE [Order Details].ProductID=14




--4 Вывести названия продуктов и названия их категорий для категории Confections и Produce
SELECT Products.ProductName, Categories.CategoryName
FROM Products,Categories
WHERE Products.CategoryID=Categories.CategoryID AND (Categories.CategoryName='Confections' OR Categories.CategoryName='Produce')


--5. Вывести фамилии сотрудников и названия территорий, по которым они работают. Сортировать по фамилиям, затем по территориям.
-- Тут произошло аналогичное с 3 заданиям , как оказалось один сотрудник работает на нескольких тереториях  и теретория с одинаковым названиям может иметь разны ID  привел пример
SELECT Employees.LastName,Territories.TerritoryDescription
FROM Employees,Territories,EmployeeTerritories
WHERE (Employees.EmployeeID=EmployeeTerritories.EmployeeID AND EmployeeTerritories.TerritoryID=Territories.TerritoryID)
ORDER BY Employees.LastName, Territories.TerritoryDescription

--пример
SELECT*
FROM Territories
WHERE Territories.TerritoryDescription='New York'

--6 Вывести названия перевозчиков, которые выполняли доставку для покупателя Martin Sommer. Без повторений.
-- Насколько смешно это б не звучало , но тут не Martin Sommer а Martín Sommer c страной буквой і 
SELECT Shippers.CompanyName
FROM Shippers
WHERE Shippers.ShipperID= ANY(SELECT Orders.ShipVia
						  FROM Orders
						  WHERE Orders.CustomerID=(SELECT Customers.CustomerID
													FROM Customers
													WHERE Customers.ContactName='Martín Sommer' ))




--7. Вывести полные имена сотрудников, которые работают по New York
SELECT Employees.LastName+' '+Employees.FirstName AS 'FULL NAME'
FROM Employees
WHERE EmployeeID=ALL(
					SELECT EmployeeTerritories.EmployeeID
					FROM EmployeeTerritories
				   WHERE EmployeeTerritories.TerritoryID= ANY (SELECT Territories.TerritoryID
										FROM Territories
										WHERE Territories.TerritoryDescription='New York'))


--8. Вывести названия фирм-поставщиков для категории Seafood
SELECT Suppliers.CompanyName
FROM Suppliers
WHERE Suppliers.SupplierID=ANY(
							SELECT Products.SupplierID
							FROM Products
							WHERE Products.CategoryID=ALL(
														SELECT Categories.CategoryID
														FROM Categories
														WHERE Categories.CategoryName='Seafood'))

--9 Вывести названия и описания категорий товаров для поставщика Bigfoot Breweries
SELECT Categories.CategoryName,Categories.[Description]
FROM Categories
WHERE Categories.CategoryID= ANY ( SELECT Products.CategoryID
							  FROM Products
							  WHERE Products.SupplierID=(SELECT Suppliers.SupplierID
														 FROM Suppliers
														 WHERE Suppliers.CompanyName='Bigfoot Breweries'))
--10  Вывести для каждого заказа дату заказа, имя продукта, имя категории и город куда он был отправлен.
SELECT Orders.OrderDate, Products.ProductName,Categories.CategoryName,ORDERS.ShipCity
FROM Orders,Products,[Order Details],Categories
where ORDERS.OrderID=[Order Details].OrderID AND Products.ProductID=[Order Details].ProductID AND Products.CategoryID=Categories.CategoryID


--по самим заданиям , я только при виполнение 10 задания понял что скроее всего задания где я делал с ANY и с ALL  , можна было сделать проще , ну що маємо те маємо



												  

																									




