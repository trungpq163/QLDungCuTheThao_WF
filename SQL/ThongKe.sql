use QuanLyDungCuTheThao;
go

-- cac mat hang ban chay nhat trong mot khoang thoi gian nao do
create procedure sp_Top5_MatHang_BanChay(@Start datetime, @End datetime)
as
	begin
		select top 5 sum(BillDetail.Quantity) as 'NumberOfItemsSold', 
		Product.Name, Product.Manufacturer, Product.Price, Product.ProductCategory, 
		ProductDetail.ProductDescription, ProductDetail.Quantity, ProductDetail.Size
		from BillDetail 
		join Bill on Bill.ID = BillDetail.Bill
		join ProductDetail on BillDetail.ProductDetail = ProductDetail.ID
		join Product on Product.ID = ProductDetail.Product
		where Bill.CheckoutDate >= @Start and Bill.CheckoutDate <= @End
		group by Product.Name, Product.Manufacturer, Product.Price, Product.ProductCategory, 
		ProductDetail.ProductDescription, ProductDetail.Quantity, ProductDetail.Size, BillDetail.Quantity
		order by BillDetail.Quantity desc;
	end
go

-- nhan vien khong ban duoc san pham nao theo chi nhanh hoac ca cong ty trong mot khoang thoi gian
create procedure sp_NhanVien_KhongBanDuocHang(@Branch int = 0, @Start datetime, @End datetime)
as
	begin
		-- ca cong ty
		if @Branch = 0
			begin
				select ID, Branch, FullName, DateOfBirth, Address, PhoneNumber, Position, Salary
				from Employee
				where Employee.ID not in 
				(select Bill.Employee from Bill where Bill.CheckoutDate >= @Start and Bill.CheckoutDate <= @End) 
				and Employee.Position = N'Nhân viên bán hàng'
				union all
				select ID, Branch, FullName, DateOfBirth, Address, PhoneNumber, Position, Salary
				from [LINK].[QuanLyDungCuTheThao].[dbo].[Employee] Employee
				where Employee.ID not in 
				(select Bill.Employee 
				from [LINK].[QuanLyDungCuTheThao].[dbo].[Bill] Bill where Bill.CheckoutDate >= @Start and Bill.CheckoutDate <= @End) 
				and Employee.Position = N'Nhân viên bán hàng'
			end

		-- chi nhanh 1 or chi nhanh 2
		if @Branch = 1
			begin
				select ID, Branch, FullName, DateOfBirth, Address, PhoneNumber, Position, Salary
				from Employee
				where Employee.ID not in (select Bill.Employee from Bill where Bill.CheckoutDate >= @Start and Bill.CheckoutDate <= @End)
				and Employee.Position = N'Nhân viên bán hàng'
			end
	end
go

-- nhan vien ban duoc nhieu hang nhat theo chi nhanh hoac ca cong ty
create procedure sp_NhanVien_BanMatHangNhieuNhat(@Start datetime, @End datetime)
as
	begin
		select top 3 sum(BillDetail.Quantity) as 'Quantity', Employee.FullName, Employee.Address, Employee.PhoneNumber, Employee.Position, Employee.Branch, Employee.Salary
		from BillDetail 
		join Bill on Bill.ID = BillDetail.Bill
		join Employee on Bill.Employee = Employee.ID
		where Bill.CheckoutDate >= @Start and Bill.CheckoutDate <= @End
		group by Employee.FullName, Employee.Address, Employee.PhoneNumber, Employee.Position, Employee.Branch, Employee.Salary
		union all
		select top 3 sum(BillDetail.Quantity) as 'Quantity', Employee.FullName, Employee.Address, Employee.PhoneNumber, Employee.Position, Employee.Branch, Employee.Salary
		from [LINK].[QuanLyDungCuTheThao].[dbo].[BillDetail] BillDetail 
		join [LINK].[QuanLyDungCuTheThao].[dbo].[Bill] Bill on Bill.ID = BillDetail.Bill
		join [LINK].[QuanLyDungCuTheThao].[dbo].[Employee] Employee on Bill.Employee = Employee.ID
		where Bill.CheckoutDate >= @Start and Bill.CheckoutDate <= @End
		group by Employee.FullName, Employee.Address, Employee.PhoneNumber, Employee.Position, Employee.Branch, Employee.Salary
		order by Quantity desc;
	end
go

-- thu tuc danh sach cac mat hang da ban
create procedure sp_DS_ChiTiet_MatHangDaBan(@Start datetime, @End datetime)
as
	begin
		select Name, BillDetail.Quantity, CurrentUnitPrice, Size, ProductDescription, Price, Manufacturer from BillDetail 
		join ProductDetail on BillDetail.ProductDetail = ProductDetail.ID
		join Product on Product.ID = ProductDetail.Product
		join Bill on Bill.ID = BillDetail.Bill
		where Bill.CheckoutDate >= @Start and Bill.CheckoutDate <= @End
	end
go

create procedure sp_SLTonKho
as
	begin
		select Product.ID, Product.Name, sum(Quantity) as 'Quantity', Product.Manufacturer, ProductCategory.Name as 'ProductCategory'
		from ProductDetail 
		join Product on ProductDetail.Product = Product.ID
		join ProductCategory on ProductCategory.ID = Product.ProductCategory
		group by Product.ID, Product.Name, Product.Manufacturer, ProductCategory.Name
	end
go

