# Online Inventory Management System

A complete web application for managing products, inventory, and orders with full authentication, role-based access control, and comprehensive testing documentation.

![.NET Version](https://img.shields.io/badge/.NET-9.0-512BD4)
![EF Core](https://img.shields.io/badge/EF%20Core-9.0-512BD4)
![SQLite](https://img.shields.io/badge/Database-SQLite-003B57)
![License](https://img.shields.io/badge/license-MIT-blue)

---

## 🎯 Project Overview

This is a **complete web application** built with ASP.NET Core MVC that provides:

- **🔐 Full Authentication System** - Login/logout with role-based access control
- **📦 Product Management** - Complete CRUD operations with search and filtering
- **📊 Inventory Management** - Real-time stock tracking and adjustments
- **🛒 Order Management** - Order creation and processing with automatic inventory updates
- **🌐 RESTful API** - Complete API with Swagger documentation
- **📱 Responsive UI** - Modern Bootstrap 5 interface
- **🧪 Comprehensive Testing** - 30 test cases covering all functionality

---

## 🗄️ Why SQLite?

This project uses **SQLite** for maximum portability and ease of use:

### Benefits
- **Single File Database** - Everything in one `OnlineInventory.db` file
- **No Server Required** - No database server installation needed
- **Cross-Platform** - Works on Windows, macOS, and Linux
- **Easy Sharing** - Database file can be copied and shared
- **Perfect for Testing** - Ideal for happy path testing scenarios

### Perfect for This Project
- **Academic/Learning Focus** - Easy setup for all team members
- **Backend-Frontend Integration** - Simple database for testing
- **API Development** - Complete RESTful API with Swagger
- **Testing Scenarios** - 5 products for comprehensive testing

---

## 🔐 Authentication & Authorization

### User Roles
- **Admin** - Full access including DELETE operations (all features visible)
- **Staff** - Can create, edit, view, and adjust inventory (DELETE button hidden)

### Demo Accounts
```
Admin:  admin@inventory.com / admin123
Staff:  staff@inventory.com / staff123
```

---

## ✨ Complete Web Application Features

### 🏠 Home Page
- **Welcome Message** - Personalized greeting with user's full name
- **Swagger UI Link** - Direct access to API documentation
- **Navigation** - Easy access to all application features
- **Role Display** - Shows user's role (Admin/Staff)

### 📦 Product Management
- **View Products** - Paginated list with search and filtering
- **Create Products** - Add new products with validation
- **Edit Products** - Update existing product information
- **Delete Products** - Admin-only product deletion (hidden from Staff)
- **Search & Filter** - Find products by name, SKU, or category
- **Sort Options** - Sort by name, price, or stock level
- **Inline Actions** - Edit, Stock buttons (Delete button hidden for Staff)

### 📊 Inventory Management
- **Transaction History** - Complete audit trail of all stock changes
- **Stock Adjustments** - Manual inventory increases/decreases
- **Reason Tracking** - Document why inventory changes occurred
- **Real-time Updates** - Automatic inventory updates on orders
- **Direct Links** - Quick access from product list to stock adjustment

### 🛒 Order Management
- **View Orders** - Paginated list of all orders
- **Order Details** - Complete order information with items
- **API Integration** - Create orders via RESTful API
- **Automatic Processing** - Inventory automatically updated on order creation
- **Stock Validation** - Prevents orders when insufficient stock

### 🌐 API Endpoints
- **Products API** - Complete CRUD operations
- **Orders API** - Order creation and retrieval
- **Categories API** - Category management
- **Inventory API** - Stock adjustments and transaction history
- **Swagger Documentation** - Interactive API testing interface

---

## 🏗️ Technology Stack

- **Framework:** ASP.NET Core 9.0 MVC
- **Database:** SQLite (portable, zero-config)
- **ORM:** Entity Framework Core 9.0
- **Frontend:** Razor Views + Bootstrap 5
- **Authentication:** ASP.NET Core Identity (simplified)
- **API:** RESTful JSON APIs with Swagger/OpenAPI
- **Patterns:** Repository, Unit of Work, DTO, SOLID principles

---

## 🚀 Getting Started

### Prerequisites
- [.NET 9.0 SDK](https://dotnet.microsoft.com/download/dotnet/9.0)
- Modern web browser (Chrome, Edge, Firefox)
- Visual Studio 2022, VS Code, or Rider (optional)

### Quick Setup

1. **Clone and Navigate**
```bash
git clone https://github.com/fidzella89/online-inventory.git
cd OnlineInventory
```

2. **Restore Dependencies**
```bash
dotnet restore
```

3. **Setup Database**
```bash
dotnet ef database update
```

4. **Run Application**
```bash
dotnet run
```

5. **Access Application**
```
https://localhost:5001
```

6. **Login with Demo Accounts**
```
Admin: admin@inventory.com / admin123
Staff: staff@inventory.com / staff123
```

---

## 📖 How to Use the Web Application

### 1. Login Process
1. Navigate to `https://localhost:5001`
2. Click "Login" in the top-right corner
3. Enter credentials (Admin or Staff)
4. Click "Login" button
5. You'll be redirected to the home page with your name displayed

### 2. Product Management
1. Click "Management" → "Products" in the navigation
2. **View Products:** See all 5 seeded products
3. **Search:** Use the search box to find specific products
4. **Filter:** Use the category dropdown to filter by category
5. **Sort:** Click column headers to sort by name, price, or stock
6. **Create:** Click "Add New Product" to add a new product
7. **Edit:** Click "Edit" button in any product row
8. **Delete:** Click "Delete" button (Admin only - Staff sees disabled button)
9. **Adjust Stock:** Click "Stock" button to adjust inventory

### 3. Inventory Management
1. Click "Management" → "Inventory" in the navigation
2. **View Transactions:** See complete history of all stock changes
3. **Adjust Stock:** Click "Adjust" button for any product
4. **Enter Details:** Specify quantity change and reason
5. **Save Changes:** Click "Save" to record the adjustment

### 4. Order Management
1. Click "Management" → "Orders" in the navigation
2. **View Orders:** See all orders in the system
3. **Order Details:** Click on any order to see detailed information
4. **Create Orders:** Use the API endpoints to create new orders

### 5. API Testing with Swagger
1. Navigate to `https://localhost:5001/swagger`
2. **Explore APIs:** Browse all available endpoints
3. **Test Endpoints:** Click "Try it out" to test any API
4. **View Responses:** See actual data returned by the API
5. **Test Authentication:** Use the API with proper authentication

---

## 🧪 Comprehensive Testing Guide

### Testing Documentation Structure

The testing documentation is organized into three main documents:

#### 📋 Document 1: Testing Overview
**File:** `Testing/Testing_Overview.md`
- Testing mission and objectives
- Scope and success criteria
- Environment setup requirements
- Expected outcomes

#### 📋 Document 2: Testing Methodology  
**File:** `Testing/Testing_Methodology.md`
- Complete 10-step testing process
- Detailed methodology for each step
- Role assignments and responsibilities
- Success metrics and deliverables

#### 📋 Document 3: All Test Cases
**File:** `Testing/All_Test_Cases.md`
- 30 comprehensive test cases
- Standard test case format
- Complete coverage of all website functionality
- Test execution results tracking

### 10-Step Testing Process

1. **Step 1:** Define Test Objectives
2. **Step 2:** Assign Roles and Responsibilities  
3. **Step 3:** Create Test Cases
4. **Step 4:** Prepare Testing Environment
5. **Step 5:** Prepare Test Data
6. **Step 6:** Execute Test Cases
7. **Step 7:** Verify Expected Outcomes
8. **Step 8:** Report Findings
9. **Step 9:** Retest After Fixes
10. **Step 10:** Review and Optimize

### Test Case Format

| Test Case ID | Description | Inputs | Steps | Expected Outcome |
|--------------|-------------|--------|-------|------------------|
| TC-001 | User login | Valid credentials | 1. Navigate to login page<br>2. Enter username and password<br>3. Click 'Login' | User successfully logged in<br>Dashboard displays |

### Complete Test Coverage (30 Test Cases)

| Category | Test Cases | Coverage |
|----------|------------|----------|
| **Authentication** | TC-001, TC-002 | Login/logout functionality |
| **Product Management** | TC-003 to TC-010 | CRUD operations, search, filtering, role-based access |
| **Inventory Management** | TC-011, TC-012 | Transaction history, stock adjustments |
| **Order Management** | TC-013 to TC-015 | Order viewing, creation, details |
| **API Endpoints** | TC-016 to TC-028 | All RESTful API functionality |
| **Integration** | TC-029, TC-030 | Swagger UI, end-to-end testing |

### How to Execute Tests

#### Quick Test Start
1. **Start Application:**
   ```bash
   dotnet run
   ```

2. **Verify Setup:**
   - Navigate to `https://localhost:5001`
   - Login with admin credentials
   - Check that 5 products and 6 categories are visible

3. **Execute Test Cases:**
   - Open `Testing/All_Test_Cases.md`
   - Follow each test case step-by-step
   - Record results in the provided table
   - Test both MVC UI and API endpoints

## 🌐 API Endpoints

### Products API
```http
GET    /api/products                      # Get paginated products
GET    /api/products?search=laptop        # Search products
GET    /api/products?categoryId=1         # Filter by category
GET    /api/products?sort=price_desc      # Sort products
GET    /api/products/{id}                 # Get product by ID
POST   /api/products                      # Create product
PUT    /api/products/{id}                 # Update product
DELETE /api/products/{id}                 # Delete product
```

### Orders API
```http
GET    /api/orders                        # Get paginated orders
GET    /api/orders/{id}                   # Get order by ID
POST   /api/orders                        # Create order (reduces inventory)
```

### Categories API
```http
GET    /api/categories                    # Get all categories
GET    /api/categories/{id}               # Get category by ID
POST   /api/categories                    # Create category
```

### Inventory API
```http
GET    /api/inventory/transactions        # Get transactions
GET    /api/inventory/transactions?productId=1  # Filter by product
POST   /api/inventory/adjust              # Manual inventory adjustment
```

### Example API Requests

**Create a Product:**
```json
POST /api/products
Content-Type: application/json

{
  "SKU": "TEST-001",
  "Name": "Test Product",
  "Description": "A test product for validation",
  "Price": 99.99,
  "QuantityInStock": 50,
  "CategoryId": 1
}
```

**Create an Order:**
```json
POST /api/orders
Content-Type: application/json

{
  "Items": [
    { "ProductId": 1, "Quantity": 2 },
    { "ProductId": 2, "Quantity": 1 }
  ]
}
```

---

## 🎨 Database Schema

**Database File:** `OnlineInventory.db` (SQLite - single file database)

```
Users (Simplified Identity) 🔐
├── Id (PK)
├── UserName
├── Email
├── Password (PBKDF2 hash)
├── FullName
├── IsActive
├── AccessFailedCount
└── SecurityStamp

Roles (Simplified Identity) 🔐
├── Id (PK)
└── Name

UserRoles (Identity junction table) 🔐
├── UserId (FK)
└── RoleId (FK)

Categories
├── Id (PK)
├── Name (Unique Index)
└── Products (Navigation)

Products
├── Id (PK)
├── SKU (Unique Index)
├── Name (Index)
├── Description
├── Price
├── QuantityInStock
├── CategoryId (FK, Index)
├── Category (Navigation)
└── InventoryTransactions (Navigation)

Orders
├── Id (PK)
├── CreatedAt (Index)
├── Total
└── Items (Navigation)

OrderItems
├── Id (PK)
├── OrderId (FK, Index)
├── ProductId (FK, Index)
├── Quantity
├── UnitPrice
├── Order (Navigation)
└── Product (Navigation)

InventoryTransactions
├── Id (PK)
├── ProductId (FK, Index)
├── QuantityChange
├── Timestamp (Index)
├── Reason
└── Product (Navigation)
```

---

## 📊 Seeded Data

The application automatically seeds the database with:

- **2 User Accounts:** Admin and Staff with secure PBKDF2 password hashes
- **2 Roles:** Admin and Staff
- **6 Categories:** Electronics, Clothing, Books, Home & Garden, Sports & Outdoors, Toys & Games
- **5 Products:** Simple sample products across different categories
  - Laptop (Electronics) - $999.99
  - Smartphone (Electronics) - $699.99
  - T-Shirt (Clothing) - $19.99
  - Programming Guide (Books) - $39.99
  - Coffee Maker (Home & Garden) - $79.99
- **Initial Inventory Transactions:** One per product with reason "Initial Stock"

---

## 🛠️ Development

### Adding a New Feature

1. Create/update entity models in `Models/`
2. Create migration: `dotnet ef migrations add YourMigration`
3. Apply migration: `dotnet ef database update`
4. Create DTOs in `DTOs/`
5. Implement service layer in `Services/`
6. Add API controller or MVC controller in `Controllers/`
7. Create views if needed in `Views/`

### Useful Commands

```bash
# Create migration
dotnet ef migrations add MigrationName

# Apply migrations
dotnet ef database update

# Rollback migration
dotnet ef database update PreviousMigrationName

# Drop database
dotnet ef database drop

# Generate SQL script
dotnet ef migrations script

# Build project
dotnet build

# Run project
dotnet run

# Run in watch mode (auto-reload)
dotnet watch run
```

---

**Version:** 1.0.0  
**Created:** October 18, 2025  

🎉 **Complete Web for Activity Oct. 18, 2025** 🎉