# QLBV – HỆ THỐNG QUẢN LÝ BỆNH VIỆN

## 1. Giới thiệu

**QLBV** là hệ thống **Quản Lý Bệnh Viện** được xây dựng nhằm hỗ trợ số hóa và tối ưu hóa các quy trình nghiệp vụ trong bệnh viện như tiếp nhận bệnh nhân, quản lý hồ sơ khám bệnh, toa thuốc, bán thuốc, ca trực và phân quyền người dùng theo vai trò.

Hệ thống được phát triển theo kiến trúc **ASP.NET Core** kết hợp **Entity Framework Core**, hướng tới tính mở rộng, bảo mật và dễ bảo trì.

---

## 2. Công nghệ sử dụng

* **Ngôn ngữ**: C#
* **Framework**: ASP.NET Core MVC / Razor Pages
* **ORM**: Entity Framework Core
* **Cơ sở dữ liệu**: SQL Server
* **Xác thực & phân quyền**: ASP.NET Core Identity
* **Giao diện**: Razor View, Bootstrap
* **Khác**: Stored Procedure, Archive Table (lưu dữ liệu đã xóa)

---

## 3. Các vai trò trong hệ thống

Hệ thống được thiết kế theo mô hình phân quyền rõ ràng:

* **Tiếp tân**

  * Tiếp nhận bệnh nhân
  * Tạo phiếu khám bệnh
  * Quản lý thông tin hành chính bệnh nhân

* **Bác sĩ**

  * Cập nhật triệu chứng
  * Chẩn đoán bệnh
  * Kê toa thuốc

* **Nhân viên bán thuốc**

  * Tìm kiếm toa thuốc theo mã
  * Bán thuốc theo toa
  * Quản lý chi tiết toa thuốc

* **Quản lý tài vụ**

  * Quản lý danh mục thuốc
  * Cập nhật giá thuốc

* **Quản trị viên (Admin)**

  * Quản lý tài khoản người dùng
  * Phân quyền hệ thống
  * Quản lý dữ liệu tổng thể

---

## 4. Chức năng chính

* Quản lý bệnh nhân
* Quản lý phiếu khám bệnh
* Quản lý triệu chứng và chẩn đoán
* Quản lý toa thuốc và chi tiết toa thuốc
* Quản lý bán thuốc (không sử dụng SQL View)
* Quản lý ca trực bệnh viện
* Phân quyền chức năng theo vai trò
* Lưu trữ dữ liệu đã xóa vào bảng **Archive**

---

## 5. Kiến trúc hệ thống

* **Presentation Layer**: Razor Pages / MVC Views
* **Business Logic Layer**: Service, Interface
* **Data Access Layer**: Entity Framework Core, Stored Procedures
* **Security**: ASP.NET Core Identity + Role-based Authorization

---

## 6. Cài đặt & Chạy dự án

### 6.1. Yêu cầu môi trường

* .NET SDK 7.0 hoặc mới hơn
* SQL Server
* Visual Studio 2022+

### 6.2. Các bước thực hiện

```bash
# Clone repository
git clone <repository-url>

# Cấu hình chuỗi kết nối trong appsettings.json

# Cập nhật database
dotnet ef database update

# Chạy ứng dụng
dotnet run
```

---

## 7. Cấu trúc thư mục (tham khảo)

```
QLBV
│── Controllers
│── Pages
│── Models
│── Data
│── Services
│── Interfaces
│── Views
│── wwwroot
│── appsettings.json
│── Program.cs
```

---

## 8. Định hướng phát triển

* Tích hợp thanh toán điện tử
* Thống kê & báo cáo chuyên sâu
* Tích hợp AI hỗ trợ chẩn đoán
* Mở rộng API cho ứng dụng mobile

---

## 9. Tác giả

* Sinh viên CNTT – Dự án học phần / Đồ án
* Mục tiêu: Học tập và nghiên cứu ASP.NET Core trong hệ thống thực tế

---

## 10. Giấy phép

Dự án phục vụ cho mục đích **học tập và nghiên cứu**, không sử dụng cho mục đích thương mại.
