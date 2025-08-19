# 🐦 BirdCageShopAPI

BirdCageShopAPI là dự án **RESTful API** được xây dựng nhằm quản lý cửa hàng bán lồng chim.  
API này cho phép quản lý **sản phẩm (lồng chim, phụ kiện)**, **danh mục**, **đơn hàng** và **khách hàng**.  
Dự án phù hợp để học tập, thực hành các kỹ thuật backend với **.NET**.

---

## 🚀 Tính năng chính
- ✅ Quản lý **Category** (danh mục sản phẩm)  
- ✅ Quản lý **Product** (lồng chim, phụ kiện)  
- ✅ Quản lý **Customer** (khách hàng)  
- ✅ Quản lý **Sale Order** & **Order Detail**  
- ✅ Tính năng **Cart / Checkout**  
- ✅ Hỗ trợ **Authentication/Authorization** (nếu có)  

---

## 🛠️ Công nghệ sử dụng
- [.NET 8](https://dotnet.microsoft.com/) / ASP.NET Core Web API  
- Entity Framework Core (Code First)  
- SQL Server / PostgreSQL (tùy cấu hình)  
- Swagger / OpenAPI (tài liệu API)  

---

## 📂 Cấu trúc thư mục

```bash
BirdCageShopAPI/
│-- Controllers/     # Chứa API Controllers
│-- Models/          # Entity Models (Product, Category, Order, ...)
│-- Data/            # DbContext, Migrations
│-- Services/        # Business logic (CartService, OrderService)
│-- Program.cs       # Điểm khởi chạy ứng dụng
│-- appsettings.json # Cấu hình DB, JWT, ...
