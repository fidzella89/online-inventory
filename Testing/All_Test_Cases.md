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
| TC-001 | User login | Valid credentials | 1. Navigate to login page | User successfully logged in |
| | | | 2. Enter username and password | Dashboard displays |
| | | | 3. Click 'Login' | |
| TC-002 | User logout | N/A | 1. Click user dropdown | User logged out |
| | | | 2. Click 'Logout' | Redirected to home page |
| TC-003 | View products | N/A | 1. Navigate to /Products | Product list displays with products |
| | | | 2. Observe product list | Pagination controls visible |
| TC-004 | Search products | Search term | 1. Enter search term in search box | Filtered products display |
| | | | 2. Click search or press Enter | Search results match criteria |
| TC-005 | Filter by category | Category selection | 1. Select category from dropdown | Only products from selected category display |
| | | | 2. Observe filtered results | |
| TC-006 | Sort products | Sort option | 1. Select sort option (Name, Price, Stock) | Products sorted according to selected criteria |
| | | | 2. Observe sorted list | |
| TC-007 | Create product | Product data | 1. Click 'Add New Product' | Product created successfully |
| | | | 2. Fill form with valid data | Redirected to product list |
| | | | 3. Click 'Create' | |
| TC-008 | Edit product | Updated data | 1. Click 'Edit' button for a product | Product updated successfully |
| | | | 2. Modify product details | Changes reflected in list |
| | | | 3. Click 'Save' | |
| TC-009 | Delete product (Admin) | N/A | 1. Click 'Delete' button for a product | Product deleted successfully |
| | | | 2. Confirm deletion | Removed from product list |
| TC-010 | Delete product (Staff) | N/A | 1. Login as Staff | Delete button is disabled |
| | | | 2. Navigate to products | Staff cannot delete products |
| | | | 3. Observe delete button | |
| TC-011 | View inventory | N/A | 1. Navigate to /Inventory | Inventory list displays |
| | | | 2. Observe inventory list | All products show current stock levels |
| TC-012 | Adjust inventory | Quantity change | 1. Click 'Adjust' for a product | Inventory updated successfully |
| | | | 2. Enter quantity change | Stock level updated |
| | | | 3. Enter reason | |
| | | | 4. Click 'Save' | |
| TC-013 | View categories (Admin) | N/A | 1. Login as Admin | Category list displays |
| | | | 2. Navigate to /Admin/Categories | All categories with product counts shown |
| | | | 3. Observe category list | |
| TC-014 | Create category (Admin) | Category data | 1. Click 'Add New Category' | Category created successfully |
| | | | 2. Enter category name | Redirected to category list |
| | | | 3. Click 'Create' | |
| TC-015 | Edit category (Admin) | Updated data | 1. Click 'Edit' button for a category | Category updated successfully |
| | | | 2. Modify category name | Changes reflected in list |
| | | | 3. Click 'Update' | |
| TC-016 | Delete category (Admin) | N/A | 1. Click 'Delete' button for empty category | Category deleted successfully |
| | | | 2. Confirm deletion | Removed from category list |
| TC-017 | Delete category with products (Admin) | N/A | 1. Try to delete category with products | Delete button disabled |
| | | | 2. Observe behavior | Cannot delete category with products |
| TC-018 | Access categories (Staff) | N/A | 1. Login as Staff | Access denied |
| | | | 2. Try to access /Admin/Categories | Redirected to unauthorized page |
| TC-019 | View product API | N/A | 1. Use GET /api/products | All products return |
| | | | 2. Observe response | Pagination metadata included |
| TC-020 | Search products via API | Search term | 1. Use GET /api/products?search=term | Filtered products return |
| | | | 2. Observe filtered results | Search functionality works |
| TC-021 | Filter products via API | Category ID | 1. Use GET /api/products?categoryId=1 | Only products from category return |
| | | | 2. Observe filtered results | Filter functionality works |
| TC-022 | Sort products via API | Sort parameter | 1. Use GET /api/products?sort=price_desc | Products sorted correctly |
| | | | 2. Observe sorted results | Sort functionality works |
| TC-023 | Get single product via API | Product ID | 1. Use GET /api/products/1 | Single product details return |
| | | | 2. Observe response | All fields populated correctly |
| TC-024 | Create product via API | Product data | 1. Use POST /api/products | Product created successfully |
| | | | 2. Send product data | Returns created product details |
| | | | 3. Verify response | |
| TC-025 | Update product via API | Product data | 1. Use PUT /api/products/1 | Product updated successfully |
| | | | 2. Send updated data | Returns updated product details |
| | | | 3. Verify response | |
| TC-026 | Delete product via API (Admin) | Product ID | 1. Use DELETE /api/products/1 | Product deleted successfully |
| | | | 2. Verify response | Returns success status |
| TC-027 | Get inventory via API | N/A | 1. Use GET /api/inventory/products | All products with stock levels return |
| | | | 2. Observe response | Product details included |
| TC-028 | Adjust inventory via API | Adjustment data | 1. Use POST /api/inventory/products/1/adjust | Inventory adjusted successfully |
| | | | 2. Send adjustment data | Stock level updated |
| | | | 3. Verify response | |
| TC-029 | Get low stock via API | N/A | 1. Use GET /api/inventory/low-stock | Low stock products return |
| | | | 2. Observe response | Threshold configurable |
| TC-030 | Access categories API (Admin) | N/A | 1. Login as Admin | All categories return |
| | | | 2. Use GET /api/categories | JSON response format correct |
| | | | 3. Observe response | |
| TC-031 | Access categories API (Staff) | N/A | 1. Login as Staff | 403 Forbidden |
| | | | 2. Use GET /api/categories | Message: "Only administrators can access this resource" |
| | | | 3. Observe response | |
| TC-032 | Create category via API (Admin) | Category data | 1. Use POST /api/categories | Category created successfully |
| | | | 2. Send category name | Available in dropdowns |
| | | | 3. Verify response | |
| TC-033 | Create category via API (Staff) | Category data | 1. Login as Staff | 403 Forbidden |
| | | | 2. Use POST /api/categories | Message: "Only administrators can access this resource" |
| | | | 3. Observe response | |
| TC-034 | Access Swagger UI | N/A | 1. Navigate to /swagger | Swagger UI loads correctly |
| | | | 2. Explore API documentation | All endpoints documented |
| TC-035 | Test API endpoint from Swagger | N/A | 1. Click on an endpoint | API call executes successfully |
| | | | 2. Click 'Try it out' | Response displays correctly |
| | | | 3. Execute request | |
| TC-036 | Verify MVC controllers hidden from Swagger | N/A | 1. Navigate to /swagger | Only API controllers visible |
| | | | 2. Check for MVC controller endpoints | No duplicate endpoints |

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
| TC-031 | [ ] Pass / [ ] Fail | [To be filled during testing] | [Any observations] |
| TC-032 | [ ] Pass / [ ] Fail | [To be filled during testing] | [Any observations] |
| TC-033 | [ ] Pass / [ ] Fail | [To be filled during testing] | [Any observations] |
| TC-034 | [ ] Pass / [ ] Fail | [To be filled during testing] | [Any observations] |
| TC-035 | [ ] Pass / [ ] Fail | [To be filled during testing] | [Any observations] |
| TC-036 | [ ] Pass / [ ] Fail | [To be filled during testing] | [Any observations] |

---

## Test Data

### Login Credentials
- **Admin:** admin@inventory.com / admin123
- **Staff:** staff@inventory.com / staff123

### Sample Product Data
- **SKU:** Auto-generated based on category
- **Name:** Test Product
- **Description:** A test product for validation
- **Price:** 99.99
- **Quantity:** 50
- **Category:** Electronics

### Sample Category Data
- **Name:** Test Category
- **Description:** A test category for validation

### Sample Inventory Adjustment Data
```json
{
  "Adjustment": 10,
  "Reason": "Stock adjustment for testing"
}
```

---

## Test Environment Setup

1. **Start Application:**
   ```bash
   dotnet run --urls "http://localhost:5000"
   ```

2. **Access URLs:**
   - Home: http://localhost:5000
   - Login: http://localhost:5000/Account/Login
   - Products: http://localhost:5000/Products
   - Inventory: http://localhost:5000/Inventory
   - Categories (Admin): http://localhost:5000/Admin/Categories
   - Swagger: http://localhost:5000/swagger

3. **Verify Setup:**
   - Database contains products
   - Categories available
   - 2 user accounts created (admin/staff)
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
- View inventory levels
- Adjust inventory levels
- Stock management

### Category Management Tests (TC-013 to TC-018)
- View categories (Admin only)
- Create categories (Admin only)
- Edit categories (Admin only)
- Delete categories (Admin only)
- Role-based access control
- Delete protection for categories with products

### API Endpoint Tests (TC-019 to TC-033)
- Product API endpoints
- Inventory API endpoints
- Category API endpoints (Admin only)
- Search and filter functionality
- CRUD operations via API
- Authorization testing

### Integration Tests (TC-034 to TC-036)
- Swagger UI functionality
- API documentation
- End-to-end API testing
- MVC controller visibility

---

## Test Execution Checklist

- [ ] Environment setup complete
- [ ] Database seeded with test data
- [ ] Application running successfully
- [ ] All 36 test cases executed
- [ ] Results documented
- [ ] Any defects logged
- [ ] Test report generated

---

**Last Updated:** October 18, 2025  
**Status:** Ready for Comprehensive Testing