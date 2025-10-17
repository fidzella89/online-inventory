# Test Data Preparation Guide

## Overview
This guide provides step-by-step instructions for preparing test data for happy path testing of the Online Inventory Management System.

---

## Prerequisites

1. ✅ Application is built and running
2. ✅ Database connection is configured
3. ✅ Migrations have been applied (`dotnet ef database update`)
4. ✅ Database is seeded with initial data

---

## Verify Initial Seed Data

### Step 1: Check Categories

**Action:** Navigate to `/Admin/Products` and check the category dropdown.

**Expected Categories:**
- Electronics
- Clothing
- Books
- Home & Garden
- Sports & Outdoors
- Toys & Games

**Verification Query (Optional):**
```sql
SELECT * FROM Categories ORDER BY Name;
```

✅ **Status:** [ ] Verified

---

### Step 2: Verify Seeded Products

**Action:** Navigate to `/Admin/Products` and count the total products.

**Expected:** At least 20 products should be visible across multiple pages.

**Sample Products to Verify:**
| SKU | Name | Category | Price | Stock |
|-----|------|----------|-------|-------|
| ELEC-001 | Laptop | Electronics | $999.99 | 50 |
| ELEC-002 | Smartphone | Electronics | $699.99 | 100 |
| CLOT-001 | T-Shirt | Clothing | $19.99 | 200 |
| BOOK-001 | Programming Guide | Books | $39.99 | 120 |

**Verification Query (Optional):**
```sql
SELECT SKU, Name, Price, QuantityInStock, c.Name as CategoryName 
FROM Products p 
INNER JOIN Categories c ON p.CategoryId = c.Id 
ORDER BY p.Id;
```

✅ **Status:** [ ] Verified

---

### Step 3: Check Initial Inventory Transactions

**Action:** Navigate to `/Admin/Inventory/Transactions`.

**Expected:** Each product should have an initial transaction with:
- Reason: "Initial Stock"
- Quantity Change: Positive number matching current stock
- Timestamp: Around seed time

**Verification Query (Optional):**
```sql
SELECT p.Name, t.QuantityChange, t.Reason, t.Timestamp 
FROM InventoryTransactions t 
INNER JOIN Products p ON t.ProductId = p.Id 
WHERE t.Reason = 'Initial Stock' 
ORDER BY t.Timestamp DESC;
```

✅ **Status:** [ ] Verified

---

## Create Test-Specific Data

### Test Data Set 1: For Product CRUD Testing

#### Create Test Product (Manual via UI)

**Purpose:** Testing create and delete operations

**Steps:**
1. Navigate to `/Admin/Products`
2. Click "Add New Product"
3. Enter the following data:

```
SKU: TEST-001
Name: Test Product for CRUD
Description: This product will be used for create and delete testing
Category: Electronics
Price: 99.99
Quantity in Stock: 50
```

4. Click "Create Product"
5. ✅ **Verify:** Success message appears
6. ✅ **Verify:** Product appears in product list

**Record Created Product ID:** ________

---

#### Create Test Product via API (Optional)

**Purpose:** API testing

**Request:**
```http
POST /api/products
Content-Type: application/json

{
  "SKU": "API-TEST-001",
  "Name": "API Test Product",
  "Description": "Created via API for testing",
  "Price": 149.99,
  "QuantityInStock": 30,
  "CategoryId": 1
}
```

**Expected Response:** 201 Created

**Record Created Product ID:** ________

---

### Test Data Set 2: For Inventory Testing

#### Prepare Product with Known Stock

**Purpose:** Testing inventory adjustments

**Recommended Product:** Use "Laptop" (ELEC-001)

**Steps:**
1. Navigate to `/Admin/Products`
2. Find "Laptop" product
3. **Record Current Stock:** ________
4. This will be used for adjustment tests (TC-010, TC-011)

---

#### Create Low Stock Product (Optional)

**Purpose:** Testing low stock scenarios

**Steps:**
1. Create or modify a product to have stock = 5
2. **Record Product Name:** ________
3. **Record Product ID:** ________

---

### Test Data Set 3: For Order Testing

#### Identify Products for Order

**Purpose:** Creating test orders

**Recommended Products:**
1. **Product 1:** Laptop (Stock should be ≥ 5)
   - **Product ID:** 1
   - **Current Stock:** ________
   - **Test Order Quantity:** 2

2. **Product 2:** Smartphone (Stock should be ≥ 5)
   - **Product ID:** 2
   - **Current Stock:** ________
   - **Test Order Quantity:** 1

**Calculate Expected Order Total:**
```
Order Total = (Laptop Price × 2) + (Smartphone Price × 1)
           = ($999.99 × 2) + ($699.99 × 1)
           = $2699.97
```

**Record Expected Total:** $________

---

### Test Data Set 4: For API Testing

#### Prepare API Test Environment

**Tools Needed:**
- Postman, Insomnia, curl, or browser developer tools
- Application must be running

**Application URL:** `https://localhost:[PORT]`
**Record Port Number:** ________

**Test API Connectivity:**
```http
GET /api/products?page=1&pageSize=10
```

✅ **Status:** [ ] API Accessible

---

#### Prepare API Test Collection (Postman Example)

Create a collection with the following requests:

1. **Get All Products**
   ```
   GET {{baseUrl}}/api/products?page=1&pageSize=10
   ```

2. **Get Product by ID**
   ```
   GET {{baseUrl}}/api/products/1
   ```

3. **Search Products**
   ```
   GET {{baseUrl}}/api/products?search=laptop
   ```

4. **Create Product**
   ```
   POST {{baseUrl}}/api/products
   Body: { "SKU": "API-TEST-002", "Name": "Test", ... }
   ```

5. **Create Order**
   ```
   POST {{baseUrl}}/api/orders
   Body: { "Items": [{"ProductId": 1, "Quantity": 1}] }
   ```

---

## Database Backup (Recommended)

**Purpose:** Restore clean state if needed

### Create Backup

**SQL Server:**
```sql
BACKUP DATABASE OnlineInventoryDb 
TO DISK = 'C:\Backups\OnlineInventoryDb_TestBackup.bak'
WITH FORMAT, MEDIANAME = 'TestBackup', NAME = 'Full Backup';
```

**OR** Use SSMS GUI: Right-click database → Tasks → Back Up...

✅ **Backup Created:** [ ] Yes  
**Backup Location:** ________

---

## Reset Test Data (If Needed)

### Option 1: Delete and Recreate Database

```bash
# In project directory
dotnet ef database drop --force
dotnet ef database update
```

⚠️ **Warning:** This will delete ALL data!

---

### Option 2: Delete Test-Specific Data Only

**Delete Test Products:**
```sql
-- Delete test products
DELETE FROM Products WHERE SKU LIKE 'TEST-%' OR SKU LIKE 'API-TEST-%';
```

**Delete Test Orders:**
```sql
-- Delete recent test orders (adjust date as needed)
DELETE FROM Orders WHERE CreatedAt > '2025-10-17';
```

**Delete Test Categories:**
```sql
DELETE FROM Categories WHERE Name = 'Test Category';
```

---

## Data Validation Checklist

Before starting testing, verify:

- [ ] Database contains at least 6 categories
- [ ] Database contains at least 20 products
- [ ] All products have positive stock quantities
- [ ] All products have associated initial inventory transactions
- [ ] No orphaned records (referential integrity intact)
- [ ] All prices are positive decimal values
- [ ] All SKUs are unique
- [ ] All category names are unique

**Validation Query:**
```sql
-- Check data integrity
SELECT 
    (SELECT COUNT(*) FROM Categories) as CategoryCount,
    (SELECT COUNT(*) FROM Products) as ProductCount,
    (SELECT COUNT(*) FROM InventoryTransactions) as TransactionCount,
    (SELECT COUNT(*) FROM Orders) as OrderCount,
    (SELECT COUNT(*) FROM OrderItems) as OrderItemCount,
    (SELECT COUNT(*) FROM Products WHERE QuantityInStock < 0) as NegativeStockCount,
    (SELECT COUNT(*) FROM Products WHERE Price <= 0) as InvalidPriceCount;
```

**Expected Results:**
- CategoryCount: ≥ 6
- ProductCount: ≥ 20
- TransactionCount: ≥ 20 (at least one per product)
- NegativeStockCount: 0
- InvalidPriceCount: 0

✅ **All Checks Passed:** [ ] Yes

---

## Test Data Documentation Template

Use this template to document any additional test data you create:

### Test Data Entry

**Created By:** ________  
**Date:** ________  
**Purpose:** ________  

**Data Type:** [ ] Product  [ ] Category  [ ] Order  [ ] Other: ________

**Details:**
```
ID: ________
SKU/Name: ________
Attributes: ________
Expected Use: ________
```

**Location in Tests:** TC-_____, TC-_____

---

## Troubleshooting

### Issue: No Products Showing

**Solution:**
1. Check if database is seeded: Run `SELECT COUNT(*) FROM Products;`
2. If count is 0, re-run seed: Restart application (seed runs at startup)
3. Check for errors in application logs

---

### Issue: Cannot Create Order (Insufficient Stock)

**Solution:**
1. Check product stock: Navigate to `/Admin/Products`
2. Increase stock via inventory adjustment: `/Admin/Inventory/Adjust`
3. Or reduce order quantity in test

---

### Issue: Duplicate SKU Error

**Solution:**
1. Change SKU to unique value
2. Or delete existing product with that SKU
3. Check database: `SELECT * FROM Products WHERE SKU = 'YOUR-SKU';`

---

### Issue: API Returns 404

**Solution:**
1. Verify application is running
2. Check port number in URL
3. Ensure endpoint path is correct (case-sensitive)
4. Check application startup logs for errors

---

### Issue: Foreign Key Constraint Error

**Solution:**
1. Ensure referenced entity exists (e.g., Category)
2. Check foreign key values match existing IDs
3. Verify referential integrity

---

## Quick Reference: Common SQL Queries

### View All Products with Details
```sql
SELECT p.Id, p.SKU, p.Name, p.Price, p.QuantityInStock, c.Name as Category
FROM Products p
INNER JOIN Categories c ON p.CategoryId = c.Id
ORDER BY p.Id;
```

### View Inventory Transactions
```sql
SELECT t.Id, p.Name as Product, t.QuantityChange, t.Reason, t.Timestamp
FROM InventoryTransactions t
INNER JOIN Products p ON t.ProductId = p.Id
ORDER BY t.Timestamp DESC;
```

### View Orders with Items
```sql
SELECT o.Id, o.CreatedAt, o.Total, oi.Quantity, p.Name as Product, oi.UnitPrice
FROM Orders o
INNER JOIN OrderItems oi ON o.Id = oi.OrderId
INNER JOIN Products p ON oi.ProductId = p.Id
ORDER BY o.CreatedAt DESC;
```

### Check Stock Levels
```sql
SELECT Name, SKU, QuantityInStock,
    CASE 
        WHEN QuantityInStock < 10 THEN 'Low Stock'
        WHEN QuantityInStock < 50 THEN 'Medium Stock'
        ELSE 'Good Stock'
    END as StockStatus
FROM Products
ORDER BY QuantityInStock ASC;
```

---

## Completion Checklist

Before proceeding to test execution:

- [ ] All initial seed data verified
- [ ] Test-specific data created
- [ ] Database backup created (optional but recommended)
- [ ] API test environment configured
- [ ] All validation checks passed
- [ ] Test team has access to this documentation
- [ ] Application is running and accessible

**Prepared By:** ________  
**Date:** ________  
**Sign-off:** ________

---

**Document Version:** 1.0  
**Last Updated:** October 17, 2025

