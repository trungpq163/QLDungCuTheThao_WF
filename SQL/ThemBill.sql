use QuanLyDungCuTheThao;
go

create procedure sp_ThemBill(@Employee int, 
	@Customer nvarchar(30), 
	@CheckoutDate datetime, 
	@PhoneNumber int, 
	@Discount int, 
	@TotalAmount int,
	@ProductDetail int,
	@Quantity int,
	@CurrentUnitPrice int)
as
	begin
		declare @BillID int;
		declare @Result int;

		begin try
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
			select 'Result' = @Result
		end try
		
		begin catch
			set @Result = 0;
			select 'Result' = @Result
		end catch
	end