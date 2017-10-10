USE SoftUni

--01
	SELECT TOP (5)
				 e.EmployeeID,
				 e.JobTitle,
				 a.AddressID,
				 a.AddressText
		  FROM Employees AS e
	INNER JOIN Addresses AS a 
	        ON a.AddressID = e.AddressID
	  ORDER BY a.AddressID

--02
	SELECT TOP (50) 
				 e.FirstName,
				 e.LastName,
				 t.Name AS [Town],
				 a.AddressText 
		  FROM Employees AS e
	INNER JOIN Addresses AS a 
			ON a.AddressID = e.AddressID
	INNER JOIN Towns AS t 
			ON t.TownID = a.TownID
	  ORDER BY e.FirstName ,e.LastName

--03
		SELECT 
				 e.EmployeeID,
				 e.FirstName,
				 e.LastName,
				 d.Name AS [DepartmentsName] 
		  FROM Employees AS e
    INNER JOIN Departments AS d 
			ON d.DepartmentID = e.DepartmentID
		 WHERE d.Name = 'Sales'
	  ORDER BY e.EmployeeID

--04
	SELECT TOP (5) 
			   e.EmployeeID,
			   e.FirstName,
			   e.Salary,
			   d.Name AS [DepartmentName] 
		  FROM Employees AS e
	INNER JOIN Departments AS d
			ON d.DepartmentID = e.DepartmentID
		 WHERE e.Salary>15000
	  ORDER BY e.DepartmentID

--05
	SELECT TOP (3)
			   e.EmployeeID,
			   e.FirstName 
		  FROM Employees AS e
	 LEFT JOIN EmployeesProjects AS ep 
		    ON eP.EmployeeID = e.EmployeeID
		 WHERE ep.EmployeeID IS NULL
	  ORDER BY e.EmployeeID

--06
		SELECT 
			   e.FirstName,
			   e.LastName,
			   e.HireDate,
			   d.Name AS 'DeptName' 
		  FROM Employees AS e
	INNER JOIN Departments AS d 
			ON d.DepartmentID = e.DepartmentID
		 WHERE d.Name IN('Sales','Finance') AND HireDate>'1.1.1999'
	  ORDER BY e.HireDate
	
--07
	SELECT TOP (5)
			   e.EmployeeID,
			   e.FirstName,
			   p.Name AS [ProjectName]
		  FROM Employees AS e
	INNER JOIN EmployeesProjects AS ep 
			ON ep.EmployeeID = e.EmployeeID
	INNER JOIN Projects AS p 
			ON p.ProjectID = ep.ProjectID
		 WHERE p.StartDate > '2002.08.13' AND p.EndDate IS NULL
	  ORDER BY e.EmployeeID

--08
		SELECT 
			   e.EmployeeID,
			   e.FirstName,
		  IIF (p.StartDate>'2005-01-01',NULL,p.Name) AS [ProjectName] 
		  FROM Employees AS e
	INNER JOIN EmployeesProjects AS ep 
			ON ep.EmployeeID = e.EmployeeID
	INNER JOIN Projects AS p 
			ON p.ProjectID = ep.ProjectID
		 WHERE e.EmployeeID = 24
	
--09	
		SELECT 
			   e.EmployeeID,
			   e.FirstName,
			   e.ManagerID,
			   m.FirstName AS [ManagerName] 
		  FROM Employees AS e
	INNER JOIN Employees AS m
			ON m.EmployeeID = e.ManagerID
		 WHERE e.ManagerID IN(3,7)
	  ORDER BY e.EmployeeID	

--10
	SELECT TOP (50)
				e.EmployeeID,
				CONCAT( e.FirstName,' ',e.LastName) AS [EmployeeName],
				CONCAT(m.FirstName,' ',m.LastName) AS [ManagerName],
				d.Name AS [DepartmentName]
		  FROM Employees AS e
	INNER JOIN Employees AS m ON m.EmployeeID = e.ManagerID
	INNER JOIN Departments AS d ON d.DepartmentID = e.DepartmentID
	  ORDER BY e.EmployeeID 

--11
	SELECT TOP (1) AVG(Salary) AS [MinAverageSalary] 
		  FROM Employees
	  GROUP BY DepartmentID
	  ORDER BY [MinAverageSalary]

USE Geography

--12

		SELECT 
			   mc.CountryCode,
			   m.MountainRange,
			   p.PeakName,
			   p.Elevation 
		  FROM Peaks AS p
	INNER JOIN Mountains AS m 
			ON m.Id = p.MountainId
	INNER JOIN  MountainsCountries AS mc 
			ON mc.MountainId = m.Id
		 WHERE mc.CountryCode = 'BG' AND p.Elevation>2835
	  ORDER BY p.Elevation DESC

--13
	    SELECT 
			   mc.CountryCode,
			   COUNT(mc.MountainId) AS [MountainRanges]
		 FROM MountainsCountries AS mc
		WHERE mc.CountryCode IN('BG','US','RU')
	 GROUP BY mc.CountryCode
	
--14
		 
   SELECT TOP (5)
			  c.CountryName,
			  r.RiverName  
		 FROM Countries AS c
	LEFT JOIN CountriesRivers AS cr ON cr.CountryCode = c.CountryCode
	LEFT JOIN Rivers AS r ON  r.Id = cr.RiverId
	    WHERE c.ContinentCode = 'AF'
	 ORDER BY c.CountryName

--15
		 WITH CCYContUsage_CTE (ContinentCode, CurrencyCode, CurrencyUsage) 
		   AS 
		   (
	   SELECT ContinentCode, CurrencyCode, COUNT(CountryCode) AS CurrencyUsage
	     FROM Countries 
     GROUP BY ContinentCode, CurrencyCode
       HAVING COUNT(CountryCode) > 1  
		   )
	   SELECT ContMax.ContinentCode, ccy.CurrencyCode, ContMax.CurrencyUsage 
	     FROM
		  (
	   SELECT ContinentCode, MAX(CurrencyUsage) AS CurrencyUsage
	     FROM CCYContUsage_CTE 
     GROUP BY ContinentCode) AS ContMax
   INNER JOIN CCYContUsage_CTE AS ccy 
		   ON 
		   (
		   ContMax.ContinentCode = ccy.ContinentCode AND ContMax.CurrencyUsage = ccy.CurrencyUsage
		   )
	 ORDER BY ContMax.ContinentCode
	
--16
	   SELECT  COUNT(c.CountryCode) AS [CountryCode] 
	     FROM Countries AS c
	LEFT JOIN MountainsCountries AS mc ON mc.CountryCode = c.CountryCode
		WHERE mc.MountainId IS NULL
	
--17
   SELECT TOP (5)
			  c.CountryName,
			  MAX(p.Elevation) AS [HighestPeakElevation],
			  MAX(r.Length) AS [LongestRiverLength]
		 FROM Countries AS c
   LEFT JOIN MountainsCountries AS mc ON mc.CountryCode = c.CountryCode
   LEFT JOIN Mountains AS m ON m.Id = mc.MountainId
   LEFT JOIN Peaks AS p  ON p.MountainId = m.Id                                   
   LEFT JOIN CountriesRivers AS cr ON cr.CountryCode = c.CountryCode
   LEFT JOIN Rivers AS r ON r.Id = cr.RiverId
	 GROUP BY c.CountryName
	 ORDER BY 
			  [HighestPeakElevation] DESC,
			  [LongestRiverLength] DESC,
			  c.CountryName

--18



  
		




SELECT * FROM MountainsCountries
SELECT * FROM Countries
SELECT * FROM Mountains
SELECT * FROM MountainsCountries
SELECT * FROM Peaks
SELECT * FROM Rivers


SELECT * FROM MountainsCountries
SELECT * FROM Peaks

SELECT * FROM Rivers
SELECT * FROM CountriesRivers