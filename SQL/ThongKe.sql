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