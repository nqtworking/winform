-- ================================================================
-- INVENTORY MANAGEMENT DATABASE SCHEMA
-- ================================================================
-- Created: October 7, 2025
-- Description: Complete inventory management system with order processing

-- Create Database
IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = 'InventoryDB')
BEGIN
    CREATE DATABASE InventoryDB;
END
GO

USE InventoryDB;
GO

-- ================================================================
-- DROP EXISTING OBJECTS (for clean setup)
-- ================================================================
IF OBJECT_ID('dbo.OrderDetails', 'U') IS NOT NULL DROP TABLE dbo.OrderDetails;
IF OBJECT_ID('dbo.Orders', 'U') IS NOT NULL DROP TABLE dbo.Orders;
IF OBJECT_ID('dbo.InventoryTransactions', 'U') IS NOT NULL DROP TABLE dbo.InventoryTransactions;
IF OBJECT_ID('dbo.Products', 'U') IS NOT NULL DROP TABLE dbo.Products;
IF OBJECT_ID('dbo.Categories', 'U') IS NOT NULL DROP TABLE dbo.Categories;
IF OBJECT_ID('dbo.Suppliers', 'U') IS NOT NULL DROP TABLE dbo.Suppliers;
IF OBJECT_ID('dbo.Customers', 'U') IS NOT NULL DROP TABLE dbo.Customers;
GO

-- ================================================================
-- CORE TABLES
-- ================================================================

-- Categories Table
CREATE TABLE dbo.Categories (
    CategoryID int IDENTITY(1,1) PRIMARY KEY,
    CategoryName nvarchar(50) NOT NULL UNIQUE,
    Description nvarchar(255),
    CreatedDate datetime2 DEFAULT GETDATE(),
    IsActive bit DEFAULT 1
);

-- Suppliers Table  
CREATE TABLE dbo.Suppliers (
    SupplierID int IDENTITY(1,1) PRIMARY KEY,
    SupplierName nvarchar(100) NOT NULL,
    ContactPerson nvarchar(100),
    Phone nvarchar(20),
    Email nvarchar(100),
    Address nvarchar(255),
    City nvarchar(50),
    Country nvarchar(50),
    CreatedDate datetime2 DEFAULT GETDATE(),
    IsActive bit DEFAULT 1
);

-- Products Table
CREATE TABLE dbo.Products (
    ProductID int IDENTITY(1,1) PRIMARY KEY,
    ProductCode nvarchar(20) NOT NULL UNIQUE,
    ProductName nvarchar(100) NOT NULL,
    CategoryID int NOT NULL,
    SupplierID int NOT NULL,
    Description nvarchar(500),
    UnitPrice decimal(10,2) NOT NULL CHECK (UnitPrice >= 0),
    CostPrice decimal(10,2) NOT NULL CHECK (CostPrice >= 0),
    MinStockLevel int DEFAULT 0 CHECK (MinStockLevel >= 0),
    MaxStockLevel int DEFAULT 1000 CHECK (MaxStockLevel >= 0),
    ReorderPoint int DEFAULT 10 CHECK (ReorderPoint >= 0),
    Unit nvarchar(20) DEFAULT 'pcs',
    Barcode nvarchar(50),
    CreatedDate datetime2 DEFAULT GETDATE(),
    ModifiedDate datetime2 DEFAULT GETDATE(),
    IsActive bit DEFAULT 1,
    
    CONSTRAINT FK_Products_Categories FOREIGN KEY (CategoryID) REFERENCES dbo.Categories(CategoryID),
    CONSTRAINT FK_Products_Suppliers FOREIGN KEY (SupplierID) REFERENCES dbo.Suppliers(SupplierID),
    CONSTRAINT CK_Products_StockLevels CHECK (MaxStockLevel >= MinStockLevel)
);

-- Customers Table
CREATE TABLE dbo.Customers (
    CustomerID int IDENTITY(1,1) PRIMARY KEY,
    CustomerCode nvarchar(20) NOT NULL UNIQUE,
    CustomerName nvarchar(100) NOT NULL,
    ContactPerson nvarchar(100),
    Phone nvarchar(20),
    Email nvarchar(100),
    Address nvarchar(255),
    City nvarchar(50),
    Country nvarchar(50),
    CreditLimit decimal(12,2) DEFAULT 0,
    CreatedDate datetime2 DEFAULT GETDATE(),
    IsActive bit DEFAULT 1
);

-- Orders Table
CREATE TABLE dbo.Orders (
    OrderID int IDENTITY(1,1) PRIMARY KEY,
    OrderNumber nvarchar(20) NOT NULL UNIQUE,
    CustomerID int NOT NULL,
    OrderDate datetime2 DEFAULT GETDATE(),
    RequiredDate datetime2,
    ShippedDate datetime2,
    OrderStatus nvarchar(20) DEFAULT 'Pending' CHECK (OrderStatus IN ('Pending', 'Processing', 'Shipped', 'Delivered', 'Cancelled')),
    TotalAmount decimal(12,2) DEFAULT 0,
    DiscountAmount decimal(12,2) DEFAULT 0,
    TaxAmount decimal(12,2) DEFAULT 0,
    ShippingAddress nvarchar(255),
    Notes nvarchar(500),
    CreatedBy nvarchar(50) DEFAULT SYSTEM_USER,
    CreatedDate datetime2 DEFAULT GETDATE(),
    ModifiedDate datetime2 DEFAULT GETDATE(),
    
    CONSTRAINT FK_Orders_Customers FOREIGN KEY (CustomerID) REFERENCES dbo.Customers(CustomerID)
);

-- Order Details Table
CREATE TABLE dbo.OrderDetails (
    OrderDetailID int IDENTITY(1,1) PRIMARY KEY,
    OrderID int NOT NULL,
    ProductID int NOT NULL,
    Quantity int NOT NULL CHECK (Quantity > 0),
    UnitPrice decimal(10,2) NOT NULL CHECK (UnitPrice >= 0),
    Discount decimal(5,2) DEFAULT 0 CHECK (Discount >= 0 AND Discount <= 100),
    LineTotal AS (Quantity * UnitPrice * (1 - Discount/100)) PERSISTED,
    
    CONSTRAINT FK_OrderDetails_Orders FOREIGN KEY (OrderID) REFERENCES dbo.Orders(OrderID) ON DELETE CASCADE,
    CONSTRAINT FK_OrderDetails_Products FOREIGN KEY (ProductID) REFERENCES dbo.Products(ProductID),
    CONSTRAINT UK_OrderDetails_OrderProduct UNIQUE (OrderID, ProductID)
);

-- Inventory Transactions Table (for tracking all stock movements)
CREATE TABLE dbo.InventoryTransactions (
    TransactionID int IDENTITY(1,1) PRIMARY KEY,
    ProductID int NOT NULL,
    TransactionType nvarchar(20) NOT NULL CHECK (TransactionType IN ('IN', 'OUT', 'ADJUSTMENT', 'TRANSFER')),
    Quantity int NOT NULL,
    ReferenceType nvarchar(20) CHECK (ReferenceType IN ('PURCHASE', 'SALE', 'ADJUSTMENT', 'TRANSFER', 'RETURN')),
    ReferenceID int, -- Could be OrderID, PurchaseID, etc.
    UnitCost decimal(10,2),
    TotalCost AS (ABS(Quantity) * ISNULL(UnitCost, 0)) PERSISTED,
    TransactionDate datetime2 DEFAULT GETDATE(),
    Notes nvarchar(255),
    CreatedBy nvarchar(50) DEFAULT SYSTEM_USER,
    
    CONSTRAINT FK_InventoryTransactions_Products FOREIGN KEY (ProductID) REFERENCES dbo.Products(ProductID)
);

-- ================================================================
-- INDEXES FOR PERFORMANCE
-- ================================================================

-- Products indexes
CREATE NONCLUSTERED INDEX IX_Products_CategoryID ON dbo.Products(CategoryID);
CREATE NONCLUSTERED INDEX IX_Products_SupplierID ON dbo.Products(SupplierID);
CREATE NONCLUSTERED INDEX IX_Products_ProductCode ON dbo.Products(ProductCode);
CREATE NONCLUSTERED INDEX IX_Products_IsActive ON dbo.Products(IsActive) WHERE IsActive = 1;

-- Orders indexes
CREATE NONCLUSTERED INDEX IX_Orders_CustomerID ON dbo.Orders(CustomerID);
CREATE NONCLUSTERED INDEX IX_Orders_OrderDate ON dbo.Orders(OrderDate);
CREATE NONCLUSTERED INDEX IX_Orders_OrderStatus ON dbo.Orders(OrderStatus);
CREATE NONCLUSTERED INDEX IX_Orders_OrderNumber ON dbo.Orders(OrderNumber);

-- OrderDetails indexes
CREATE NONCLUSTERED INDEX IX_OrderDetails_ProductID ON dbo.OrderDetails(ProductID);

-- InventoryTransactions indexes
CREATE NONCLUSTERED INDEX IX_InventoryTransactions_ProductID ON dbo.InventoryTransactions(ProductID);
CREATE NONCLUSTERED INDEX IX_InventoryTransactions_TransactionDate ON dbo.InventoryTransactions(TransactionDate);
CREATE NONCLUSTERED INDEX IX_InventoryTransactions_TransactionType ON dbo.InventoryTransactions(TransactionType);

PRINT 'Database schema created successfully!';
GO