USE Bank
--01

CREATE TABLE Logs 
(
	LogId INT PRIMARY KEY IDENTITY,
	AccountId INT ,
	OldSum MONEY ,
	NewSum MONEY 
)

GO

CREATE TRIGGER tr_LogChange 
	ON Accounts
 AFTER UPDATE
	AS
 BEGIN
       INSERT Logs(AccountId,OldSum,NewSum )
	   SELECT inserted.Id,deleted.Balance,inserted.Balance
         FROM inserted,deleted
   END

--02
	CREATE TABLE NotificationEmails
	(
		Id INT PRIMARY KEY IDENTITY,
		Recipient VARCHAR(100),
		[Subject] NVARCHAR(100),
		 Body NVARCHAR(100)
	)
	GO

	CREATE TRIGGER tr_TransactionNotification
	ON Logs
	AFTER INSERT
	AS
	BEGIN
		INSERT NotificationEmails(Recipient,[Subject],Body)
		SELECT 
			inserted.AccountId,
			CONCAT('Balance change for account: ',inserted.AccountId),
			CONCAT('On ',GETDATE(),' your balance was changed from ',inserted.OldSum,' to ',inserted.NewSum)
		
		FROM inserted

	END 

	GO
	
--03
	CREATE PROC usp_DepositMoney (@AccountId INT, @MoneyAmount MONEY)
	AS
	BEGIN
		 TRAN
		  UPDATE Accounts
		  SET Balance = Balance+ @MoneyAmount		 
		  WHERE Accounts.Id = @AccountId 
		  BEGIN
			COMMIT		
	END 

	GO
--04

	CREATE PROC	usp_WithdrawMoney (@AccountId INT, @MoneyAmount MONEY)
	AS
	BEGIN 
		BEGIN TRAN

		DECLARE @currentBalance	MONEY;
			
			UPDATE Accounts
			SET Balance -=@MoneyAmount
			WHERE Accounts.Id = @AccountId			
			SET @currentBalance	= (SELECT Balance FROM Accounts WHERE Id = @AccountId);
			IF	@currentBalance<0
			BEGIN
				RAISERROR ('Insuficiond Funds',16,1)
				ROLLBACK
			END
						
			COMMIT
	END

	EXEC 	usp_WithdrawMoney 5, 25

	GO

	--05
	CREATE PROC	usp_TransferMoney(@SenderId INT, @ReceiverId INT, @Amount MONEY)
	AS
	BEGIN
			DECLARE @senderBalance MONEY ;
			SET  @senderBalance = (SELECT Balance FROM Accounts WHERE Accounts.Id = @SenderId); 

		BEGIN TRAN

		IF (@Amount<0)
			BEGIN 			
				ROLLBACK
			END
		ELSE
			BEGIN 
				IF(@senderBalance-@Amount>=0)	
				BEGIN
					
					EXEC usp_WithdrawMoney @SenderId, @Amount
					EXEC usp_DepositMoney @ReceiverId,@Amount
				END
			END
		COMMIT
	END

	EXEC usp_TransferMoney 5,1,5000

	GO

--07
	
	
   DECLARE @User VARCHAR(MAX) = 'Stamat'
   DECLARE @GameName VARCHAR(MAX) = 'Safflower'
   DECLARE @UserId INT = (SELECT Id FROM Users WHERE Username = @User)
   DECLARE @GameId INT = (SELECT Id FROM Games WHERE Name = @GameName)
   DECLARE @UserMoney MONEY = (SELECT Cash FROM UsersGames WHERE UserId = @UserId AND GameId = @GameId)
   DECLARE @ItemsBulkPrice MONEY
   DECLARE @UserGameId INT = (SELECT Id FROM UsersGames WHERE UserId = @UserId AND GameId = @GameId)
   
   BEGIN TRAN--11 to 12
   		SET @ItemsBulkPrice = (SELECT SUM(Price) FROM Items WHERE MinLevel BETWEEN 11 AND 12)
   		IF (@UserMoney - @ItemsBulkPrice >= 0)
   		BEGIN
   			INSERT UserGameItems
   			SELECT i.Id, @UserGameId FROM Items AS i
   			WHERE i.id IN (Select Id FROM Items WHERE MinLevel BETWEEN 11 AND 12)
   			UPDATE UsersGames
   			SET Cash = Cash - @ItemsBulkPrice
   			WHERE GameId = @GameId AND UserId = @UserId
   			COMMIT
   		END
   		ELSE
   		BEGIN
   			ROLLBACK
   		END
   		
   
   SET @UserMoney = (SELECT Cash FROM UsersGames WHERE UserId = @UserId AND GameId = @GameId)
   BEGIN TRAN--19 to 21
   		SET @ItemsBulkPrice = (SELECT SUM(Price) FROM Items WHERE MinLevel BETWEEN 19 AND 21)
   		IF (@UserMoney - @ItemsBulkPrice >= 0)
   		BEGIN
   			INSERT UserGameItems
   			SELECT i.Id, @UserGameId FROM Items AS i
   			WHERE i.id IN (Select Id FROM Items WHERE MinLevel BETWEEN 19 AND 21)
   			UPDATE UsersGames
   			SET Cash = Cash - @ItemsBulkPrice
   			WHERE GameId = @GameId AND UserId = @UserId
   			COMMIT
   		END
   		ELSE
   		BEGIN
   			ROLLBACK
   		END
   
    SELECT Name AS 'Item Name' FROM Items
    WHERE Id IN (SELECT ItemId FROM UserGameItems WHERE UserGameId = @UserGameId)
    ORDER BY [Item Name]

	GO
--08
	USE SoftUni

	SELECT * FROM Projects
	SELECT * FROM EmployeesProjects
	GO

	CREATE PROC usp_AssignProject(@emloyeeId INT, @projectID INT)
	AS
	BEGIN
		
		DECLARE @employeeProjectsCount INT
		BEGIN TRAN
			INSERT EmployeesProjects (EmployeeID, ProjectID) VALUES
			(@emloyeeId,@projectID)

			SET @employeeProjectsCount = (SELECT COUNT(*) FROM EmployeesProjects WHERE EmployeeID = @emloyeeId)

			IF(@employeeProjectsCount > 3)
			BEGIN
				RAISERROR('The employee has too many projects!',16,1)
				ROLLBACK
			END
			COMMIT		
	END

	GO

--09
	
	CREATE TABLE Deleted_Employees
	(	
		EmployeeId INT PRIMARY KEY,
		FirstName VARCHAR(50),
		LastName VARCHAR(50),
		MiddleName VARCHAR(50),
		JobTitle VARCHAR(50),
		DepartmentId INT,
		Salary MONEY
	)
	GO

	CREATE TRIGGER TR_EmployeesDelete
	ON Employees
	AFTER DELETE
	AS
	BEGIN
	  INSERT  INTO Deleted_Employees(FirstName,LastName,MiddleName,JobTitle,DepartmentId,Salary)
			SELECT d.FirstName,d.LastName,d.MiddleName,d.JobTitle,d.DepartmentID,d.Salary 
			FROM deleted AS d
	END
	GO

