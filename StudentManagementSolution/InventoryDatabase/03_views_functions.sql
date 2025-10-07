-- VIEWS AND FUNCTIONS - INVENTORY MANAGEMENT  
-- Location: C:\Users\nqtpe\InventoryDatabase\03_views_functions.sql

USE InventoryDB;
GO

-- ================================================================
-- Functions
-- ================================================================

-- Get Product Stock Function
CREATE OR ALTER FUNCTION dbo.fn_GetProductStock(@ProductID int)
RETURNS int
AS
BEGIN
    DECLARE @Stock int;
    SELECT @Stock = ISNULL(SUM(Quantity), 0)
    FROM dbo.InventoryTransactions 
    WHERE ProductID = @ProductID;
    RETURN @Stock;
END
GO

-- ================================================================
-- Views
-- ================================================================

-- Current Inventory View
CREATE OR ALTER VIEW dbo.vw_CurrentInventory
AS
SELECT 
    p.ProductID,
    p.ProductCode,
    p.ProductName,
    c.CategoryName,
    s.SupplierName,
    dbo.fn_GetProductStock(p.ProductID) as CurrentStock,
    p.MinStockLevel,
    p.ReorderPoint,
    p.UnitPrice,
    p.CostPrice,
    CASE 
        WHEN dbo.fn_GetProductStock(p.ProductID) <= 0 THEN 'Out of Stock'
        WHEN dbo.fn_GetProductStock(p.ProductID) <= p.MinStockLevel THEN 'Critical'
        WHEN dbo.fn_GetProductStock(p.ProductID) <= p.ReorderPoint THEN 'Low'
        ELSE 'Normal'
    END as StockStatus
FROM dbo.Products p
INNER JOIN dbo.Categories c ON p.CategoryID = c.CategoryID
INNER JOIN dbo.Suppliers s ON p.SupplierID = s.SupplierID
WHERE p.IsActive = 1;
GO

-- Low Stock Alert View
CREATE OR ALTER VIEW dbo.vw_LowStockAlert
AS
SELECT *
FROM dbo.vw_CurrentInventory
WHERE StockStatus IN ('Out of Stock', 'Critical', 'Low');
GO

-- Order Summary View
CREATE OR ALTER VIEW dbo.vw_OrderSummary
AS
SELECT 
    o.OrderID,
    o.OrderNumber,
    o.OrderDate,
    o.OrderStatus,
    c.CustomerName,
    o.TotalAmount,
    COUNT(od.OrderDetailID) as ItemCount
FROM dbo.Orders o
INNER JOIN dbo.Customers c ON o.CustomerID = c.CustomerID
LEFT JOIN dbo.OrderDetails od ON o.OrderID = od.OrderID
GROUP BY o.OrderID, o.OrderNumber, o.OrderDate, o.OrderStatus, c.CustomerName, o.TotalAmount;
GO

PRINT 'Views and functions created successfully!';