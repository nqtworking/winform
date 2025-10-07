# INVENTORY MANAGEMENT DATABASE SYSTEM

## 📍 **Vị Trí File**
```
C:\Users\nqtpe\InventoryDatabase\
├── 01_database_schema.sql      # Database tables và indexes
├── 02_stored_procedures.sql    # Stored procedures chính
├── 03_views_functions.sql      # Views và functions
├── 04_sample_data.sql          # Dữ liệu mẫu để test
├── 05_triggers_constraints.sql # Triggers và audit trail
├── setup.bat                   # Script tự động cài đặt
└── README.md                   # File hướng dẫn này
```

## 🚀 **Cách Cài Đặt Nhanh**

### **Phương pháp 1: Tự động (Khuyến nghị)**
```batch
# Mở Command Prompt tại folder InventoryDatabase
cd C:\Users\nqtpe\InventoryDatabase
setup.bat
```

### **Phương pháp 2: Thủ công**
```sql
-- Chạy từng file theo thứ tự trong SQL Server Management Studio:
-- 1. 01_database_schema.sql
-- 2. 02_stored_procedures.sql  
-- 3. 03_views_functions.sql
-- 4. 04_sample_data.sql
-- 5. 05_triggers_constraints.sql
```

## 🎯 **Tính Năng Chính**

### **Quản Lý Kho Hàng**
- ✅ Tính tồn kho realtime
- ✅ Cảnh báo hàng thiếu
- ✅ Định giá tồn kho  
- ✅ Phân tích ABC
- ✅ Lịch sử xuất nhập

### **Xử Lý Đơn Hàng**
- ✅ Tạo đơn hàng
- ✅ Kiểm tra tồn kho
- ✅ Tự động trừ kho
- ✅ Tracking status
- ✅ Tính toán tự động

## 📊 **Test Nhanh**
```sql
-- Kết nối database
USE InventoryDB;

-- Xem tồn kho hiện tại
SELECT TOP 10 * FROM dbo.vw_CurrentInventory;

-- Kiểm tra dữ liệu mẫu
EXEC dbo.sp_GetInventoryMetrics;

-- Xem báo cáo thiếu hàng
SELECT * FROM dbo.vw_LowStockAlert;
```

## 🔧 **Các Lệnh Thường Dùng**
```sql
-- Nhập hàng
EXEC dbo.sp_AddStock @ProductID = 1, @Quantity = 100, @UnitCost = 50.00;

-- Xuất hàng  
EXEC dbo.sp_RemoveStock @ProductID = 1, @Quantity = 10;

-- Tạo đơn hàng
DECLARE @OrderID int;
EXEC dbo.sp_CreateOrder @CustomerID = 1, @OrderItems = '[{"ProductID":1,"Quantity":5}]', @OrderID = @OrderID OUTPUT;

-- Xử lý đơn hàng
EXEC dbo.sp_ProcessOrder @OrderID = @OrderID, @ProcessType = 'SHIP';
```

## 📞 **Hỗ Trợ**
- **Database**: InventoryDB
- **Server**: localhost (hoặc server của bạn)
- **Authentication**: Windows Authentication
- **Compatibility**: SQL Server 2016+

---
**Created**: October 7, 2025  
**Location**: `C:\Users\nqtpe\InventoryDatabase`  
**Total Files**: 6 files