@echo off
echo ================================================================
echo INVENTORY DATABASE SETUP SCRIPT
echo ================================================================
echo Created: October 7, 2025
echo Location: C:\Users\nqtpe\InventoryDatabase
echo.

echo [1/5] Creating database schema...
sqlcmd -S localhost -E -i "01_database_schema.sql"

echo [2/5] Creating stored procedures...
sqlcmd -S localhost -E -i "02_stored_procedures.sql"

echo [3/5] Creating views and functions...
sqlcmd -S localhost -E -i "03_views_functions.sql"

echo [4/5] Inserting sample data...
sqlcmd -S localhost -E -i "04_sample_data.sql"

echo [5/5] Creating triggers and constraints...
sqlcmd -S localhost -E -i "05_triggers_constraints.sql"

echo.
echo ================================================================
echo INVENTORY DATABASE SETUP COMPLETED SUCCESSFULLY!
echo ================================================================
echo.
echo Database: InventoryDB
echo Location: C:\Users\nqtpe\InventoryDatabase
echo.
echo To connect: sqlcmd -S localhost -E -d InventoryDB
echo Or use SQL Server Management Studio (SSMS)
echo.
echo Quick test queries:
echo SELECT * FROM dbo.vw_CurrentInventory;
echo EXEC dbo.sp_GetInventoryMetrics;
echo.
pause