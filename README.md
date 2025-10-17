# Online Inventory Management System

A production-ready ASP.NET Core MVC application for managing products, inventory, and orders with optimized Entity Framework Core integration.

![.NET Version](https://img.shields.io/badge/.NET-9.0-512BD4)
![EF Core](https://img.shields.io/badge/EF%20Core-9.0-512BD4)
![License](https://img.shields.io/badge/license-MIT-blue)

---

## 🎯 Project Overview

This project is a complete **Online Inventory Management System** built with ASP.NET Core MVC, featuring:

- **Server-rendered MVC views** for administration
- **RESTful API endpoints** for programmatic access
- **Entity Framework Core** with optimized queries
- **Repository + Unit of Work pattern** for clean architecture
- **Comprehensive test documentation** for happy path testing

---

## 🗄️ Why SQLite?

This project uses **SQLite** as the database provider for several important reasons:

### Portability & Accessibility
- **Single File Database**: All data stored in one `OnlineInventory.db` file
- **No Server Required**: No need to install or configure SQL Server
- **Cross-Platform**: Works on Windows, macOS, and Linux without changes
- **Easy Sharing**: Database file can be copied and shared between team members

### Educational Benefits
- **Simple Setup**: No database server installation or configuration
- **Easy Testing**: Perfect for happy path testing and demonstrations
- **Immediate Start**: Clone repository and run - database is created automatically
- **Version Control Friendly**: Can be included in repository for consistent test data

### Development Advantages
- **Zero Configuration**: No connection string modifications needed
- **Self-Contained**: Entire application + database in one project folder
- **Fast Development**: Rapid prototyping and testing cycles
- **Easy Reset**: Simply delete `.db` file to reset database

### Perfect for This Project
This is an **academic/learning project** focused on:
- Backend-Frontend integration testing
- Application architecture and design patterns
- API development and testing with Swagger
- Happy path testing scenarios

SQLite provides all necessary database features while keeping setup simple and accessible for everyone on the team.

> **Note**: For production deployment with high concurrency, consider migrating to SQL Server or PostgreSQL. The repository pattern makes this easy - just change the connection string and database provider in `Program.cs`.

---

## 🔐 Authentication & Authorization

**NEW:** Complete login system with role-based access control!

### User Roles
- **Admin** - Full access including DELETE operations
- **Staff** - Can create, edit, view, and adjust inventory (CANNOT delete products)

### Demo Accounts
```
Admin:  admin@inventory.com / Admin@123
Staff:  staff@inventory.com / Staff@123
```

### Security Features
- ✅ Login/Logout functionality
- ✅ Role-based authorization
- ✅ Protected admin pages (requires login)
- ✅ Session management (2-hour timeout)
- ✅ Account lockout after failed attempts
- ✅ Remember me functionality

**See** `AUTHENTICATION_GUIDE.md` for complete details

---

## ✨ Features

### Core Functionality

#### 📦 Product Management
- Create, Read, Update, Delete (CRUD) products
- Search and filter by name, SKU, description
- Filter by category
- Sort by price, name, or stock level
- Unique SKU validation
- Pagination support

#### 📊 Inventory Management
- Real-time inventory tracking
- Manual stock adjustments (increase/decrease)
- Complete transaction history
- Automatic inventory updates on orders
- Reason tracking for all changes
- Negative stock prevention

#### 🛒 Order Management
- Create orders with multiple items
- Automatic inventory deduction
- Order history with pagination
- Detailed order views
- Transaction-based order processing
- Stock validation before order creation

#### 🔖 Category Management
- Organize products by category
- Product count per category
- Category-based filtering

---

## 🏗️ Architecture

### Technology Stack

- **Framework:** ASP.NET Core 9.0
- **ORM:** Entity Framework Core 9.0
- **Database:** SQLite (portable, zero-config)
- **Frontend:** Razor Views + Bootstrap 5
- **API:** RESTful JSON APIs with Swagger/OpenAPI
- **Caching:** IMemoryCache
- **Patterns:** Repository, Unit of Work, DTO, SOLID principles
- **API Documentation:** Swagger UI (interactive testing)

### Project Structure

```
OnlineInventory/
├── Controllers/
│   ├── HomeController.cs                 # Home page
│   ├── AdminProductsController.cs        # Product management UI
│   ├── AdminInventoryController.cs       # Inventory management UI
│   ├── AdminOrdersController.cs          # Order management UI
│   ├── ProductsApiController.cs          # Product API
│   ├── OrdersApiController.cs            # Order API
│   ├── CategoriesApiController.cs        # Category API
│   └── InventoryApiController.cs         # Inventory API
├── Models/
│   ├── Product.cs                        # Product entity
│   ├── Category.cs                       # Category entity
│   ├── Order.cs                          # Order entity
│   ├── OrderItem.cs                      # Order item entity
│   └── InventoryTransaction.cs           # Inventory transaction entity
├── DTOs/
│   ├── ProductDto.cs                     # Product DTOs
│   ├── OrderDto.cs                       # Order DTOs
│   ├── CategoryDto.cs                    # Category DTOs
│   └── InventoryTransactionDto.cs        # Transaction DTOs
├── ViewModels/
│   ├── ProductViewModel.cs               # Product view models
│   ├── InventoryViewModel.cs             # Inventory view models
│   └── OrderViewModel.cs                 # Order view models
├── Services/
│   ├── ProductService.cs                 # Product business logic
│   ├── OrderService.cs                   # Order business logic
│   ├── InventoryService.cs               # Inventory business logic
│   └── CategoryService.cs                # Category business logic
├── Repositories/
│   ├── Repository.cs                     # Generic repository
│   ├── ProductRepository.cs              # Product-specific repository
│   ├── OrderRepository.cs                # Order-specific repository
│   └── UnitOfWork.cs                     # Unit of Work implementation
├── Data/
│   ├── ApplicationDbContext.cs           # EF Core DbContext
│   └── DbSeeder.cs                       # Database seeding
├── Views/
│   ├── Home/                             # Home views
│   ├── AdminProducts/                    # Product management views
│   ├── AdminInventory/                   # Inventory views
│   ├── AdminOrders/                      # Order views
│   └── Shared/                           # Shared layouts
├── Testing/
│   ├── TestCases_HappyPath.md           # 33 comprehensive test cases
│   ├── TestDataPreparation.md           # Test data setup guide
│   ├── TestExecutionReport_Template.md  # Report template
│   └── README.md                         # Testing documentation index
├── Migrations/                           # EF Core migrations
└── Program.cs                            # Application startup
```

---

## 🚀 Getting Started

### Prerequisites

- [.NET 9.0 SDK](https://dotnet.microsoft.com/download/dotnet/9.0)
- Visual Studio 2022, VS Code, or Rider (optional)
- A modern web browser (Chrome, Edge, Firefox)

**That's it!** No database server installation required - SQLite is embedded!

### Installation

1. **Clone the repository**
```bash
git clone <repository-url>
cd OnlineInventory
```

2. **Restore dependencies**
```bash
dotnet restore
```

3. **Connection string (already configured)**
   
   SQLite is pre-configured in `appsettings.json`:
   ```json
   "ConnectionStrings": {
     "DefaultConnection": "Data Source=OnlineInventory.db"
   }
   ```
   This creates a database file in your project directory.

4. **Install EF Core tools** (if not already installed)
```bash
dotnet tool install --global dotnet-ef
```

5. **Apply migrations and seed database**
```bash
dotnet ef database update
```

6. **Run the application**
```bash
dotnet run
```

7. **Open in browser**
```
https://localhost:5001
```

8. **Login to access admin features**
```
Click "Login" in the navigation bar
Email: admin@inventory.com
Password: Admin@123
```

9. **Access Swagger UI for API Testing**
```
https://localhost:5001/swagger
```
Interactive API documentation where you can test all endpoints!

---

## 📖 Usage

### Swagger UI (Recommended for API Testing)

**Access at:** `https://localhost:5001/swagger`

Swagger provides an **interactive API testing interface** where you can:
- 🔍 Browse all available API endpoints
- 📝 See request/response models
- ▶️ Execute API calls directly from the browser
- 📊 View response data and status codes
- 🧪 Test different scenarios without writing code

**Perfect for:**
- Frontend developers integrating with the API
- Backend testing and validation
- API documentation and exploration
- Happy path testing scenarios

### Admin Panel (Login Required)

**⚠️ You must login first to access these pages**

Navigate to the admin sections to manage your inventory:

- **Products:** `/Admin/Products`
  - View, search, filter, and sort products
  - Create, edit, and delete products
  - **NEW:** Inline Edit/Stock/Delete buttons in each row
  
- **Inventory:** `/Admin/Inventory/Transactions`
  - View transaction history
  - Adjust inventory levels manually
  - **NEW:** Direct links from product list

- **Orders:** `/Admin/Orders`
  - View all orders
  - View order details

**UI Improvements:**
- ✨ Inline action buttons (Edit, Stock, Delete) in each product row
- ✨ No more navigation confusion
- ✨ Quick access to stock adjustment for specific products
- ✨ Role badges in navigation (Admin/Staff)
- ✨ User-friendly login page with demo credentials displayed

### API Endpoints

#### Products API

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

#### Orders API

```http
GET    /api/orders                        # Get paginated orders
GET    /api/orders/{id}                   # Get order by ID
POST   /api/orders                        # Create order (reduces inventory)
```

#### Categories API

```http
GET    /api/categories                    # Get all categories
GET    /api/categories/{id}               # Get category by ID
POST   /api/categories                    # Create category
```

#### Inventory API

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
  "SKU": "PROD-001",
  "Name": "Sample Product",
  "Description": "A sample product",
  "Price": 99.99,
  "QuantityInStock": 100,
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

## 🧪 Testing

This project includes comprehensive happy path testing documentation.

### Test Documentation

Navigate to the `Testing/` folder:

- **TestCases_HappyPath.md** - 33 detailed test cases
- **TestDataPreparation.md** - Setup and validation guide
- **TestExecutionReport_Template.md** - Results reporting template
- **README.md** - Testing documentation index

### Quick Test Start

1. Ensure application is running
2. Follow `Testing/TestDataPreparation.md` to verify setup
3. Execute tests from `Testing/TestCases_HappyPath.md`
4. Record results using `Testing/TestExecutionReport_Template.md`

### Test Coverage

- ✅ Product Management (8 test cases)
- ✅ Inventory Management (4 test cases)
- ✅ Order Management (2 test cases)
- ✅ Product API (10 test cases)
- ✅ Order API (4 test cases)
- ✅ Category API (2 test cases)
- ✅ Inventory API (3 test cases)

**Total: 33 test cases**

---

## 🔐 Authorization (Ready for Implementation)

Controllers are prepared with authorization attributes (currently commented out):

```csharp
// [Authorize(Roles = "Admin")] // Uncomment when authentication is implemented
[Route("Admin/Products")]
public class AdminProductsController : Controller
```

To enable authentication:
1. Add ASP.NET Core Identity
2. Uncomment `[Authorize]` attributes in admin controllers
3. Configure authentication in `Program.cs`

For now, all endpoints are open for testing purposes.

---

## 🎨 Database Schema

**Database File:** `OnlineInventory.db` (SQLite - single file database)

```
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

## ⚡ Performance Optimizations

This project implements several EF Core optimizations:

1. **AsNoTracking()** - For read-only queries
2. **Projection to DTOs** - Using `.Select()` to avoid over-fetching
3. **Eager Loading** - Strategic use of `.Include()` for related data
4. **Database Indexes** - On SKU, CategoryId, Name, Timestamp
5. **Pagination** - For all list endpoints
6. **Memory Caching** - Configured for frequently accessed data
7. **Transaction Management** - For critical operations (orders)

---

## 🔐 Security Considerations

⚠️ **Note:** This is a demonstration project. For production use, add:

- Authentication & Authorization (e.g., ASP.NET Core Identity)
- Input validation and sanitization
- HTTPS enforcement
- CORS policies (currently open for development)
- Rate limiting for API endpoints
- SQL injection prevention (EF Core provides this by default)
- XSS protection in views

---

## 📊 Seeded Data

The application automatically seeds the database with:

- **6 Categories:** Electronics, Clothing, Books, Home & Garden, Sports & Outdoors, Toys & Games
- **21 Products:** Sample products across all categories
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

## 🤝 Contributing

1. Fork the repository
2. Create a feature branch (`git checkout -b feature/AmazingFeature`)
3. Commit your changes (`git commit -m 'Add some AmazingFeature'`)
4. Push to the branch (`git push origin feature/AmazingFeature`)
5. Open a Pull Request

---

## 📝 License

This project is licensed under the MIT License - see the LICENSE file for details.

---

## 👥 Authors

- **Your Name** - Initial work

---

## 🙏 Acknowledgments

- ASP.NET Core team for the excellent framework
- Entity Framework Core team for powerful ORM
- Bootstrap team for responsive UI components
- Community contributors and testers

---

## 📞 Support

For questions or issues:
- Create an issue in the repository
- Contact: [your-email@example.com]

---

## 🗺️ Roadmap

Future enhancements to consider:

- [ ] User authentication and authorization
- [ ] Role-based access control
- [ ] Advanced reporting and analytics
- [ ] Export to Excel/PDF
- [ ] Email notifications
- [ ] Product images upload
- [ ] Barcode/QR code generation
- [ ] Multi-warehouse support
- [ ] Supplier management
- [ ] Purchase order tracking
- [ ] Low stock alerts
- [ ] API versioning
- [ ] GraphQL endpoint (optional)
- [ ] Mobile app integration
- [ ] Real-time notifications (SignalR)

---

## 📚 Additional Resources

- [ASP.NET Core Documentation](https://docs.microsoft.com/aspnet/core)
- [Entity Framework Core Documentation](https://docs.microsoft.com/ef/core)
- [Bootstrap Documentation](https://getbootstrap.com/docs)
- [REST API Best Practices](https://restfulapi.net/)

---

**Version:** 1.0.0  
**Last Updated:** October 17, 2025  
**Status:** ✅ Production Ready (with security enhancements for production use)

#   o n l i n e - i n v e n t o r y  
 