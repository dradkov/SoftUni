--17
GO
	CREATE FUNCTION udf_GetCost(@JobsId INT)
	RETURNS DECIMAL(15,2)
	AS 
	BEGIN
		DECLARE @TotalCost DECIMAL(15,2) = 
		(
			SELECT ISNULL(SUM(p.Price* op.Quantity),0) FROM Jobs AS j
			LEFT JOIN Orders AS o ON o.JobId = j.JobId
			LEFT JOIN OrderParts AS op ON op.OrderId = o.OrderId
			LEFT JOIN Parts AS p ON p.PartId = op.PartId
			GROUP BY j.JobId
			HAVING j.JobId = @JobsId
		) 
		
		RETURN @TotalCost
	END
	
	GO
	
--18
CREATE PROC usp_PlaceOrder @JobId INT, @SerialNumber VARCHAR(50), @Quantity INT
AS
BEGIN
    IF (@Quantity <= 0)
    BEGIN
        RAISERROR('Part quantity must be more than zero!', 16, 1);
        RETURN;
    END
    
    DECLARE @JobIdSelected INT = (SELECT JobId FROM Jobs WHERE JobId = @JobId)
    IF (@JobIdSelected IS NULL)
    BEGIN
        RAISERROR('Job not found!', 16, 1);
        RETURN;
    END

    DECLARE @JobStatus VARCHAR(11) = (SELECT Status FROM Jobs WHERE JobId = @JobId)

    IF (@JobStatus = 'Finished')
    BEGIN
        RAISERROR('This job is not active!', 16, 1);
        RETURN;
    END

    DECLARE @PartId INT = (SELECT PartId FROM Parts WHERE SerialNumber = @SerialNumber)
    IF (@PartId IS NULL)
    BEGIN
        RAISERROR('Part not found!', 16, 1);
        RETURN;
    END

    DECLARE @OrderId INT = (SELECT o.OrderId FROM Orders AS o
    JOIN OrderParts AS op ON op.OrderId = o.OrderId
    JOIN Parts AS p ON p.PartId = op.PartId
    WHERE JobId = @JobId AND p.PartId = @PartId AND IssueDate IS NULL)

    -- Order does not exist -> create new order
    IF (@OrderId IS NULL)
    BEGIN
        INSERT INTO Orders (JobId, IssueDate) VALUES
        (@JobId, NULL)

        INSERT INTO OrderParts (OrderId, PartId, Quantity) VALUES
        (IDENT_CURRENT('Orders'), @PartId, @Quantity)
    END
    ELSE
    BEGIN
        DECLARE @PartExistsInOrder INT = (SELECT @@ROWCOUNT FROM OrderParts
                                          WHERE OrderId = @OrderId AND PartId = @PartId)
        
        IF (@PartExistsInOrder IS NULL)
        BEGIN
            -- Order exists, part does not exist in it -> add part to order      
            INSERT INTO OrderParts (OrderId, PartId, Quantity) VALUES
            (@OrderId, @PartId, @Quantity)
        END
        ELSE
        BEGIN
            -- Order exists, part exists -> increase part quantity in order
            UPDATE OrderParts
            SET Quantity += @Quantity
            WHERE OrderId = @OrderId AND PartId = @PartId
        END
    END
END

GO
--19
	CREATE TRIGGER tr_OrderDelivered ON Orders
AFTER UPDATE
AS
BEGIN
    DECLARE @OldStatus INT = (SELECT Delivered FROM deleted)
    DECLARE @NewStatus INT = (SELECT Delivered FROM inserted)

    IF (@OldStatus = 0 AND @NewStatus = 1)
    BEGIN
        UPDATE Parts
        SET StockQty += op.Quantity
        FROM Parts AS p
        JOIN OrderParts op ON op.PartId = p.PartId
        JOIN Orders o ON o.OrderId = op.OrderId
        JOIN inserted AS i ON i.OrderId = o.OrderId
        JOIN deleted AS d ON d.OrderId = o.OrderId
        WHERE d.Delivered = 0 AND i.Delivered = 1
    END
END

--TEST 
	BEGIN TRAN
    UPDATE Orders
    SET Delivered = 1
    WHERE OrderId = 21
ROLLBACK
	GO

--20
	WITH CTE_VendorPreference
AS
(
    SELECT m.MechanicId, v.VendorId, SUM(op.Quantity) AS ItemsFromVendor FROM Mechanics AS m
    JOIN Jobs AS j ON j.MechanicId = m.MechanicId
    JOIN Orders AS o ON o.JobId = j.JobId
    JOIN OrderParts op ON op.OrderId = o.OrderId
    JOIN Parts AS p ON p.PartId = op.PartId
    JOIN Vendors v ON v.VendorId = p.VendorId
    GROUP BY m.MechanicId, v.VendorId
)

SELECT m.FirstName + ' ' + LastName AS Mechanic,
       v.Name AS Vendor,
       c.ItemsFromVendor AS Parts,
CAST(CAST(CAST(ItemsFromVendor AS DECIMAL(6, 2)) / (SELECT SUM(ItemsFromVendor) FROM CTE_VendorPreference WHERE MechanicId = c.MechanicId) * 100 AS INT) AS VARCHAR(20)) + '%' AS Preference
FROM CTE_VendorPreference AS c
JOIN Mechanics m ON m.MechanicId = c.MechanicId
JOIN Vendors v ON v.VendorId = c.VendorId
ORDER BY Mechanic, Parts DESC, Vendor
