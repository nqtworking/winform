-- STORED PROCEDURES - INVENTORY MANAGEMENT
-- Location: C:\Users\nqtpe\InventoryDatabase\02_stored_procedures.sql

USE InventoryDB;
GO

-- ================================================================
-- Core Stored Procedures
-- ================================================================

-- Add Stock Procedure
CREATE OR ALTER PROCEDURE dbo.sp_AddStock
    @ProductID int,
    @Quantity int,
    @UnitCost decimal(10,2) = NULL,
    @ReferenceType nvarchar(20) = 'PURCHASE',
    @Notes nvarchar(255) = NULL
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRY
        INSERT INTO dbo.InventoryTransactions (ProductID, TransactionType, Quantity, ReferenceType, UnitCost, Notes)
        VALUES (@ProductID, 'IN', @Quantity, @ReferenceType, @UnitCost, @Notes);
        SELECT 'Stock added successfully' as Result;
    END TRY
    BEGIN CATCH
        THROW;
    END CATCH
END
GO

-- Remove Stock Procedure  
CREATE OR ALTER PROCEDURE dbo.sp_RemoveStock
    @ProductID int,
    @Quantity int,
    @ReferenceType nvarchar(20) = 'SALE',
    @Notes nvarchar(255) = NULL
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRY
        INSERT INTO dbo.InventoryTransactions (ProductID, TransactionType, Quantity, ReferenceType, Notes)
        VALUES (@ProductID, 'OUT', -@Quantity, @ReferenceType, @Notes);
        SELECT 'Stock removed successfully' as Result;
    END TRY
    BEGIN CATCH
        THROW;
    END CATCH
END
GO

-- Get Current Stock
CREATE OR ALTER PROCEDURE dbo.sp_GetCurrentStock
    @ProductID int,
    @CurrentStock int OUTPUT
AS
BEGIN
    SELECT @CurrentStock = ISNULL(SUM(Quantity), 0)
    FROM dbo.InventoryTransactions 
    WHERE ProductID = @ProductID;
END
GO

-- Get Low Stock Products
CREATE OR ALTER PROCEDURE dbo.sp_GetLowStockProducts
AS
BEGIN
    SELECT 
        p.ProductCode,
        p.ProductName,
        ISNULL(SUM(it.Quantity), 0) as CurrentStock,
        p.ReorderPoint,
        p.MinStockLevel
    FROM dbo.Products p
    LEFT JOIN dbo.InventoryTransactions it ON p.ProductID = it.ProductID
    WHERE p.IsActive = 1
    GROUP BY p.ProductID, p.ProductCode, p.ProductName, p.ReorderPoint, p.MinStockLevel
    HAVING ISNULL(SUM(it.Quantity), 0) <= p.ReorderPoint
    ORDER BY CurrentStock;
END
GO

-- Get Inventory Metrics
CREATE OR ALTER PROCEDURE dbo.sp_GetInventoryMetrics
AS
BEGIN
    SELECT 
        'Total Products' as Metric,
        COUNT(*) as Value
    FROM dbo.Products WHERE IsActive = 1
    
    UNION ALL
    
    SELECT 
        'Total Categories',
        COUNT(*)
    FROM dbo.Categories WHERE IsActive = 1
    
    UNION ALL
    
    SELECT 
        'Active Orders',
        COUNT(*)
    FROM dbo.Orders WHERE OrderStatus IN ('Pending', 'Processing');
END
GO

PRINT 'Stored procedures created successfully!';