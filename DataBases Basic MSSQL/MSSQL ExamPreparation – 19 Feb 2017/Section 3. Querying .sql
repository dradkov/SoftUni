	
--05
	SELECT 
	       Name,
	       Price,
	       Description 
	  FROM Products
      ORDER BY Price DESC ,Name
	
--06
	SELECT Name,Description,OriginCountryId 
	  FROM Ingredients
	 WHERE OriginCountryId IN(1,10,20)
      ORDER BY Id
	
--07
	SELECT TOP 15
	       i.Name,
	       i.Description,
	       c.Name 
	  FROM Ingredients AS i
    INNER JOIN Countries AS c ON c.Id = i.OriginCountryId
	 WHERE c.Name = 'Bulgaria' OR c.Name = 'Greece' 
      ORDER BY i.Name,c.Name
	
--08
	
	SELECT TOP 10 
	       p.Name,
	       p.Description,
	       AVG(f.Rate) AS [AverageRate],
	       COUNT(f.Id) AS [FeedbacksAmount]
	  FROM Feedbacks AS f
    INNER JOIN Products AS p ON p.Id = f.ProductId
      GROUP BY p.Name,p.Description
      ORDER BY [AverageRate] DESC,[FeedbacksAmount] DESC
	
--09
        SELECT f.ProductId,
	       f.Rate,
	       f.Description,
	       f.CustomerId,
	       c.Age,c.Gender
	  FROM Feedbacks AS f
    INNER JOIN Customers AS c ON c.Id = f.CustomerId
         WHERE f.Rate<5.0
      ORDER BY f.ProductId DESC,f.Rate 
	
--10
	SELECT CONCAT(c.FirstName,' ',c.LastName) AS [CustomerName],
	       c.PhoneNumber,
	       c.Gender 
	  FROM Customers AS c
     LEFT JOIN Feedbacks AS f ON c.Id = f.CustomerId
         WHERE f.Id IS NULL
      ORDER BY c.Id
	
--11
	SELECT f.ProductId,
	       CONCAT(c.FirstName,' ',c.LastName) AS [CustomerName],
	       f.Description AS [FeedbackDescription] 
	  FROM Feedbacks AS f
    INNER JOIN (SELECT CustomerId
		  FROM Feedbacks AS f
	      GROUP BY CustomerId
	        HAVING COUNT(Id)>=3) AS best ON best.CustomerId = f.CustomerId
    INNER JOIN Customers AS c ON c.Id = f.CustomerId
      ORDER BY f.ProductId,[CustomerName],f.Id
	
--12
	SELECT cus.FirstName,
	       cus.Age,
	       cus.PhoneNumber 
	  FROM Customers AS cus
    INNER JOIN Countries AS c ON c.Id = cus.CountryId
	 WHERE (Age>=21 AND FirstName LIKE '%an%') OR (PhoneNumber LIKE '%38' AND c.Name <> 'Greece')		
      ORDER BY FirstName,Age DESC
	
--13
       SELECT 
       	      d.Name AS [DistributorName],
       	      i.Name AS [IngredientName],
       	      p.Name AS [ProductName],
       	      AVG(f.Rate) AS [AverageRate]
         FROM Distributors AS d	
   INNER JOIN Ingredients AS i ON i.DistributorId = d.Id
   INNER JOIN ProductsIngredients AS pin ON pin.IngredientId = i.Id 
   INNER JOIN Products AS p ON p.Id = pin.ProductId
   INNER JOIN Feedbacks AS f ON f.ProductId = p.Id
     GROUP BY d.Name,i.Name,p.Name 
       HAVING AVG(f.Rate)>=5 AND AVG(f.Rate)<=8
     ORDER BY d.Name,i.Name,p.Name
	
--14
       SELECT TOP 1 WITH TIES 
       	      c.Name AS [CountryName],
	      AVG(f.Rate) AS [FeedbackRate] 
	 FROM Countries AS c
   INNER JOIN Customers AS cus ON cus.CountryId = c.Id
   INNER JOIN Feedbacks AS f ON f.CustomerId = cus.Id
     GROUP BY c.Name
     ORDER BY AVG(f.Rate) DESC
	
--15
       SELECT CountryName, DistributorName
         FROM 
         (
       		SELECT 
       		       co.Name AS CountryName,
       		       d.Name AS DistributorName, 
       		       COUNT(i.Id) AS IngredientsCount,
       		       DENSE_RANK() OVER (PARTITION BY co.Name ORDER BY COUNT(i.Id) DESC) AS DistributorRank 
       		  FROM Countries AS co
            INNER JOIN Distributors AS d ON d.CountryId = co.Id
            INNER JOIN Ingredients AS i ON i.DistributorId = d.Id
       	      GROUP BY d.Name, co.Name
          ) AS CountryDistributorStats
      WHERE DistributorRank = 1
   ORDER BY CountryName, DistributorName       
