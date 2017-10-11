    USE SoftUni
    
    GO
    
    --01
     CREATE PROC usp_GetEmployeesSalaryAbove35000
    	AS
    	BEGIN
    	   SELECT 
	   	  FirstName,
		  LastName 
	     FROM Employees
    	    WHERE Salary>35000
        END
    
    EXEC usp_GetEmployeesSalaryAbove35000 --DO NOT SUBMIT 
    
    GO
    --02
     CREATE PROC usp_GetEmployeesSalaryAboveNumber (@Salary DECIMAL(15,2))
    	 AS
    	 BEGIN
    	    SELECT 
	           FirstName,
		   LastName
	      FROM Employees
    	     WHERE Salary>= @Salary
    	 END
    
    EXEC usp_GetEmployeesSalaryAboveNumber 48100 -- TEST
    
    GO
    
    --03
     CREATE PROC usp_GetTownsStartingWith (@StartingWith NVARCHAR(MAX))
    	 AS
    	 BEGIN 
    	    SELECT Name AS [Town] 
	      FROM Towns
    	     WHERE Name LIKE CONCAT(@StartingWith,'%')    
         END
    GO
    --04
     CREATE PROC usp_GetEmployeesFromTown @TownName NVARCHAR(MAX)
    	 AS
    	 BEGIN
    	    SELECT e.FirstName,
	           e.LastName 
	      FROM Employees AS e
    	INNER JOIN Addresses AS a 
		ON a.AddressID = e.AddressID
    	INNER JOIN Towns AS t 
		ON t.TownID = a.TownID
    	     WHERE t.Name = @TownName
    	END
    
    EXEC usp_GetEmployeesFromTown 'Sofia'
    
    	GO
    
    --05
     CREATE FUNCTION ufn_GetSalaryLevel(@salary DECIMAL(18,4))
    RETURNS VARCHAR(10)
         AS
         BEGIN
    	   DECLARE @LevelOfSalary VARCHAR(10);
    	   SET @LevelOfSalary = 
    		CASE
    			WHEN @salary <30000 THEN 'Low'
    			WHEN @salary BETWEEN 30000 AND 50000 THEN 'Average'
    			WHEN @salary > 50000 THEN 'High'
    		END
           RETURN @LevelOfSalary
         END 
     GO
      SELECT 
      	     Salary,
    	     dbo.ufn_GetSalaryLevel(Salary) AS [Salary Level] 
        FROM Employees
    
    GO
    --06
     CREATE PROC usp_EmployeesBySalaryLevel @SalaryLevel VARCHAR(10)
    	 AS
    	 BEGIN
    	   SELECT 
	   	  e.FirstName,
		  e.LastName 
	     FROM Employees AS e
    	    WHERE  dbo.ufn_GetSalaryLevel(e.Salary) = @SalaryLevel
    
    	 END
    
    	EXEC usp_EmployeesBySalaryLevel 'hIGH'
    
    	GO
    
    --07
     CREATE FUNCTION ufn_IsWordComprised(@setOfLetters NVARCHAR(MAX), @word NVARCHAR(MAX))
    RETURNS BIT
    	 AS
    	 BEGIN
    	 	DECLARE @Result BIT = 0;
    		DECLARE @CurrentIndex INT = 1;
    		DECLARE @CurrentChar CHAR;
    		
    		WHILE(@CurrentIndex<=LEN(@word))
    	     BEGIN
    		SET @CurrentChar = SUBSTRING(@word,@CurrentIndex,1)
    			IF(CHARINDEX(@CurrentChar,@setOfLetters) = 0)
    			BEGIN
    				RETURN @Result;
    			END
    		SET @CurrentIndex +=1 
    	     END 
    		RETURN @Result + 1;
    	  END
    	
    	GO
    
    USE Bank	
    
    GO
    --09
     CREATE PROC usp_GetHoldersFullName
         AS
         BEGIN 
    	   SELECT FirstName+' '+LastName AS [Full Name] 
	     FROM AccountHolders
         END 
     	
    EXEC usp_GetHoldersFullName
    
    GO
    --10
     CREATE PROC usp_GetHoldersWithBalanceHigherThan (@SuppliedNumber DECIMAL(10,2))
    	 AS
    	 BEGIN 
    	   WITH CTE_MinBalance(HolderId)
    	    AS
    	   (
    		SELECT AccountHolderId 
		  FROM Accounts
    	      GROUP BY AccountHolderId
    		HAVING SUM(Balance)>@SuppliedNumber
    	   )
    
    	        SELECT 
		       ah.FirstName,
		       ah.LastName
		  FROM CTE_MinBalance AS minBalanceHolders
    	    INNER JOIN AccountHolders AS ah 
	    	    ON ah.Id = minBalanceHolders.HolderId
    	      ORDER BY ah.LastName,ah.FirstName  	
    	END
    
    	EXEC usp_GetHoldersWithBalanceHigherThan 1000
    
    --11
    GO
      CREATE FUNCTION ufn_CalculateFutureValue(@Sum MONEY,@YearlyInterestRate FLOAT,@NumberOfYears INT)
    	RETURNS MONEY
    	  AS
    	  BEGIN
    		DECLARE @Result MONEY;
    		SET  @Result = @Sum *POWER(1+@YearlyInterestRate,@NumberOfYears) 
    		RETURN @Result
    	  END
    	GO
    
    	  SELECT dbo.ufn_CalculateFutureValue(1000, 0.10, 5) 
    
    	GO
    --12
     CREATE PROC usp_CalculateFutureValueForAccount (@BalanceID INT,@YearlyInterestRate FLOAT)
    	 AS
    	 BEGIN
    	 	DECLARE @Years INT = 5
    			
    		 SELECT 
    			a.Id AS [Account Id],
    			ah.FirstName,
    			ah.LastName,
    			a.Balance AS [Current Balance],
    			dbo.ufn_CalculateFutureValue(a.Balance,@YearlyInterestRate, @Years) AS [Balance in 5 years]
    		  FROM AccountHolders AS ah
    	    INNER JOIN Accounts AS a 
    		    ON a.AccountHolderId = ah.Id
    		 WHERE a.Id = @BalanceID 			
    	END
    
    	EXEC usp_CalculateFutureValueForAccount 1, 0.10
    
    	GO
    --13
    USE Diablo
    
    GO
    
     CREATE FUNCTION ufn_CashInUsersGames (@gameName nvarchar(50))
     RETURNS TABLE
        AS
     RETURN (
       WITH CTE_CashInRows (Cash, RowNumber) AS (
          SELECT ug.Cash, ROW_NUMBER() OVER (ORDER BY ug.Cash DESC)
            FROM UsersGames AS ug
            JOIN Games AS g ON ug.GameId = g.Id
           WHERE g.Name = @gameName
      )
      SELECT SUM(Cash) AS SumCash
        FROM CTE_CashInRows
       WHERE RowNumber % 2 = 1 -- odd row numbers only
    
    )
    
    
