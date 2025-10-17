# Online Inventory Management System - Happy Path Test Cases

## Project Information
- **Project Name:** Online Inventory Management (MVC)
- **Test Type:** Happy Path Testing (BE & FE Integration)
- **Date:** October 17, 2025
- **Technology Stack:** ASP.NET Core MVC, Entity Framework Core, SQL Server

---

## 1. Define Test Objectives

1. Verify that all core features work correctly in ideal conditions
2. Validate backend and frontend integration
3. Ensure data flow between layers (Controller → Service → Repository → Database)
4. Confirm UI displays correct data and responds appropriately
5. Validate API endpoints return expected responses
6. Ensure database transactions maintain data integrity

---

## Step 2: Assign Roles and Responsibilities

| Role | Name | Responsibilities |
|------|------|------------------|
| Test Lead | [To be assigned] | Coordinate testing activities, review test results |
| Backend Tester | [To be assigned] | Test API endpoints, database operations |
| Frontend Tester | [To be assigned] | Test MVC views, user interactions |
| Integration Tester | [To be assigned] | Test BE/FE integration, data flow |
| Documentation | [To be assigned] | Record test results, document issues |

---

---

## Step 3: Create Test Cases

### Module 1: Product Management (Admin MVC)

#### TC-001: View All Products
| Field | Details |
|-------|---------|
| **Test Case ID** | TC-001 |
| **Description** | Admin views the list of all products with pagination |
| **Preconditions** | Database is seeded with initial products |
| **Test Data** | N/A |
| **Steps** | 1. Navigate to `/Admin/Products`<br>2. Observe the product list display |
| **Expected Outcome** | - Product list displays with columns: SKU, Name, Category, Price, Stock<br>- Stock badges show color coding (red < 10, warning 10-49, green ≥ 50)<br>- Pagination controls appear if products > 10<br>- "Add New Product" button is visible |
| **Actual Outcome** | [To be filled during testing] |
| **Status** | [Pass/Fail] |
| **Comments** | |

#### TC-002: Search Products
| Field | Details |
|-------|---------|
| **Test Case ID** | TC-002 |
| **Description** | Admin searches for products by name, SKU, or description |
| **Preconditions** | Database contains products |
| **Test Data** | Search term: "Laptop" |
| **Steps** | 1. Navigate to `/Admin/Products`<br>2. Enter "Laptop" in search box<br>3. Click "Filter" button |
| **Expected Outcome** | - Only products matching "Laptop" are displayed<br>- Page refreshes with filtered results<br>- Search term remains in search box |
| **Actual Outcome** | [To be filled during testing] |
| **Status** | [Pass/Fail] |
| **Comments** | |

#### TC-003: Filter Products by Category
| Field | Details |
|-------|---------|
| **Test Case ID** | TC-003 |
| **Description** | Admin filters products by category |
| **Preconditions** | Multiple categories exist with products |
| **Test Data** | Category: "Electronics" |
| **Steps** | 1. Navigate to `/Admin/Products`<br>2. Select "Electronics" from category dropdown<br>3. Click "Filter" button |
| **Expected Outcome** | - Only products from Electronics category displayed<br>- Category dropdown shows "Electronics" selected<br>- Product count reflects filtered results |
| **Actual Outcome** | [To be filled during testing] |
| **Status** | [Pass/Fail] |
| **Comments** | |

#### TC-004: Sort Products by Price (Ascending)
| Field | Details |
|-------|---------|
| **Test Case ID** | TC-004 |
| **Description** | Admin sorts products by price from low to high |
| **Preconditions** | Multiple products with varying prices exist |
| **Test Data** | N/A |
| **Steps** | 1. Navigate to `/Admin/Products`<br>2. Select "Price (Low-High)" from sort dropdown<br>3. Click "Filter" button |
| **Expected Outcome** | - Products displayed in ascending price order<br>- First product has lowest price<br>- Last product has highest price |
| **Actual Outcome** | [To be filled during testing] |
| **Status** | [Pass/Fail] |
| **Comments** | |

#### TC-005: Create New Product
| Field | Details |
|-------|---------|
| **Test Case ID** | TC-005 |
| **Description** | Admin creates a new product successfully |
| **Preconditions** | Categories exist in database |
| **Test Data** | - SKU: "TEST-001"<br>- Name: "Test Product"<br>- Description: "This is a test product"<br>- Category: "Electronics"<br>- Price: 99.99<br>- Quantity: 50 |
| **Steps** | 1. Navigate to `/Admin/Products`<br>2. Click "Add New Product" button<br>3. Fill in all required fields with test data<br>4. Click "Create Product" button |
| **Expected Outcome** | - Success message: "Product created successfully"<br>- Redirected to product list<br>- New product appears in the list<br>- Inventory transaction created with reason "Initial Stock" |
| **Actual Outcome** | [To be filled during testing] |
| **Status** | [Pass/Fail] |
| **Comments** | |

#### TC-006: Create Product with Duplicate SKU
| Field | Details |
|-------|---------|
| **Test Case ID** | TC-006 |
| **Description** | System prevents creating product with duplicate SKU |
| **Preconditions** | Product with SKU "ELEC-001" exists |
| **Test Data** | - SKU: "ELEC-001" (duplicate)<br>- Name: "Another Product"<br>- Price: 50.00<br>- Category: "Electronics"<br>- Quantity: 10 |
| **Steps** | 1. Navigate to `/Admin/Products/Create`<br>2. Fill form with duplicate SKU<br>3. Click "Create Product" |
| **Expected Outcome** | - Error message displayed: "Product with SKU 'ELEC-001' already exists"<br>- Product is NOT created<br>- Form remains on create page<br>- Entered data is retained |
| **Actual Outcome** | [To be filled during testing] |
| **Status** | [Pass/Fail] |
| **Comments** | |

#### TC-007: Edit Existing Product
| Field | Details |
|-------|---------|
| **Test Case ID** | TC-007 |
| **Description** | Admin successfully edits an existing product |
| **Preconditions** | Product exists (e.g., "Laptop") |
| **Test Data** | - Updated Name: "Gaming Laptop"<br>- Updated Price: 1299.99<br>- Updated Description: "High-performance gaming laptop" |
| **Steps** | 1. Navigate to `/Admin/Products`<br>2. Click "Edit" on a product<br>3. Modify name, price, and description<br>4. Click "Save Changes" |
| **Expected Outcome** | - Success message: "Product updated successfully"<br>- Redirected to product list<br>- Product shows updated information<br>- SKU and stock remain unchanged (not editable) |
| **Actual Outcome** | [To be filled during testing] |
| **Status** | [Pass/Fail] |
| **Comments** | |

#### TC-008: Delete Product
| Field | Details |
|-------|---------|
| **Test Case ID** | TC-008 |
| **Description** | Admin successfully deletes a product |
| **Preconditions** | Product exists and has no order dependencies |
| **Test Data** | Product: "Test Product" (created in TC-005) |
| **Steps** | 1. Navigate to `/Admin/Products`<br>2. Click "Delete" on test product<br>3. Confirm deletion in popup<br>4. Submit form |
| **Expected Outcome** | - Success message: "Product deleted successfully"<br>- Product removed from list<br>- Database record deleted<br>- Related inventory transactions deleted (cascade) |
| **Actual Outcome** | [To be filled during testing] |
| **Status** | [Pass/Fail] |
| **Comments** | |

---

### Module 2: Inventory Management (Admin MVC)

#### TC-009: View Inventory Transactions
| Field | Details |
|-------|---------|
| **Test Case ID** | TC-009 |
| **Description** | Admin views all inventory transactions with pagination |
| **Preconditions** | Database has inventory transactions |
| **Test Data** | N/A |
| **Steps** | 1. Navigate to `/Admin/Inventory/Transactions`<br>2. Observe transaction list |
| **Expected Outcome** | - Transactions displayed with: Date/Time, Product, SKU, Change, Reason<br>- Positive changes shown in green badge with "+"<br>- Negative changes shown in red badge<br>- Transactions sorted by timestamp (newest first)<br>- Pagination controls visible if > 20 transactions |
| **Actual Outcome** | [To be filled during testing] |
| **Status** | [Pass/Fail] |
| **Comments** | |

#### TC-010: Adjust Inventory - Increase Stock
| Field | Details |
|-------|---------|
| **Test Case ID** | TC-010 |
| **Description** | Admin increases product stock through manual adjustment |
| **Preconditions** | Product "Laptop" exists with current stock of 50 |
| **Test Data** | - Product: "Laptop"<br>- Quantity Change: +25<br>- Reason: "Purchase" |
| **Steps** | 1. Navigate to `/Admin/Inventory/Adjust`<br>2. Select "Laptop" from product dropdown<br>3. Enter "25" in Quantity Change field<br>4. Select "Purchase" as reason<br>5. Click "Submit Adjustment" |
| **Expected Outcome** | - Success message: "Inventory adjusted successfully"<br>- Redirected to transactions page<br>- New transaction visible with +25 change<br>- Product stock updated to 75<br>- Transaction timestamp is current |
| **Actual Outcome** | [To be filled during testing] |
| **Status** | [Pass/Fail] |
| **Comments** | |

#### TC-011: Adjust Inventory - Decrease Stock
| Field | Details |
|-------|---------|
| **Test Case ID** | TC-011 |
| **Description** | Admin decreases product stock through manual adjustment |
| **Preconditions** | Product "Laptop" exists with current stock of 75 |
| **Test Data** | - Product: "Laptop"<br>- Quantity Change: -10<br>- Reason: "Damaged" |
| **Steps** | 1. Navigate to `/Admin/Inventory/Adjust`<br>2. Select "Laptop"<br>3. Enter "-10" in Quantity Change<br>4. Select "Damaged" as reason<br>5. Click "Submit Adjustment" |
| **Expected Outcome** | - Success message displayed<br>- Product stock updated to 65<br>- Transaction recorded with -10 change<br>- Reason shows "Damaged" |
| **Actual Outcome** | [To be filled during testing] |
| **Status** | [Pass/Fail] |
| **Comments** | |

#### TC-012: Prevent Negative Stock Adjustment
| Field | Details |
|-------|---------|
| **Test Case ID** | TC-012 |
| **Description** | System prevents adjustment that would result in negative stock |
| **Preconditions** | Product has stock of 10 |
| **Test Data** | - Quantity Change: -15 (more than current stock) |
| **Steps** | 1. Navigate to `/Admin/Inventory/Adjust`<br>2. Select product with 10 stock<br>3. Enter "-15" in Quantity Change<br>4. Select reason<br>5. Click "Submit Adjustment" |
| **Expected Outcome** | - Error message: "Adjustment would result in negative stock. Current: 10, Change: -15"<br>- Adjustment NOT applied<br>- Stock remains at 10<br>- No transaction created |
| **Actual Outcome** | [To be filled during testing] |
| **Status** | [Pass/Fail] |
| **Comments** | |

---

### Module 3: Order Management (Admin MVC)

#### TC-013: View All Orders
| Field | Details |
|-------|---------|
| **Test Case ID** | TC-013 |
| **Description** | Admin views list of all orders |
| **Preconditions** | Orders exist in database |
| **Test Data** | N/A |
| **Steps** | 1. Navigate to `/Admin/Orders`<br>2. Observe order list |
| **Expected Outcome** | - Orders displayed with: Order #, Date, Items count, Total<br>- Orders sorted by date (newest first)<br>- "View Details" button available for each order<br>- Pagination controls if > 20 orders |
| **Actual Outcome** | [To be filled during testing] |
| **Status** | [Pass/Fail] |
| **Comments** | |

#### TC-014: View Order Details
| Field | Details |
|-------|---------|
| **Test Case ID** | TC-014 |
| **Description** | Admin views detailed information of a specific order |
| **Preconditions** | Order exists in database |
| **Test Data** | Order ID: 1 |
| **Steps** | 1. Navigate to `/Admin/Orders`<br>2. Click "View Details" on first order<br>3. Observe order details page |
| **Expected Outcome** | - Order header shows: Order #, Date, Total<br>- Order items table displays: Product Name, SKU, Quantity, Unit Price, Subtotal<br>- Footer shows grand total<br>- All amounts formatted as currency<br>- "Back to Orders" button available |
| **Actual Outcome** | [To be filled during testing] |
| **Status** | [Pass/Fail] |
| **Comments** | |

---

### Module 4: Product API (Backend)

#### TC-015: API - Get All Products (Paginated)
| Field | Details |
|-------|---------|
| **Test Case ID** | TC-015 |
| **Description** | API returns paginated list of products |
| **Preconditions** | Database has products |
| **Test Data** | API Endpoint: `GET /api/products?page=1&pageSize=10` |
| **Steps** | 1. Send GET request to `/api/products?page=1&pageSize=10`<br>2. Observe response |
| **Expected Outcome** | - HTTP Status: 200 OK<br>- Response contains: Items[], TotalCount, Page, PageSize, TotalPages<br>- Items array contains max 10 products<br>- Each product has: Id, SKU, Name, Description, Price, QuantityInStock, CategoryId, CategoryName<br>- JSON properly formatted |
| **Actual Outcome** | [To be filled during testing] |
| **Status** | [Pass/Fail] |
| **Comments** | |

#### TC-016: API - Get Products with Search Filter
| Field | Details |
|-------|---------|
| **Test Case ID** | TC-016 |
| **Description** | API returns filtered products based on search term |
| **Preconditions** | Products exist |
| **Test Data** | `GET /api/products?search=phone&page=1&pageSize=20` |
| **Steps** | 1. Send GET request with search parameter<br>2. Observe response |
| **Expected Outcome** | - HTTP Status: 200 OK<br>- Only products with "phone" in name, SKU, or description returned<br>- TotalCount reflects filtered count<br>- All standard fields present |
| **Actual Outcome** | [To be filled during testing] |
| **Status** | [Pass/Fail] |
| **Comments** | |

#### TC-017: API - Get Products by Category
| Field | Details |
|-------|---------|
| **Test Case ID** | TC-017 |
| **Description** | API returns products filtered by category |
| **Preconditions** | Category "Electronics" (ID: 1) has products |
| **Test Data** | `GET /api/products?categoryId=1&page=1&pageSize=20` |
| **Steps** | 1. Send GET request with categoryId parameter<br>2. Observe response |
| **Expected Outcome** | - HTTP Status: 200 OK<br>- Only products with CategoryId = 1 returned<br>- All products have CategoryName = "Electronics"<br>- Correct pagination info |
| **Actual Outcome** | [To be filled during testing] |
| **Status** | [Pass/Fail] |
| **Comments** | |

#### TC-018: API - Sort Products by Price (Descending)
| Field | Details |
|-------|---------|
| **Test Case ID** | TC-018 |
| **Description** | API returns products sorted by price (high to low) |
| **Preconditions** | Products with varying prices exist |
| **Test Data** | `GET /api/products?sort=price_desc&page=1&pageSize=20` |
| **Steps** | 1. Send GET request with sort parameter<br>2. Observe response |
| **Expected Outcome** | - HTTP Status: 200 OK<br>- Products in Items[] sorted by Price descending<br>- First product has highest price<br>- Last product has lowest price in the page |
| **Actual Outcome** | [To be filled during testing] |
| **Status** | [Pass/Fail] |
| **Comments** | |

#### TC-019: API - Get Product by ID
| Field | Details |
|-------|---------|
| **Test Case ID** | TC-019 |
| **Description** | API returns single product by ID |
| **Preconditions** | Product with ID 1 exists |
| **Test Data** | `GET /api/products/1` |
| **Steps** | 1. Send GET request to `/api/products/1`<br>2. Observe response |
| **Expected Outcome** | - HTTP Status: 200 OK<br>- Response is ProductDto object (not array)<br>- Contains: Id, SKU, Name, Description, Price, QuantityInStock, CategoryId, CategoryName<br>- Data matches database record |
| **Actual Outcome** | [To be filled during testing] |
| **Status** | [Pass/Fail] |
| **Comments** | |

#### TC-020: API - Get Non-Existent Product
| Field | Details |
|-------|---------|
| **Test Case ID** | TC-020 |
| **Description** | API returns 404 for non-existent product |
| **Preconditions** | Product ID 99999 does not exist |
| **Test Data** | `GET /api/products/99999` |
| **Steps** | 1. Send GET request to `/api/products/99999`<br>2. Observe response |
| **Expected Outcome** | - HTTP Status: 404 Not Found<br>- Response body contains error message: "Product with ID 99999 not found."<br>- Message property present in response |
| **Actual Outcome** | [To be filled during testing] |
| **Status** | [Pass/Fail] |
| **Comments** | |

#### TC-021: API - Create New Product
| Field | Details |
|-------|---------|
| **Test Case ID** | TC-021 |
| **Description** | API creates new product successfully |
| **Preconditions** | Categories exist |
| **Test Data** | ```json<br>{<br>  "SKU": "API-TEST-001",<br>  "Name": "API Test Product",<br>  "Description": "Created via API",<br>  "Price": 149.99,<br>  "QuantityInStock": 30,<br>  "CategoryId": 1<br>}<br>``` |
| **Steps** | 1. Send POST request to `/api/products` with JSON body<br>2. Observe response<br>3. Verify product in database |
| **Expected Outcome** | - HTTP Status: 201 Created<br>- Location header contains URL to new product<br>- Response body contains created ProductDto with generated ID<br>- Product exists in database<br>- Inventory transaction created |
| **Actual Outcome** | [To be filled during testing] |
| **Status** | [Pass/Fail] |
| **Comments** | |

#### TC-022: API - Create Product with Invalid Data
| Field | Details |
|-------|---------|
| **Test Case ID** | TC-022 |
| **Description** | API rejects product with invalid/missing data |
| **Preconditions** | N/A |
| **Test Data** | ```json<br>{<br>  "SKU": "",<br>  "Name": "",<br>  "Price": -10,<br>  "CategoryId": 9999<br>}<br>``` |
| **Steps** | 1. Send POST request with invalid data<br>2. Observe response |
| **Expected Outcome** | - HTTP Status: 400 Bad Request<br>- Response contains validation errors<br>- Product NOT created in database |
| **Actual Outcome** | [To be filled during testing] |
| **Status** | [Pass/Fail] |
| **Comments** | |

#### TC-023: API - Update Product
| Field | Details |
|-------|---------|
| **Test Case ID** | TC-023 |
| **Description** | API updates existing product |
| **Preconditions** | Product with ID 1 exists |
| **Test Data** | ```json<br>{<br>  "Name": "Updated Product Name",<br>  "Description": "Updated description",<br>  "Price": 199.99,<br>  "CategoryId": 1<br>}<br>``` |
| **Steps** | 1. Send PUT request to `/api/products/1` with JSON body<br>2. Observe response<br>3. Verify update in database |
| **Expected Outcome** | - HTTP Status: 200 OK<br>- Response contains updated ProductDto<br>- Database record reflects changes<br>- SKU and stock unchanged |
| **Actual Outcome** | [To be filled during testing] |
| **Status** | [Pass/Fail] |
| **Comments** | |

#### TC-024: API - Delete Product
| Field | Details |
|-------|---------|
| **Test Case ID** | TC-024 |
| **Description** | API deletes product successfully |
| **Preconditions** | Test product exists (from TC-021) |
| **Test Data** | `DELETE /api/products/{id}` |
| **Steps** | 1. Send DELETE request to product endpoint<br>2. Observe response<br>3. Verify deletion in database |
| **Expected Outcome** | - HTTP Status: 204 No Content<br>- No response body<br>- Product removed from database<br>- Related transactions deleted |
| **Actual Outcome** | [To be filled during testing] |
| **Status** | [Pass/Fail] |
| **Comments** | |

---

### Module 5: Order API (Backend)

#### TC-025: API - Create Order (Reduces Inventory)
| Field | Details |
|-------|---------|
| **Test Case ID** | TC-025 |
| **Description** | API creates order and automatically reduces product inventory |
| **Preconditions** | - Product ID 1 exists with stock ≥ 2<br>- Product ID 2 exists with stock ≥ 1 |
| **Test Data** | ```json<br>{<br>  "Items": [<br>    { "ProductId": 1, "Quantity": 2 },<br>    { "ProductId": 2, "Quantity": 1 }<br>  ]<br>}<br>``` |
| **Steps** | 1. Note current stock of products 1 & 2<br>2. Send POST to `/api/orders`<br>3. Observe response<br>4. Check product stock<br>5. Check inventory transactions |
| **Expected Outcome** | - HTTP Status: 201 Created<br>- Response contains OrderDto with items and calculated total<br>- Product 1 stock decreased by 2<br>- Product 2 stock decreased by 1<br>- Inventory transactions created with reason "Sale - Order #[id]"<br>- Order total = sum of (quantity × current price) |
| **Actual Outcome** | [To be filled during testing] |
| **Status** | [Pass/Fail] |
| **Comments** | |

#### TC-026: API - Create Order with Insufficient Stock
| Field | Details |
|-------|---------|
| **Test Case ID** | TC-026 |
| **Description** | API rejects order when product stock is insufficient |
| **Preconditions** | Product exists with stock = 5 |
| **Test Data** | ```json<br>{<br>  "Items": [<br>    { "ProductId": 1, "Quantity": 10 }<br>  ]<br>}<br>``` |
| **Steps** | 1. Send POST to `/api/orders` requesting more than available stock<br>2. Observe response |
| **Expected Outcome** | - HTTP Status: 400 Bad Request<br>- Error message: "Insufficient stock for product '[name]'. Available: 5, Requested: 10"<br>- Order NOT created<br>- Stock unchanged<br>- No transactions created |
| **Actual Outcome** | [To be filled during testing] |
| **Status** | [Pass/Fail] |
| **Comments** | |

#### TC-027: API - Get All Orders (Paginated)
| Field | Details |
|-------|---------|
| **Test Case ID** | TC-027 |
| **Description** | API returns paginated list of orders |
| **Preconditions** | Orders exist |
| **Test Data** | `GET /api/orders?page=1&pageSize=20` |
| **Steps** | 1. Send GET request to `/api/orders`<br>2. Observe response |
| **Expected Outcome** | - HTTP Status: 200 OK<br>- Response structure: { Items[], TotalCount, Page, PageSize, TotalPages }<br>- Each order includes: Id, CreatedAt, Total, Items[]<br>- Items contain: ProductName, ProductSKU, Quantity, UnitPrice<br>- Orders sorted by CreatedAt descending |
| **Actual Outcome** | [To be filled during testing] |
| **Status** | [Pass/Fail] |
| **Comments** | |

#### TC-028: API - Get Order by ID
| Field | Details |
|-------|---------|
| **Test Case ID** | TC-028 |
| **Description** | API returns specific order with all details |
| **Preconditions** | Order with ID 1 exists |
| **Test Data** | `GET /api/orders/1` |
| **Steps** | 1. Send GET request to `/api/orders/1`<br>2. Observe response |
| **Expected Outcome** | - HTTP Status: 200 OK<br>- Response is OrderDto object<br>- Contains order header info and all order items<br>- Each item shows product details and pricing<br>- Total matches sum of item subtotals |
| **Actual Outcome** | [To be filled during testing] |
| **Status** | [Pass/Fail] |
| **Comments** | |

---

### Module 6: Category API (Backend)

#### TC-029: API - Get All Categories
| Field | Details |
|-------|---------|
| **Test Case ID** | TC-029 |
| **Description** | API returns list of all categories |
| **Preconditions** | Categories exist (seeded) |
| **Test Data** | `GET /api/categories` |
| **Steps** | 1. Send GET request to `/api/categories`<br>2. Observe response |
| **Expected Outcome** | - HTTP Status: 200 OK<br>- Response is array of CategoryDto<br>- Each category has: Id, Name, ProductCount<br>- Categories sorted alphabetically<br>- ProductCount reflects actual product count |
| **Actual Outcome** | [To be filled during testing] |
| **Status** | [Pass/Fail] |
| **Comments** | |

#### TC-030: API - Create New Category
| Field | Details |
|-------|---------|
| **Test Case ID** | TC-030 |
| **Description** | API creates new category |
| **Preconditions** | N/A |
| **Test Data** | ```json<br>{ "Name": "Test Category" }<br>``` |
| **Steps** | 1. Send POST to `/api/categories` with JSON<br>2. Observe response<br>3. Verify in database |
| **Expected Outcome** | - HTTP Status: 201 Created<br>- Location header contains new category URL<br>- Response contains CategoryDto with generated ID<br>- ProductCount = 0 for new category<br>- Category exists in database |
| **Actual Outcome** | [To be filled during testing] |
| **Status** | [Pass/Fail] |
| **Comments** | |

---

### Module 7: Inventory API (Backend)

#### TC-031: API - Get Inventory Transactions
| Field | Details |
|-------|---------|
| **Test Case ID** | TC-031 |
| **Description** | API returns paginated inventory transactions |
| **Preconditions** | Transactions exist |
| **Test Data** | `GET /api/inventory/transactions?page=1&pageSize=20` |
| **Steps** | 1. Send GET request<br>2. Observe response |
| **Expected Outcome** | - HTTP Status: 200 OK<br>- Paginated response structure<br>- Each transaction has: Id, ProductId, ProductName, ProductSKU, QuantityChange, Timestamp, Reason<br>- Sorted by Timestamp descending |
| **Actual Outcome** | [To be filled during testing] |
| **Status** | [Pass/Fail] |
| **Comments** | |

#### TC-032: API - Filter Transactions by Product
| Field | Details |
|-------|---------|
| **Test Case ID** | TC-032 |
| **Description** | API returns transactions for specific product |
| **Preconditions** | Product ID 1 has transactions |
| **Test Data** | `GET /api/inventory/transactions?productId=1` |
| **Steps** | 1. Send GET with productId parameter<br>2. Observe response |
| **Expected Outcome** | - HTTP Status: 200 OK<br>- Only transactions for ProductId = 1 returned<br>- All transactions have same ProductId, ProductName, ProductSKU<br>- Correct pagination |
| **Actual Outcome** | [To be filled during testing] |
| **Status** | [Pass/Fail] |
| **Comments** | |

#### TC-033: API - Adjust Inventory
| Field | Details |
|-------|---------|
| **Test Case ID** | TC-033 |
| **Description** | API performs manual inventory adjustment |
| **Preconditions** | Product ID 1 exists with stock ≥ 0 |
| **Test Data** | ```json<br>{<br>  "ProductId": 1,<br>  "QuantityChange": 15,<br>  "Reason": "Purchase"<br>}<br>``` |
| **Steps** | 1. Note current stock of product<br>2. Send POST to `/api/inventory/adjust`<br>3. Observe response<br>4. Check product stock |
| **Expected Outcome** | - HTTP Status: 200 OK<br>- Response contains InventoryTransactionDto<br>- Product stock increased by 15<br>- New transaction visible in transaction list<br>- Timestamp is current<br>- Reason shows "Purchase" |
| **Actual Outcome** | [To be filled during testing] |
| **Status** | [Pass/Fail] |
| **Comments** | |

---

## Step 4: Prepare Test Environment

### Prerequisites
- Visual Studio 2022 or VS Code
- .NET 9.0 SDK
- SQL Server LocalDB or SQL Server
- Postman or similar API testing tool (optional)
- Modern web browser (Chrome, Edge, Firefox)

### Setup Steps
1. Clone/Open project in IDE
2. Restore NuGet packages: `dotnet restore`
3. Update database connection string in `appsettings.json` if needed
4. Apply migrations: `dotnet ef database update`
5. Run application: `dotnet run` or F5 in Visual Studio
6. Navigate to `https://localhost:[port]`

---

## Step 5: Test Data Sets

### Seeded Data (Automatically Created)

**Categories:**
1. Electronics
2. Clothing
3. Books
4. Home & Garden
5. Sports & Outdoors
6. Toys & Games

**Sample Products (from seed):**
- ELEC-001: Laptop ($999.99, Stock: 50)
- ELEC-002: Smartphone ($699.99, Stock: 100)
- CLOT-001: T-Shirt ($19.99, Stock: 200)
- BOOK-001: Programming Guide ($39.99, Stock: 120)

### Additional Test Data (To Be Created During Testing)

**Test Product for Create/Delete:**
- SKU: TEST-001
- Name: Test Product
- Category: Electronics
- Price: $99.99
- Stock: 50

**Test Category:**
- Name: Test Category

**Test Order:**
- Items: 2x Laptop, 1x Smartphone
- Expected Total: $2399.97

---

## Step 6: Test Execution Tracking

### Execution Summary

| Module | Total Tests | Passed | Failed | Pending | Pass Rate |
|--------|-------------|--------|--------|---------|-----------|
| Product Management (MVC) | 8 | - | - | 8 | -% |
| Inventory Management (MVC) | 4 | - | - | 4 | -% |
| Order Management (MVC) | 2 | - | - | 2 | -% |
| Product API | 10 | - | - | 10 | -% |
| Order API | 4 | - | - | 4 | -% |
| Category API | 2 | - | - | 2 | -% |
| Inventory API | 3 | - | - | 3 | -% |
| **TOTAL** | **33** | **-** | **-** | **33** | **-%** |

### Test Execution Log

| Date | Tester | Test IDs | Duration | Notes |
|------|--------|----------|----------|-------|
| [Date] | [Name] | TC-001 to TC-010 | [Time] | [Notes] |
| | | | | |

---

## Pass/Fail Criteria

### Pass Criteria
- All test cases (TC-001 to TC-033) must pass
- No critical or high-priority defects
- All expected outcomes match actual outcomes
- Data integrity maintained across all operations
- UI displays correctly in all target browsers
- API responses conform to expected structure
- Response times are acceptable (< 3 seconds for most operations)

### Fail Criteria
- Any test case fails
- Critical defects found
- Data corruption or loss occurs
- Application crashes or throws unhandled exceptions
- Major UI rendering issues
- API returns incorrect data or status codes

---

## Risk Assessment

| Risk | Impact | Probability | Mitigation |
|------|--------|-------------|------------|
| Database not seeded | High | Low | Run migrations and verify seed data before testing |
| Invalid connection string | High | Medium | Verify connection string in appsettings.json |
| Missing dependencies | High | Low | Run `dotnet restore` before testing |
| Browser compatibility | Medium | Low | Test on multiple browsers |
| Network issues (for API tests) | Low | Low | Use localhost for testing |

---

## Notes and Observations

[Space for testers to add general observations, patterns, or recommendations]

---

## Sign-off

| Role | Name | Signature | Date |
|------|------|-----------|------|
| Test Lead | | | |
| Backend Tester | | | |
| Frontend Tester | | | |
| Integration Tester | | | |
| Project Lead | | | |

---

**Document Version:** 1.0  
**Last Updated:** October 17, 2025  
**Next Review Date:** [As needed after test execution]

