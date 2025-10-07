-- TRIGGERS AND CONSTRAINTS - INVENTORY MANAGEMENT
-- Location: C:\Users\nqtpe\InventoryDatabase\05_triggers_constraints.sql

USE InventoryDB;
GO

-- ================================================================
-- Triggers
-- ================================================================

-- Update Order Total Trigger
CREATE OR ALTER TRIGGER dbo.tr_OrderDetails_UpdateTotal
ON dbo.OrderDetails
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
    SET NOCOUNT ON;
    
    UPDATE o
    SET TotalAmount = ISNULL(totals.OrderTotal, 0),
        ModifiedDate = GETDATE()
    FROM dbo.Orders o
    INNER JOIN (
        SELECT DISTINCT OrderID FROM inserted
        UNION
        SELECT DISTINCT OrderID FROM deleted
    ) affected ON o.OrderID = affected.OrderID
    LEFT JOIN (
        SELECT OrderID, SUM(LineTotal) as OrderTotal
        FROM dbo.OrderDetails
        GROUP BY OrderID
    ) totals ON o.OrderID = totals.OrderID;
END
GO

-- Update Product Modified Date Trigger
CREATE OR ALTER TRIGGER dbo.tr_Products_UpdateModified
ON dbo.Products
AFTER UPDATE
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE dbo.Products 
    SET ModifiedDate = GETDATE()
    WHERE ProductID IN (SELECT ProductID FROM inserted);
END
GO

-- ================================================================
-- Audit Table
-- ================================================================

-- Create audit table
IF OBJECT_ID('dbo.AuditTrail', 'U') IS NULL
BEGIN
    CREATE TABLE dbo.AuditTrail (
        AuditID int IDENTITY(1,1) PRIMARY KEY,
        TableName nvarchar(50) NOT NULL,
        RecordID int NOT NULL,
        Action nvarchar(10) NOT NULL,
        ColumnName nvarchar(50),
        OldValue nvarchar(500),
        NewValue nvarchar(500),
        ChangedBy nvarchar(50) DEFAULT SYSTEM_USER,
        ChangedDate datetime2 DEFAULT GETDATE()
    );
END
GO

-- Price Change Audit Trigger
CREATE OR ALTER TRIGGER dbo.tr_Products_PriceAudit
ON dbo.Products
AFTER UPDATE
AS
BEGIN
    SET NOCOUNT ON;
    
    INSERT INTO dbo.AuditTrail (TableName, RecordID, Action, ColumnName, OldValue, NewValue)
    SELECT 
        'Products',
        i.ProductID,
        'UPDATE',
        'UnitPrice',
        CAST(d.UnitPrice as nvarchar(50)),
        CAST(i.UnitPrice as nvarchar(50))
    FROM inserted i
    INNER JOIN deleted d ON i.ProductID = d.ProductID
    WHERE i.UnitPrice != d.UnitPrice;
END
GO

-- ================================================================
-- Validation Procedures
-- ================================================================

-- Validate Inventory Integrity
CREATE OR ALTER PROCEDURE dbo.sp_ValidateInventory
AS
BEGIN
    -- Check negative stock
    SELECT 
        'Negative Stock' as Issue,
        p.ProductCode,
        p.ProductName,
        SUM(it.Quantity) as CurrentStock
    FROM dbo.Products p
    LEFT JOIN dbo.InventoryTransactions it ON p.ProductID = it.ProductID
    WHERE p.IsActive = 1
    GROUP BY p.ProductID, p.ProductCode, p.ProductName
    HAVING SUM(it.Quantity) < 0
    
    UNION ALL
    
    -- Check low stock
    SELECT 
        'Low Stock' as Issue,
        p.ProductCode,
        p.ProductName,
        SUM(it.Quantity) as CurrentStock
    FROM dbo.Products p
    LEFT JOIN dbo.InventoryTransactions it ON p.ProductID = it.ProductID
    WHERE p.IsActive = 1
    GROUP BY p.ProductID, p.ProductCode, p.ProductName, p.MinStockLevel
    HAVING SUM(it.Quantity) <= p.MinStockLevel;
END
GO

-- Cleanup Audit Trail
CREATE OR ALTER PROCEDURE dbo.sp_CleanupAudit
    @RetentionDays int = 365
AS
BEGIN
    DELETE FROM dbo.AuditTrail 
    WHERE ChangedDate < DATEADD(day, -@RetentionDays, GETDATE());
    
    SELECT @@ROWCOUNT as RecordsDeleted;
END
GO

PRINT 'Triggers and constraints created successfully!';
PRINT 'Database setup completed!';