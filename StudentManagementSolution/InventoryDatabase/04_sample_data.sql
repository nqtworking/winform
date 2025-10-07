-- SAMPLE DATA - INVENTORY MANAGEMENT
-- Location: C:\Users\nqtpe\InventoryDatabase\04_sample_data.sql

USE InventoryDB;
GO

-- ================================================================
-- Insert Sample Data
-- ================================================================

-- Categories
INSERT INTO dbo.Categories (CategoryName, Description) VALUES
('Electronics', 'Electronic devices and components'),
('Computers', 'Computers and accessories'),
('Mobile Phones', 'Smartphones and accessories'),
('Office Supplies', 'Office and business supplies'),
('Books', 'Books and educational materials');

-- Suppliers
INSERT INTO dbo.Suppliers (SupplierName, ContactPerson, Phone, Email, City, Country) VALUES
('TechCorp Solutions', 'John Smith', '+1-555-0101', 'john@techcorp.com', 'New York', 'USA'),
('Global Electronics', 'Lisa Wang', '+1-555-0102', 'lisa@globalelec.com', 'San Francisco', 'USA'),
('Office Plus', 'Sarah Johnson', '+1-555-0104', 'sarah@officeplus.com', 'Chicago', 'USA'),
('Book Publishers Inc', 'Michael Davis', '+1-555-0105', 'michael@bookpub.com', 'Boston', 'USA');

-- Products
INSERT INTO dbo.Products (ProductCode, ProductName, CategoryID, SupplierID, UnitPrice, CostPrice, MinStockLevel, ReorderPoint) VALUES
('ELEC001', 'Laptop Dell Inspiron 15', 2, 1, 599.99, 450.00, 5, 10),
('ELEC002', 'Desktop Monitor 24"', 2, 1, 199.99, 150.00, 10, 20),
('ELEC003', 'Wireless Mouse', 2, 2, 39.99, 25.00, 20, 40),
('MOB001', 'iPhone 15 Pro 128GB', 3, 2, 999.99, 750.00, 3, 5),
('MOB002', 'Phone Case iPhone 15', 3, 2, 24.99, 12.00, 25, 50),
('OFF001', 'Office Chair', 4, 3, 299.99, 180.00, 2, 5),
('OFF002', 'Paper A4 (500 sheets)', 4, 3, 8.99, 5.50, 50, 100),
('BOOK001', 'SQL Server Guide', 5, 4, 59.99, 35.00, 5, 10),
('BOOK002', 'Python Programming', 5, 4, 49.99, 30.00, 8, 15);

-- Customers
INSERT INTO dbo.Customers (CustomerCode, CustomerName, ContactPerson, Phone, Email, City, Country, CreditLimit) VALUES
('CUST001', 'ABC Corporation', 'Robert Miller', '+1-555-1001', 'robert@abccorp.com', 'New York', 'USA', 10000.00),
('CUST002', 'XYZ Retail Store', 'Jennifer Lee', '+1-555-1002', 'jennifer@xyzretail.com', 'Los Angeles', 'USA', 15000.00),
('CUST003', 'Tech Solutions Inc', 'Mark Johnson', '+1-555-1003', 'mark@techsolutions.com', 'San Francisco', 'USA', 20000.00);

-- Initial Stock
EXEC dbo.sp_AddStock @ProductID = 1, @Quantity = 25, @UnitCost = 450.00, @Notes = 'Initial stock';
EXEC dbo.sp_AddStock @ProductID = 2, @Quantity = 50, @UnitCost = 150.00, @Notes = 'Initial stock';
EXEC dbo.sp_AddStock @ProductID = 3, @Quantity = 100, @UnitCost = 25.00, @Notes = 'Initial stock';
EXEC dbo.sp_AddStock @ProductID = 4, @Quantity = 15, @UnitCost = 750.00, @Notes = 'Initial stock';
EXEC dbo.sp_AddStock @ProductID = 5, @Quantity = 100, @UnitCost = 12.00, @Notes = 'Initial stock';
EXEC dbo.sp_AddStock @ProductID = 6, @Quantity = 10, @UnitCost = 180.00, @Notes = 'Initial stock';
EXEC dbo.sp_AddStock @ProductID = 7, @Quantity = 200, @UnitCost = 5.50, @Notes = 'Initial stock';
EXEC dbo.sp_AddStock @ProductID = 8, @Quantity = 30, @UnitCost = 35.00, @Notes = 'Initial stock';
EXEC dbo.sp_AddStock @ProductID = 9, @Quantity = 40, @UnitCost = 30.00, @Notes = 'Initial stock';

-- Sample Orders
INSERT INTO dbo.Orders (OrderNumber, CustomerID, ShippingAddress, Notes) VALUES
('ORD20251007001', 1, '100 Business Park, New York', 'Office setup order'),
('ORD20251007002', 2, '200 Retail Plaza, Los Angeles', 'Retail stock order');

-- Order Details
INSERT INTO dbo.OrderDetails (OrderID, ProductID, Quantity, UnitPrice) VALUES
(1, 1, 3, 599.99),
(1, 2, 5, 199.99),
(1, 6, 3, 299.99),
(2, 4, 2, 999.99),
(2, 5, 10, 24.99);

-- Update order totals
UPDATE o SET TotalAmount = (SELECT SUM(LineTotal) FROM dbo.OrderDetails WHERE OrderID = o.OrderID)
FROM dbo.Orders o;

-- Some sales transactions
EXEC dbo.sp_RemoveStock @ProductID = 3, @Quantity = 15, @ReferenceType = 'SALE', @Notes = 'Walk-in sale';
EXEC dbo.sp_RemoveStock @ProductID = 7, @Quantity = 30, @ReferenceType = 'SALE', @Notes = 'Bulk order';

PRINT 'Sample data inserted successfully!';

-- Display summary
SELECT 'Data Summary' as Info;
SELECT 'Products' as Table_Name, COUNT(*) as Record_Count FROM dbo.Products
UNION ALL SELECT 'Categories', COUNT(*) FROM dbo.Categories
UNION ALL SELECT 'Customers', COUNT(*) FROM dbo.Customers
UNION ALL SELECT 'Orders', COUNT(*) FROM dbo.Orders
UNION ALL SELECT 'Inventory Transactions', COUNT(*) FROM dbo.InventoryTransactions;