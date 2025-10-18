# All Test Cases - Online Inventory Management System

## Project Information
- **Project Name:** Online Inventory Management (MVC)
- **Test Type:** Happy Path Testing (BE & FE Integration)
- **Date:** October 18, 2025
- **Technology Stack:** ASP.NET Core MVC, Entity Framework Core, SQLite

---

## Test Case Format

| Test Case ID | Description | Inputs | Steps | Expected Outcome |
|--------------|-------------|--------|-------|------------------|
| TC-001 | User login | Valid credentials | 1. Navigate to login page<br>2. Enter username and password<br>3. Click 'Login' | User successfully logged in<br>Dashboard displays |
| TC-002 | User logout | N/A | 1. Click user dropdown<br>2. Click 'Logout' | User logged out<br>Redirected to home page |
| TC-003 | View products | N/A | 1. Navigate to /Admin/Products<br>2. Observe product list | Product list displays with 5 products<br>Pagination controls visible |
| TC-004 | Search products | Search term | 1. Enter search term in search box<br>2. Click search or press Enter | Filtered products display<br>Search results match criteria |
| TC-005 | Filter by category | Category selection | 1. Select category from dropdown<br>2. Observe filtered results | Only products from selected category display |
| TC-006 | Sort products | Sort option | 1. Select sort option (Name, Price, Stock)<br>2. Observe sorted list | Products sorted according to selected criteria |
| TC-007 | Create product | Product data | 1. Click 'Add New Product'<br>2. Fill form with valid data<br>3. Click 'Create' | Product created successfully<br>Redirected to product list |
| TC-008 | Edit product | Updated data | 1. Click 'Edit' button for a product<br>2. Modify product details<br>3. Click 'Save' | Product updated successfully<br>Changes reflected in list |
| TC-009 | Delete product (Admin) | N/A | 1. Click 'Delete' button for a product<br>2. Confirm deletion | Product deleted successfully<br>Removed from product list |
| TC-010 | Delete product (Staff) | N/A | 1. Login as Staff<br>2. Navigate to products<br>3. Observe delete button | Delete button is disabled<br>Staff cannot delete products |
| TC-011 | View inventory transactions | N/A | 1. Navigate to /Admin/Inventory/Transactions<br>2. Observe transaction list | Transaction history displays<br>All 5 products show initial stock |
| TC-012 | Adjust inventory | Quantity change | 1. Click 'Adjust' for a product<br>2. Enter quantity change<br>3. Enter reason<br>4. Click 'Save' | Inventory updated successfully<br>Transaction recorded |
| TC-013 | View orders | N/A | 1. Navigate to /Admin/Orders<br>2. Observe order list | Order list displays<br>Pagination controls visible |
| TC-014 | Create order via API | Order data | 1. Use POST /api/orders<br>2. Send order with items<br>3. Verify response | Order created successfully<br>Inventory automatically reduced |
| TC-015 | View order details | Order ID | 1. Click on an order<br>2. Observe order details | Order details display<br>Items and totals shown correctly |
| TC-016 | View categories | N/A | 1. Navigate to /api/categories<br>2. Observe category list | All 6 categories display<br>JSON response format correct |
| TC-017 | Create category via API | Category data | 1. Use POST /api/categories<br>2. Send category name<br>3. Verify response | Category created successfully<br>Available in dropdowns |
| TC-018 | View product API | N/A | 1. Use GET /api/products<br>2. Observe response | All 5 products return<br>Pagination metadata included |
| TC-019 | Search products via API | Search term | 1. Use GET /api/products?search=term<br>2. Observe filtered results | Filtered products return<br>Search functionality works |
| TC-020 | Filter products via API | Category ID | 1. Use GET /api/products?categoryId=1<br>2. Observe filtered results | Only products from category return<br>Filter functionality works |
| TC-021 | Sort products via API | Sort parameter | 1. Use GET /api/products?sort=price_desc<br>2. Observe sorted results | Products sorted correctly<br>Sort functionality works |
| TC-022 | Get single product via API | Product ID | 1. Use GET /api/products/1<br>2. Observe response | Single product details return<br>All fields populated correctly |
| TC-023 | Create product via API | Product data | 1. Use POST /api/products<br>2. Send product data<br>3. Verify response | Product created successfully<br>Returns created product details |
| TC-024 | Update product via API | Product data | 1. Use PUT /api/products/1<br>2. Send updated data<br>3. Verify response | Product updated successfully<br>Returns updated product details |
| TC-025 | Delete product via API | Product ID | 1. Use DELETE /api/products/1<br>2. Verify response | Product deleted successfully<br>Returns success status |
| TC-026 | Get inventory transactions via API | N/A | 1. Use GET /api/inventory/transactions<br>2. Observe response | All transactions return<br>Product details included |
| TC-027 | Filter transactions via API | Product ID | 1. Use GET /api/inventory/transactions?productId=1<br>2. Observe filtered results | Only transactions for product return<br>Filter functionality works |
| TC-028 | Adjust inventory via API | Adjustment data | 1. Use POST /api/inventory/adjust<br>2. Send adjustment data<br>3. Verify response | Inventory adjusted successfully<br>Transaction recorded |
| TC-029 | Access Swagger UI | N/A | 1. Navigate to /swagger<br>2. Explore API documentation | Swagger UI loads correctly<br>All endpoints documented |
| TC-030 | Test API endpoint from Swagger | N/A | 1. Click on an endpoint<br>2. Click 'Try it out'<br>3. Execute request | API call executes successfully<br>Response displays correctly |

---

## Test Execution Results

| Test Case ID | Status | Actual Outcome | Notes |
|--------------|--------|----------------|-------|
| TC-001 | [ ] Pass / [ ] Fail | [To be filled during testing] | [Any observations] |
| TC-002 | [ ] Pass / [ ] Fail | [To be filled during testing] | [Any observations] |
| TC-003 | [ ] Pass / [ ] Fail | [To be filled during testing] | [Any observations] |
| TC-004 | [ ] Pass / [ ] Fail | [To be filled during testing] | [Any observations] |
| TC-005 | [ ] Pass / [ ] Fail | [To be filled during testing] | [Any observations] |
| TC-006 | [ ] Pass / [ ] Fail | [To be filled during testing] | [Any observations] |
| TC-007 | [ ] Pass / [ ] Fail | [To be filled during testing] | [Any observations] |
| TC-008 | [ ] Pass / [ ] Fail | [To be filled during testing] | [Any observations] |
| TC-009 | [ ] Pass / [ ] Fail | [To be filled during testing] | [Any observations] |
| TC-010 | [ ] Pass / [ ] Fail | [To be filled during testing] | [Any observations] |
| TC-011 | [ ] Pass / [ ] Fail | [To be filled during testing] | [Any observations] |
| TC-012 | [ ] Pass / [ ] Fail | [To be filled during testing] | [Any observations] |
| TC-013 | [ ] Pass / [ ] Fail | [To be filled during testing] | [Any observations] |
| TC-014 | [ ] Pass / [ ] Fail | [To be filled during testing] | [Any observations] |
| TC-015 | [ ] Pass / [ ] Fail | [To be filled during testing] | [Any observations] |
| TC-016 | [ ] Pass / [ ] Fail | [To be filled during testing] | [Any observations] |
| TC-017 | [ ] Pass / [ ] Fail | [To be filled during testing] | [Any observations] |
| TC-018 | [ ] Pass / [ ] Fail | [To be filled during testing] | [Any observations] |
| TC-019 | [ ] Pass / [ ] Fail | [To be filled during testing] | [Any observations] |
| TC-020 | [ ] Pass / [ ] Fail | [To be filled during testing] | [Any observations] |
| TC-021 | [ ] Pass / [ ] Fail | [To be filled during testing] | [Any observations] |
| TC-022 | [ ] Pass / [ ] Fail | [To be filled during testing] | [Any observations] |
| TC-023 | [ ] Pass / [ ] Fail | [To be filled during testing] | [Any observations] |
| TC-024 | [ ] Pass / [ ] Fail | [To be filled during testing] | [Any observations] |
| TC-025 | [ ] Pass / [ ] Fail | [To be filled during testing] | [Any observations] |
| TC-026 | [ ] Pass / [ ] Fail | [To be filled during testing] | [Any observations] |
| TC-027 | [ ] Pass / [ ] Fail | [To be filled during testing] | [Any observations] |
| TC-028 | [ ] Pass / [ ] Fail | [To be filled during testing] | [Any observations] |
| TC-029 | [ ] Pass / [ ] Fail | [To be filled during testing] | [Any observations] |
| TC-030 | [ ] Pass / [ ] Fail | [To be filled during testing] | [Any observations] |

---

## Test Data

### Login Credentials
- **Admin:** admin@inventory.com / Admin@123
- **Staff:** staff@inventory.com / Staff@123

### Sample Product Data
- **SKU:** TEST-001
- **Name:** Test Product
- **Description:** A test product for validation
- **Price:** 99.99
- **Quantity:** 50
- **Category:** Electronics

### Sample Order Data
```json
{
  "Items": [
    { "ProductId": 1, "Quantity": 2 },
    { "ProductId": 2, "Quantity": 1 }
  ]
}
```

### Sample Inventory Adjustment Data
```json
{
  "ProductId": 1,
  "QuantityChange": 10,
  "Reason": "Stock adjustment for testing"
}
```

---

## Test Environment Setup

1. **Start Application:**
   ```bash
   dotnet run
   ```

2. **Access URLs:**
   - Home: https://localhost:5001
   - Login: https://localhost:5001/Account/Login
   - Products: https://localhost:5001/Admin/Products
   - Inventory: https://localhost:5001/Admin/Inventory/Transactions
   - Orders: https://localhost:5001/Admin/Orders
   - Swagger: https://localhost:5001/swagger

3. **Verify Setup:**
   - Database contains 5 products
   - 6 categories available
   - 2 user accounts created
   - Application runs without errors

---

## Test Categories

### Authentication Tests (TC-001, TC-002)
- User login functionality
- User logout functionality
- Session management

### Product Management Tests (TC-003 to TC-010)
- View products list
- Search and filter products
- Sort products
- Create new products
- Edit existing products
- Delete products (role-based)
- Role-based access control

### Inventory Management Tests (TC-011, TC-012)
- View transaction history
- Adjust inventory levels
- Transaction recording

### Order Management Tests (TC-013 to TC-015)
- View orders list
- Create orders via API
- View order details

### API Endpoint Tests (TC-016 to TC-028)
- Category API endpoints
- Product API endpoints
- Order API endpoints
- Inventory API endpoints
- Search and filter functionality
- CRUD operations via API

### Integration Tests (TC-029, TC-030)
- Swagger UI functionality
- API documentation
- End-to-end API testing

---

## Test Execution Checklist

- [ ] Environment setup complete
- [ ] Database seeded with test data
- [ ] Application running successfully
- [ ] All 30 test cases executed
- [ ] Results documented
- [ ] Any defects logged
- [ ] Test report generated

---

**Last Updated:** October 18, 2025  
**Status:** Ready for Comprehensive Testing