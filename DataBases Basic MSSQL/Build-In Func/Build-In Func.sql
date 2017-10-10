   USE SoftUni

--01
   SELECT FirstName,LastName
     FROM Employees
    WHERE FirstName LIKE 'sa%'
   
--02
   SELECT FirstName,LastName
     FROM Employees
    WHERE LastName LIKE '%ei%'
   
--03
   SELECT FirstName
     FROM Employees
    WHERE (HireDate>=1995 OR HireDate<=2005) AND DepartmentID IN(3,10)
   
--04
   SELECT FirstName,LastName
     FROM Employees
    WHERE JobTitle NOT LIKE '%engineer%'
   
--05
   SELECT [Name] 
     FROM Towns
    WHERE LEN(Name)=5 OR LEN(Name) = 6
 ORDER BY [Name]	    
   
--06
   SELECT TownID,[Name]      
     FROM Towns
    WHERE [Name] LIKE '[mkbe]%'
 ORDER BY [Name]
   
--07
   SELECT * 
     FROM Towns
    WHERE [Name] LIKE '[^rbd]%'
 ORDER BY [Name]
   
--08
   GO
   
   CREATE VIEW V_EmployeesHiredAfter2000 AS
   SELECT FirstName,LastName 
     FROM Employees
    WHERE YEAR(HireDate)>2000
   	
--09
   SELECT FirstName,LastName 
     FROM Employees
    WHERE LEN(LastName) = 5
   
   
   USE Geography
   
--10
   SELECT CountryName,IsoCode
     FROM Countries
    WHERE CountryName LIKE '%A%A%A%'
 ORDER BY IsoCode 
   
--11
   SELECT PeakName,RiverName,LOWER(PeakName + RIGHT(RiverName, LEN(RiverName) -1 )) AS [Mix] 
     FROM Peaks, Rivers
    WHERE RIGHT(PeakName,1) = LEFT(RiverName,1)
 ORDER BY [Mix]
   
   USE Diablo
   
--12
   SELECT TOP(50) [Name],FORMAT(Start,'yyyy-MM-dd') AS [START]
     FROM Games
    WHERE YEAR(Start) = 2011 OR YEAR(Start) = 2012
 ORDER BY [START],[Name]
   
--13
   SELECT Username, RIGHT(Email, LEN(Email)-CHARINDEX('@',Email)) AS [Email Provider]
     FROM Users
 ORDER BY [Email Provider],Username
   
--14
   SELECT Username,IpAddress 
     FROM Users
    WHERE IpAddress LIKE '___.1%.%.___'
 ORDER BY Username
    
--15
   SELECT Name AS [Game],
   	CASE
   		WHEN DATEPART(HOUR,Start) BETWEEN  0 AND 11 THEN 'Morning'
   		WHEN DATEPART(HOUR,Start) BETWEEN 12 AND 17 THEN 'Afternoon'
   		WHEN DATEPART(HOUR,Start) BETWEEN 18 AND 23 THEN 'Evening'
   	END AS [Part Of The Day],
   	CASE
   		WHEN Duration <=3 THEN 'Extra Short'
   		WHEN Duration BETWEEN 4 AND 6 THEN 'Short'
   		WHEN Duration >6 THEN 'Long'
   		ELSE 'Extra Long'
   	END AS [Duration]
     FROM Games 
 ORDER BY Name,[Duration], [Part Of The Day]
   
 --16
   USE Orders
   
   SELECT ProductName, OrderDate,
   DATEADD(DAY, 3, OrderDate) AS [Pay Due],
   DATEADD(MONTH, 1, OrderDate) AS [Deliver Due]
     FROM Orders
