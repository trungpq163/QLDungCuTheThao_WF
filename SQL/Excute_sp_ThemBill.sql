USE [QuanLyDungCuTheThao]
GO

DECLARE	@return_value int

EXEC	@return_value = [dbo].[sp_ThemBill]
		@Employee = 4,
		@Customer = N'TrungPhan',
		@CheckoutDate = N'5/17/2021',
		@PhoneNumber = 0666666,
		@Discount = 0,
		@TotalAmount = 16500,
		@ProductDetail = 1,
		@Quantity = 1,
		@CurrentUnitPrice = 16500

SELECT	'Return Value' = @return_value

GO

select * from Bill