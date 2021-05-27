create database QuanLyDungCuTheThao;

use QuanLyDungCuTheThao;

-- Chi Nhanh
create table Branch (
	ID int identity(1,1) primary key,
	Name nvarchar(20) not null,
	Address nvarchar(50) not null
);

-- Nhan Vien
create table Employee (
	ID int identity(1,1) primary key,
	Branch int not null foreign key references Branch(ID),
	FullName nvarchar(30) not null,
	DateOfBirth datetime not null,
	Address nvarchar(50) not null,
	PhoneNumber int,
	Position nvarchar(30) not null,
	Salary int not null,
);

-- Loai San Pham
create table ProductCategory (
	ID int identity(1,1) primary key,
	Name nvarchar(50) not null,
);

-- San Pham
create table Product (
	ID int identity(1,1) primary key,
	Name nvarchar(50) not null,
	Price int not null,
	ProductCategory int not null foreign key references ProductCategory(ID),
	Manufacturer nvarchar(30) not null
);

-- Chi tiet San Pham
create table ProductDetail (
	ID int identity(1,1) primary key,
	Product int not null foreign key references Product(ID),
	Branch int not null foreign key references Branch(ID),
	Size char(5),
	Quantity int not null,
	ProductDescription nvarchar(50) not null,
);

-- Hoa Don
create table Bill (
	ID int identity(1,1) primary key,
	Employee int not null foreign key references Employee(ID),
	Customer nvarchar(50) not null,
	PhoneNumber int not null,
	CheckoutDate datetime not null,
	Discount int,
	TotalAmount int not null,
);


-- Chi Tiet Hoa Don
create table BillDetail (
	ID int identity(1,1) primary key,
	Bill int not null foreign key references Bill(ID),
	ProductDetail int not null foreign key references ProductDetail(ID),
	Quantity int not null,
	CurrentUnitPrice int not null,
);

-- Chen bang Chi Nhanh
insert into Branch(Name, Address) values (N'Bùi Thị Xuân', N'55A Bùi Thị Xuân - Phuong8 - TP Đà Lạt');
insert into Branch(Name, Address) values (N'Hòa Bình', N'1A Hòa Bình - Phuong1 - TP Đà Lạt');

-- Chen bang Loai San Pham
insert into ProductCategory(Name) values (N'Kính bơi');
insert into ProductCategory(Name) values (N'Phao');
insert into ProductCategory(Name) values (N'Đồ bơi');
insert into ProductCategory(Name) values (N'Mũ bơi');
insert into ProductCategory(Name) values (N'Đồ bơi liền người');
insert into ProductCategory(Name) values (N'Giày đá bóng');
insert into ProductCategory(Name) values (N'Quần đá bóng');
insert into ProductCategory(Name) values (N'Áo đá bóng');
insert into ProductCategory(Name) values (N'Bóng đá');
insert into ProductCategory(Name) values (N'Giày chạy bộ');
insert into ProductCategory(Name) values (N'Mũ chạy bộ');
insert into ProductCategory(Name) values (N'Quần chay bộ');
insert into ProductCategory(Name) values (N'Áo chạy bộ');
insert into ProductCategory(Name) values (N'Găng tay chống nắng');
insert into ProductCategory(Name) values (N'Áo khoác');
insert into ProductCategory(Name) values (N'Khăn');
insert into ProductCategory(Name) values (N'Tất');
insert into ProductCategory(Name) values (N'Đồng Hồ');

-- chen bang San Pham
insert into Product(Name, Price, ProductCategory, Manufacturer) values (N'Kính bơi nam',  16500, 1, 'Xbase');
insert into Product(Name, Price, ProductCategory, Manufacturer) values (N'Kính bơi nữ',  14200, 1, 'Nabaiji');
insert into Product(Name, Price, ProductCategory, Manufacturer) values (N'Kính bơi trẻ em',  10200, 1, 'Xbase');
insert into Product(Name, Price, ProductCategory, Manufacturer) values (N'Phao người lớn',  158000, 2, 'adidas');
insert into Product(Name, Price, ProductCategory, Manufacturer) values (N'Phao trẻ em',  108000, 2, 'Nabaiji');
insert into Product(Name, Price, ProductCategory, Manufacturer) values (N'Đồ bơi nam',  108000, 3, 'Xbase');
insert into Product(Name, Price, ProductCategory, Manufacturer) values (N'Đồ bơi nữ',  108000, 3, 'Xbase');
insert into Product(Name, Price, ProductCategory, Manufacturer) values (N'Đồ bơi trẻ em',  51200, 3, 'adidas');
insert into Product(Name, Price, ProductCategory, Manufacturer) values (N'Mũ bơi người lớn',  151000, 4, 'Nabaiji');
insert into Product(Name, Price, ProductCategory, Manufacturer) values (N'Mũ bơi trẻ em',  99000, 4, 'Nabaiji');
insert into Product(Name, Price, ProductCategory, Manufacturer) values (N'Đồ bơi liền người nam', 301000, 5, 'Xbase');
insert into Product(Name, Price, ProductCategory, Manufacturer) values (N'Đồ bơi liền người nữ', 295000, 5, 'adidas');
insert into Product(Name, Price, ProductCategory, Manufacturer) values (N'Đồ bơi liền người trẻ em', 195000, 5, 'Xbase');
insert into Product(Name, Price, ProductCategory, Manufacturer) values (N'Giày đá bóng nam', 275000, 6, 'Xbase');
insert into Product(Name, Price, ProductCategory, Manufacturer) values (N'Giày đá bóng nữ', 210000, 6, 'Nabaiji');
insert into Product(Name, Price, ProductCategory, Manufacturer) values (N'Giày đá bóng trẻ em',  155000, 6, 'Xbase');
insert into Product(Name, Price, ProductCategory, Manufacturer) values (N'Quần đá bóng nam',  150000, 7, 'adidas');
insert into Product(Name, Price, ProductCategory, Manufacturer) values (N'Quần đá bóng nữ',  145000, 7, 'Xbase');
insert into Product(Name, Price, ProductCategory, Manufacturer) values (N'Quần đá bóng trẻ em',  125000, 7, 'Xbase');
insert into Product(Name, Price, ProductCategory, Manufacturer) values (N'Áo đá bóng nam',  150000, 8, 'Xbase');
insert into Product(Name, Price, ProductCategory, Manufacturer) values (N'Áo đá bóng nữ',  145000, 8, 'Nabaiji');
insert into Product(Name, Price, ProductCategory, Manufacturer) values (N'Áo đá bóng trẻ em',  125000, 8, 'adidas');
insert into Product(Name, Price, ProductCategory, Manufacturer) values (N'Bóng đá thể thao',  100000, 9, 'Xbase');
insert into Product(Name, Price, ProductCategory, Manufacturer) values (N'Bóng đá nhựa',  12000, 9, 'Xbase');

-- chen bang Chi Tiet San Pham
insert into ProductDetail(Product, Branch, Size, Quantity, ProductDescription) values (1, 1, null, 98, N'Kính bơi nam mới và đẹp 2021');
insert into ProductDetail(Product, Branch, Size, Quantity, ProductDescription) values (1, 2, null, 80, N'Kính bơi nam mới và đẹp 2021');

insert into ProductDetail(Product, Branch, Size, Quantity, ProductDescription) values (2, 1, null, 80, N'Kính bơi nữ mới và đẹp 2021');
insert into ProductDetail(Product, Branch, Size, Quantity, ProductDescription) values (2, 2, null, 98, N'Kính bơi nữ mới và đẹp 2021');

insert into ProductDetail(Product, Branch, Size, Quantity, ProductDescription) values (3, 1, null, 90, N'Kính bơi trẻ em mới và đẹp 2021');
insert into ProductDetail(Product, Branch, Size, Quantity, ProductDescription) values (3, 2, null, 56, N'Kính bơi trẻ em mới và đẹp 2021');

insert into ProductDetail(Product, Branch, Size, Quantity, ProductDescription) values (4, 1, null, 123, N'Phao người lớn mới và đẹp 2021');
insert into ProductDetail(Product, Branch, Size, Quantity, ProductDescription) values (4, 2, null, 86, N'Phao người lớn mới và đẹp 2021');

insert into ProductDetail(Product, Branch, Size, Quantity, ProductDescription) values (5, 1, null, 56, N'Phao trẻ em mới và đẹp 2021');
insert into ProductDetail(Product, Branch, Size, Quantity, ProductDescription) values (5, 2, null, 156, N'Phao trẻ em mới và đẹp 2021');

insert into ProductDetail(Product, Branch, Size, Quantity, ProductDescription) values (6, 1, 'xl', 34, N'Đồ bơi nam mới size xl');
insert into ProductDetail(Product, Branch, Size, Quantity, ProductDescription) values (6, 1, 'l', 123, N'Đồ bơi nam mới size l');
insert into ProductDetail(Product, Branch, Size, Quantity, ProductDescription) values (6, 1, 'm', 233, N'Đồ bơi nam mới size m');
insert into ProductDetail(Product, Branch, Size, Quantity, ProductDescription) values (6, 1, 's', 74, N'Đồ bơi nam mới size s');

insert into ProductDetail(Product, Branch, Size, Quantity, ProductDescription) values (6, 2, 'xl', 134, N'Đồ bơi nam mới size xl');
insert into ProductDetail(Product, Branch, Size, Quantity, ProductDescription) values (6, 2, 'l', 223, N'Đồ bơi nam mới size l');
insert into ProductDetail(Product, Branch, Size, Quantity, ProductDescription) values (6, 2, 'm', 65, N'Đồ bơi nam mới size m');
insert into ProductDetail(Product, Branch, Size, Quantity, ProductDescription) values (6, 2, 's', 87, N'Đồ bơi nam mới size s');

insert into ProductDetail(Product, Branch, Size, Quantity, ProductDescription) values (7, 1, 'xl', 72, N'Đồ bơi nữ mới size xl');
insert into ProductDetail(Product, Branch, Size, Quantity, ProductDescription) values (7, 1, 'l', 48, N'Đồ bơi nữ mới size l');
insert into ProductDetail(Product, Branch, Size, Quantity, ProductDescription) values (7, 1, 'm', 94, N'Đồ bơi nữ mới size m');
insert into ProductDetail(Product, Branch, Size, Quantity, ProductDescription) values (7, 1, 's', 46, N'Đồ bơi nữ mới size s');

insert into ProductDetail(Product, Branch, Size, Quantity, ProductDescription) values (7, 2, 'xl', 172, N'Đồ bơi nữ mới size xl');
insert into ProductDetail(Product, Branch, Size, Quantity, ProductDescription) values (7, 2, 'l', 148, N'Đồ bơi nữ mới size l');
insert into ProductDetail(Product, Branch, Size, Quantity, ProductDescription) values (7, 2, 'm', 194, N'Đồ bơi nữ mới size m');
insert into ProductDetail(Product, Branch, Size, Quantity, ProductDescription) values (7, 2, 's', 146, N'Đồ bơi nữ mới size s');

insert into ProductDetail(Product, Branch, Size, Quantity, ProductDescription) values (8, 1, 'xl', 123, N'Đồ bơi trẻ em mới size xl');
insert into ProductDetail(Product, Branch, Size, Quantity, ProductDescription) values (8, 1, 'l', 26, N'Đồ bơi trẻ em mới size l');
insert into ProductDetail(Product, Branch, Size, Quantity, ProductDescription) values (8, 1, 'm', 19, N'Đồ bơi trẻ em mới size m');
insert into ProductDetail(Product, Branch, Size, Quantity, ProductDescription) values (8, 1, 's', 223, N'Đồ bơi trẻ em mới size s');

insert into ProductDetail(Product, Branch, Size, Quantity, ProductDescription) values (8, 2, 'xl', 223, N'Đồ bơi trẻ em mới size xl');
insert into ProductDetail(Product, Branch, Size, Quantity, ProductDescription) values (8, 2, 'l', 126, N'Đồ bơi trẻ em mới size l');
insert into ProductDetail(Product, Branch, Size, Quantity, ProductDescription) values (8, 2, 'm', 119, N'Đồ bơi trẻ em mới size m');
insert into ProductDetail(Product, Branch, Size, Quantity, ProductDescription) values (8, 2, 's', 123, N'Đồ bơi trẻ em mới size s');

insert into ProductDetail(Product, Branch, Size, Quantity, ProductDescription) values (9, 1, null, 312, N'Mũ bơi người lớn mới và đẹp 2021');
insert into ProductDetail(Product, Branch, Size, Quantity, ProductDescription) values (10, 1, null, 413, N'Mũ bơi trẻ em mới và đẹp 2021');

insert into ProductDetail(Product, Branch, Size, Quantity, ProductDescription) values (9, 2, null, 112, N'Mũ bơi người lớn mới và đẹp 2021');
insert into ProductDetail(Product, Branch, Size, Quantity, ProductDescription) values (10, 2, null, 213, N'Mũ bơi trẻ em mới và đẹp 2021');

insert into ProductDetail(Product, Branch, Size, Quantity, ProductDescription) values (11, 1, 'xl', 48, N'Đồ bơi liền người nam size xl');
insert into ProductDetail(Product, Branch, Size, Quantity, ProductDescription) values (11, 1, 'l', 36, N'Đồ bơi liền người nam size l');
insert into ProductDetail(Product, Branch, Size, Quantity, ProductDescription) values (11, 1, 'm', 124, N'Đồ bơi liền người nam size m');
insert into ProductDetail(Product, Branch, Size, Quantity, ProductDescription) values (11, 1, 's', 129, N'Đồ bơi liền người nam size s');

insert into ProductDetail(Product, Branch, Size, Quantity, ProductDescription) values (11, 2, 'xl', 148, N'Đồ bơi liền người nam size xl');
insert into ProductDetail(Product, Branch, Size, Quantity, ProductDescription) values (11, 2, 'l', 136, N'Đồ bơi liền người nam size l');
insert into ProductDetail(Product, Branch, Size, Quantity, ProductDescription) values (11, 2, 'm', 224, N'Đồ bơi liền người nam size m');
insert into ProductDetail(Product, Branch, Size, Quantity, ProductDescription) values (11, 2, 's', 229, N'Đồ bơi liền người nam size s');

insert into ProductDetail(Product, Branch, Size, Quantity, ProductDescription) values (12, 1, 'xl', 232, N'Đồ bơi liền người nữ size xl');
insert into ProductDetail(Product, Branch, Size, Quantity, ProductDescription) values (12, 1, 'l', 425, N'Đồ bơi liền người nữ size l');
insert into ProductDetail(Product, Branch, Size, Quantity, ProductDescription) values (12, 1, 'm', 21, N'Đồ bơi liền người nữ size m');
insert into ProductDetail(Product, Branch, Size, Quantity, ProductDescription) values (12, 1, 's', 28, N'Đồ bơi liền người nữ size s');

insert into ProductDetail(Product, Branch, Size, Quantity, ProductDescription) values (12, 2, 'xl', 232, N'Đồ bơi liền người nữ size xl');
insert into ProductDetail(Product, Branch, Size, Quantity, ProductDescription) values (12, 2, 'l', 125, N'Đồ bơi liền người nữ size l');
insert into ProductDetail(Product, Branch, Size, Quantity, ProductDescription) values (12, 2, 'm', 121, N'Đồ bơi liền người nữ size m');
insert into ProductDetail(Product, Branch, Size, Quantity, ProductDescription) values (12, 2, 's', 128, N'Đồ bơi liền người nữ size s');

insert into ProductDetail(Product, Branch, Size, Quantity, ProductDescription) values (13, 1, 'xl', 144, N'Đồ bơi liền người trẻ em size xl');
insert into ProductDetail(Product, Branch, Size, Quantity, ProductDescription) values (13, 1, 'l', 874, N'Đồ bơi liền người trẻ em size l');
insert into ProductDetail(Product, Branch, Size, Quantity, ProductDescription) values (13, 1, 'm', 44, N'Đồ bơi liền người trẻ em size m');
insert into ProductDetail(Product, Branch, Size, Quantity, ProductDescription) values (13, 1, 's', 126, N'Đồ bơi liền người trẻ em size s');

insert into ProductDetail(Product, Branch, Size, Quantity, ProductDescription) values (13, 2, 'xl', 244, N'Đồ bơi liền người trẻ em size xl');
insert into ProductDetail(Product, Branch, Size, Quantity, ProductDescription) values (13, 2, 'l', 174, N'Đồ bơi liền người trẻ em size l');
insert into ProductDetail(Product, Branch, Size, Quantity, ProductDescription) values (13, 2, 'm', 144, N'Đồ bơi liền người trẻ em size m');
insert into ProductDetail(Product, Branch, Size, Quantity, ProductDescription) values (13, 2, 's', 123, N'Đồ bơi liền người trẻ em size s');

insert into ProductDetail(Product, Branch, Size, Quantity, ProductDescription) values (14, 1, null, 144, N'Giày đá bóng nam mới và đẹp 2021');
insert into ProductDetail(Product, Branch, Size, Quantity, ProductDescription) values (15, 1, null, 22, N'Giày đá bóng nữ mới và đẹp 2021');
insert into ProductDetail(Product, Branch, Size, Quantity, ProductDescription) values (16, 1, null, 344, N'Giày đá bóng trẻ em mới và đẹp 2021');

insert into ProductDetail(Product, Branch, Size, Quantity, ProductDescription) values (14, 2, null, 144, N'Giày đá bóng nam mới và đẹp 2021');
insert into ProductDetail(Product, Branch, Size, Quantity, ProductDescription) values (15, 2, null, 122, N'Giày đá bóng nữ mới và đẹp 2021');
insert into ProductDetail(Product, Branch, Size, Quantity, ProductDescription) values (16, 2, null, 144, N'Giày đá bóng trẻ em mới và đẹp 2021');

insert into ProductDetail(Product, Branch, Size, Quantity, ProductDescription) values (17, 1, 'xl', 121, N'Quần đá bóng nam size xl');
insert into ProductDetail(Product, Branch, Size, Quantity, ProductDescription) values (17, 1, 'l', 28, N'Quần đá bóng nam size l');
insert into ProductDetail(Product, Branch, Size, Quantity, ProductDescription) values (17, 1, 'm', 30, N'Quần đá bóng nam size m');
insert into ProductDetail(Product, Branch, Size, Quantity, ProductDescription) values (17, 1, 's', 150, N'Quần đá bóng nam size s');

insert into ProductDetail(Product, Branch, Size, Quantity, ProductDescription) values (17, 2, 'xl', 121, N'Quần đá bóng nam size xl');
insert into ProductDetail(Product, Branch, Size, Quantity, ProductDescription) values (17, 2, 'l', 28, N'Quần đá bóng nam size l');
insert into ProductDetail(Product, Branch, Size, Quantity, ProductDescription) values (17, 2, 'm', 30, N'Quần đá bóng nam size m');
insert into ProductDetail(Product, Branch, Size, Quantity, ProductDescription) values (17, 2, 's', 150, N'Quần đá bóng nam size s');

insert into ProductDetail(Product, Branch, Size, Quantity, ProductDescription) values (18, 1, 'xl', 98, N'Quần đá bóng nữ size xl');
insert into ProductDetail(Product, Branch, Size, Quantity, ProductDescription) values (18, 1, 'l', 172, N'Quần đá bóng nữ size l');
insert into ProductDetail(Product, Branch, Size, Quantity, ProductDescription) values (18, 1, 'm', 356, N'Quần đá bóng nữ size m');
insert into ProductDetail(Product, Branch, Size, Quantity, ProductDescription) values (18, 1, 's', 100, N'Quần đá bóng nữ size s');

insert into ProductDetail(Product, Branch, Size, Quantity, ProductDescription) values (18, 2, 'xl', 98, N'Quần đá bóng nữ size xl');
insert into ProductDetail(Product, Branch, Size, Quantity, ProductDescription) values (18, 2, 'l', 172, N'Quần đá bóng nữ size l');
insert into ProductDetail(Product, Branch, Size, Quantity, ProductDescription) values (18, 2, 'm', 356, N'Quần đá bóng nữ size m');
insert into ProductDetail(Product, Branch, Size, Quantity, ProductDescription) values (18, 2, 's', 100, N'Quần đá bóng nữ size s');

insert into ProductDetail(Product, Branch, Size, Quantity, ProductDescription) values (19, 1, 'xl', 354, N'Quần đá bóng trẻ em size xl');
insert into ProductDetail(Product, Branch, Size, Quantity, ProductDescription) values (19, 1, 'l', 114, N'Quần đá bóng trẻ em size l');
insert into ProductDetail(Product, Branch, Size, Quantity, ProductDescription) values (19, 1, 'm', 35, N'Quần đá bóng trẻ em size m');
insert into ProductDetail(Product, Branch, Size, Quantity, ProductDescription) values (19, 1, 's', 88, N'Quần đá bóng trẻ em size s');

insert into ProductDetail(Product, Branch, Size, Quantity, ProductDescription) values (19, 2, 'xl', 354, N'Quần đá bóng trẻ em size xl');
insert into ProductDetail(Product, Branch, Size, Quantity, ProductDescription) values (19, 2, 'l', 114, N'Quần đá bóng trẻ em size l');
insert into ProductDetail(Product, Branch, Size, Quantity, ProductDescription) values (19, 2, 'm', 35, N'Quần đá bóng trẻ em size m');
insert into ProductDetail(Product, Branch, Size, Quantity, ProductDescription) values (19, 2, 's', 88, N'Quần đá bóng trẻ em size s');

insert into ProductDetail(Product, Branch, Size, Quantity, ProductDescription) values (20, 1, 'xl', 202, N'Áo đá bóng nam size xl');
insert into ProductDetail(Product, Branch, Size, Quantity, ProductDescription) values (20, 1, 'l', 725, N'Áo đá bóng nam size l');
insert into ProductDetail(Product, Branch, Size, Quantity, ProductDescription) values (20, 1, 'm', 625, N'Áo đá bóng nam size m');
insert into ProductDetail(Product, Branch, Size, Quantity, ProductDescription) values (20, 1, 's', 125, N'Áo đá bóng nam size s');

insert into ProductDetail(Product, Branch, Size, Quantity, ProductDescription) values (20, 2, 'xl', 202, N'Áo đá bóng nam size xl');
insert into ProductDetail(Product, Branch, Size, Quantity, ProductDescription) values (20, 2, 'l', 725, N'Áo đá bóng nam size l');
insert into ProductDetail(Product, Branch, Size, Quantity, ProductDescription) values (20, 2, 'm', 625, N'Áo đá bóng nam size m');
insert into ProductDetail(Product, Branch, Size, Quantity, ProductDescription) values (20, 2, 's', 125, N'Áo đá bóng nam size s');

insert into ProductDetail(Product, Branch, Size, Quantity, ProductDescription) values (21, 1, 'xl', 111, N'Áo đá bóng nữ size xl');
insert into ProductDetail(Product, Branch, Size, Quantity, ProductDescription) values (21, 1, 'l', 211, N'Áo đá bóng nữ size l');
insert into ProductDetail(Product, Branch, Size, Quantity, ProductDescription) values (21, 1, 'm', 200, N'Áo đá bóng nữ size m');
insert into ProductDetail(Product, Branch, Size, Quantity, ProductDescription) values (21, 1, 's', 215, N'Áo đá bóng nữ size s');

insert into ProductDetail(Product, Branch, Size, Quantity, ProductDescription) values (21, 2, 'xl', 111, N'Áo đá bóng nữ size xl');
insert into ProductDetail(Product, Branch, Size, Quantity, ProductDescription) values (21, 2, 'l', 211, N'Áo đá bóng nữ size l');
insert into ProductDetail(Product, Branch, Size, Quantity, ProductDescription) values (21, 2, 'm', 200, N'Áo đá bóng nữ size m');
insert into ProductDetail(Product, Branch, Size, Quantity, ProductDescription) values (21, 2, 's', 215, N'Áo đá bóng nữ size s');

insert into ProductDetail(Product, Branch, Size, Quantity, ProductDescription) values (22, 1, 'xl', 154, N'Áo đá bóng trẻ size xl');
insert into ProductDetail(Product, Branch, Size, Quantity, ProductDescription) values (22, 1, 'l', 54, N'Áo đá bóng trẻ size l');
insert into ProductDetail(Product, Branch, Size, Quantity, ProductDescription) values (22, 1, 'm', 212, N'Áo đá bóng trẻ size m');
insert into ProductDetail(Product, Branch, Size, Quantity, ProductDescription) values (22, 1, 's', 122, N'Áo đá bóng trẻ size s');

insert into ProductDetail(Product, Branch, Size, Quantity, ProductDescription) values (22, 2, 'xl', 154, N'Áo đá bóng trẻ size xl');
insert into ProductDetail(Product, Branch, Size, Quantity, ProductDescription) values (22, 2, 'l', 54, N'Áo đá bóng trẻ size l');
insert into ProductDetail(Product, Branch, Size, Quantity, ProductDescription) values (22, 2, 'm', 212, N'Áo đá bóng trẻ size m');
insert into ProductDetail(Product, Branch, Size, Quantity, ProductDescription) values (22, 2, 's', 122, N'Áo đá bóng trẻ size s');

insert into ProductDetail(Product, Branch, Size, Quantity, ProductDescription) values (23, 1, null, 1520, N'Bóng đá thể thao mới và đẹp 2021');
insert into ProductDetail(Product, Branch, Size, Quantity, ProductDescription) values (24, 1, null, 1220, N'Bóng đá nhựa mới và đẹp 2021');

insert into ProductDetail(Product, Branch, Size, Quantity, ProductDescription) values (23, 2, null, 520, N'Bóng đá thể thao mới và đẹp 2021');
insert into ProductDetail(Product, Branch, Size, Quantity, ProductDescription) values (24, 2, null, 220, N'Bóng đá nhựa mới và đẹp 2021');

-- chen bang Nhan Vien
insert into Employee(Branch, FullName, DateOfBirth, Address, PhoneNumber, Position, Salary) values(1, N'Phạm Bá Xuân Duy', '19991215', N'Đà Lạt', 0349981227, N'Giám đốc chi nhánh', 30000000 );
insert into Employee(Branch, FullName, DateOfBirth, Address, PhoneNumber, Position, Salary) values(2,  N'Phạm Hoàng Việt', '19990216', N'Gia Lai', 0940975555, N'Giám đốc chi nhánh', 30000000 );
insert into Employee(Branch, FullName, DateOfBirth, Address, PhoneNumber, Position, Salary) values(1, N'Hứa Đình Doanh', '19990915', N'Hà Nội', 0789123123, N'Nhân viên bán hàng', 8000000 );
insert into Employee(Branch, FullName, DateOfBirth, Address, PhoneNumber, Position, Salary) values(1, N'Nguyễn Đăng khoa', '19990122', N'TP.HCM', 0326688990, N'Nhân viên bán hàng', 8000000 );
insert into Employee(Branch, FullName, DateOfBirth, Address, PhoneNumber, Position, Salary) values(1, N'Đặng Trần Hữu Nhân', '19990803', N'Nha Trang', 0562377167, N'Nhân viên bán hàng', 8000000 );
insert into Employee(Branch, FullName, DateOfBirth, Address, PhoneNumber, Position, Salary) values(2, N'Lê Anh Trí', '19990214', N'Đà Lạt', 0789943256, N'Nhân viên bán hàng', 8000000 );
insert into Employee(Branch, FullName, DateOfBirth, Address, PhoneNumber, Position, Salary) values(2, N'Hoàng Minh Khôi','19991020', N'Đà Nẵng', 0654689326, N'Nhân viên bán hàng', 8000000 );
insert into Employee(Branch, FullName, DateOfBirth, Address, PhoneNumber, Position, Salary) values(2, N'Lương Tuyên Quang', '19990727', N'Đà Lạt', 0453668210, N'Nhân viên bán hàng', 8000000 );
insert into Employee(Branch, FullName, DateOfBirth, Address, PhoneNumber, Position, Salary) values(1, N'Huỳnh Lê Hữu Thành', '19990711', N'Đà Lạt', 0940975555, N'Quản lý chi nhánh', 14000000 );
insert into Employee(Branch, FullName, DateOfBirth, Address, PhoneNumber, Position, Salary) values(2, N'Phan Quốc Trung', '19990212', N'Đà Lạt', 0654488882, N'Quản lý chi nhánh', 14000000 );

insert into Bill(Employee, Customer, CheckoutDate, PhoneNumber, Discount, TotalAmount) values(3, N'Lê Thúy Hồng', '20210403', 0992065534, null, 290000);
insert into Bill(Employee, Customer, CheckoutDate, PhoneNumber, Discount, TotalAmount) values(4, N'Trần Minh Chiến', '20210408', 0754423414, 2000, 98000);
insert into Bill(Employee, Customer, CheckoutDate, PhoneNumber, Discount, TotalAmount) values(6, N'Nguyễn Thị Thu Huyền', '20210416', 0883256640, null, 316000);
insert into Bill(Employee, Customer, CheckoutDate, PhoneNumber, Discount, TotalAmount) values(7, N'Nguyễn Đức Đề', '20210420', 0342267421, 2000, 183000);


insert into BillDetail(Bill, ProductDetail, Quantity, CurrentUnitPrice) values (1, 78, 2, 145000);
insert into BillDetail(Bill, ProductDetail, Quantity, CurrentUnitPrice) values (2, 117, 1, 100000);
insert into BillDetail(Bill, ProductDetail, Quantity, CurrentUnitPrice) values (3, 7, 2, 158000);
insert into BillDetail(Bill, ProductDetail, Quantity, CurrentUnitPrice) values (4, 3, 15, 14200);
go


--v
-- tao tai khoan
create proc sp_TaoTaiKhoan (@LGNAME nvarchar(50), @PASS nvarchar(50), @USERNAME nvarchar(50), @ROLE nvarchar(50))
as
	begin
		declare @RET int
		exec @RET = sp_addlogin @LGNAME, @PASS, 'QuanLyDungCuTheThao'
		if (@RET = 1) -- LGNAME bi trung
			return 1
		exec @RET = sp_grantdbaccess @LGNAME, @USERNAME
		if (@RET = 1) -- LGNAME bi trung
		begin
			exec sp_droplogin @LGNAME
			return 2
		end
		
		if @ROLE = 'GIAMDOC'
		begin
			exec sp_addsrvrolemember @LGNAME, 'sysadmin'
			exec sp_addsrvrolemember @LGNAME, 'SecurityAdmin'
			exec sp_addsrvrolemember @LGNAME, 'ProcessAdmin'
		end
		if @ROLE = 'QLCHINHANH'
		begin
			exec sp_addsrvrolemember @LGNAME, 'sysadmin'
			exec sp_addsrvrolemember @LGNAME, 'SecurityAdmin'
			exec sp_addsrvrolemember @LGNAME, 'ProcessAdmin'
		end
		if @ROLE = 'NHANVIEN'
		begin
			exec sp_addsrvrolemember @LGNAME, 'sysadmin'
			exec sp_addsrvrolemember @LGNAME, 'SecurityAdmin'
			exec sp_addsrvrolemember @LGNAME, 'ProcessAdmin'
		end
	end
go

-- get login info
create proc sp_GetLoginInfo
@LoginName nvarchar(50)
as 
	begin
		declare @Id nvarchar(50)
		select @Id= Name From sys.sysusers where sid = SUSER_SID(@LoginName)

		select ID = @Id, ROLENAME = NAME
		from sys.sysusers
		where UID = (select groupuid from sys.sysmembers where memberuid = (select uid from sys.sysusers where Name = @Id))
	end
go
--


-- thu tuc xem chi tiet tat ca san pham
create procedure sp_ChitietTatCaSP 
	as 
	begin
		select Product.Name as 'Name', ProductCategory.Name as 'Category', 
		Product.Manufacturer, Product.Price, ProductDetail.ID, 
		ProductDetail.Size, ProductDetail.Quantity, 
		ProductDetail.ProductDescription from ProductDetail
		join Product on Product.ID = ProductDetail.Product
		join ProductCategory on ProductCategory.ID = Product.ProductCategory;
	end
go

-- thu tuc them xoa sua chen chi tiet san pham
-- them
create procedure sp_Insert_ChitietSP(@Product int, @Branch int, @Size char(5), @Quantity int, @ProductDescription nvarchar(50))
as
	begin
		insert into ProductDetail(Product, Branch, Size, Quantity, ProductDescription)
		values (@Product, @Branch, @Size, @Quantity, @ProductDescription)
	end
go

-- xoa
create procedure sp_Delete_ChitietSP(@ID int)
as
	begin
		delete from ProductDetail where ID=@ID
	end
go

-- sua
create procedure sp_Update_ChitietSP(@ID int = 0, @Branch int, @Product int, @Size char(5), @Quantity int, @ProductDescription nvarchar(50))
as
	begin
		update ProductDetail
		set Product=@Product, Branch=@Branch, Size=@Size, Quantity=@Quantity, ProductDescription=@ProductDescription
		where ID=@ID
	end
go

-- thu tuc so luong ton kho cho moi size (neu sanpham la quanao)
create procedure sp_SL_TonKho_SizeSP(@Size char(5))
as
	begin
		select sum(Quantity) as 'SLTonKho' from ProductDetail where ProductDetail.Size=@Size;
	end
go

-- thu tuc so luong ton kho (neu sanpham khong phai la quanao)
create procedure sp_SL_TonKho_SP
as
	begin
		select sum(Quantity) as 'SLTonKho' from ProductDetail where ProductDescription not like N'%size%';
	end
go

-- thu tuc xem chi tiet thong tin nhan vien
create procedure sp_CT_NhanVien(@FullName nvarchar(30))
as
	begin
		select * from Employee where Employee.FullName = @FullName
	end
go

-- thu tuc so luong hang da ban va doanh thu cua cua hang hoac tung chi nhanh (Bui Thi Xuan va Hoa Binh)
create procedure sp_SL_HangDaBan_DoanhThu(@BranchId int = 0)
as
	begin
		-- Cua Hang(Gom 2 Chi Nhanh)
		if @BranchId = 0
			begin
				select sum(Quantity) as 'SLHangDaBan', sum(Bill.TotalAmount) as 'DoanhThu' 
				from BillDetail 
				join Bill on Bill.ID = BillDetail.Bill;
			end
		-- Chi Nhanh Bui Thi Xuan (1) hoac Chi Nhanh Hoa Binh (2)
		if @BranchId = 1 or @BranchId = 2
			begin
				select sum(Quantity) as 'SLHangDaBan', sum(Bill.TotalAmount) as 'DoanhThu' 
				from BillDetail 
				join Bill on Bill.ID = BillDetail.Bill
				where Bill.Employee in (select Employee.ID from Employee where Employee.Branch=@BranchId);
			end
	end
go

-- thu tuc so luong hang da ban va doanh thu cua cua hang hoac tung chi nhanh (Bui Thi Xuan va Hoa Binh) theo tung thang
create procedure sp_SL_HangDaBan_DoanhThu_Thang(@BranchId int = 0, @Month nvarchar(2))
as
	begin
		-- Cua Hang(Gom 2 Chi Nhanh)
		if @BranchId = 0
			begin
				select sum(Quantity) as 'SLHangDaBan', sum(Bill.TotalAmount) as 'DoanhThu' 
				from BillDetail 
				join Bill on Bill.ID = BillDetail.Bill
				where DATEPART(MM,[CheckoutDate])=@Month;
			end
		-- Chi Nhanh Bui Thi Xuan (1) hoac Chi Nhanh Hoa Binh (2)
		if @BranchId = 1 or @BranchId = 2
			begin
				select sum(Quantity) as 'SLHangDaBan', sum(Bill.TotalAmount) as 'DoanhThu' 
				from BillDetail 
				join Bill on Bill.ID = BillDetail.Bill
				where Bill.Employee in (select Employee.ID from Employee where Employee.Branch=@BranchId)
				and DATEPART(MM,[CheckoutDate])=@Month;
			end
	end
go

-- thu tuc danh sach cac mat hang da ban
create procedure sp_DS_ChiTiet_MatHangDaBan
as
	begin
		select Name, BillDetail.Quantity, CurrentUnitPrice, Size, ProductDescription, Price, Manufacturer from BillDetail 
		join ProductDetail 
		on BillDetail.ProductDetail = ProductDetail.ID
		join Product on Product.ID = ProductDetail.Product;
	end
go

-- thong ke
-- nhan vien ban duoc nhieu hang nhat theo chi nhanh hoac ca cong ty
create procedure sp_NhanVien_BanMatHangNhieuNhat(@Branch int = 0)
as
	begin
		-- ca 2 chi nhanh
		if @Branch = 0
			begin
				select top 1 sum(BillDetail.Quantity) as 'Quantity', Employee.FullName, Employee.Address, Employee.PhoneNumber, Employee.Position, Employee.Branch, Employee.Salary
				from BillDetail 
				join Bill on Bill.ID = BillDetail.Bill
				join Employee on Bill.Employee = Employee.ID
				group by Employee.FullName, Employee.Address, Employee.PhoneNumber, Employee.Position, Employee.Branch, Employee.Salary
				order by Quantity desc;
			end

		-- chi nhanh 1 or chi nhanh 2
		if @Branch = 1 or @Branch = 2
			begin
				select top 1 sum(BillDetail.Quantity) as 'Quantity', Employee.FullName, Employee.Address, Employee.PhoneNumber, Employee.Position, Employee.Branch, Employee.Salary
				from BillDetail 
				join Bill on Bill.ID = BillDetail.Bill
				join Employee on Bill.Employee = Employee.ID
				where Employee.Branch = @Branch
				group by Employee.FullName, Employee.Address, Employee.PhoneNumber, Employee.Position, Employee.Branch, Employee.Salary
				order by Quantity desc;
			end
	end
go

-- nhan vien khong ban duoc san pham nao theo chi nhanh hoac ca cong ty
create procedure sp_NhanVien_KhongBanDuocHang(@Branch int = 0)
as
	begin
		-- ca 2 chi nhanh
		if @Branch = 0
			begin
				select *
				from Employee
				where Employee.ID not in (select Bill.Employee from Bill) and Employee.Position = N'Nhân viên bán hàng'
			end

		-- chi nhanh 1 or chi nhanh 2
		if @Branch = 1 or @Branch = 2
			begin
				select *
				from Employee
				where Employee.ID not in (select Bill.Employee from Bill)
				and Employee.Branch = @Branch and Employee.Position = N'Nhân viên bán hàng'
			end
	end
go

-- cac mat hang ban chay nhat
create procedure sp_Top3_MatHang_BanChay
as
	begin
		select top 3 sum(BillDetail.Quantity) as 'NumberOfItemsSold', 
		Product.Name, Product.Manufacturer, Product.Price, Product.ProductCategory, 
		ProductDetail.ProductDescription, ProductDetail.Quantity, ProductDetail.Size
		from BillDetail 
		join Bill on Bill.ID = BillDetail.Bill
		join ProductDetail on BillDetail.ProductDetail = ProductDetail.ID
		join Product on Product.ID = ProductDetail.Product
		group by Product.Name, Product.Manufacturer, Product.Price, Product.ProductCategory, 
		ProductDetail.ProductDescription, ProductDetail.Quantity, ProductDetail.Size, BillDetail.Quantity
		order by BillDetail.Quantity desc;
	end
go

-- thu tuc them bill2
create procedure sp_Them_HoaDon( 
	@Employee int, 
	@Customer nvarchar(30), 
	@CheckoutDate datetime, 
	@PhoneNumber int, 
	@Discount int, 
	@TotalAmount int,
	@ProductDetail int,
	@Quantity int,
	@CurrentUnitPrice int,
	@Result INT OUTPUT
)
as
	begin
		begin try
			declare @BillID int;
			insert into Bill(Employee, Customer, CheckoutDate, PhoneNumber, Discount, TotalAmount)
			values (@Employee, @Customer, @CheckoutDate, @PhoneNumber, @Discount, @TotalAmount)

			select @BillID = ID from Bill 
			where Bill.CheckoutDate = @CheckoutDate 
			and Bill.Customer = @Customer
			and Bill.Employee = @Employee
			and Bill.TotalAmount = @TotalAmount;

			insert into BillDetail(Bill, ProductDetail, Quantity, CurrentUnitPrice)
			values (@BillID, @ProductDetail, @Quantity, @CurrentUnitPrice)

			update ProductDetail
			set Quantity = Quantity - @Quantity
			where ID = @ProductDetail;
			set @Result = 1;
		end try
		begin catch
			set @Result = 0;
		end catch
	end
go

create procedure sp_GetAllNhanVien
as
	begin
		select * from [LINK].[QLDungCuTheThao].[dbo].[Employee]
		UNION ALL
		select * from Employee;
	end
go

EXEC sp_addlinkedserver @server = 'LINK' --or may be server ip address
