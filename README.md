# Online Product Management System

A complete web application for managing products and categories with full authentication, role-based access control, and comprehensive testing documentation.

![.NET Version](https://img.shields.io/badge/.NET-9.0-512BD4)
![EF Core](https://img.shields.io/badge/EF%20Core-9.0-512BD4)
![SQLite](https://img.shields.io/badge/Database-SQLite-003B57)
![License](https://img.shields.io/badge/license-MIT-blue)

---

## 🎯 Project Overview

This is a **complete web application** built with ASP.NET Core MVC that provides:

- **🔐 Full Authentication System** - Login/logout with role-based access control
- **📦 Product Management** - Complete CRUD operations with search and filtering
- **📊 Inventory Management** - Stock tracking and adjustments
- **🏷️ Category Management** - Admin-only category organization
- **🌐 RESTful API** - Complete API with Swagger documentation
- **📱 Responsive UI** - Modern Bootstrap 5 interface
- **🧪 Comprehensive Testing** - 36 test cases covering all functionality

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

## 🔐 Security Features
- ✅ **Secure Password Hashing** - PBKDF2 algorithm
- ✅ **Role-Based Access Control** - Different permissions for Admin/Staff
- ✅ **Session Management** - 2-hour timeout with sliding expiration
- ✅ **Account Lockout** - 5 failed attempts = 5-minute lockout
- ✅ **Remember Me** - Persistent login option
- ✅ **Simplified Identity Model** - Clean, maintainable authentication
- ✅ **Clean UI/UX** - Admin-only features hidden from Staff (not disabled)
- ✅ **API Authorization** - All API endpoints require Staff/Admin authentication

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

### 🏷️ Category Management (Admin Only)
- **View Categories** - List of all product categories with product counts
- **Create Categories** - Add new product categories
- **Edit Categories** - Update existing category information
- **Delete Categories** - Admin-only category deletion (with protection)
- **Product Organization** - Organize products by categories
- **Delete Protection** - Cannot delete categories with associated products
- **Admin-Only Access** - Complete web interface restricted to administrators

### 📊 Inventory Management
- **View Inventory** - Real-time stock levels for all products
- **Stock Adjustments** - Add or reduce stock quantities
- **Low Stock Alerts** - Identify products with low inventory
- **Simple Interface** - Easy-to-use stock management

### 🌐 API Endpoints
- **Authentication API** - Login/logout and user information
- **Products API** - Complete CRUD operations for products
- **Inventory API** - Stock management and low stock alerts
- **Categories API** - Admin-only category management
- **Swagger Documentation** - Interactive API testing interface
- **Clean API Structure** - No duplicate endpoints in Swagger

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


### 4. Category Management
1. Click "Management" → "Categories" in the navigation
2. **View Categories:** See all product categories
3. **Create Categories:** Add new categories for organizing products
4. **Edit Categories:** Update existing category information

### 5. API Testing with Swagger
1. **Access Swagger:** Go to `http://localhost:5000/swagger`
2. **Test Authentication API:** Use the `/api/auth/login` endpoint with your credentials:
   - Email: `admin@inventory.com` or `staff@inventory.com`
   - Password: `admin123` or `staff123`
3. **Test Other Endpoints:** Use `/api/auth/me` to get current user info
4. **View Responses:** See JSON responses from the authentication API
5. **Note:** All product/order/inventory management is done through the web interface, not APIs

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
- 36 comprehensive test cases
- Standard test case format
- Complete coverage of all website functionality
- Test execution results tracking
- Updated to reflect all current features

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
   - Navigate to `http://localhost:5000`
   - Login with admin credentials
   - Check that products and categories are visible
   - Verify role-based access works

3. **Execute Test Cases:**
   - Open `Testing/All_Test_Cases.md`
   - Follow each test case step-by-step
   - Record results in the provided table
   - Test both MVC UI and API endpoints
   - Test both Admin and Staff user roles

## 🌐 API Endpoints

> **🔐 Authorization Required:** All API endpoints require Staff or Admin authentication. 
> 
> **How to Authenticate:**
> 1. **Option 1:** Use the `/api/auth/login` endpoint in Swagger with your credentials
> 2. **Option 2:** Login at `http://localhost:5000/Account/Login` then access Swagger
> 3. Lock icons (🔒) indicate authentication is required
> 4. Without login, all API calls will return 401 Unauthorized

### Authentication API
```http
POST   /api/auth/login                   # Login with email/username and password
POST   /api/auth/logout                  # Logout current user  
GET    /api/auth/me                      # Get current user information
```

### Products API
```http
GET    /api/products                      # Get paginated products (Staff/Admin)
GET    /api/products?search=laptop        # Search products (Staff/Admin)
GET    /api/products?categoryId=1         # Filter by category (Staff/Admin)
GET    /api/products?sort=price_desc      # Sort products (Staff/Admin)
GET    /api/products/{id}                 # Get product by ID (Staff/Admin)
POST   /api/products                      # Create product (Staff/Admin)
PUT    /api/products/{id}                 # Update product (Staff/Admin)
DELETE /api/products/{id}                 # Delete product (Admin only)
```

### Inventory API
```http
GET    /api/inventory/products            # Get products with stock levels (Staff/Admin)
GET    /api/inventory/products/{id}       # Get product stock info (Staff/Admin)
POST   /api/inventory/products/{id}/adjust # Adjust product stock (Staff/Admin)
GET    /api/inventory/low-stock           # Get low stock products (Staff/Admin)
```

### Categories API (Admin Only)
```http
GET    /api/categories                    # Get all categories (Admin only)
GET    /api/categories/{id}               # Get category by ID (Admin only)
POST   /api/categories                    # Create category (Admin only)
PUT    /api/categories/{id}               # Update category (Admin only)
DELETE /api/categories/{id}               # Delete category (Admin only)
```

> **🔐 Admin Only:** All category management endpoints require Admin role. Non-admin users will receive 403 Forbidden with message "Only administrators can access this resource."


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
└── Category (Navigation)
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