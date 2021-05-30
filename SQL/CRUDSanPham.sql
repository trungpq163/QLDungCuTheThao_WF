use QuanLyDungCuTheThao;

create procedure sp_TaoSP (@Name nvarchar(50), @Price int, @ProductCategory int, @Manufacturer nvarchar(30))
as
	begin
		declare @Result int;
		-- @Result = 0 => err
		-- @Result = 1 => sucess :D

		begin try
			insert into Product(Name, Price, ProductCategory, Manufacturer)
			values (@Name, @Price, @ProductCategory, @Manufacturer);
			
			set @Result = 1; 
			select 'Result' = @Result
		end try
		begin catch
			set @Result = 0; 
			SELECT	'Result' = @Result
		end catch
	end
go

create procedure sp_XoaSP(@ID int) 
as
	begin
		declare @Result int;
		declare @ProductDetailID int;
		declare @BillID int;
		-- @Result = 0 => err
		-- @Result = 1 => sucess :D
		begin try
			select @ProductDetailID = ID 
			from ProductDetail where ProductDetail.Product = @ID;

			select @BillID = Bill
			from BillDetail where BillDetail.ProductDetail = @ProductDetailID;

			delete from BillDetail where BillDetail.ProductDetail = @ProductDetailID;
			delete from Bill where Bill.ID = @BillID;

			delete from ProductDetail where ProductDetail.Product = @ID;
			delete from Product where ID = @ID;

			set @Result = 1; 
			SELECT	'Result' = @Result
			
		end try
		begin catch
			set @Result = 0; 
			SELECT	'Result' = @Result
		end catch
	end
go

create procedure sp_ChinhSuaSP(@ID int, @Name nvarchar(50), @Price int, @ProductCategory int, @Manufacturer nvarchar(20)) 
as
	begin
		declare @Result int;
		-- @Result = 0 => err
		-- @Result = 1 => sucess :D

		begin try
			update Product
			set Name = @Name, Price = @Price, ProductCategory = @ProductCategory, Manufacturer = @Manufacturer
			where ID = @ID

			set @Result = 1; 
			SELECT	'Result' = @Result;
		end try
		begin catch
			set @Result = 0; 
			SELECT	'Result' = @Result;
		end catch
	end
go

create procedure sp_XemTatCaSP
as
	begin
		select Product.ID, SUM(Quantity) as 'Quantity', Product.Name, ProductCategory.Name as 'ProductCategory', Price, Manufacturer 
		from Product 
		join ProductCategory on Product.ProductCategory = ProductCategory.ID
		left join ProductDetail on ProductDetail.Product = Product.ID
		group by Product.ID, Product.Name, ProductCategory.Name, Price, Manufacturer 
	end
go