USE Northwind

--1--
SELECT * FROM Products

--2--
SELECT ProductID, ProductName, UnitPrice FROM Products

--3--
SELECT ProductID, ProductName, UnitPrice
FROM Products
WHERE UnitPrice > 15

--4--
SELECT ProductID, ProductName, UnitPrice
FROM Products
WHERE UnitPrice >= 15 AND UnitPrice <= 50

--5--
SELECT ProductID, ProductName, UnitPrice
FROM Products
WHERE UnitPrice BETWEEN 15 AND 50

--6--
SELECT ProductID, ProductName, UnitPrice
FROM Products
WHERE NOT UnitPrice > 15

--7--
SELECT ProductID, ProductName, UnitPrice
FROM Products
WHERE ProductID > 15 OR UnitPrice < 10

--8--
SELECT EmployeeID, LastName FROM Employees
WHERE LastName LIKE 'D%'

--9--
SELECT EmployeeID, LastName FROM Employees
WHERE LastName LIKE '%N'

--10--
SELECT EmployeeID, LastName, Title FROM Employees
WHERE Title LIKE '%SALES%'

--11--
SELECT EmployeeID, LastName FROM Employees
WHERE LastName NOT LIKE 'D%'

--12--
SELECT ProductID, ProductName, UnitPrice
FROM Products
ORDER BY ProductID ASC

--13--
SELECT ProductID, ProductName, UnitPrice
FROM Products
ORDER BY ProductID DESC

--14--
SELECT DISTINCT OrderID FROM [Order Details]

--15--
SELECT TOP 5 OrderID, ProductID, Quantity
FROM [Order Details]

--16--
SELECT TOP 10 PERCENT OrderID, ProductID, Quantity
FROM [Order Details]

--17--
SELECT CategoryName AS [Nombre de Categoria]
FROM Categories

--18--
SELECT OrderID, OrderDate, ShippedDate, ShippedDate + 5 AS RetrasoEnvio
FROM Orders

--19--
SELECT OrderID, P.ProductID, ProductName
FROM Products P
INNER JOIN [Order Details] OD
ON P.ProductID=OD.ProductID

--20--
SELECT ProductName, CompanyName, ContactName
FROM Products P
FULL JOIN Suppliers S
ON P.SupplierID=S.SupplierID