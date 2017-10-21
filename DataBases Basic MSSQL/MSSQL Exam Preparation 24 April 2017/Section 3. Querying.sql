--05
	SELECT FirstName,LastName,PHONE FROM Clients
	ORDER BY LastName,ClientId

--06
	SELECT Status,IssueDate 
	  FROM Jobs
	  WHERE Status <> 'Finished'
	  ORDER BY IssueDate,JobId

--07
	SELECT 
		   CONCAT(m.FirstName,' ',m.LastName) AS [Mechanic],
		   j.Status,
		   j.IssueDate
	  FROM Jobs AS j
	INNER JOIN Mechanics AS m ON m.MechanicId = j.MechanicId
	ORDER BY m.MechanicId,j.IssueDate,j.JobId

--08
	SELECT 
		   CONCAT(c.FirstName,' ',c.LastName) AS [Client],
		   DATEDIFF(DAY,j.IssueDate,'2017-04-24') AS [Days going],
		   j.Status
	  FROM Clients AS c
	INNER JOIN Jobs AS j ON j.ClientId = c.ClientId
	WHERE j.Status<> 'Finished'
	ORDER BY [Days going] DESC,c.ClientId

--09
	 SELECT 
			CONCAT(m.FirstName,' ',m.LastName) AS [Mechanic],
			AVG(DATEDIFF(DAY,j.IssueDate,j.FinishDate)) AS [Average Days]
	   FROM Mechanics AS m
	 INNER JOIN Jobs AS j ON j.MechanicId = m.MechanicId
	 GROUP BY m.FirstName,m.LastName, m.MechanicId
	 ORDER BY m.MechanicId

--10 
	SELECT TOP 3
				 CONCAT(m.FirstName,' ',m.LastName) AS [Mechanic],
				 COUNT(j.JobId) AS [Jobs]
				 FROM Mechanics AS m
	INNER JOIN Jobs AS j ON j.MechanicId = m.MechanicId
	GROUP BY m.FirstName,m.LastName,m.MechanicId,j.Status
	HAVING j.Status <> 'Finished' AND COUNT(j.JobId)>1
 	ORDER BY  COUNT(j.JobId) DESC ,m.MechanicId
	
	 
--11
	SELECT FirstName + ' ' + LastName AS Available
	 FROM Mechanics
	WHERE MechanicId NOT IN
  (SELECT DISTINCT MechanicId FROM Jobs
   WHERE MechanicId IS NOT NULL AND Status <> 'Finished')
  ORDER BY MechanicId

--12
	SELECT ISNULL(SUM(p.Price * orp.Quantity),0) AS [Parts Total] FROM Orders AS o
	INNER JOIN OrderParts AS orp ON orp.OrderId = o.OrderId
	INNER JOIN Parts AS p ON p.PartId= orp.PartId
	WHERE  DATEDIFF(WEEK,o.IssueDate,'2017-04-24')<=3

--13
	SELECT j.JobId,
		(SELECT ISNULL(SUM(p.Price * op.Quantity),0) FROM Parts AS p
					INNER JOIN OrderParts AS op ON op.PartId = p.PartId
					INNER JOIN Orders AS o ON o.OrderId = op.OrderId
					INNER JOIN Jobs AS jo ON jo.JobId = o.JobId
					WHERE jo.JobId = j.JobId )  AS [Total]		
	 FROM Jobs AS j 
	WHERE j.Status = 'Finished'
	ORDER BY  [Total] DESC ,j.JobId

--14
	SELECT  m.ModelId,m.Name ,
	  CAST(AVG(DATEDIFF(DAY,j.IssueDate,j.FinishDate)) AS VARCHAR(10))+ ' '+ 'days' AS [Average Service Time]	
	   FROM Models AS m
	INNER JOIN Jobs AS j ON j.ModelId = m.ModelId
	GROUP BY m.ModelId,m.Name,j.Status
	HAVING j.Status = 'Finished'
	ORDER BY  AVG(DATEDIFF(DAY,j.IssueDate,j.FinishDate))

--15
	SELECT TOP 1 WITH TIES
		   m.Name,
		   COUNT(*) AS [Times Serviced],
		   (SELECT ISNULL(SUM(p.Price* op.Quantity),0) FROM Jobs AS jo
		   INNER JOIN Orders AS o ON o.JobId = jo.JobId
		   INNER JOIN OrderParts AS op ON op.OrderId = o.OrderId
		   INNER JOIN Parts AS p ON p.PartId = op.PartId
		   WHERE jo.ModelId = m.ModelId) AS [Parts Total]
		   
     FROM Models AS m
	JOIN Jobs AS j ON j.ModelId = m.ModelId
	GROUP BY  m.Name,m.ModelId
	ORDER BY [Times Serviced] DESC
		
--16
	SELECT p.PartId,
       p.Description,
       SUM(pn.Quantity) AS Required,
       AVG(p.StockQty) AS [In Stock],
       ISNULL(SUM(op.Quantity), 0) AS Ordered
  FROM Parts AS p
JOIN PartsNeeded pn ON pn.PartId = p.PartId
JOIN Jobs AS j ON j.JobId = pn.JobId
LEFT JOIN Orders AS o ON o.JobId = j.JobId
LEFT JOIN OrderParts AS op ON op.OrderId = o.OrderId
WHERE j.Status <> 'Finished'
GROUP BY p.PartId, p.Description
HAVING AVG(p.StockQty) + ISNULL(SUM(op.Quantity), 0) < SUM(pn.Quantity)
ORDER BY p.PartId
		
