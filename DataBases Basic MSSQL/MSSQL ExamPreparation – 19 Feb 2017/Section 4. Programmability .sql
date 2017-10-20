--16
	CREATE VIEW v_UserWithCountries AS
	(
		SELECT CONCAT(cus.FirstName,' ',cus.LastName) AS [CustomerName],cus.Age ,cus.Gender,cO.Name AS [CountryName] FROM Customers AS cus
		INNER JOIN  Countries AS co ON co.Id = cus.CountryId
	
	) 

GO

--17
	CREATE FUNCTION udf_GetRating (@ProductName NVARCHAR(50))
	RETURNS VARCHAR (10)
	AS
	BEGIN 
		
		DECLARE @rate DECIMAL(15,2) = 
		(
			SELECT AVG(f.Rate) FROM Feedbacks AS f
			LEFT JOIN  Products AS p ON p.Id = f.ProductId
			GROUP BY p.Name
			HAVING p.Name = @ProductName
		)
			
	DECLARE @condition NVARCHAR(20)  = 
		CASE
		WHEN  @rate<5 THEN 'Bad'
		WHEN  @rate BETWEEN 5 AND 8 THEN 'Average'
		WHEN  @rate>8 THEN 'Good'
		WHEN @rate IS NULL THEN 'No rating'			  
		END 

		RETURN  @condition
	END

	GO
--18
	CREATE PROC usp_SendFeedback(@customerID INT,@productID INT,@rate DECIMAL(15,2), @description NVARCHAR(MAX))
	AS
	BEGIN 
		BEGIN TRAN

		INSERT INTO Feedbacks (Description,Rate,ProductId,CustomerId) VALUES
		(@description,@rate,@productID,@customerID)

		IF ((SELECT COUNT(Id) FROM Feedbacks WHERE  CustomerId = @customerID) >=3 )
		BEGIN 
			ROLLBACK 
			RAISERROR ('You are limited to only 3 feedbacks per product!',16,1)
			
		END

		COMMIT
		
	END	

GO
	
--19
CREATE TRIGGER tr_DeleteProductRelations ON Products
INSTEAD OF DELETE
AS
BEGIN
  DELETE FROM ProductsIngredients
  WHERE ProductId = (SELECT Id FROM deleted)

  DELETE FROM Feedbacks
  WHERE ProductId = (SELECT Id FROM deleted)
  
  DELETE FROM Products 
  WHERE Id = (SELECT Id FROM deleted)

  END

