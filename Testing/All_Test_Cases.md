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
| TC-003 | View products | N/A | 1. Navigate to /Products<br>2. Observe product list | Product list displays with products<br>Pagination controls visible |
| TC-004 | Search products | Search term | 1. Enter search term in search box<br>2. Click search or press Enter | Filtered products display<br>Search results match criteria |
| TC-005 | Filter by category | Category selection | 1. Select category from dropdown<br>2. Observe filtered results | Only products from selected category display |
| TC-006 | Sort products | Sort option | 1. Select sort option (Name, Price, Stock)<br>2. Observe sorted list | Products sorted according to selected criteria |
| TC-007 | Create product | Product data | 1. Click 'Add New Product'<br>2. Fill form with valid data<br>3. Click 'Create' | Product created successfully<br>Redirected to product list |
| TC-008 | Edit product | Updated data | 1. Click 'Edit' button for a product<br>2. Modify product details<br>3. Click 'Save' | Product updated successfully<br>Changes reflected in list |
| TC-009 | Delete product (Admin) | N/A | 1. Click 'Delete' button for a product<br>2. Confirm deletion | Product deleted successfully<br>Removed from product list |
| TC-010 | Delete product (Staff) | N/A | 1. Login as Staff<br>2. Navigate to products<br>3. Observe delete button | Delete button is disabled<br>Staff cannot delete products |
| TC-011 | View inventory | N/A | 1. Navigate to /Inventory<br>2. Observe inventory list | Inventory list displays<br>All products show current stock levels |
| TC-012 | Adjust inventory | Quantity change | 1. Click 'Adjust' for a product<br>2. Enter quantity change<br>3. Enter reason<br>4. Click 'Save' | Inventory updated successfully<br>Stock level updated |
| TC-013 | View categories (Admin) | N/A | 1. Login as Admin<br>2. Navigate to /Admin/Categories<br>3. Observe category list | Category list displays<br>All categories with product counts shown |
| TC-014 | Create category (Admin) | Category data | 1. Click 'Add New Category'<br>2. Enter category name<br>3. Click 'Create' | Category created successfully<br>Redirected to category list |
| TC-015 | Edit category (Admin) | Updated data | 1. Click 'Edit' button for a category<br>2. Modify category name<br>3. Click 'Update' | Category updated successfully<br>Changes reflected in list |
| TC-016 | Delete category (Admin) | N/A | 1. Click 'Delete' button for empty category<br>2. Confirm deletion | Category deleted successfully<br>Removed from category list |
| TC-017 | Delete category with products (Admin) | N/A | 1. Try to delete category with products<br>2. Observe behavior | Delete button disabled<br>Cannot delete category with products |
| TC-018 | Access categories (Staff) | N/A | 1. Login as Staff<br>2. Try to access /Admin/Categories | Access denied<br>Redirected to unauthorized page |
| TC-019 | View product API | N/A | 1. Use GET /api/products<br>2. Observe response | All products return<br>Pagination metadata included |
| TC-020 | Search products via API | Search term | 1. Use GET /api/products?search=term<br>2. Observe filtered results | Filtered products return<br>Search functionality works |
| TC-021 | Filter products via API | Category ID | 1. Use GET /api/products?categoryId=1<br>2. Observe filtered results | Only products from category return<br>Filter functionality works |
| TC-022 | Sort products via API | Sort parameter | 1. Use GET /api/products?sort=price_desc<br>2. Observe sorted results | Products sorted correctly<br>Sort functionality works |
| TC-023 | Get single product via API | Product ID | 1. Use GET /api/products/1<br>2. Observe response | Single product details return<br>All fields populated correctly |
| TC-024 | Create product via API | Product data | 1. Use POST /api/products<br>2. Send product data<br>3. Verify response | Product created successfully<br>Returns created product details |
| TC-025 | Update product via API | Product data | 1. Use PUT /api/products/1<br>2. Send updated data<br>3. Verify response | Product updated successfully<br>Returns updated product details |
| TC-026 | Delete product via API (Admin) | Product ID | 1. Use DELETE /api/products/1<br>2. Verify response | Product deleted successfully<br>Returns success status |
| TC-027 | Get inventory via API | N/A | 1. Use GET /api/inventory/products<br>2. Observe response | All products with stock levels return<br>Product details included |
| TC-028 | Adjust inventory via API | Adjustment data | 1. Use POST /api/inventory/products/1/adjust<br>2. Send adjustment data<br>3. Verify response | Inventory adjusted successfully<br>Stock level updated |
| TC-029 | Get low stock via API | N/A | 1. Use GET /api/inventory/low-stock<br>2. Observe response | Low stock products return<br>Threshold configurable |
| TC-030 | Access categories API (Admin) | N/A | 1. Login as Admin<br>2. Use GET /api/categories<br>3. Observe response | All categories return<br>JSON response format correct |
| TC-031 | Access categories API (Staff) | N/A | 1. Login as Staff<br>2. Use GET /api/categories<br>3. Observe response | 403 Forbidden<br>Message: "Only administrators can access this resource" |
| TC-032 | Create category via API (Admin) | Category data | 1. Use POST /api/categories<br>2. Send category name<br>3. Verify response | Category created successfully<br>Available in dropdowns |
| TC-033 | Create category via API (Staff) | Category data | 1. Login as Staff<br>2. Use POST /api/categories<br>3. Observe response | 403 Forbidden<br>Message: "Only administrators can access this resource" |
| TC-034 | Access Swagger UI | N/A | 1. Navigate to /swagger<br>2. Explore API documentation | Swagger UI loads correctly<br>All endpoints documented |
| TC-035 | Test API endpoint from Swagger | N/A | 1. Click on an endpoint<br>2. Click 'Try it out'<br>3. Execute request | API call executes successfully<br>Response displays correctly |
| TC-036 | Verify MVC controllers hidden from Swagger | N/A | 1. Navigate to /swagger<br>2. Check for MVC controller endpoints | Only API controllers visible<br>No duplicate endpoints |

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