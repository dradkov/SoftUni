   USE Gringotts
   
   --01
   SELECT COUNT(Id) AS [TotalRecords] 
     FROM WizzardDeposits
     
   --02
   SELECT MAX(MagicWandSize) AS [LongestMagicWand] 
     FROM WizzardDeposits
   
   --03
   SELECT DepositGroup,MAX(MagicWandSize)
     FROM WizzardDeposits
 GROUP BY DepositGroup
    
    --04
   SELECT TOP(2) DepositGroup 
     FROM WizzardDeposits
 GROUP BY DepositGroup 
 ORDER BY AVG(MagicWandSize)
   
   --05
   SELECT DepositGroup , SUM(DepositAmount) AS [TotalSum]
     FROM WizzardDeposits
 GROUP BY DepositGroup
   
   --06
   SELECT DepositGroup , SUM(DepositAmount) AS [TotalSum]
     FROM WizzardDeposits
    WHERE MagicWandCreator = 'Ollivander family'
 GROUP BY DepositGroup
   
   --07
   SELECT DepositGroup , SUM(DepositAmount) AS [TotalSum]
     FROM WizzardDeposits
    WHERE MagicWandCreator = 'Ollivander family'
 GROUP BY DepositGroup
   HAVING SUM(DepositAmount) < 150000
 ORDER BY SUM(DepositAmount) DESC
   
   --08
   SELECT 
          DepositGroup,
	  MagicWandCreator,
	  MIN(DepositCharge) AS [MinDepositCharge]
     FROM WizzardDeposits
 GROUP BY DepositGroup,MagicWandCreator
 ORDER BY MagicWandCreator,DepositGroup
   
   --09
   SELECT WizardCount.AgeGroup ,COUNT(*) 
     FROM
   (
   SELECT 
   	  CASE 
   		WHEN Age BETWEEN 0 AND 10 THEN '[0-10]'
   		WHEN Age BETWEEN 11 AND 20 THEN '[11-20]'
   		WHEN Age BETWEEN 21 AND 30 THEN '[21-30]'
   		WHEN Age BETWEEN 31 AND 40 THEN '[31-40]'
   		WHEN Age BETWEEN 41 AND 50 THEN '[41-50]'
   		WHEN Age BETWEEN 51 AND 60 THEN '[51-60]'
   		WHEN Age >= 61 THEN '[61+]'
   	   END AS [AgeGroup]
      FROM WizzardDeposits
    )   AS [WizardCount]	
  GROUP BY WizardCount.AgeGroup 
   
   --10
   SELECT DISTINCT UPPER(LEFT(FirstName,1)) AS [FirstLetter]
     FROM WizzardDeposits
    WHERE DepositGroup = 'Troll Chest'
   
   --11
   SELECT 
   	  DepositGroup,
	  IsDepositExpired,
	  AVG(DepositInterest) AS [AverageInterest]
     FROM WizzardDeposits
     WHERE DepositStartDate > '01/01/1985'
  GROUP BY DepositGroup,IsDepositExpired
  ORDER BY DepositGroup DESC ,IsDepositExpired
   
   --12
    SELECT SUM(wizardDeposit.Difference) AS SumDifference
      FROM
     (
    SELECT FirstName, DepositAmount,
           LEAD(FirstName) OVER (ORDER BY Id) AS GuestWizard,
   	   LEAD(DepositAmount) OVER (ORDER BY Id) AS GuestDeposit,
           DepositAmount - LEAD(DepositAmount) OVER (ORDER BY Id) AS Difference 
      FROM WizzardDeposits
      ) AS wizardDeposit  
   
   --13
   USE SoftUni
   
     SELECT DepartmentID ,SUM(Salary) AS [TotalSalary]
       FROM Employees
   GROUP BY DepartmentID
   ORDER BY DepartmentID
   
   --14
    SELECT DepartmentID,MIN(Salary) 
      FROM Employees
     WHERE DepartmentID IN(2,5,7) AND HireDate > '01/01/2000' 
  GROUP BY DepartmentID
  ORDER BY DepartmentID
      
   --15
    SELECT * INTO NewTABLE FROM Employees
     WHERE Salary> 30000
   
    DELETE FROM NewTABLE
     WHERE ManagerID = 42
   
    UPDATE NewTABLE
       SET Salary = Salary+ 5000
     WHERE DepartmentID = 1
   
    SELECT DepartmentID,AVG(Salary)  AS AverageSalary
      FROM NewTABLE
  GROUP BY DepartmentID
   
   --16
    SELECT DepartmentID, MAX(Salary) 
      FROM Employees
  GROUP BY DepartmentID
    HAVING MAX(Salary)<30000 OR MAX(Salary)>70000
   
   --17
    SELECT COUNT(EmployeeID) AS [Count]
      FROM Employees
     WHERE ManagerID IS NULL
   
   --18
    SELECT Salaries.DepartmentID, Salaries.Salary 
      FROM
   (
      SELECT DepartmentId,
      MAX(Salary) AS Salary,
      DENSE_RANK() OVER (PARTITION BY DepartmentId ORDER BY Salary DESC) AS Rank
       FROM Employees
     GROUP BY DepartmentID, Salary
    )AS Salaries 
    WHERE Rank=3
   
   --19
   SELECT TOP 10 FirstName, LastName, DepartmentID FROM Employees AS emp1
    WHERE Salary >
   (
	  SELECT AVG(Salary) FROM Employees AS emp2
    	   WHERE emp1.DepartmentID = emp2.DepartmentID
       GROUP BY DepartmentID
   )
 ORDER BY DepartmentID 
